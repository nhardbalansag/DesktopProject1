using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace building_management_system
{
    public partial class panel_admin_profile : UserControl
    {
        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        Image file;
        ClassValidations validate = new ClassValidations();

        private string query;
        private string tableName = "dbt_personal_information";

        private string u_id;
        private bool username_status;
        private bool password_status;

        public panel_admin_profile()
        {
            InitializeComponent();
            label10.Enabled = true;
            labelWarning1.Visible = false;
            labelWarning.Visible = false;
            buttonSaveChanges.Enabled = false;
            gender();
            displayUserInfo_Login_userID_label();
            labelResetPassword.Enabled = true;
            label15.Enabled = true;
        }

     
        private void button4_Click(object sender, EventArgs e)
        {
            update_userInformation();
        }// button save chnages for personal information

       
        private void label15_Click(object sender, EventArgs e)
        {
            textBoxChangeUserId.Enabled = true;
            username_status = true;
            password_status = false;
            label10.ForeColor = Color.DodgerBlue;
            displayUserInfo_Login_userID();
        }/// label change user id

        private void label14_Click(object sender, EventArgs e)
        {
            textBoxChangeUserPassword.Enabled = true;
            textBoxConfirmPassword.Enabled = true;
            password_status = true;
            username_status = false;
            label11.ForeColor = Color.DodgerBlue;
            label12.ForeColor = Color.DodgerBlue;
            displayUserInfo_Login_pass();
        }// label change user password
       
        private void button1_Click(object sender, EventArgs e)
        {
            choosePhotoFile();
        }// choose a file for photo

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(username_status == true)
            {
                update_loginUsername();
                username_status = false;
                displayUserInfo_Login_userID_label();
            }
            else if(password_status == true)
            {
                update_loginPassword();
                password_status = false;
            }
        }// button save changes for login information

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            searchPicture();
            displayUserInfo();
            buttonSaveChanges.Enabled = true;
        }// button edit user information

        private void gender()
        {
            comboBoxGenderUser.Items.Add("Male");
            comboBoxGenderUser.Items.Add("Female");
        }// end of the method

        public void displayUserInfo()
        {
            try
            {
                this.query = "SELECT * FROM dbt_personal_information WHERE login_status = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        this.u_id = this.mdr.GetString("dbt_personalInfoId");
                        textBoxFirstNameUser.Text = this.mdr.GetString("personalInfoFirstName");
                        textBoxLastNameUser.Text = this.mdr.GetString("personalInfomiddleName");
                        textBoxMidNameUser.Text = this.mdr.GetString("personalInfoLastName");
                        comboBoxGenderUser.Text = this.mdr.GetString("personalInfosex");
                    }
                }
            }
            catch (Exception)
            {
                // error handling
            }
            finally
            {
                this.connect.Close();
            }

        }// end of the method

        private void choosePhotoFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG(*.JPG)|*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {

                file = Image.FromFile(open.FileName);
                pictureBoxUser.Image = file;
                textBoxPathUser.Text = open.FileName.ToString();
            }
        }// end of the method
        public static byte[] SaveImageToByteArray(Image image, int jpegQuality)
        {
            using (var ms = new MemoryStream())
            {
                var jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder QualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(QualityEncoder, jpegQuality);
                image.Save(ms, jpegEncoder, encoderParameters);

                return ms.ToArray();
            }
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }// end of the method

        private void update_userInformation()
        {

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxFirstNameUser.Text, textBoxMidNameUser.Text, textBoxLastNameUser.Text, comboBoxGenderUser.Text};

            for (int i = 0; i < textbox.Length; i++)
            {
                result = validate.validateStringInput(textbox[i], textbox.Length);
                if (result == true)
                {
                    trueResult++;
                }
            }// for loop

            if (trueResult == textbox.Length)
            {
                try
                {
                    byte[] imgbyte;
                    imgbyte = SaveImageToByteArray(pictureBoxUser.Image, 90);

                    this.query = "UPDATE " + this.tableName +
                                     @" SET 
                                personalInfoFirstName = @data1, 
                                personalInfoProfilePicture = @data2, 
                                personalInfomiddleName = @data3, 
                                personalInfoLastName = @data4, 
                                personalInfoBirthday = @data5,                          
                                personalInfosex = @data6                               
                               WHERE dbt_personalInfoId = " + this.u_id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", textBoxFirstNameUser.Text);
                        this.command.Parameters.AddWithValue("@data2", imgbyte);
                        this.command.Parameters.AddWithValue("@data3", textBoxMidNameUser.Text);
                        this.command.Parameters.AddWithValue("@data4", textBoxLastNameUser.Text);
                        this.command.Parameters.AddWithValue("@data5", dateTimePickerBirthday.Value.ToString("yyy-MM-dd"));
                        this.command.Parameters.AddWithValue("@data6", comboBoxGenderUser.Text);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();
                    }

                    labelWarning.Visible = true;
                    labelWarning.Text = "Succesfully updated!";
                    buttonSaveChanges.Enabled = false;
                }
                catch (Exception)
                {
                    // error handling
                    labelWarning.Visible = true;
                    labelWarning.Text = "internal problem please check your connection";
                }
                finally
                {
                    this.connect.Close();
                }
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }
                
        }// end of the method

        public void displayUserInfo_Login_pass()
        {
            try
            {
                this.query = "SELECT registerPassword, dbt_personalInfoId FROM dbt_personal_information WHERE login_status = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        this.u_id = this.mdr.GetString("dbt_personalInfoId");
                        //textBoxChangeUserId.Text = this.mdr.GetString("registerUsername");
                        textBoxChangeUserPassword.Text = this.mdr.GetString("registerPassword");
                        textBoxConfirmPassword.Text = this.mdr.GetString("registerPassword");
                        //labelDisplayUserId.Text = this.mdr.GetString("registerUsername");
                    }
                }
            }
            catch (Exception)
            {
                // error handling
            }
            finally
            {
                this.connect.Close();
            }

        }// end of the method
        public void displayUserInfo_Login_userID()
        {
            try
            {
                this.query = "SELECT registerUsername, dbt_personalInfoId FROM dbt_personal_information WHERE login_status = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        this.u_id = this.mdr.GetString("dbt_personalInfoId");
                        textBoxChangeUserId.Text = this.mdr.GetString("registerUsername");
                        labelDisplayUserId.Text = this.mdr.GetString("registerUsername");
                    }
                }
            }
            catch (Exception)
            {
                // error handling
            }
            finally
            {
                this.connect.Close();
            }

        }// end of the method
        public void displayUserInfo_Login_userID_label()
        {
            try
            {
                this.query = "SELECT registerUsername FROM dbt_personal_information WHERE login_status = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {                                              
                        labelDisplayUserId.Text = this.mdr.GetString("registerUsername");
                    }
                }
            }
            catch (Exception)
            {
                // error handling
            }
            finally
            {
                this.connect.Close();
            }

        }// end of the method
        private void update_loginUsername()
        {

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxChangeUserId.Text};

            for (int i = 0; i < textbox.Length; i++)
            {
                result = validate.validateStringInput(textbox[i], textbox.Length);
                if (result == true)
                {
                    trueResult++;
                }
            }// for loop

            if (trueResult == textbox.Length)
            {
                try
                {
                    byte[] imgbyte;
                    imgbyte = SaveImageToByteArray(pictureBoxUser.Image, 90);

                    this.query = "UPDATE " + this.tableName +
                                     @" SET 
                                registerUsername = @data1                                                             
                               WHERE dbt_personalInfoId = " + this.u_id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", textBoxChangeUserId.Text);
                          
                        this.connect.Open();
                        this.command.ExecuteNonQuery();
                    }

                    labelWarning1.Visible = true;
                    labelWarning1.Text = "Succesfully updated!";
                    buttonSaveChanges.Enabled = false;
                    label10.ForeColor = Color.Silver;
                }
                catch (Exception)
                {
                    // error handling
                    labelWarning1.Visible = true;
                    labelWarning1.Text = "internal problem please check your connection";
                }
                finally
                {
                    this.connect.Close();
                }
            }
            else
            {
                labelWarning1.Visible = true;
                labelWarning1.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }

        }// end of the method
        private void update_loginPassword()
        {

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxConfirmPassword.Text };

            for (int i = 0; i < textbox.Length; i++)
            {
                result = validate.validateStringInput(textbox[i], textbox.Length);
                if (result == true)
                {
                    trueResult++;
                }
            }// for loop

            if (trueResult == textbox.Length)
            {
                try
                {
                    byte[] imgbyte;
                    imgbyte = SaveImageToByteArray(pictureBoxUser.Image, 90);

                    this.query = "UPDATE " + this.tableName +
                                     @" SET 
                                registerPassword = @data1                                                            
                               WHERE dbt_personalInfoId = " + this.u_id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        if(textBoxConfirmPassword.Text == textBoxChangeUserPassword.Text)
                        {
                            this.command.Parameters.AddWithValue("@data1", textBoxConfirmPassword.Text);
                            this.connect.Open();
                            this.command.ExecuteNonQuery();

                            labelWarning1.Visible = true;
                            labelWarning1.Text = "Succesfully updated!";
                            buttonSaveChanges.Enabled = false;
                            label11.ForeColor = Color.Silver;
                            label12.ForeColor = Color.Silver;
                        }
                        else if(textBoxConfirmPassword.Text != textBoxChangeUserPassword.Text)
                        {
                            labelWarning1.Visible = true;
                            labelWarning1.Text = "Password not match Please try again";
                        }
                                      
                    }
                   
                }
                catch (Exception)
                {
                    // error handling
                    labelWarning1.Visible = true;
                    labelWarning1.Text = "internal problem please check your connection";
                }
                finally
                {
                    this.connect.Close();
                }
            }
            else
            {
                labelWarning1.Visible = true;
                labelWarning1.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }

        }// end of the method

        private void searchPicture()
        {
            this.query = @"SELECT personalInfoProfilePicture
                           FROM " + this.tableName + " WHERE login_status = 1";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();

                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "dbt_personal_information");
                    int count = ds.Tables["dbt_personal_information"].Rows.Count;

                    byte[] imgbyt = new byte[0];
                    imgbyt = (byte[])ds.Tables["dbt_personal_information"].Rows[count - 1]["personalInfoProfilePicture"];
                    MemoryStream ms = new MemoryStream(imgbyt);

                    pictureBoxUser.Image = Image.FromStream(ms);

                }

            }
            catch (Exception)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

    }// end of the class

}// end of the namespace
