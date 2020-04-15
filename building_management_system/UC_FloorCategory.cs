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
    public partial class UC_FloorCategory : UserControl
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;


        private string query;
        private string tableName = "dbt_floor_type_category";
        private int editValueId;


        public UC_FloorCategory()
        {
            InitializeComponent();
            viewAll();
            labelWarning.Visible = false;          
            buttonBack.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.editValueId = int.Parse(editRecord());
        }// button method

        private void buttonFloorTypeDelete_Click(object sender, EventArgs e)
        {
            deleteFloorNumber();
            viewAll();
        }//button method

        private void buttonFloorTypeAdd_Click(object sender, EventArgs e)
        {
            validateInput(textBoxFloorType.Text);//add floor category
            viewAll();
        }//Button method

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
            string[] sysHeader = new string[2] { "floorTypeCategoryId", "floorTypeCategoryName" };
            string[] sysHeadernew = new string[2] { "ID", "Floor Category" };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataGridFloorTypes.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
            }
        }// end of the method

        private void viewAll()
        {
            this.query = @"SELECT *
                           FROM " + this.tableName;
            this.designsGrid();// for the design

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridFloorTypes.DataSource = ds.Tables[0];
                    this.connect.Close();
                }
                changeLabelDataGrid();// to change the label of the datagrid
                dataGridFloorTypes.Columns[0].Visible = false;
            }
            catch (Exception e)
            {
                // error handling messages here;
            }


        }// end of the method
       
        private int dbCount()
        {
            this.query = @"SELECT COUNT(dbt_floor_type_category) as num_count
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

        private void addFloorCategory()
        {
            this.query = "INSERT INTO " + this.tableName + "(floorTypeCategoryName) VALUES(@data)";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    command.Parameters.AddWithValue("@data", textBoxFloorType.Text);
                    command.ExecuteNonQuery();
                    viewAll();// to refresh the views
                    labelWarning.Text = " Record added Thank you.";
                }
            }
            catch (Exception)
            {
                // error handling messages here;
                labelWarning.Text = " Record cannot be added.";
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void deleteFloorNumber()
        {
            int rowindex = dataGridFloorTypes.SelectedCells[0].RowIndex;
            string floor = dataGridFloorTypes.Rows[rowindex].Cells[0].Value.ToString();
            string floorType = dataGridFloorTypes.Rows[rowindex].Cells[1].Value.ToString();

            this.query = @"DELETE 
                           FROM " + this.tableName +
                           " WHERE floorTypeCategoryId = @data";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    command.Parameters.AddWithValue("@data", int.Parse(floor));
                    //command.Parameters.AddWithValue("@data", textBoxFloorType.Text);
                    command.ExecuteNonQuery();
                    labelWarning.Visible = true;
                    labelWarning.Text = "Record floor category  " + floorType + " is succesfully deleted.";

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

        private void validateInput(string inputString)
        {
            int duplicate = 0;

            for (int i = 0; i < dbCount(); i++)
            {
                if (inputString == dataGridFloorTypes.Rows[i].Cells[1].Value.ToString())
                {
                    duplicate++; // look if there is a data duplication
                    // prompt messages                   
                }
            }
            if (duplicate > 0)
            {
                labelWarning.Text = "Sorry there is already a record for this entry floor number " + textBoxFloorType.Text + "\n please try again another";
                labelWarning.Visible = true;
            }
            else
            {
                addAndEdit();
                labelWarning.Visible = true;             
            }

        }// end of the method

        private void submitEditQuery()
        {
            try
            {
                this.query = "UPDATE " + this.tableName + " SET floorTypeCategoryName = @data WHERE  floorTypeCategoryId = " + this.editValueId;

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();

                    this.command.Parameters.AddWithValue("@data", textBoxFloorType.Text);
                    this.command.ExecuteNonQuery();
                    buttonFloorTypeAdd.Text = "Save";
                    textBoxFloorType.Text = null;
                    buttonBack.Visible = false;
                    labelWarning.Text = " Record Edited successfully Thank you.";
                }
            }
            catch (Exception Ex)
            {
                // error handling
              
            }
            finally
            {
                this.connect.Close();
            }
        }// edn of the method

        private void dataGridFloorTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private string editRecord()
        {
            int rowindex = dataGridFloorTypes.SelectedCells[0].RowIndex;
            string floor = dataGridFloorTypes.Rows[rowindex].Cells[0].Value.ToString();
            string floorType = dataGridFloorTypes.Rows[rowindex].Cells[1].Value.ToString();

            textBoxFloorType.Text = floorType;
            buttonFloorTypeAdd.Text = "Save Edit";
            buttonBack.Visible = true;

            return floor;
        }// end of the method

        private void addAndEdit()
        {
            if(buttonFloorTypeAdd.Text == "Save")
            {
                addFloorCategory();               
            }
            else if(buttonFloorTypeAdd.Text == "Save Edit")
            {
                submitEditQuery();            
            }
        }// end of the method

        private void buttonBack_Click(object sender, EventArgs e)
        {
            textBoxFloorType.Text = null;
            buttonFloorTypeAdd.Text = "Save";
            buttonBack.Visible = false;
        }
    }// end of the class
}// end of the namespace
