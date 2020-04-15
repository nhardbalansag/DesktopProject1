using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace building_management_system
{
    public partial class UC_reading : UserControl
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;


        ClassValidations validate = new ClassValidations();


        private string query;
        private string tableName = "dbt_utilities_reading";
     
        private int u_personnelID;
        private int u_utilitiesId;     
        private int u_prevRead;    
        private int u_tenantsId;
        private string u_notes;
        private int id;
        private int u_total;
        private int u_currentSelected, u_currentPrevious, u_currentNext;
        private string utility;
        private int utilityNumber = 0;
        private string error;

        public UC_reading()
        {
            InitializeComponent();
            //deleteAll();
            start();
           
        }

        private void UC_reading_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();           
        }// button save
        private void buttonClose_Click(object sender, EventArgs e)
        {
            panelViewOneRead.Visible = false;
            dataGridReadingContent.Visible = true;
            buutonCloseGrid.Visible = true;
            buttonSave.Text = "Save";
        }

        private void dataGridReadingContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonEditPersonnel_Click(object sender, EventArgs e)
        {
            displayWhatToEdit();          
            panelMainGrid.Visible = false;
            buttonSave.Text = "Save Edit";
            labelWarning.Visible = false;
        }//button edit

        private void comboBoxPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchPicture();          
        }

        private void buttonViewGrid_Click(object sender, EventArgs e)
        {
            comboBoxUtilityReadingSearch();
            panelMainGrid.Visible = true;
            viewAlldataGridReadingContent();

        }// view all teh main reading

        private void buutonCloseGrid_Click(object sender, EventArgs e)
        {
            panelMainGrid.Visible = false;
            labelWarning.Visible = false;
        }// button close the main grid reading

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewAlldataGridReadingContent();          
        }// search 

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void comboBoxUtilityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.utility = comboBoxUtilityType.Text.ToLower();

            if(this.utility == "electricity")
            {
                this.utilityNumber = 2;

                if (dbCountElectricity() <= 0)
                {
                    textBoxPrevReading.Text = "0";                  
                }
                else if (dbCountElectricity() > 0)
                {
                    textBoxPrevReading.Text = null;
                    previousElectric();                 
                    allqueryGrid();
                }
            }else if(this.utility == "water")
            {
                this.utilityNumber = 1;

                if (dbCountWater() <= 0)
                {
                    textBoxPrevReading.Text = "0";                   
                }
                else if (dbCountWater() > 0)
                {
                    textBoxPrevReading.Text = null;
                    previous();             
                    allqueryGrid();
                }
            }

        }//utilities 

        private void labelMiddleName_Click(object sender, EventArgs e)
        {

        }

        private void labelPosition_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearchPersonnel_Click(object sender, EventArgs e)
        {
            panelViewOneRead.Visible = true;
            dataGridReadingContent.Visible = false;
            Viewtenants();
            ViewOnePersonelName();
            ViewOneUtility();
            ViewReadingPrevCurrTotalDetails();
            buutonCloseGrid.Visible = false;
        }// button search

        /// <summary>
        /// for adding mapping
        /// </summary>
        private void add()
        {
            int prev = 0;
            int current = 0;

            try
            {
                prev = int.Parse(textBoxPrevReading.Text);
                current = int.Parse(textBoxCurrentReading.Text);
            }
            catch (Exception)
            {
                textBoxCurrentReading.Text = "";               
            }

            bool result;
            int trueResult = 0;
            string[] textbox = { comboBoxPersonnel.Text, comboBoxUtilityType.Text, comboBoxTenant.Text, textBoxCurrentReading.Text,
                                textBoxPrevReading.Text};

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
                

                int total_d = 0;

                this.u_total = current - prev;

                this.query = @"INSERT 
                           INTO " + this.tableName +
                               @" (personnelId, utilitiesTypeId, utilityReadingDate, tenantsId, readingNotes, utilityCurrentReading, utilityPrevReading, utilityTotalReading)     
                               VALUE( @data1, @data2,  @data3, @data4,  @data5, @data6,  @data7, @data8)";

                try
                {
                    

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", comboBoxPersonnel.SelectedValue);
                        this.command.Parameters.AddWithValue("@data2", comboBoxUtilityType.SelectedValue);
                        this.command.Parameters.AddWithValue("@data3", dateTimePickerReadingDate.Value.ToString("yyy-MM-dd")); // for now eto muna dapat current date n to di na user input                                     
                        this.command.Parameters.AddWithValue("@data4", comboBoxTenant.SelectedValue);
                        this.command.Parameters.AddWithValue("@data5", textBoxReadingNotes.Text);
                        this.command.Parameters.AddWithValue("@data6", textBoxCurrentReading.Text);
                        this.command.Parameters.AddWithValue("@data7", textBoxPrevReading.Text);
                        this.command.Parameters.AddWithValue("@data8", total_d); // process

                        this.connect.Open();
                        this.command.ExecuteNonQuery();

                    }
                    labelWarning.Text = " Record added Thank you.";
                    clearAll();
                }
                catch (Exception)
                {
                    // error handling messages here;
                    labelWarning.Text = "Record cannot be added please input a valid data.";
                }
                finally
                {
                    this.connect.Close();
                }

                this.error = "succcess";
            }
            else
            {
                this.error = "error";
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }

        }// end of the method

        private int dbCountWater()
        {
            this.query = @"SELECT COUNT(utilitiesReadingId) as num_count
                           FROM " + this.tableName + " WHERE utilitiesTypeId = 1";
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

        private int dbCountElectricity()
        {
            this.query = @"SELECT COUNT(utilitiesReadingId) as num_count
                           FROM " + this.tableName + " WHERE utilitiesTypeId = 2";
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

        private int prevValueIDElectric()
        {
            int id = 0;

            this.query = @"SELECT 
                            MAX(utilitiesReadingId) AS max_id
                          FROM " + this.tableName + " WHERE utilitiesTypeId = 2";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        id = int.Parse(this.mdr.GetString("max_id"));
                    }
                }
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
            return id;
        }// end of the method     opyion

        private void previousElectric()
        {
            this.query = @" SELECT 
                                utilityCurrentReading
                            FROM
                                dbt_utilities_reading
                            WHERE
                                utilitiesReadingId = " + prevValueIDElectric() + " AND  utilitiesTypeId = 2";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        textBoxPrevReading.Text = this.mdr.GetString("utilityCurrentReading");
                    }
                }
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
        }// end of the method       option

        private void utiltyType()
        {

            this.query = @"SELECT dbt_utilities_type.utilitesTypeName
                           FROM dbt_utilities_type, dbt_utilities_reading
                           WHERE (dbt_utilities_type.utilitesTypeId = dbt_utilities_reading.utilitiesTypeId)
                           ORDER BY dbt_utilities_reading.utilitiesReadingId DESC";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());

                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    this.connect.Open();
                    adapter.Fill(ds);
                    dataGridViewUtilityType.DataSource = ds.Tables[0];
                    this.designsGridUtility();// for the designs of the grid
                }

                dataGridViewUtilityType.Columns["utilitesTypeName"].HeaderText = "UTILITY TYPE";
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

        private void total()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { this.u_total.ToString()};

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
                                  @" SET                                                                                          
                               utilityTotalReading = @data6                                                      
                               WHERE utilitiesReadingId = " + this.id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        command.Parameters.AddWithValue("@data6", this.u_total);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();

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
                    
        }// end of the method

        private bool minimumId(int id)
        {
            bool hasMinimum = false;
            int mimum_val;

            this.query = "SELECT MIN(utilitiesReadingId) AS mininimum_id FROM dbt_utilities_reading WHERE utilitiesTypeId = " + this.utilityNumber;

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        mimum_val = int.Parse(this.mdr.GetString("mininimum_id"));
                        if (mimum_val == id)
                        {
                            hasMinimum = true;
                        }
                        else
                        {
                            hasMinimum = false;
                        }
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

            return hasMinimum;
        }// end of the method  else if

        private void viewAll()
        {


            this.query = @"SELECT utilityReadingDate, utilityTotalReading
                           FROM " + this.tableName + " ORDER BY utilitiesReadingId DESC";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataAllEntry.DataSource = ds.Tables[0];
                    this.designsGrid();// for the designs of the grid
                }
                changeLabelDataGrid();
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

        private void previous()
        {

            this.query = @" SELECT 
                                utilityCurrentReading
                            FROM
                                dbt_utilities_reading
                            WHERE
                                utilitiesReadingId = " + prevValueIDwater() + " AND  utilitiesTypeId = 1";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        textBoxPrevReading.Text = this.mdr.GetString("utilityCurrentReading");
                    }
                }
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
        /// <summary>
        /// for adding mapping
        /// </summary>




        /// <summary>
        /// for editing mapping minimum 
        /// </summary>
        private void displayWhatToEdit()
        {                     
            try
            {
                int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
                string Id = dataGridReadingContent.Rows[rowindex].Cells[0].Value.ToString();

                this.query = @"SELECT *
                           FROM dbt_utilities_reading 
                           WHERE utilitiesReadingId = " + Id;

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        pictureBoxPersonnel.Image = pictureBoxviewReadingPerson.Image;
                        comboBoxUtilityType.SelectedValue = this.mdr.GetString("utilitiesTypeId");
                        comboBoxPersonnel.SelectedValue = this.mdr.GetString("personnelId");
                        comboBoxTenant.SelectedValue = this.mdr.GetString("tenantsId");
                        dateTimePickerReadingDate.Text = this.mdr.GetString("utilityReadingDate");
                        textBoxCurrentReading.Text = this.mdr.GetString("utilityCurrentReading");
                        textBoxPrevReading.Text = this.mdr.GetString("utilityPrevReading");
                        textBoxReadingNotes.Text = this.mdr.GetString("readingNotes");


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

        public void save()
        {
            if (buttonSave.Text == "Save Edit")
            {
                implementEditing();
                previous();
                buttonSave.Text = "Save";
            }
            else if (buttonSave.Text == "Save")
            {

                if (comboBoxUtilityType.Text.ToLower() == "water")
                {
                    int countWater = dbCountWater();

                    if (countWater <= 0)
                    {
                        textBoxPrevReading.Text = "0";
                        this.u_total = 0;
                        add();
                        previous();                      
                    }
                    else if (countWater > 0)
                    {
                        add();                                                                                       
                        if (this.error != "error")
                        {
                            previous();
                            queryForAdding();
                            string Id = dataGridALLQuery.Rows[dbCountWater() - 2].Cells[0].Value.ToString();
                            this.id = int.Parse(Id);
                            total();
                        }
                        else if(this.error == "error")
                        {
                            clearAll();
                        }
                    }
                }
                else if (comboBoxUtilityType.Text.ToLower() == "electricity")
                {
                    int countElectric = dbCountElectricity();

                    if (countElectric <= 0)
                    {
                        textBoxPrevReading.Text = "0";
                        this.u_total = 0;
                        add();
                        previousElectric();                       
                    }
                    else if (countElectric > 0)
                    {
                        add();                        
                        if (this.error != "error")
                        {
                            previousElectric();
                            queryForAdding();
                            string Id = dataGridALLQuery.Rows[dbCountElectricity() - 2].Cells[0].Value.ToString();
                            this.id = int.Parse(Id);
                            total();
                        }
                        else if(this.error == "error")
                        {
                            clearAll();
                        }

                    }
                }
            }
            
            utiltyType();
            viewAll();           
            
        }// end of the method

        private void queryForAdding()
        {
            this.query = @" SELECT 
                                utilitiesReadingId                                                           
                            FROM
                                dbt_utilities_reading 
                             WHERE utilitiesTypeId = " + this.utilityNumber + " ORDER BY(utilitiesReadingId)";
            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridALLQuery.DataSource = ds.Tables[0];
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void implementEditing()
        {         
            string Id;
            allqueryGrid();

            if (minimumId(selectingID()) == true) // if the record is minimum or the lowest
            {
                if(utilityID() == 1) // if utility is water
                {
                    if (dbCountWater() > 1)
                    {
                        allqueryGrid();
                        Id = dataGridALLQuery.Rows[1].Cells[0].Value.ToString();
                        this.id = int.Parse(Id); // get the primary key of the next record and store to global variable this.id


                        saveEditQueryMin();
                        if(this.error != "error")
                        {
                            processMinTotal(); // to get the differerence of current and previous of the record to be stored in the total

                            Id = dataGridALLQuery.Rows[0].Cells[0].Value.ToString();
                            this.id = int.Parse(Id);// get the primary key of the what you are editing

                            saveEditTotalQueryMin(); // to store the total and the current edited record
                        }
                        else if(this.error == "error")
                        {
                            clearAll();
                        }
                        
                    }
                    else if (dbCountWater() == 1)
                    {
                        allqueryGrid();
                        Id = dataGridALLQuery.Rows[0].Cells[0].Value.ToString();
                        this.id = int.Parse(Id); // get the primary key of the next record and store to global variable this.id
                        saveEditQueryMinOne();
                    }
                }
                else if(utilityID() == 2) // if utility is electric
                {
                    if (dbCountElectricity() > 1)
                    {
                        allqueryGrid();
                        Id = dataGridALLQuery.Rows[1].Cells[0].Value.ToString();
                        this.id = int.Parse(Id); // get the primary key of the next record and store to global variable this.id


                        saveEditQueryMin();
                        if(this.error != "error")
                        {
                            labelWarning.Visible = false;
                            processMinTotal(); // to get the differerence of current and previous of the record to be stored in the total

                            Id = dataGridALLQuery.Rows[0].Cells[0].Value.ToString();
                            this.id = int.Parse(Id);// get the primary key of the what you are editing

                            saveEditTotalQueryMin(); // to store the total and the current edited record
                        }
                        else if(this.error == "error")
                        {
                            clearAll();
                        }
                        
                    }
                    else if (dbCountElectricity() == 1)
                    {
                        allqueryGrid();
                        Id = dataGridALLQuery.Rows[0].Cells[0].Value.ToString();
                        this.id = int.Parse(Id); // get the primary key of the next record and store to global variable this.id
                        saveEditQueryMinOne();
                    }
                }
              
            }// end of if minimum is true
            else if (maximumId(selectingID()) == true)
            {
                saveEditQuery();
                if(this.error != "error")
                {
                    labelWarning.Visible = false;

                    if (this.utility == "water" && this.utilityNumber == 1)
                    {
                        int watergridNumber = (dbCountWater() - 2);
                        Id = dataGridALLQuery.Rows[watergridNumber].Cells[0].Value.ToString();
                        this.id = int.Parse(Id);

                    }
                    else if (this.utility == "electricity" && this.utilityNumber == 2)
                    {
                        int electricgridNumber = (dbCountElectricity() - 2);
                        Id = dataGridALLQuery.Rows[electricgridNumber].Cells[0].Value.ToString();
                        this.id = int.Parse(Id);
                    }
                    saveEditTotalQueryMax();
                }else if(this.error == "error")
                {
                    clearAll();
                }
                
            }
            else
            {
                selectEDitREcord_step_2();
                selectEDitREcord_step_1Update();
                if (this.error != "error")
                {
                    labelWarning.Visible = false;
                    selectEDitREcord_step_3();
                    selectEDitREcord_step_4();
                    selectEDitREcord_step_5();
                    selectEDitREcord_step_6();
                }else if(this.error == "error")
                {
                    clearAll();
                }
                
            }

        }// end of the method  else

        private void allqueryGrid()
        {

            this.query = @" SELECT 
                                utilitiesReadingId                                                           
                            FROM
                                dbt_utilities_reading 
                             WHERE utilitiesTypeId = " + utilityID() + " ORDER BY(utilitiesReadingId)";
            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridALLQuery.DataSource = ds.Tables[0];
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        private void saveEditQueryMin()
        {

            int prev = 0;
            int current = 0;

            try
            {
                prev = int.Parse(textBoxPrevReading.Text);
                current = int.Parse(textBoxCurrentReading.Text);
            }
            catch (Exception)
            {
                textBoxCurrentReading.Text = null;
            }

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxCurrentReading.Text, comboBoxPersonnel.Text, comboBoxUtilityType.Text, comboBoxTenant.Text,
                                textBoxPrevReading.Text};

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
                                @" SET                              
                                utilityPrevReading = @data1,
                                personnelId = @data2,
                                utilitiesTypeId = @data3,
                                utilityReadingDate = @data4,
                                tenantsId = @data5,
                                readingNotes = @data6                                     
                               WHERE utilitiesReadingId = " + this.id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", textBoxCurrentReading.Text);
                        this.command.Parameters.AddWithValue("@data2", comboBoxPersonnel.SelectedValue);
                        this.command.Parameters.AddWithValue("@data3", comboBoxUtilityType.SelectedValue);
                        this.command.Parameters.AddWithValue("@data4", dateTimePickerReadingDate.Value.ToString("yyy-MM-dd"));
                        this.command.Parameters.AddWithValue("@data5", comboBoxTenant.SelectedValue);
                        this.command.Parameters.AddWithValue("@data6", textBoxReadingNotes.Text);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();
                        //this.connect.BeginTransaction();

                        
                        
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

                this.error = "success";
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
                this.error = "error";      
            }
           
        }// end of the method this is for max id only

        private void saveEditQueryMinOne()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxCurrentReading.Text, comboBoxPersonnel.Text, comboBoxUtilityType.Text, comboBoxTenant.Text,
                                textBoxPrevReading.Text};

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
                                @" SET                              
                                utilityCurrentReading = @data1,
                                personnelId = @data2,
                                utilitiesTypeId = @data3,
                                utilityReadingDate = @data4,
                                tenantsId = @data5,
                                readingNotes = @data6                                     
                               WHERE utilitiesReadingId = " + this.id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", textBoxCurrentReading.Text);
                        this.command.Parameters.AddWithValue("@data2", comboBoxPersonnel.SelectedValue);
                        this.command.Parameters.AddWithValue("@data3", comboBoxUtilityType.SelectedValue);
                        this.command.Parameters.AddWithValue("@data4", dateTimePickerReadingDate.Value.ToString("yyy-MM-dd"));
                        this.command.Parameters.AddWithValue("@data5", comboBoxTenant.SelectedValue);
                        this.command.Parameters.AddWithValue("@data6", textBoxReadingNotes.Text);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();

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
           
        }// end of the method this is for max id only

        private void processMinTotal()
        {

            this.query = @"SELECT utilityCurrentReading, utilityPrevReading
                           FROM dbt_utilities_reading 
                           WHERE utilitiesReadingId = " + this.id;
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        this.u_currentNext = int.Parse(this.mdr.GetString("utilityCurrentReading"));
                        this.u_currentPrevious = int.Parse(this.mdr.GetString("utilityPrevReading"));
                        this.u_total = this.u_currentNext - this.u_currentPrevious;
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

        private void saveEditTotalQueryMin()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxCurrentReading.Text, this.u_total.ToString() };

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
                                @" SET 
                                utilityTotalReading = @data1,
                                utilityCurrentReading = @data2                                       
                               WHERE utilitiesReadingId = " + this.id;


                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {

                        this.command.Parameters.AddWithValue("@data1", this.u_total);
                        this.command.Parameters.AddWithValue("@data2", int.Parse(textBoxCurrentReading.Text));

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
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }
      
        }// end of the method this is for max id only

        private int utilityID()
        {

            int utilityNumberId = 0;

            try
            {
                this.query = "SELECT utilitiesTypeId FROM dbt_utilities_reading WHERE utilitiesReadingId = " + selectingID();

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        utilityNumberId = int.Parse(this.mdr.GetString("utilitiesTypeId"));
                    }
                }
            }
            catch (Exception)
            {
                //handle errors here
            }
            finally
            {
                this.connect.Close();
            }

            return utilityNumberId;
        }// to get the utility type id

        private int selectingID()
        {
            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex].Cells[0].Value.ToString();

            return int.Parse(Id);
        }// end of the method
        /// <summary>
        /// end of minimum process editing
        /// </summary>
  
        

        private void comboBoxTenantsDropDown()
        {
            this.query = @"SELECT *
                           FROM dbt_tenants";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxTenant.DisplayMember = "tenantCompanyname";
                    comboBoxTenant.ValueMember = "tenantsId";
                    comboBoxTenant.DataSource = ds.Tables[0];                  
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

        private void comboBoxPersonnelDropDown()
        {
            this.query = @"SELECT *
                           FROM dbt_utilities_assigned_personnel";

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

        private void comboBoxUtilityTypeDropDown()
        {
            this.query = @"SELECT *
                           FROM dbt_utilities_type";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxUtilityType.DisplayMember = "utilitesTypeName";
                    comboBoxUtilityType.ValueMember = "utilitesTypeId";
                    comboBoxUtilityType.DataSource = ds.Tables[0];
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

        private void start()
        {
            labelWarning.Visible = false;
            tempCurrent.Visible = false;
            temprevious.Visible = false;
            tempTotal.Visible = false;
            dataGridALLQuery.Visible = false;
            comboBoxTenantsDropDown();
            comboBoxPersonnelDropDown();
            comboBoxUtilityTypeDropDown();
            viewAlldataGridReadingContent();
            viewAll();
            panelViewOneRead.Visible = false;
            panelMainGrid.Visible = false;
            utiltyType();
   
        }// end of the method

        public void designsGrid()
        {
            dataAllEntry.BorderStyle = BorderStyle.None;
            dataAllEntry.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataAllEntry.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataAllEntry.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataAllEntry.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataAllEntry.BackgroundColor = Color.White;

            dataAllEntry.EnableHeadersVisualStyles = false;
            dataAllEntry.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataAllEntry.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataAllEntry.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method
                                                                                                                            
        public void designsGridUtility()
        {
            dataGridViewUtilityType.BorderStyle = BorderStyle.None;
            dataGridViewUtilityType.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewUtilityType.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewUtilityType.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewUtilityType.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewUtilityType.BackgroundColor = Color.White;

            dataGridViewUtilityType.EnableHeadersVisualStyles = false;
            dataGridViewUtilityType.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewUtilityType.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewUtilityType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method

        private void changeLabelDataGrid()
        {
            string[] sysHeader = new string[2] { "utilityReadingDate", "utilityTotalReading" };
            string[] sysHeadernew = new string[2] { "date", "total" };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataAllEntry.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
            }
         
            //dataAllEntry.Columns[0].Visible = false;

        }// end of the method

        private void clearAll()
        {
            pictureBoxPersonnel.Image = null;
            comboBoxTenant.Text = null;
            comboBoxPersonnel.Text = null;
            comboBoxUtilityType.Text = null;
            dateTimePickerReadingDate.Text = null;
            textBoxCurrentReading.Text = null;
            textBoxPrevReading.Text = null;
            textBoxReadingNotes.Text = null;

        }// end of the method

        private void searchPicture()
        {
            this.query = @"SELECT personnelPhoto
                           FROM dbt_utilities_assigned_personnel WHERE personnelId = " + comboBoxPersonnel.SelectedValue;

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

                    pictureBoxPersonnel.Image = Image.FromStream(ms);

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

        private int prevValueIDwater()
        {
            int id = 0;

            this.query = @"SELECT 
                            MAX(utilitiesReadingId) AS max_id
                          FROM " + this.tableName + " WHERE utilitiesTypeId = 1";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        id = int.Parse(this.mdr.GetString("max_id"));
                    }
                }
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
            return id;
        }// end of the method     opyion

        private int prevMinID()
        {
            int id = 0;

            this.query = @"SELECT 
                            MIN(utilitiesReadingId) AS min_id
                          FROM " + this.tableName + " WHERE utilitiesTypeId = " + this.utilityNumber;

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        id = int.Parse(this.mdr.GetString("min_id"));
                    }
                }
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
            return id;
        }// end of the method     opyion

        private void deleteAll()
        {
            this.query = "DELETE FROM " + this.tableName;

            this.connect = new MySqlConnection(db.stringConnection());
            using (this.command = new MySqlCommand(this.query, this.connect))
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

        private int dbCount()
        {
            this.query = @"SELECT COUNT(utilitiesReadingId) as num_count
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

        public void dataGridReadingContentDesign()
        {
            dataGridReadingContent.BorderStyle = BorderStyle.None;
            dataGridReadingContent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridReadingContent.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridReadingContent.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridReadingContent.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridReadingContent.BackgroundColor = Color.White;

            dataGridReadingContent.EnableHeadersVisualStyles = false;
            dataGridReadingContent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridReadingContent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridReadingContent.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method

        private void dataGridReadingContentLabel()
        {
            string[] sysHeader = new string[9] { "utilitiesReadingId", "utilityPrevReading", "tenantsId", "readingNotes", "personnelId", "utilitiesTypeId", "utilityReadingDate", "utilityCurrentReading", "utilityTotalReading" };
            string[] sysHeadernew = new string[9] { "ID", "previous reading", "tenants id", "notes", "personnel","utility", "date", "Current Reading", "total" };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataGridReadingContent.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
            }

            dataGridReadingContent.Columns[0].Visible = false;
            dataGridReadingContent.Columns[1].Visible = false;
            dataGridReadingContent.Columns[2].Visible = false;
            dataGridReadingContent.Columns[3].Visible = false;
            dataGridReadingContent.Columns[4].Visible = false;
            dataGridReadingContent.Columns[5].Visible = false;

        }// end of the method
        private void comboBoxUtilityReadingSearch()
        {
            this.query = @"SELECT *
                           FROM dbt_utilities_type";

            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (adapter = new MySqlDataAdapter(this.query, this.connect))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    comboBoxSearchUtility.DisplayMember = "utilitesTypeName";
                    comboBoxSearchUtility.ValueMember = "utilitesTypeId";
                    comboBoxSearchUtility.DataSource = ds.Tables[0];
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

        private void viewAlldataGridReadingContent()
        {
            this.query = @" SELECT 
                                utilitiesReadingId,
                                utilityPrevReading,
                                tenantsId,
                                readingNotes,
                                personnelId,
                                utilitiesTypeId,
                                utilityReadingDate,
                                utilityCurrentReading,
                                utilityTotalReading                              
                            FROM
                                dbt_utilities_reading                           
                            WHERE
                                 utilitiesTypeId = " + comboBoxSearchUtility.SelectedValue + " ORDER BY (utilityReadingDate)";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridReadingContent.DataSource = ds.Tables[0];
                    dataGridReadingContentDesign();// design the grid
                }
                dataGridReadingContentLabel();
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
       
        private void getLowerThanMaxID()
        {
            
            try
            {
                this.query = "SELECT MAX(utilitiesReadingId - 1) as id FROM dbt_utilities_reading WHERE utilitiesTypeId = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using(this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();

                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        this.id = int.Parse(this.mdr.GetString("id"));

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
                      
        }// end of the method

        private void getPreviousRead()
        {
            try
            {
                this.query = @"SELECT                              
                                utilityCurrentReading                              
                            FROM dbt_utilities_reading
                            WHERE utilitiesReadingId = " + this.id;

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();

                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {                    
                        textBoxCurrentReading.Text = this.mdr.GetString("utilityCurrentReading"); /// this will be the prevous
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
           
        }// end of the method

        
 
        private void ViewReadingPrevCurrTotalDetails()
        {
            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex].Cells[0].Value.ToString();

            this.query = @"SELECT *
                           FROM dbt_utilities_reading 
                           WHERE utilitiesReadingId = " + Id;
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {

                        labeldate.Text = this.mdr.GetString("utilityReadingDate");
                        labelcurrentreading.Text = this.mdr.GetString("utilityCurrentReading");
                        labelprevreading.Text = this.mdr.GetString("utilityPrevReading");
                        labeltotalreading.Text = this.mdr.GetString("utilityTotalReading");
                        labelnotes.Text = this.mdr.GetString("readingNotes");

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

        private void Viewtenants()
        {
            
            try
            {
                int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
                string Id = dataGridReadingContent.Rows[rowindex].Cells[2].Value.ToString();

                this.query = @"SELECT tenantCompanyname
                           FROM dbt_tenants 
                           WHERE tenantsId = " + Id;

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {

                        labeltenants.Text = this.mdr.GetString("tenantCompanyname");

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

        private void ViewOnePersonelName()
        {
            
            try
            {
                int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
                string Id = dataGridReadingContent.Rows[rowindex].Cells[4].Value.ToString();

                searchPictureGrid(Id);

                this.query = @"SELECT *
                           FROM dbt_utilities_assigned_personnel 
                           WHERE personnelId = " + Id;

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                        string fname, lname, mname;

                        fname = this.mdr.GetString("personnelFirstName");
                        lname = this.mdr.GetString("personnelLastName");
                        mname = this.mdr.GetString("personnelMiddleName");

                        labelpersonnelname.Text = lname + ", " + fname + " " + mname;
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

        private void ViewOneUtility()
        {
            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex].Cells[5].Value.ToString();
              
            this.query = @"SELECT utilitesTypeName
                           FROM dbt_utilities_type 
                           WHERE utilitesTypeId = " + Id;
            try
            {

                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.mdr = this.command.ExecuteReader();

                    if (this.mdr.Read())
                    {
                       
                        labelutilitiestype.Text = this.mdr.GetString("utilitesTypeName");
                        
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
                           FROM dbt_utilities_assigned_personnel 
                            WHERE personnelId = " + id;

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

                    pictureBoxviewReadingPerson.Image = Image.FromStream(ms);

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

        private void saveEditQuery()
        {

            int prev = 0;
            int current = 0;

            try
            {
                prev = int.Parse(textBoxPrevReading.Text);
                current = int.Parse(textBoxCurrentReading.Text);
            }
            catch (Exception)
            {
                textBoxCurrentReading.Text = null;
            }

            bool result;
            int trueResult = 0;
            string[] textbox = { textBoxCurrentReading.Text, comboBoxPersonnel.Text, comboBoxUtilityType.Text, comboBoxTenant.Text,
                                textBoxPrevReading.Text};

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
                    int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
                    string Id = dataGridReadingContent.Rows[rowindex].Cells[0].Value.ToString();


                    this.query = "UPDATE " + this.tableName +
                                @" SET 
                                personnelId = @data1,
                                utilitiesTypeId = @data2,
                                utilityReadingDate = @data3,
                                utilityCurrentReading = @data4, 
                                utilityPrevReading = @data5, 
                               
                                tenantsId = @data7, 
                                readingNotes = @data8                            
                               WHERE utilitiesReadingId = " + Id;


                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", comboBoxPersonnel.SelectedValue);
                        this.command.Parameters.AddWithValue("@data2", comboBoxUtilityType.SelectedValue);
                        this.command.Parameters.AddWithValue("@data3", dateTimePickerReadingDate.Value.ToString("yyy-MM-dd")); // for now eto muna dapat current date n to di na user input
                        this.command.Parameters.AddWithValue("@data4", int.Parse(textBoxCurrentReading.Text));
                        this.command.Parameters.AddWithValue("@data5", int.Parse(textBoxPrevReading.Text));
                        //this.command.Parameters.AddWithValue("@data6", total); // process
                        this.command.Parameters.AddWithValue("@data7", comboBoxTenant.SelectedValue);
                        this.command.Parameters.AddWithValue("@data8", textBoxReadingNotes.Text);

                        prev = int.Parse(textBoxPrevReading.Text);
                        current = int.Parse(textBoxCurrentReading.Text);

                        this.u_total = current - prev;


                        //command.Parameters.AddWithValue("@data6", total);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();

                        labelWarning.Visible = true;
                        this.u_prevRead = 0;
                        //labelWarning.Text = " Record Edited successfully Thank you.";
                        //ClearAllTextBox();
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

                this.error = "success";
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
                this.error = "error";
            }
                      
        }// end of the method

        private void saveEditTotalQueryMax()
        {
            bool result;
            int trueResult = 0;
            string[] textbox = { this.u_total.ToString()};

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
                                @" SET 
                                utilityTotalReading = @data1                                                     
                               WHERE utilitiesReadingId = " + this.id;


                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", this.u_total);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();

                        labelWarning.Visible = true;

                        //labelWarning.Text = " Record Edited successfully Thank you.";
                        //ClearAllTextBox();

                    }
                    this.u_total = 0;
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
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
            }
       
        }// end of the method this is for max id only
           
       /// <summary>
                    /// this must execute if there is a record  
        private void selectEDitREcord_step_1()
        {
            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex].Cells[0].Value.ToString();
          
                this.query = @"SELECT *
                           FROM dbt_utilities_reading 
                           WHERE utilitiesReadingId = " + Id;
                try
                {

                    this.connect = new MySqlConnection(db.stringConnection());
                    this.connect.Open();
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.mdr = this.command.ExecuteReader();

                        if (this.mdr.Read())
                        {
                            pictureBoxPersonnel.Image = pictureBoxviewReadingPerson.Image;
                            comboBoxUtilityType.SelectedValue = this.mdr.GetString("utilitiesTypeId");
                            comboBoxPersonnel.SelectedValue = this.mdr.GetString("personnelId");
                            comboBoxTenant.SelectedValue = this.mdr.GetString("tenantsId");
                            dateTimePickerReadingDate.Text = this.mdr.GetString("utilityReadingDate");
                            textBoxCurrentReading.Text = this.mdr.GetString("utilityCurrentReading"); // pinaka babaguhin
                            textBoxPrevReading.Text = this.mdr.GetString("utilityPrevReading");
                            textBoxReadingNotes.Text = this.mdr.GetString("readingNotes");

                           
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
         
        } // done first step

        private void selectEDitREcord_step_1Update()
        {
            //tempCurrent.Text = textBoxCurrentReading.Text;

            int prev = 0;
            int current = 0;

            try
            {
                prev = int.Parse(textBoxPrevReading.Text);
                current = int.Parse(textBoxCurrentReading.Text);

                tempCurrent.Text = current.ToString();
            }
            catch (Exception)
            {
                tempCurrent.Text = null;
            }

            bool result;
            int trueResult = 0;
            string[] textbox = { tempCurrent.Text, temprevious.Text, comboBoxPersonnel.Text, comboBoxUtilityType.Text, comboBoxTenant.Text };

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
                    int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
                    string Id = dataGridReadingContent.Rows[rowindex].Cells[0].Value.ToString();
 
                    this.query = "UPDATE " + this.tableName +
                                    @" SET 
                                utilityCurrentReading = @data1,
                                utilityPrevReading = @data2,
                                personnelId = @data3,
                                utilitiesTypeId = @data4,
                                utilityReadingDate = @data5,
                                tenantsId = @data6,
                                readingNotes = @data7               
                               WHERE utilitiesReadingId = " + Id;

                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {

                        this.command.Parameters.AddWithValue("@data1", tempCurrent.Text);
                        this.command.Parameters.AddWithValue("@data2", temprevious.Text);
                        this.command.Parameters.AddWithValue("@data3", comboBoxPersonnel.SelectedValue);
                        this.command.Parameters.AddWithValue("@data4", comboBoxUtilityType.SelectedValue);
                        this.command.Parameters.AddWithValue("@data5", dateTimePickerReadingDate.Value.ToString("yyy-MM-dd"));
                        this.command.Parameters.AddWithValue("@data6", comboBoxTenant.SelectedValue);
                        this.command.Parameters.AddWithValue("@data7", textBoxReadingNotes.Text);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();

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

                this.error = "success";
            }
            else
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Input must not be null and must not contain \n (/ | \\ * & # @ = + ! ^ $ ? : ;)";
                this.error = "error";
            }      
           
        }// end of the method this is not for max id

        private void selectEDitREcord_step_2()
        {

            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex - 1].Cells[0].Value.ToString();

            this.query = @"SELECT utilityCurrentReading
                           FROM dbt_utilities_reading 
                           WHERE utilitiesReadingId = " + Id;

            try
                {

                    this.connect = new MySqlConnection(db.stringConnection());
                   
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.connect.Open();
                        this.mdr = this.command.ExecuteReader();

                        if (this.mdr.Read())
                        {
                            temprevious.Text = this.mdr.GetString("utilityCurrentReading"); // pinaka babaguhin                       
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
          
        } // done first step

        private void selectEDitREcord_step_3()
        {

            try
            {
                int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
                string Id = dataGridReadingContent.Rows[rowindex - 1].Cells[0].Value.ToString();

                this.query = "UPDATE " + this.tableName +
                                @" SET 
                                utilityTotalReading = @data1,
                                utilityCurrentReading = @data2                                                 
                               WHERE utilitiesReadingId = " + Id;

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {

                    int tot = int.Parse(tempCurrent.Text) - int.Parse(temprevious.Text);
                    tempTotal.Text = tot.ToString();

                    this.command.Parameters.AddWithValue("@data1", tempTotal.Text);
                    this.command.Parameters.AddWithValue("@data2", temprevious.Text);
                    this.connect.Open();
                    this.command.ExecuteNonQuery();

                    labelWarning.Visible = true;

                    labelWarning.Text = " Record Edited successfully Thank you.";
                    //ClearAllTextBox();

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

        }// end of the method this is not for max id

        private void selectEDitREcord_step_4()
        {
            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex + 1].Cells[0].Value.ToString();

            
                this.query = "UPDATE " + this.tableName +
                            @" SET 
                                utilityPrevReading = @data1                                                     
                               WHERE utilitiesReadingId = " + Id;
                try
                {

                    this.connect = new MySqlConnection(db.stringConnection());
                    this.connect.Open();
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", tempCurrent.Text);
                        this.command.ExecuteNonQuery();
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
           
        } // done first step

        private void selectEDitREcord_step_5()
        {
            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex + 1].Cells[0].Value.ToString();

           
                this.query = @"SELECT utilityCurrentReading, utilityPrevReading
                           FROM dbt_utilities_reading 
                           WHERE utilitiesReadingId = " + Id;
                try
                {

                    this.connect = new MySqlConnection(db.stringConnection());
                    this.connect.Open();
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.mdr = this.command.ExecuteReader();

                        if (this.mdr.Read())
                        {
                            int tot = int.Parse(this.mdr.GetString("utilityCurrentReading")) - int.Parse(this.mdr.GetString("utilityPrevReading"));
                        tempTotal.Text = tot.ToString();
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
                   
        } // done first step

        private void selectEDitREcord_step_6()
        {
            int rowindex = dataGridReadingContent.SelectedCells[0].RowIndex;
            string Id = dataGridReadingContent.Rows[rowindex].Cells[0].Value.ToString();

           
                try
                {

                    this.query = "UPDATE " + this.tableName +
                                @" SET 
                                utilityTotalReading = @data1                                                     
                               WHERE utilitiesReadingId = " + Id;


                    this.connect = new MySqlConnection(db.stringConnection());
                    using (this.command = new MySqlCommand(this.query, this.connect))
                    {
                        this.command.Parameters.AddWithValue("@data1", tempTotal.Text);

                        this.connect.Open();
                        this.command.ExecuteNonQuery();

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
           
        }// end of the method this is for max id only
 
        private bool compareId(int id)
        {
            bool hasEqual = false;
            int value;

            this.query = "SELECT COUNT(utilitiesReadingId) AS value FROM dbt_utilities_reading WHERE utilitiesReadingId = " + id;

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using(this.command =  new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        value = int.Parse(this.mdr.GetString("value"));
                        if(value > 0)
                        {
                            hasEqual = true;
                        }
                        else
                        {
                            hasEqual = false;
                        }
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

            return hasEqual;
        }// end of the method

        
        private void disable()
        {
            comboBoxUtilityType.Enabled = false;
            comboBoxPersonnel.Enabled = false;
            comboBoxTenant.Enabled = false;
            textBoxCurrentReading.Enabled = false;
            textBoxReadingNotes.Enabled = false;

        }// end of the method

        private bool maximumId(int id)
        {
            bool hasMAximum = false;
            int maximum_val;

            this.query = "SELECT MAX(utilitiesReadingId) AS maximum_id FROM dbt_utilities_reading WHERE utilitiesTypeId = " + this.utilityNumber;

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        maximum_val = int.Parse(this.mdr.GetString("maximum_id"));
                        if (maximum_val == id)
                        {
                            hasMAximum = true;
                        }
                        else
                        {
                            hasMAximum = false;
                        }
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

            return hasMAximum;
        }// end of the method  else if

        private int maximumIdutility()
        {

            int maximum_val = 0;

            this.query = "SELECT MAX(utilitiesReadingId) AS maximum_id FROM dbt_utilities_reading WHERE utilitiesTypeId = " + this.utilityNumber;

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        maximum_val = int.Parse(this.mdr.GetString("maximum_id"));
                       
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

            return maximum_val;
        }// end of the method  else if

    }// end of mthe class


}// end of the namespace
