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
    public partial class UC_graph : UserControl
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;


        private string query;
        private string tableName = "dbt_utilities_reading";


        public UC_graph()
        {
            InitializeComponent();           
            start();
         

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void UC_graph_Load(object sender, EventArgs e)
        {
         
        }

       

        private void start()
        {
            dataGridViewGraphContentWater.Visible = false;
            dataGridViewGraphContentElectricity.Visible = false;
            viewAlldataGridReadingContent_Water();
            viewAlldataGridReadingContent_Electricity();
            dataInchart_water();
            dataInchart_electricity();
            waterAndElectricity();
        }// end of the method

       
        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dateTimePickerfrom.Value.ToString("yyy-MM-dd"), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Dispose();
            //Form3 a = new Form3();
            //a.Show();
           
            //selectBydateToGrid_water();
            ////selectBydateToGrid_electric();
            //dataInchart_water_date_func();
            ////dataInchart_electricity_date_func();

        }//date









        private void waterAndElectricity()
        {
            // name of the graph
            for (int i = 0; i < dbCountGridContent_water(); i++)
            {
                var consumption = dataGridViewGraphContentWater.Rows[i].Cells[1].Value.ToString();
                chart_WaterElectric.Series["Water"].Points.AddXY(consumption, consumption);

                //chart_pdf_water.Series["water"].Label = "Consumption";
            }
            for (int i = 0; i < dbCountGridContent_electricity(); i++)
            {
                var consumption = dataGridViewGraphContentElectricity.Rows[i].Cells[1].Value.ToString();
                chart_WaterElectric.Series["Electricity"].Points.AddXY(consumption, consumption);

                //chart_pdf_water.Series["water"].Label = "Consumption";
            }

        }// end od the method

        private void dataInchart_water()
        {
            for (int i = 0; i < dbCountGridContent_water(); i++)
            {               
                var consumption = dataGridViewGraphContentWater.Rows[i].Cells[1].Value.ToString();
                chart_water.Series["water"].Points.AddXY(consumption, consumption);              
            }
             // grid of the graph
        }// end of the method  

        private void dataInchart_electricity()
        {
            for (int i = 0; i < dbCountGridContent_electricity(); i++)
            {              
                var consumption = dataGridViewGraphContentElectricity.Rows[i].Cells[1].Value.ToString();
                chart_Electric.Series["electric"].Points.AddXY(consumption, consumption);
            }
            // grid of the graph
        }// end of the method  

        private int dbCountGridContent_water()
        {
            this.query = @"SELECT COUNT(utilitiesReadingId) as num_count
                           FROM " + this.tableName + " WHERE utilitiesTypeId = " + 1;
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
        }// end of the method water count content in db

        private int dbCountGridContent_electricity()
        {
            this.query = @"SELECT COUNT(utilitiesReadingId) as num_count
                           FROM " + this.tableName + " WHERE utilitiesTypeId = " + 2;
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
        }// end of the method water count content in db

        private void viewAlldataGridReadingContent_Water()
        {
            this.query = @" SELECT                                                             
                                utilityReadingDate,
                                utilityTotalReading                           
                            FROM
                                dbt_utilities_reading                           
                            WHERE
                                 utilitiesTypeId = 1 ORDER BY (utilitiesReadingId)";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridViewGraphContentWater.DataSource = ds.Tables[0];
                    
                }
               
            }
            catch (Exception)
            {
                // error handling messages here;
                //labelWarning.Text = "Unable to show records.";
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method water grid

        private void viewAlldataGridReadingContent_Electricity()
        {
            this.query = @" SELECT                               
                                utilityReadingDate,                              
                                utilityTotalReading                              
                            FROM
                                dbt_utilities_reading                           
                            WHERE
                                 utilitiesTypeId = " + 2 + " ORDER BY (utilityReadingDate)";

            try
            {
                this.connect = new MySqlConnection(db.stringConnection());
                this.connect.Open();
                using (this.adapter = new MySqlDataAdapter(this.query, this.connect))
                {

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridViewGraphContentElectricity.DataSource = ds.Tables[0];

                }

            }
            catch (Exception)
            {
                // error handling messages here;
                //labelWarning.Text = "Unable to show records.";
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method electricity grid


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
