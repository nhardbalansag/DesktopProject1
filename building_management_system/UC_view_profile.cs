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
    public partial class UC_view_profile : UserControl
    {
        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        Image file;
      

        private string query;
        private string tableName = "dbt_personal_information";
        public UC_view_profile()
        {
            InitializeComponent();
            searchPicture();
            SearchPersonnel();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

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
        private void SearchPersonnel()
        {
            this.query = @"SELECT *
                           FROM " + this.tableName + " WHERE login_status = 1";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        string a = this.mdr.GetString("personalInfoFirstName");
                        string b = this.mdr.GetString("personalInfomiddleName");
                        string c = this.mdr.GetString("personalInfoLastName");

                        label3Name.Text = a + " " + b + " " + c;
                        label2Position.Text = this.mdr.GetString("dbt_jobPosition").ToUpper();
  
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






    }// end of the class
}/// end of the namespace
