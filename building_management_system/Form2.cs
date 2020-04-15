using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace building_management_system
{
    public partial class Form2 : Form
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


        public Form2()
        {
            InitializeComponent();
            comboBoxJobPosition.Visible = false;
            label4.Visible = false;
            start();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_welcome_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 register_login = new Form1();
            register_login.Show();
        }// button back
        private void btn_register_Click(object sender, EventArgs e)
        {
            SaveRegister();
        }// button register


        
        private void comboBoxJobPosition_dropdown()
        {
            this.query = @"SELECT *
                           FROM 
                                dbt_job_position";                          
                          
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxJobPosition.DisplayMember = "jobPositionTittle";
                    comboBoxJobPosition.ValueMember = "jobPositionTittle";
                    comboBoxJobPosition.DataSource = ds.Tables[0];
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
        private void comboBoxJobPosition_forNoneAdmin()
        {
            this.query = @"SELECT *
                           FROM 
                                dbt_job_position WHERE jobPositionTittle != 'admin'";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxJobPosition.DisplayMember = "jobPositionTittle";
                    comboBoxJobPosition.ValueMember = "jobPositionTittle";
                    comboBoxJobPosition.DataSource = ds.Tables[0];
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



        private int dbCountUser()
        {
            this.query = @"SELECT COUNT(dbt_personalInfoId) as num_count
                           FROM dbt_personal_information";
            string num;
            int finalCount = 0;
            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        num = mdr.GetString("num_count");
                        finalCount = int.Parse(num);
                    }
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
           
            return finalCount;
        }// end of the method

        
        private void addFirstUserJobPosition()
        {
            this.query = @"INSERT 
                           INTO 
                                dbt_job_position(jobPositionTittle) VALUES(@data1)";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());             
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.command.Parameters.AddWithValue("@data1", "Admin");

                    this.connect.Open();
                    this.command.ExecuteNonQuery();
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
        private void addOtherUser()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxFirstName.Text, textBoxMiddleName.Text, textBoxLastName.Text, textBoxUsername.Text, textBoxPassword.Text, comboBoxJobPosition.Text };

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
                             @" (
                                    personalInfoFirstName, 
                                    personalInfomiddleName, 
                                    personalInfoLastName, 
                                    personalInfoBirthday,                           
                                    personalInfosex, 
                                    dbt_jobPosition, 
                                    registerUsername, 
                                    registerPassword,
                                    personalInfoProfilePicture) 
                                VALUES (@data1, @data2, @data3, now(), @data4, @data5, @data6, @data7, @data8)";

                try
                {


                    this.connect = new MySqlConnection(db.stringConnection());
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@data1", textBoxFirstName.Text);
                        command.Parameters.AddWithValue("@data2", textBoxMiddleName.Text);
                        command.Parameters.AddWithValue("@data3", textBoxLastName.Text);
                        command.Parameters.AddWithValue("@data4", "not set");
                        command.Parameters.AddWithValue("@data5", comboBoxJobPosition.Text);
                        command.Parameters.AddWithValue("@data6", textBoxUsername.Text);
                        command.Parameters.AddWithValue("@data7", textBoxPassword.Text);
                        command.Parameters.AddWithValue("@data8", null);

                        this.connect.Open();
                        command.ExecuteNonQuery();

                        this.Close();
                        clearAll();
                        Form1 register_login = new Form1();
                        register_login.Show();
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
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }
        }// end of the method
        private void addMainUserAdmin()
        {
            //ModifySize();

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxFirstName.Text, textBoxMiddleName.Text, textBoxLastName.Text, textBoxUsername.Text, textBoxPassword.Text};

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
                            @" (
                                    personalInfoFirstName, 
                                    personalInfomiddleName, 
                                    personalInfoLastName, 
                                    personalInfoBirthday,                           
                                    personalInfosex, 
                                    dbt_jobPosition, 
                                    registerUsername, 
                                    registerPassword,
                                    personalInfoProfilePicture,
                                    login_status) 
                                VALUES (@data1, @data2, @data3, now(), @data4, @data5, @data6, @data7, @data8, @data9)";

                try
                {
                    
                    this.connect = new MySqlConnection(db.stringConnection());                 
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@data1", textBoxFirstName.Text);                       
                        command.Parameters.AddWithValue("@data2", textBoxMiddleName.Text);
                        command.Parameters.AddWithValue("@data3", textBoxLastName.Text);                      
                        command.Parameters.AddWithValue("@data4", "not set");
                        command.Parameters.AddWithValue("@data5", "Admin");
                        command.Parameters.AddWithValue("@data6", textBoxUsername.Text);
                        command.Parameters.AddWithValue("@data7", textBoxPassword.Text);
                        command.Parameters.AddWithValue("@data8", null);
                        command.Parameters.AddWithValue("@data9", 2);


                        this.connect.Open();
                        this.command.ExecuteNonQuery();

                        clearAll();                      
                        Form1 register_login = new Form1();
                        register_login.Show();
                        this.Hide();

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
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }

        }// end of the method

        private void clearAll()
        {
           
            textBoxFirstName.Text = null;
            textBoxLastName.Text = null;
            textBoxMiddleName.Text = null;
            textBoxUsername.Text = null;
            textBoxPassword.Text = null;
            

        }// end of the method
        private void refreshDb()
        {

            try
            {
                this.query = "SELECT * FROM dbt_personal_information WHERE login_status = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
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

        private void SaveRegister()
        {
            if(dbCountUser() <= 0)
            {
               addFirstUserJobPosition();
                addMainUserAdmin();
            }
            else if(dbCountUser() > 0)
            {               
                addOtherUser();
            }
        }// end of the method

        public void start()
        {
            labelWarning.Visible = false;
               
            if (dbCountUser() > 0)
            {
                comboBoxJobPosition_forNoneAdmin();
                comboBoxJobPosition.Visible = true;
                refreshDb();
            }
            else
            {
                comboBoxJobPosition.Visible = false;
                comboBoxJobPosition_dropdown();
            }
        }


        private string maximumIdutility()
        {

            string maximum_Id = null;

            this.query = "SELECT MAX(dbt_personalInfoId) AS maximum_id FROM dbt_personal_information";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        maximum_Id = this.mdr.GetString("maximum_id");
                    }

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                this.connect.Close();
            }

            return maximum_Id;
        }// end of the method
        private void currentRegistered()
        {
            this.query = @"SELECT registerPassword
                           FROM 
                                dbt_personal_information 
                               WHERE dbt_personalInfoId = " + maximumIdutility(); ;

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        this.u_id = this.mdr.GetString("registerPassword");
                    }
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
        private void updateId()
        {
            try
            {

                this.query = "UPDATE " + this.tableName +
                            @" SET 
                                dbt_personalInfoId = @data1                                                              
                               WHERE utilitiesReadingId = " + maximumIdutility();


                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {

                    this.command.Parameters.AddWithValue("@data1", this.u_id);
                
                    this.connect.Open();
                    this.command.ExecuteNonQuery();

                    labelWarning.Visible = true;

                    labelWarning.Text = " Record Edited successfully Thank you.";
                    //ClearAllTextBox();

                }

                clearAll();
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
        }// end of the method

       



    }// end of the class

}// end of the namespace
