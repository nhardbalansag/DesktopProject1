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
    public partial class UC_FloorNumber : UserControl
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        

        private string query;
        private string tableName = "dbt_floor_number";
        private int intData;


        public UC_FloorNumber()
        {
            InitializeComponent();
            //deleteAllFloors();
            viewAll();
            labelWarning.Visible = false;
            
            //dataGridFloorNumber.Rows[0].Cells[0].ReadOnly = true;
            //string a = dataGridFloorNumber.Rows[3].Cells[1].Value.ToString();
            //MessageBox.Show(dbCount().ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void UC_FloorNumber_Load(object sender, EventArgs e)
        {

        }
       
        public void designsGrid()
        {
            dataGridFloorNumber.BorderStyle = BorderStyle.None;
            dataGridFloorNumber.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridFloorNumber.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridFloorNumber.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridFloorNumber.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridFloorNumber.BackgroundColor = Color.White;

            dataGridFloorNumber.EnableHeadersVisualStyles = false;
            dataGridFloorNumber.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridFloorNumber.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridFloorNumber.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method

        private void changeLabelDataGrid()
        {
            string[] sysHeader = new string[2] { "dbt_floorNumberId", "floorTypeNumber" };
            string[] sysHeadernew = new string[2] { "ID", "Floor Numbers"};

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataGridFloorNumber.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
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
                    dataGridFloorNumber.DataSource = ds.Tables[0];
                    
                }
                changeLabelDataGrid();// to change the label of the datagrid
                dataGridFloorNumber.Columns[0].Visible = false;
            }
            catch(Exception e)
            {
                // error handling messages here;
            }
            finally
            {
                this.connect.Close();
            }
                   
        }// end of the method

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {
            validationsNumber();
            viewAll();
            textBoxFloorNumber.Text = null;
        }// button end method

        private void dataGridFloorNumber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteFloorNumber();// delete floor number
            viewAll();
            textBoxFloorNumber.Text = null;
        }// end of the button method

        private void addlabel()
        {
            int width = 0;
            int height = 3;
            string value;
          
            for(int i = 0; i < dbCount(); i++)
            {
                
                Label fnumber = new Label();
                
                    fnumber.Name = "labelFloor_" + (i + 1).ToString();
                    value = dataGridFloorNumber.Rows[i].Cells[1].Value.ToString();
                    fnumber.Text = value;
                    fnumber.Size = new Size(144, 33);
                    fnumber.Font = new Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    fnumber.Location = new Point(width, height);

                    panelViews.Controls.Add(fnumber);
                    height = height + 29;
                
                
            }
        }// end of the method

        private int dbCount()
        {
            this.query = @"SELECT COUNT(dbt_floorNumberId) as num_count
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

        private void addFloorNumber(int data)
        {
            this.query = "INSERT INTO " + this.tableName + "(floorTypeNumber) VALUES(@data)";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    command.Parameters.AddWithValue("@data", data.ToString());
                    command.ExecuteNonQuery();                  
                    viewAll();// to refresh the views
                   
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

        private void deleteFloorNumber()
        {
            int rowindex = dataGridFloorNumber.SelectedCells[0].RowIndex;
            string floorId = dataGridFloorNumber.Rows[rowindex].Cells[0].Value.ToString();
            string floor = dataGridFloorNumber.Rows[rowindex].Cells[1].Value.ToString();

            this.query = @"DELETE 
                           FROM " + this.tableName +
                           " WHERE dbt_floorNumberId = @data";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (command = new MySqlCommand(this.query, this.connect))
                {
                    command.Parameters.AddWithValue("@data", int.Parse(floorId));
                    //command.Parameters.AddWithValue("@data", textBoxFloorNumber.Text);
                    command.ExecuteNonQuery();
                    labelWarning.Visible = true;
                    labelWarning.Text = "floor number " + floor + " is succesfully deleted.";
                                   
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

        public void generateNumber(int number)
        {       
            for (int i = 0; i < number; i++)
            {
               addFloorNumber(i + 1);
            }        
        }// emd of the method

        public void validationsNumber()
        {
            int duplicate = 0;
            try
            {
                intData = int.Parse(textBoxFloorNumber.Text);
                for (int i = 0; i < dbCount(); i++)
                {
                    if (intData.ToString() == dataGridFloorNumber.Rows[i].Cells[1].Value.ToString())
                    {
                        duplicate++; // look if there is a data duplication
                                     // prompt messages                   
                    }
                }
                if (duplicate > 0)
                {
                    labelWarning.Text = "Sorry there is already a record for this entry floor number " + textBoxFloorNumber.Text + "\n please try again another";
                    labelWarning.Visible = true;
                }
                else if(duplicate <= 0)
                {
                    if (dbCount() <= 0)
                    {
                        generateNumber(intData);
                        labelWarning.Visible = true;
                    }
                    else
                    {
                        addFloorNumber(intData);
                        labelWarning.Visible = true;
                    }

                    labelWarning.Text = " Record added Thank you.";

                }

            }
            catch(Exception)
            {
                labelWarning.Text = "Record " + textBoxFloorNumber.Text + " cannot be added \n please input a valid number only";
            }
            
        }// end of the method

        private void deleteAllFloors()
        {
            this.query = "DELETE FROM " + this.tableName;

            this.connect = new MySqlConnection(db.stringConnection());
            using(this.command =  new MySqlCommand(this.query, this.connect))
            {
                try
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                    
                }
                catch (Exception)
                {

                }
                finally
                {
                    this.connect.Close();
                }
            }

        }// end of then method

        


       
    }
}
