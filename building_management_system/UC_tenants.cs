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
    public partial class UC_tenants : UserControl
    {
        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        ClassValidations validate = new ClassValidations();

        private string query;
        private string tableName = "dbt_tenants";
        private int id;


        public UC_tenants()
        {
            InitializeComponent();
            //deleteAll();
            start();
            textBoxCompanyName.Text = null;
            textBoxFloorNumber.Text = null;
            textBoxFloorType.Text = null;

        }

        private void buttonSaveInfo_Click(object sender, EventArgs e)
        {
            save();
            disable();
        }// button save or add record
        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
             viewAllMeterReader();
             enabled();
            labelWarning.Visible = false;
            Clear();
            buttonSaveInfo.Text = "Save";
            buttonBack.Visible = false;
        }// button add record

        public void start()
        {
            ViewAll();
            labelWarning.Visible = false;        
            buttonBack.Visible = false;
            disable();
        }// end of the method

       
        private void viewAllMeterReader()
        {
            this.query = @"SELECT *
                           FROM dbt_submeter";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxMeterReader.DisplayMember = "submeter_type_name";
                    comboBoxMeterReader.ValueMember = "submeterId";
                    comboBoxMeterReader.DataSource = ds.Tables[0];
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

        public void ViewAll()
        {           
            viewAllMeterReader();
            viewAllDataGrid();          
        }// end of the method
        private void viewAllDataGrid()
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
                    dataGridTenants.DataSource = ds.Tables[0];
                    this.designsGrid();// for the designs of the grid
                }
                changeLabelDataGrid();// to change the label of the datagrid
                dataGridTenants.Columns[0].Visible = false;
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

        private void addTenant()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = new string[4] { textBoxCompanyName.Text, textBoxFloorNumber.Text, textBoxFloorType.Text, comboBoxMeterReader.Text };

            for (int i = 0; i < textbox.Length; i++)
            {
                result = validate.validateStringInput(textbox[i], textbox.Length);        
                if(result == true)
                {
                    trueResult++;
                }           
            }// for loop
          
            if (trueResult == textbox.Length)
            {
                this.query = "INSERT INTO " + this.tableName + " (tenantCompanyname, floorNumber, floorTypeCategorytype, floorSubmetertype) VALUES(@data1, @data2, @data3, @data4)";
                try
                {

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@data1", textBoxCompanyName.Text);
                        command.Parameters.AddWithValue("@data2", textBoxFloorNumber.Text);
                        command.Parameters.AddWithValue("@data3", textBoxFloorType.Text);
                        command.Parameters.AddWithValue("@data4", comboBoxMeterReader.Text);

                        this.connect.Open();
                        command.ExecuteNonQuery();
                        labelWarning.Visible = true;
                        labelWarning.Text = " Record succesfully added Thank you.";
                    }

                    
                }
                catch (Exception)
                {
                    // error handling messages here;
                    labelWarning.Text = "internal error - sorry unable to add the record";
                }
                finally
                {
                    this.connect.Close();
                }
                Clear(); // clear the entries
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }

  
        }// end of the method

        private void Clear()
        {
            textBoxCompanyName.Text = null; 
            textBoxFloorNumber.Text = null;
            textBoxFloorType.Text = null;
            comboBoxMeterReader.Text = null;
        }// end of the method

        public void designsGrid()
        {
            dataGridTenants.BorderStyle = BorderStyle.None;
            dataGridTenants.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridTenants.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridTenants.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridTenants.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridTenants.BackgroundColor = Color.White;

            dataGridTenants.EnableHeadersVisualStyles = false;
            dataGridTenants.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridTenants.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridTenants.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method
        private void changeLabelDataGrid()
        {
            string[] sysHeader = new string[5] { "tenantsId", "tenantCompanyname", "floorNumber", "floorTypeCategorytype", "floorSubmetertype" };
            string[] sysHeadernew = new string[5] { "ID", "Company Name", "Floor", "Floor Type", "Meter Reader Type" };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataGridTenants.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
            }
            dataGridTenants.Columns[0].Visible = false;
        }// end of the method

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editRecord();
            enabled();
            buttonBack.Visible = true;
            labelWarning.Visible = false;
        }// button edit

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deleteTenants();
            ViewAll();
        }// button delete

        private void buttonBack_Click(object sender, EventArgs e)
        {
            buttonBack.Visible = false;
            buttonSaveInfo.Text = "Save";
            ViewAll();
            textBoxCompanyName.Text = null;
        }// button back

        private void deleteTenants()
        {
            int rowindex = dataGridTenants.SelectedCells[0].RowIndex;
            string tenantsId = dataGridTenants.Rows[rowindex].Cells[0].Value.ToString();
            string tenants = dataGridTenants.Rows[rowindex].Cells[1].Value.ToString();

            this.query = @"DELETE 
                           FROM " + this.tableName +
                           " WHERE tenantsId = @data";
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());

                using (command = new MySqlCommand(this.query, this.connect))
                {
                    command.Parameters.AddWithValue("@data", int.Parse(tenantsId));
                    //command.Parameters.AddWithValue("@data", textBoxFloorType.Text);
                    this.connect.Open();
                    command.ExecuteNonQuery();
                    labelWarning.Visible = true;
                    labelWarning.Text = "Record " + tenants + " is succesfully deleted.";

                }
            }
            catch (Exception)
            {
                // error handling messages here;
                labelWarning.Text = "Record " + tenants + " cannot be deleted.";

            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method


        private void editRecord()
        {
            int rowindex = dataGridTenants.SelectedCells[0].RowIndex;
            string tenantsid = dataGridTenants.Rows[rowindex].Cells[0].Value.ToString();
            string Company = dataGridTenants.Rows[rowindex].Cells[1].Value.ToString();
            string floorNumber = dataGridTenants.Rows[rowindex].Cells[2].Value.ToString();
            string FloorCategory = dataGridTenants.Rows[rowindex].Cells[3].Value.ToString();
            string MeterReader = dataGridTenants.Rows[rowindex].Cells[4].Value.ToString();

            textBoxCompanyName.Text = Company;
            textBoxFloorNumber.Text = floorNumber;
            textBoxFloorType.Text = FloorCategory;
            comboBoxMeterReader.Text = MeterReader;
            buttonSaveInfo.Text = "Save Edit";
            buttonBack.Visible = true;
            this.id = int.Parse(tenantsid);
        }// end of the method

        private void submitEditQuery()
        {

            bool result;
            int trueResult = 0;
            string[] textbox = new string[4] { textBoxCompanyName.Text, textBoxFloorNumber.Text, textBoxFloorType.Text, comboBoxMeterReader.Text };

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
                    this.query = "UPDATE " + this.tableName +
                                @" SET tenantCompanyname = @data1, floorNumber = @data2, floorTypeCategorytype = @data3, floorSubmeterId = @data4
                                WHERE tenantsId = " + this.id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", textBoxCompanyName.Text);
                        this.command.Parameters.AddWithValue("@data2", textBoxFloorNumber.Text);
                        this.command.Parameters.AddWithValue("@data3", textBoxFloorType.Text);
                        this.command.Parameters.AddWithValue("@data4", comboBoxMeterReader.Text);
                        this.connect.Open();
                        this.command.ExecuteNonQuery();
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

        public void save()
        {
            if (buttonSaveInfo.Text == "Save Edit")
            {
                submitEditQuery();
                buttonSaveInfo.Text = "Save";
            }
            else if (buttonSaveInfo.Text == "Save")
            {
                addTenant();
                //buttonSaveInfo.Text = "Save Edit";
            }
            ViewAll();
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


        private void disable()
        {
            textBoxCompanyName.Enabled = false;
            textBoxFloorNumber.Enabled = false;
            textBoxFloorType.Enabled = false;
            comboBoxMeterReader.Enabled = false;
            buttonSaveInfo.Enabled = false;

        }// end of the method

        private void enabled()
        {
            viewAllMeterReader();
            textBoxCompanyName.Enabled = true;
            textBoxFloorNumber.Enabled = true;
            textBoxFloorType.Enabled = true;
            comboBoxMeterReader.Enabled = true;
            buttonSaveInfo.Enabled = true;
                        
            label3.ForeColor = Color.CornflowerBlue;
            label5.ForeColor = Color.CornflowerBlue;
            label4.ForeColor = Color.CornflowerBlue;
            label2.ForeColor = Color.CornflowerBlue;

        }// end of the method

        private void UC_tenants_Load(object sender, EventArgs e)
        {

        }
    }// end of the class
}

