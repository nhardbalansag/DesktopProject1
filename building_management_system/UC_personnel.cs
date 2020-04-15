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
    public partial class UC_personnel : UserControl
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        Image file;
        ClassValidations validate = new ClassValidations();

        private string query;
        private string tableName = "dbt_utilities_assigned_personnel";

        public UC_personnel()
        {
            InitializeComponent();         
            start();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            save();
        }// button save end 

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            choosePhotoFile();
        }// button choosefile

        private void buttonViewGrid_Click(object sender, EventArgs e)
        {
            viewAllDataGrid();
            panelViewAllPersonnel.Visible = true;
            buutonCloseGrid.Visible = true;
            panelViewpersonnel.Visible = false;
            buttonSearchPersonnel.Visible = false;
            comboBoxPersonnel.Visible = false;
            buttonViewOneGridRec.Visible = true;
            buttonCancelEdit.Visible = false;
        }// button view grid

        private void buutonCloseGrid_Click(object sender, EventArgs e)
        {
            panelViewAllPersonnel.Visible = false;
            buutonCloseGrid.Visible = false;                    
            buttonSearchPersonnel.Visible = true;
            comboBoxPersonnel.Visible = true;
            start();
            ClearAllTextBox();
            labelWarning.Visible = false;
        }// button close grid

        private void buttonSearchPersonnel_Click(object sender, EventArgs e)
        {
            SearchPersonnel();
            panelViewpersonnel.Visible = true;
            searchPicture();
            SearchJobPosition();
            labelWarning.Visible = false;
        }// button search personnel

        private void buttonDeletePersonnel_Click(object sender, EventArgs e)
        {
            deletePersonnelProfile();
            viewAllPersonnelSearch();
        }// button delete personnel

        private void buttonEditPersonnel_Click(object sender, EventArgs e)
        {
            showEdit();
            panelViewpersonnel.Visible = false;
            buttonSave.Text = "Save Edit";
            buttonCancelEdit.Visible = true;
            buutonCloseGrid.Visible = false;
        }// button edit personnel

        private void buttonCancelEdit_Click(object sender, EventArgs e)
        {
            ClearAllTextBox();
            panelViewpersonnel.Visible = true;
            buttonCancelEdit.Visible = false;
            labelWarning.Visible = false;
        }// end button cancel

        private void buttonClose_Click(object sender, EventArgs e)
        {
            start();
            panelViewpersonnel.Visible = false;
        }// button end close
        private void buttonViewOneGridRec_Click(object sender, EventArgs e)
        {
            searchPicture();
            SearchJobPosition();
            ViewOnePersonelGrid();
            panelViewAllPersonnel.Visible = false;
            panelViewpersonnel.Visible = true;
            buttonViewOneGridRec.Visible = false;
            buutonCloseGrid.Visible = false;
            buttonSearchPersonnel.Visible = true;
            comboBoxPersonnel.Visible = true;
        }// button view one grid record
        
        private void start()
        {
            buutonCloseGrid.Visible = false;
            panelViewAllPersonnel.Visible = false;
            viewAllJobPosition();
            gender();
            viewAllPersonnelSearch();
            panelViewpersonnel.Visible = false;
            buttonCancelEdit.Visible = false;
            labelWarning.Visible = false;
            buttonViewOneGridRec.Visible = false;
            buttonCancelEdit.Visible = false;
            buttonSearchPersonnel.Visible = true;
            comboBoxPersonnel.Visible = true;
            buttonSave.Text = "Save";
        }// end of the method

        private void dataGridpersonnel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewAllPersonnelSearch()
        {
            this.query = @"SELECT *
                           FROM " + this.tableName;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxPersonnel.DisplayMember = "personnelLastName";
                    comboBoxPersonnel.ValueMember = "personnelId";
                    comboBoxPersonnel.DataSource = ds.Tables[0];
                    //this.dataGridTenants();// for the designs of the grid
                }
                //changeLabelDataGrid();// to change the label of the datagrid
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
        private void SearchPersonnel()
        {
            this.query = @"SELECT *
                           FROM " + this.tableName + " WHERE personnelId = " + comboBoxPersonnel.SelectedValue;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        labelLastName.Text = this.mdr.GetString("personnelLastName");
                        labelFirstName.Text = this.mdr.GetString("personnelFirstName");
                        labelMiddleName.Text = this.mdr.GetString("personnelMiddleName");
                        labelSex.Text = this.mdr.GetString("personnelSex");
                        labelBDay.Text = this.mdr.GetString("personnelBday");

                       

                        string housenumNme = this.mdr.GetString("personnelAddressHouseBlockNum");
                        string street = this.mdr.GetString("personnelAddressStreet");
                        string subdivision = this.mdr.GetString("personnelAddressSubdivision");
                        string city = this.mdr.GetString("personnelAddressCity");

                        labelAddress.Text = housenumNme + "/ " +  street + "/ " + subdivision + "/ " + city;

                        

                    }
                }
                //changeLabelDataGrid();// to change the label of the datagrid
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

        private void SearchJobPosition()
        {
            this.query = @"SELECT jobPositionTittle
                           FROM 
                                dbt_job_position,
                                dbt_utilities_assigned_personnel  
                           WHERE 
                           ((dbt_job_position.dbt_jobPositionId = dbt_utilities_assigned_personnel.dbt_jobPositionId) AND dbt_utilities_assigned_personnel.personnelId = " + comboBoxPersonnel.SelectedValue + " )";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        labelPosition.Text = this.mdr.GetString("jobPositionTittle");
                    }
                }
                //changeLabelDataGrid();// to change the label of the datagrid
            }
            catch (Exception)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }

        }

        private void showEdit()
        {


            this.query = @"SELECT *
                           FROM " + this.tableName + " WHERE personnelId = " + comboBoxPersonnel.SelectedValue;

            comboBoxJobPosition.Text = labelPosition.Text;
            pictureBoxPhoto.Image = pictureBoxviewPerson.Image;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        textBoxLastName.Text = this.mdr.GetString("personnelLastName");
                        textBoxFirstName.Text = this.mdr.GetString("personnelFirstName");
                        textBoxMiddleName.Text = this.mdr.GetString("personnelMiddleName");
                        comboBoxGender.Text = this.mdr.GetString("personnelSex");
                        dateTimePickerBirthday.Text = this.mdr.GetString("personnelBday");
                        textBoxRoomBldgName.Text = this.mdr.GetString("personnelAddressRoomBldgName");
                        textBoxHouseBlockLotNum.Text = this.mdr.GetString("personnelAddressHouseBlockNum");
                        textBoxStreet.Text = this.mdr.GetString("personnelAddressStreet");
                        textBoxSubdivision.Text = this.mdr.GetString("personnelAddressSubdivision");
                        textBoxCity.Text = this.mdr.GetString("personnelAddressCity");
               
                    }
                }
                //changeLabelDataGrid();// to change the label of the datagrid
            }
            catch (Exception)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }
          
            
        }// end of method

        public void save()
        {
            if (buttonSave.Text == "Save Edit")
            {
                submitEditQuery();
                buttonSave.Text = "Save";
            }
            else if (buttonSave.Text == "Save")
            {
                addPersonnel();                
            }
            viewAllPersonnelSearch();
        }// end of the method

        private void submitEditQuery()
        {

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxFirstName.Text, textBoxLastName.Text, textBoxMiddleName.Text, comboBoxGender.Text, textBoxRoomBldgName.Text, comboBoxJobPosition.Text,
                textBoxHouseBlockLotNum.Text, textBoxStreet.Text, textBoxSubdivision.Text, textBoxCity.Text };

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
                    imgbyte = SaveImageToByteArray(pictureBoxviewPerson.Image, 90);

                    this.query = "UPDATE " + this.tableName +
                                @" SET 
                                personnelFirstName = @data1, 
                                personnelLastName = @data2, 
                                personnelMiddleName = @data3, 
                                personnelSex = @data4, 
                                personnelAddressRoomBldgName = @data5,                          
                                personnelBday = @data6, 
                                dbt_jobPosition = @data7, 
                                personnelAddressHouseBlockNum = @data8, 
                                personnelAddressStreet = @data9, 
                                personnelAddressSubdivision = @data10, 
                                personnelAddressCity = @data11, 
                                personnelPhoto = @data12 
                               WHERE personnelId = " + comboBoxPersonnel.SelectedValue;


                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@data1", textBoxFirstName.Text);
                        command.Parameters.AddWithValue("@data2", textBoxLastName.Text);
                        command.Parameters.AddWithValue("@data3", textBoxMiddleName.Text);
                        command.Parameters.AddWithValue("@data4", comboBoxGender.Text);
                        command.Parameters.AddWithValue("@data5", textBoxRoomBldgName.Text);
                        command.Parameters.AddWithValue("@data6", dateTimePickerBirthday.Value.ToString("yyy-MM-dd"));
                        command.Parameters.AddWithValue("@data7", comboBoxJobPosition.SelectedValue);
                        command.Parameters.AddWithValue("@data8", textBoxHouseBlockLotNum.Text);
                        command.Parameters.AddWithValue("@data9", textBoxStreet.Text);
                        command.Parameters.AddWithValue("@data10", textBoxSubdivision.Text);
                        command.Parameters.AddWithValue("@data11", textBoxCity.Text);
                        command.Parameters.AddWithValue("@data12", imgbyte);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();
                        labelWarning.Visible = true;
                        labelWarning.Text = " Record Edited successfully Thank you.";
                        ClearAllTextBox();
                    }
                }
                catch (Exception)
                {
                    // error handling
                    labelWarning.Text = "Sorry Unable to edit the record.";
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
       
        }// edn of the method

        private void deletePersonnelProfile()
        {
           
            this.query = @"DELETE 
                           FROM " + this.tableName +
                           " WHERE personnelId = " + comboBoxPersonnel.SelectedValue;
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());

                using (command = new MySqlCommand(this.query, this.connect))
                {
                                     
                    this.connect.Open();
                    command.ExecuteNonQuery();
                    labelWarning.Visible = true;
                    labelWarning.Text = "Record succesfully deleted.";
                    panelViewpersonnel.Visible = false;
                }
            }
            catch (Exception)
            {
                // error handling messages here;
                labelWarning.Text = "Sorry unable to delete the record.";

            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void ModifySize()
        {
            using (this.connect = new MySqlConnection(db.stringConnection()))
            {
                using (this.command = new MySqlCommand())
                {
                    this.command.Connection = this.connect;
                    this.connect.Open();
                    this.command.CommandText = "SET GLOBAL max_allowed_packet=15471080;";

                    this.command.ExecuteNonQuery();

                    this.connect.Close();
                }
            }
        }// end of the method
     
        public void viewAllJobPosition()
        {
            this.query = @"SELECT *
                           FROM dbt_job_position";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxJobPosition.DisplayMember = "jobPositionTittle";
                    comboBoxJobPosition.ValueMember = "dbt_jobPositionId";
                    comboBoxJobPosition.DataSource = ds.Tables[0];
                    //this.dataGridTenants();// for the designs of the grid
                }
                //changeLabelDataGrid();// to change the label of the datagrid
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

        private void ClearAllTextBox()
        {
            pictureBoxPhoto.Image = null;
            textBoxPicPath.Text = null;
            comboBoxGender.Text = null;
            dateTimePickerBirthday.Text = null;
            textBoxFirstName.Text = null;
            textBoxLastName.Text = null;
            textBoxMiddleName.Text = null;
            textBoxRoomBldgName.Text = null;
            textBoxHouseBlockLotNum.Text = null;
            textBoxStreet.Text = null;
            textBoxSubdivision.Text = null;
            textBoxCity.Text = null;
            comboBoxJobPosition.Text = null;
        }// end of the method

        private void deleteAll()
        {
            this.query = @"DELETE 
                           FROM " + this.tableName;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());

                using (command = new MySqlCommand(this.query, this.connect))
                {

                    this.connect.Open();
                    command.ExecuteNonQuery();

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

        private void searchPicture()
        {
            this.query = @"SELECT personnelPhoto
                           FROM " + this.tableName + " WHERE personnelId = " + comboBoxPersonnel.SelectedValue;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();

                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "dbt_utilities_assigned_personnel");
                    int count = ds.Tables["dbt_utilities_assigned_personnel"].Rows.Count;

                    byte[] imgbyt = new byte[0];
                    imgbyt = (byte[])ds.Tables["dbt_utilities_assigned_personnel"].Rows[count - 1]["personnelPhoto"];
                    MemoryStream ms = new MemoryStream(imgbyt);

                    pictureBoxviewPerson.Image = Image.FromStream(ms);

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

        private void uC_lepnatoLogoDARKfont1_Load(object sender, EventArgs e)
        {

        }

        public void designsGrid()
        {
            dataGridpersonnel.BorderStyle = BorderStyle.None;
            dataGridpersonnel.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridpersonnel.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridpersonnel.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridpersonnel.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridpersonnel.BackgroundColor = Color.White;

            dataGridpersonnel.EnableHeadersVisualStyles = false;
            dataGridpersonnel.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridpersonnel.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridpersonnel.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method

        private void changeLabelDataGrid()
        {
            string[] sysHeader = new string[12] {   "personnelId",
                                                    "personnelFirstName",
                                                    "personnelLastName",
                                                    "personnelMiddleName",
                                                    "personnelAddressRoomBldgName",
                                                    "personnelSex",
                                                    "personnelBday",
                                                    "dbt_jobPosition",
                                                    "personnelAddressHouseBlockNum",
                                                    "personnelAddressStreet",
                                                    "personnelAddressSubdivision",
                                                    "personnelAddressCity" };

            string[] sysHeadernew = new string[12] {
                "ID",
                "first name",
                "last name",
                "middle name",
                "building name && room number",
                "sex",
                "birthday",
                "job position",
                "house number / block number",
                "street",
                "subdivision",
                "city"
            };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataGridpersonnel.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
            }
        }// end of the method

        private void viewAllDataGrid()
        {
            this.query = @"SELECT personnelId, personnelFirstName, personnelLastName, personnelMiddleName, personnelSex, personnelAddressRoomBldgName, personnelBday, dbt_jobPosition, personnelAddressStreet,personnelAddressCity, personnelAddressSubdivision, personnelAddressHouseBlockNum
                           FROM " + this.tableName;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridpersonnel.DataSource = ds.Tables[0];
                    this.designsGrid();// for the designs of the grid
                }
                changeLabelDataGrid();// to change the label of the datagrid
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
        private void choosePhotoFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG(*.JPG)|*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {

                file = Image.FromFile(open.FileName);
                pictureBoxPhoto.Image = file;
                textBoxPicPath.Text = open.FileName.ToString();
            }
        }// end of the method

        private void addPersonnel()
        {
            //ModifySize();

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxFirstName.Text, textBoxLastName.Text, textBoxMiddleName.Text, comboBoxGender.Text, textBoxRoomBldgName.Text, comboBoxJobPosition.Text,
                textBoxHouseBlockLotNum.Text, textBoxStreet.Text, textBoxSubdivision.Text, textBoxCity.Text };

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
                this.query = @"INSERT 
                            INTO " + this.tableName +
                            @" (personnelFirstName, personnelLastName, personnelMiddleName, personnelSex, personnelAddressRoomBldgName,
                               personnelBday, dbt_jobPosition, personnelAddressHouseBlockNum, personnelAddressStreet, personnelAddressSubdivision, personnelAddressCity, personnelPhoto) 
                                VALUES(@data1, @data2, @data3, @data4, @data5, @data6, @data7, @data8, @data9, @data10, @data11, @data12)";

                try
                {
                    byte[] imgbyte;
                    imgbyte = SaveImageToByteArray(pictureBoxPhoto.Image, 90);

                    this.connect = new MySqlConnection(db.stringConnection());
                    this.connect.Open();
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@data1", textBoxFirstName.Text);
                        command.Parameters.AddWithValue("@data2", textBoxLastName.Text);
                        command.Parameters.AddWithValue("@data3", textBoxMiddleName.Text);
                        command.Parameters.AddWithValue("@data4", comboBoxGender.Text);
                        command.Parameters.AddWithValue("@data5", textBoxRoomBldgName.Text);
                        command.Parameters.AddWithValue("@data6", dateTimePickerBirthday.Value.ToString("yyy-MM-dd"));
                        command.Parameters.AddWithValue("@data7", comboBoxJobPosition.SelectedValue);
                        command.Parameters.AddWithValue("@data8", textBoxHouseBlockLotNum.Text);
                        command.Parameters.AddWithValue("@data9", textBoxStreet.Text);
                        command.Parameters.AddWithValue("@data10", textBoxSubdivision.Text);
                        command.Parameters.AddWithValue("@data11", textBoxCity.Text);
                        command.Parameters.AddWithValue("@data12", imgbyte);

                        command.ExecuteNonQuery();
                        labelWarning.Visible = true;
                        labelWarning.Text = " Record added Thank you.";
                        ClearAllTextBox();

                    }
                }
                catch (Exception ex)
                {
                    // error handling messages here;
                    labelWarning.Text = " Sorry Unable to add the record.";
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

        private void gender()
        {
            comboBoxGender.Items.Add("Male");
            comboBoxGender.Items.Add("Female");
        }// end of the method

        private void ViewOnePersonelGrid()
        {
            int rowindex = dataGridpersonnel.SelectedCells[0].RowIndex;
            string Id = dataGridpersonnel.Rows[rowindex].Cells[0].Value.ToString();
            string personnel = dataGridpersonnel.Rows[rowindex].Cells[1].Value.ToString();

            searchPictureGrid(Id);

            this.query = @"SELECT *
                           FROM " + this.tableName + " WHERE personnelId = " + Id;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        labelLastName.Text = this.mdr.GetString("personnelLastName");
                        labelFirstName.Text = this.mdr.GetString("personnelFirstName");
                        labelMiddleName.Text = this.mdr.GetString("personnelMiddleName");
                        labelSex.Text = this.mdr.GetString("personnelSex");
                        labelBDay.Text = this.mdr.GetString("personnelBday");



                        string housenumNme = this.mdr.GetString("personnelAddressHouseBlockNum");
                        string street = this.mdr.GetString("personnelAddressStreet");
                        string subdivision = this.mdr.GetString("personnelAddressSubdivision");
                        string city = this.mdr.GetString("personnelAddressCity");

                        labelAddress.Text = housenumNme + "/ " + street + "/ " + subdivision + "/ " + city;



                    }
                }
                //changeLabelDataGrid();// to change the label of the datagrid
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

        private void searchPictureGrid(string id)
        {
            this.query = @"SELECT personnelPhoto
                           FROM " + this.tableName + " WHERE personnelId = " + id;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();

                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "dbt_utilities_assigned_personnel");
                    int count = ds.Tables["dbt_utilities_assigned_personnel"].Rows.Count;

                    byte[] imgbyt = new byte[0];
                    imgbyt = (byte[])ds.Tables["dbt_utilities_assigned_personnel"].Rows[count - 1]["personnelPhoto"];
                    MemoryStream ms = new MemoryStream(imgbyt);

                    pictureBoxviewPerson.Image = Image.FromStream(ms);

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

        private void UC_personnel_Load(object sender, EventArgs e)
        {
            viewAllJobPosition();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }// end of the class
}
