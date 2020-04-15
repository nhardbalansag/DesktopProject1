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
    public partial class UC_Submeter : UserControl
    {
        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        ClassValidations validate = new ClassValidations();

        private string query;
        private string tableName = "dbt_submeter";

        public UC_Submeter()
        {
            InitializeComponent();
            start();
        }

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {
            save();
        }// button add end

        private void buttonBack_Click(object sender, EventArgs e)
        {
            buttonBack.Visible = false;
            buttonSaveInfo.Text = "Add";
            viewAll();
            textBoxMeterReader.Text = null;
            labelWarning.Visible = false;
        }// button back or cancel end

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editRecord();
            buttonBack.Visible = true;
            labelWarning.Visible = false;
        }// button edit

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deleteFloorNumber();
            viewAll();
        }// button delete

        public void start()
        {
            viewAll();
            labelWarning.Visible = false;            
            buttonBack.Visible = false;
        }// end of the method

        public void designsGrid()
        {
            dataGridFloorTypes.BorderStyle = BorderStyle.None;
            dataGridFloorTypes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridFloorTypes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridFloorTypes.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridFloorTypes.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridFloorTypes.BackgroundColor = Color.White;

            dataGridFloorTypes.EnableHeadersVisualStyles = false;
            dataGridFloorTypes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridFloorTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridFloorTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method

        private void changeLabelDataGrid()
        {
            string[] sysHeader = new string[2] { "submeterId", "submeter_type_name" };
            string[] sysHeadernew = new string[2] { "ID", "Meter Reader Type" };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataGridFloorTypes.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
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
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridFloorTypes.DataSource = ds.Tables[0];
                    this.designsGrid();// for the designs of the grid
                }
                changeLabelDataGrid();// to change the label of the datagrid
                dataGridFloorTypes.Columns[0].Visible = false;
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

        private int dbCount()
        {
            this.query = @"SELECT COUNT(submeterId) as num_count
                           FROM " + this.tableName;
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
            catch (Exception ex)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }

            return finalCount;
        }// end of the method

        private void addSubmeter()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxMeterReader.Text };

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
                this.query = "INSERT INTO " + this.tableName + "(submeter_type_name) VALUES(@data)";
                try
                {

                    this.connect = new MySqlConnection(db.stringConnection());
                    this.connect.Open();
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@data", textBoxMeterReader.Text);
                        command.ExecuteNonQuery();
                        labelWarning.Text = " Record added Thank you.";
                    }
                }
                catch (Exception)
                {
                    // error handling messages here;
                    labelWarning.Text = "Record job position  " + textBoxMeterReader.Text + " cannot be added.";
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

        private void deleteFloorNumber()
        {
            int rowindex = dataGridFloorTypes.SelectedCells[0].RowIndex;
            string meterID = dataGridFloorTypes.Rows[rowindex].Cells[0].Value.ToString();
            string meterType = dataGridFloorTypes.Rows[rowindex].Cells[1].Value.ToString();

            this.query = @"DELETE 
                           FROM " + this.tableName +
                           " WHERE submeterId = @data";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());

                using (command = new MySqlCommand(this.query, this.connect))
                {
                    command.Parameters.AddWithValue("@data", int.Parse(meterID));
                    //command.Parameters.AddWithValue("@data", textBoxFloorType.Text);
                    this.connect.Open();
                    command.ExecuteNonQuery();
                    labelWarning.Visible = true;
                    labelWarning.Text = "Record job category  " + meterType + " is succesfully deleted.";

                }
            }
            catch (Exception)
            {
                // error handling messages here;
                labelWarning.Text = "Record job category  " + meterType + " cannot be deleted.";

            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void submitEditQuery()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxMeterReader.Text };

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

                    int rowindex = dataGridFloorTypes.SelectedCells[0].RowIndex;
                    string meterId = dataGridFloorTypes.Rows[rowindex].Cells[0].Value.ToString();

                    this.query = "UPDATE " + this.tableName + " SET submeter_type_name = @data WHERE submeterId = " + int.Parse(meterId);

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data", textBoxMeterReader.Text);
                        this.connect.Open();
                        this.command.ExecuteNonQuery();
                        textBoxMeterReader.Text = null;
                        buttonBack.Visible = false;
                        labelWarning.Visible = true;
                        labelWarning.Text = " Record Edited successfully Thank you.";

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
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }
            
        }// edn of the method

        private void dataGridFloorTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editRecord()
        {
            int rowindex = dataGridFloorTypes.SelectedCells[0].RowIndex;
            string floor = dataGridFloorTypes.Rows[rowindex].Cells[0].Value.ToString();
            string floorType = dataGridFloorTypes.Rows[rowindex].Cells[1].Value.ToString();

            textBoxMeterReader.Text = floorType;
            buttonSaveInfo.Text = "Save Edit";
            buttonBack.Visible = true;
        }// end of the method

        public void save()
        {
            if (buttonSaveInfo.Text == "Save Edit")
            {
                submitEditQuery();
                buttonSaveInfo.Text = "Add";
            }
            else if (buttonSaveInfo.Text == "Add")
            {
                addSubmeter();
                //buttonSaveInfo.Text = "Save Edit";
            }
            viewAll();
        }// end of the method


    }// end of the class
}
