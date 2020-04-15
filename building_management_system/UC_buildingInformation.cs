using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace building_management_system
{
    public partial class UC_buildingInformation : UserControl
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        ClassValidations validate = new ClassValidations();

        private string query;
        private string tableName = "dbt_building_information";
        private int checkRows, checkMax;


        public UC_buildingInformation()
        {          
            InitializeComponent();
            //deleteAllBuildingInformation();
            hideShowBuildingInfo();
            implementFunction();
            labelWarning.Visible = false;            
        }

        public void panelAddBuldingInfo()
        {          
            panelAddEditBuldingInfo.Show();
            
        }//end of the method

        private void hideAddBuildingInfo()
        {
            panelAddEditBuldingInfo.Hide();
            panelShowBuldingInfo.Show();
            panelShowBuldingInfo.Location = new Point(58, 324);
        }// end of the method
        private void hideShowBuildingInfo()
        {
            panelShowBuldingInfo.Hide();
            panelAddEditBuldingInfo.Show();
            panelShowBuldingInfo.Location = new Point(58, 324);
        }// end of the method
        
        private void button1_Click(object sender, EventArgs e)
        {
            hideShowBuildingInfo();
            showEditBuildingInfo();
            buttonSaveInfo.Text = "Save Edit";
            labelWarning.Visible = false;
            
        }// button method

        private void changeBtnFunction(string btnText)
        {

            if (btnText == "Save")
            {
                addBuildingInformation();
                hideAddBuildingInfo();
                viewAllBuildingInfo();
            }
            else if(btnText == "Save Edit")
            {
                submitEditBuildingInfo(); // run the update  
                viewAllBuildingInfo();
            }
        }// end of the method

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {                   
            hideAddBuildingInfo();
            viewAllBuildingInfo();
            changeBtnFunction(buttonSaveInfo.Text);
        }// button method

        private void deleteAllBuildingInformation()
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
                    MessageBox.Show("Information Deleted", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // viewAll();// to refresh the views
                }
            }
            catch (Exception ex)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void addBuildingInformation()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxBuildingName.Text, textBoxBuildingNumber.Text, textBoxStreet.Text, textBoxBarangay.Text, textBoxCity.Text };

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
                           INTO " + this.tableName + "(buildingInfoName, buildingInfoNumber, buildingInfoStreet, buildingInfoBarangay, buildingInfoCity) VALUES(@d1, @d2, @d3, @d4, @d5)";
                try
                {
                    this.connect = new MySqlConnection(db.stringConnection());
                    this.connect.Open();
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@d1", textBoxBuildingName.Text);
                        command.Parameters.AddWithValue("@d2", textBoxBuildingNumber.Text);
                        command.Parameters.AddWithValue("@d3", textBoxStreet.Text);
                        command.Parameters.AddWithValue("@d4", textBoxBarangay.Text);
                        command.Parameters.AddWithValue("@d5", textBoxCity.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Record already saved", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // viewAll();// to refresh the views
                    }
                }
                catch (Exception ex)
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

        private void viewAllBuildingInfo()
        {
            this.query = @"SELECT buildingInfoName, buildingInfoNumber, buildingInfoStreet, buildingInfoBarangay, buildingInfoCity
                           FROM " + this.tableName;                         
            try
            {
                this.connect = new MySqlConnection(db.stringConnection());             
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        textBoxShowBuildingName.Text = mdr.GetString("buildingInfoName");
                        textBoxShowBuildingNumber.Text = mdr.GetString("buildingInfoNumber");
                        textBoxShowStreet.Text = mdr.GetString("buildingInfoStreet");
                        textBoxShowBarangay.Text = mdr.GetString("buildingInfoBarangay");
                        textBoxShowCity.Text = mdr.GetString("buildingInfoCity");
                    }                                                                
                }
            }
            catch (Exception ex)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void showEditBuildingInfo()
        {
            this.query = @"SELECT buildingInfoName, buildingInfoNumber, buildingInfoStreet, buildingInfoBarangay, buildingInfoCity
                           FROM " + this.tableName;
            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        textBoxBuildingName.Text = mdr.GetString("buildingInfoName");
                        textBoxBuildingNumber.Text = mdr.GetString("buildingInfoNumber");
                        textBoxStreet.Text = mdr.GetString("buildingInfoStreet");
                        textBoxBarangay.Text = mdr.GetString("buildingInfoBarangay");
                        textBoxCity.Text = mdr.GetString("buildingInfoCity");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void submitEditBuildingInfo()
        {
            int num = findmaxQuery();

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxBuildingName.Text, textBoxBuildingNumber.Text, textBoxStreet.Text, textBoxBarangay.Text, textBoxCity.Text };

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
                this.query = @"UPDATE " + this.tableName + " SET buildingInfoName = @d1, buildingInfoNumber = @d2, buildingInfoStreet = @d3, buildingInfoBarangay = @d4, buildingInfoCity = @d5 WHERE buildingInformationID = " + num;
                try
                {
                    this.connect = new MySqlConnection(db.stringConnection());
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@d1", textBoxBuildingName.Text);
                        command.Parameters.AddWithValue("@d2", textBoxBuildingNumber.Text);
                        command.Parameters.AddWithValue("@d3", textBoxStreet.Text);
                        command.Parameters.AddWithValue("@d4", textBoxBarangay.Text);
                        command.Parameters.AddWithValue("@d5", textBoxCity.Text);

                        this.connect.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
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

        private int checkDb()
        {
            this.query = @"SELECT COUNT(buildingInformationID) as num_count
                           FROM " + this.tableName;
            string num;
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
                       checkRows = int.Parse(num);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }

            return checkRows;
        }// end of the method

        private void implementFunction()
        {
            this.checkRows = checkDb();
            if (this.checkRows > 0)
            {
                viewAllBuildingInfo();
                hideAddBuildingInfo();                            
                buttonSaveInfo.Text = "Save Edit";
            }
            else if (this.checkRows <= 0)
            {
                //panelAddBuldingInfo();
                hideShowBuildingInfo();
            }
           
        }// end of the method

        private void button1_Click_1(object sender, EventArgs e)
        {
            hideAddBuildingInfo();
        }

        private int findmaxQuery()
        {
            this.query = @"SELECT MAX(buildingInformationID) as max_num
                           FROM " + this.tableName;         
            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        this.checkMax = int.Parse(mdr.GetString("max_num"));
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }

            return this.checkMax;
        }// end of method

    }
}
