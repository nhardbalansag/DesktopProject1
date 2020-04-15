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
    public partial class UC_utilititesType : UserControl
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        ClassValidations validate = new ClassValidations();


        private string query;
        private string tableName = "dbt_utilities_type";

        public UC_utilititesType()
        {
            InitializeComponent();
            start();
            buttonDelete.Visible = false;
            buttonDelete.Enabled = false;
        }

        private void UC_utilititesType_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {
            save_saveEdit();
        }// button save

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Visible = false;
            buttonSaveInfo.Text = "Save";
            clearAll();
            labelWarning.Visible = false;
        }// button cancel

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonSaveInfo.Text = "Save Edit";
            buttonCancel.Visible = true;
            GetRecord();
            labelWarning.Visible = false;
        }// button edit

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            delete();
        }// button delete

        private void delete()
        {
            int rowindex = dataUtilityType.SelectedCells[0].RowIndex;
            string meterID = dataUtilityType.Rows[rowindex].Cells[0].Value.ToString();
            string meterType = dataUtilityType.Rows[rowindex].Cells[1].Value.ToString();

            this.query = @"DELETE 
                           FROM " + this.tableName +
                           " WHERE utilitesTypeId = @data";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());

                using (command = new MySqlCommand(this.query, this.connect))
                {
                    command.Parameters.AddWithValue("@data", int.Parse(meterID));
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                    labelWarning.Visible = true;
                    labelWarning.Text = "Record is succesfully deleted.";
                    clearAll();
                }
            }
            catch (Exception)
            {
                // error handling messages here;
                labelWarning.Text = "Sorry unable to delete this record.";

            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void submitEdit()
        {

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxUtilitiesType.Text, textBoxProvider.Text };

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
                    int rowindex = dataUtilityType.SelectedCells[0].RowIndex;
                    string Id = dataUtilityType.Rows[rowindex].Cells[0].Value.ToString();

                    this.query = "UPDATE " + this.tableName + " SET utilitesTypeName = @data1, utilitesProvider = @data2 WHERE utilitesTypeId = " + int.Parse(Id);

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", textBoxUtilitiesType.Text);
                        this.command.Parameters.AddWithValue("@data2", textBoxProvider.Text);
                        this.connect.Open();
                        this.command.ExecuteNonQuery();
                        labelWarning.Visible = true;
                        labelWarning.Text = " Record Edited successfully Thank you.";
                        clearAll();
                    }
                }
                catch (Exception)
                {
                    // error handling
                    labelWarning.Text = "Unable to edit this record.";
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

        private void add()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxUtilitiesType.Text, textBoxProvider.Text};

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
                this.query = "INSERT INTO " + this.tableName + "(utilitesTypeName, utilitesProvider) VALUES(@data1, @data2)";
                try
                {

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", textBoxUtilitiesType.Text);
                        this.command.Parameters.AddWithValue("@data2", textBoxProvider.Text);
                        this.connect.Open();
                        command.ExecuteNonQuery();
                        labelWarning.Text = " Record added Thank you.";
                        clearAll();
                    }
                }
                catch (Exception)
                {
                    // error handling messages here;
                    labelWarning.Text = "Record cannot be added.";
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

        private void viewAll()
        {
            this.query = @"SELECT *
                           FROM " + this.tableName;

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                   
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataUtilityType.DataSource = ds.Tables[0];
                    this.designsGrid();// for the designs of the grid
                }
                changeLabelDataGrid();// to change the label of the datagrid
            }
            catch (Exception)
            {
                // error handling messages here;
                labelWarning.Text = "Unable to show records.";
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void save_saveEdit()
        {
            if (buttonSaveInfo.Text == "Save Edit")
            {
                submitEdit();
                buttonSaveInfo.Text = "Save";
            }
            else if (buttonSaveInfo.Text == "Save")
            {
                add();               
            }
            viewAll();
        }// end of the method

        private void start()
        {
            designsGrid();
            viewAll();
            buttonCancel.Visible = true;
            labelWarning.Visible = false;
            buttonCancel.Visible = false;          
        }// edn of the method

        public void designsGrid()
        {
            dataUtilityType.BorderStyle = BorderStyle.None;
            dataUtilityType.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataUtilityType.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataUtilityType.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataUtilityType.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataUtilityType.BackgroundColor = Color.White;

            dataUtilityType.EnableHeadersVisualStyles = false;
            dataUtilityType.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataUtilityType.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataUtilityType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method

        private void changeLabelDataGrid()
        {
            string[] sysHeader = new string[3] { "utilitesTypeId", "utilitesTypeName", "utilitesProvider" };
            string[] sysHeadernew = new string[3] { "ID", "utility", "Provider" };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataUtilityType.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
            }

            dataUtilityType.Columns[0].Visible = false;

        }// end of the method

        private void clearAll()
        {
            textBoxUtilitiesType.Text = null;
            textBoxProvider.Text = null;
            labelWarning.Text = null;
            start();
        }// end of the method

        private void GetRecord()
        {
            int rowindex = dataUtilityType.SelectedCells[0].RowIndex;
            string Id = dataUtilityType.Rows[rowindex].Cells[0].Value.ToString();

            this.query = @"SELECT utilitesTypeName, utilitesProvider
                           FROM " + this.tableName +
                           " WHERE utilitesTypeId = " + Id;

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using(this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        textBoxUtilitiesType.Text = this.mdr.GetString("utilitesTypeName");
                        textBoxProvider.Text = this.mdr.GetString("utilitesProvider");
                    }                   
                }
            }
            catch (Exception)
            {
                labelWarning.Text = " Unable to show record.";
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

    }// end of the class
}// end of the namespace
