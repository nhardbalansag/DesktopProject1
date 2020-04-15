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
    public partial class Form1 : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        Image file;
        ClassValidations validate = new ClassValidations();
        Form3 form3 = new Form3();

        private string query;
        private string tableName = "dbt_personal_information";
        private string u_id;
        private int u_count;


        public Form1()
        {
            InitializeComponent();
            labelWarning.Visible = false;
            Log_outTheNotLogin();
            
        }

        private void label_logo_text_Click(object sender, EventArgs e)
        {

        }

        private void label_description_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
            //this.Dispose();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Form2 register_form = new Form2();
            this.Hide();
            register_form.Show();

        }//button register

        private void btn_login_Click(object sender, EventArgs e)
        {
            confirmLogin();          
        }// button login

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void confirmLogin()
        {
            string a = null;
            string b = null;         
            bool result;
            int trueResult = 0;
            string[] textbox = { text_password.Text, text_username.Text };

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
                    this.query = @"SELECT registerUsername, registerPassword, dbt_personalInfoId
                                FROM dbt_personal_information 
                                    WHERE registerPassword = @data1 AND registerUsername = @data2";

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", text_password.Text);
                        this.command.Parameters.AddWithValue("@data2", text_username.Text);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();
                        this.mdr = this.command.ExecuteReader();

                        if (this.mdr.Read())
                        {
                           a = this.mdr.GetString("registerUsername");
                           b = this.mdr.GetString("registerPassword");

                            if (a != text_username.Text)
                            {
                                labelWarning.Visible = true;
                                labelWarning.Text = "Invalid Username";                               
                              
                            }else if(b != text_password.Text)
                            {
                                labelWarning.Visible = true;
                                labelWarning.Text = "Invalid Password";
                            }
                            else
                            {
                                this.u_id = this.mdr.GetString("dbt_personalInfoId");
                            }

                        }
                 
                    }
                }
                catch (Exception)
                {
                    // error handling messages here;
                    labelWarning.Visible = true;
                    labelWarning.Text = "internal error Invalid login";
                }
                finally
                {
                    this.connect.Close();
                }

                if (a == text_username.Text && b == text_password.Text)
                {
                    update_loginStatus();
                    //form3.Show();
                    //this.Hide();

                    Form3 registered_form = new Form3();
                    this.Hide();
                    registered_form.Show();
                }
                else
                {
                    labelWarning.Visible = true;
                    labelWarning.Text = "Invalid Login";
                }
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Invalid login";
            }             

        }// end of the method

        private int CountNotLogout()
        {
            int count = 0;
            try
            {
                this.query = "SELECT COUNT(login_status) AS count FROM dbt_personal_information WHERE login_status = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        count = int.Parse(this.mdr.GetString("count"));
                        this.u_count = int.Parse(this.mdr.GetString("count"));
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

            return count;
        }// end of the method
        
        private void findTheNotLogout()
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

        private void update_loginStatus()
        {
            try
            {
                query = "UPDATE " + this.tableName +
                            @" SET login_status = @data1 WHERE dbt_personalInfoId = " + this.u_id;

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    if (this.u_count > 0)
                    {
                        this.command.Parameters.AddWithValue("@data1", 2);
                        this.u_count = 0;
                    }
                    else
                    {
                        this.command.Parameters.AddWithValue("@data1", 1);
                    }

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


        private void Log_outTheNotLogin()
        {
            if(CountNotLogout() > 0)
            {
                findTheNotLogout();
                update_loginStatus();
            }
        }// end of the method


    }// end of the class
}// end of the namespace
