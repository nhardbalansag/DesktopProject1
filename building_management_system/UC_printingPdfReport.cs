using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;// pdf converter
using iTextSharp.text.pdf; // itext for pdf file convertion
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting; // for the charts




namespace building_management_system
{
    public partial class UC_printingPdfReport : UserControl
    {

        MySqlConnection connect;
        MySqlDataAdapter adapter;
        Document doc;    
        PdfPTable table;
        PdfPTable enclosedTable;
        MemoryStream chartImage;
        Paragraph paragraph;
        DatabaseConnection db = new DatabaseConnection();
        MySqlCommand command;
        MySqlDataReader mdr;
        // MySqlCommand command;
        private string query;
        private string tableName = "dbt_utilities_reading";
        private string pdfFilePath = "C:\\Users\\bernard\\Documents\\3rd year\\Advance_programming\\";

        private int lenght;
        private string thisdate;
        private string u_dateTime, u_date;
        private bool meron = false;

        public UC_printingPdfReport()
        {
            InitializeComponent();
            start();
            dateAndTime();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.u_dateTime = DateTime.Now.ToLongTimeString();
        }
        public void dateAndTime()
        {
            this.u_date = DateTime.Now.ToLongDateString();
            this.u_dateTime = DateTime.Now.ToLongTimeString();
        }// current date and time

        private void button4_Click(object sender, EventArgs e)
        {
           
            try
            {
                
                string generatedPath = this.pdfFilePath + "Test_" + this.u_date + ".pdf";

                // print the document         
                this.doc = new Document(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter pdfWriter = PdfWriter.GetInstance(this.doc, new FileStream(generatedPath, FileMode.Create));
                this.doc.Open();
                iTextSharp.text.Font fontParagraph = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                this.paragraph = new Paragraph(labelTittlePdfwater.Text, fontParagraph); // center tittle 
                var address = new Paragraph(labelAddressWaterpdf.Text);// right address
                this.paragraph.Alignment = Element.ALIGN_CENTER; //align the center to the center point
                address.Alignment = Element.ALIGN_RIGHT; // align the adress to the right point
                PdfPTable paragraph1table = new PdfPTable(1);

                paragraph1table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                paragraph1table.AddCell(this.paragraph);
                paragraph1table.SetTotalWidth(new float[] { 100f });
                address.Add("\n\n");
                doc.Add(address);
                this.doc.Add(paragraph1table);

                this.tableGridReportTo_Pdf(); // chart and table

                doc.Close();
                labelWarning.Visible = true;
                labelWarning.Text = "Succesfully generated pdf file";
            }
            catch (Exception)
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Unable to generate file";
            }
     
        }// button generating a pdf file

        public void tableGridReportTo_Pdf()
        {
            
            int columnCount = dataGridPdrfReading.Columns.Count;// count the number of columns of the grid table
            this.table = new PdfPTable(columnCount);        
            for (int i = 0; i < columnCount; i++)
            {
                table.AddCell(new Phrase(dataGridPdrfReading.Columns[i].HeaderText));
            }

            table.HeaderRows = 1;

            if (comboBoxSearchUtility.Text == "water" || comboBoxSearchUtility.Text == "Water")
            {
                for (int i = 0; i < dbCountWater(); i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (dataGridPdrfReading[j, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridPdrfReading[j, i].Value.ToString()));
                        }// if
                    }//end of for
                }// end of for
            }
            else if(comboBoxSearchUtility.Text != "water" || comboBoxSearchUtility.Text != "Water")
            {
                for (int i = 0; i < dbCountElectric(); i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (dataGridPdrfReading[j, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridPdrfReading[j, i].Value.ToString()));
                        }// if
                    }//end of for
                }// end of for
            }

           

            table.WidthPercentage = 50;
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            ///        this is for the chart
            this.chartImage = new MemoryStream();
            chart_pdf_water.SaveImage(this.chartImage, ChartImageFormat.Png);
            iTextSharp.text.Image imageOfChart = iTextSharp.text.Image.GetInstance(chartImage.GetBuffer());
            imageOfChart.Alignment = Element.ALIGN_RIGHT;

            this.enclosedTable = new PdfPTable(1);// this is the table for the table and the graph

            this.enclosedTable.AddCell(table);
            this.enclosedTable.SetTotalWidth(new float[] { 70f}); // 150
            doc.Add(this.enclosedTable);

            this.enclosedTable = new PdfPTable(1);

            this.enclosedTable.AddCell(imageOfChart);
            this.enclosedTable.HorizontalAlignment = Element.ALIGN_CENTER;
            this.enclosedTable.SetTotalWidth(new float[] { 70f}); // 150

            doc.Add(this.enclosedTable);// to put the two item together in one row of the table
   
        }// end of the method

        private void comboBoxSearchUtility_SelectedIndexChanged(object sender, EventArgs e)
        {         
            viewAlldataGridReadingContent();
            dbCountGridContent();
           
            //MessageBox.Show(comboBoxSearchUtility.Text, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }// utility type dropdown choose

        private void label19_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSearchReading_Click(object sender, EventArgs e)
        {
            
            refreshGraph();
            dataInchart();

            
            

        }// refreshh

        

        private void start()
        {
            comboBoxUtilityTypeDropDown();
            labelWarning.Visible = false;
            dbCountGridContent();          
        }// ende of the method

        private void viewAlldataGridReadingContent()
        {
            this.query = @" SELECT                              
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
                    dataGridPdrfReading.DataSource = ds.Tables[0];
                    dataGridReadingContentDesign();// design the grid
                }
                dataGridReadingContentLabel();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        public void dataGridReadingContentDesign()
        {
            dataGridPdrfReading.BorderStyle = BorderStyle.None;
            dataGridPdrfReading.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridPdrfReading.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridPdrfReading.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridPdrfReading.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridPdrfReading.BackgroundColor = Color.White;

            dataGridPdrfReading.EnableHeadersVisualStyles = false;
            dataGridPdrfReading.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridPdrfReading.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridPdrfReading.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }// end of the method

        private void dataGridReadingContentLabel()
        {
            string[] sysHeader = new string[3] { "utilityReadingDate", "utilityCurrentReading", "utilityTotalReading" };
            string[] sysHeadernew = new string[3] {"date", "Meter Reading", "Consumption" };

            for (int i = 0; i < sysHeader.Length; i++)
            {
                dataGridPdrfReading.Columns[sysHeader[i]].HeaderText = sysHeadernew[i].ToUpper();
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

        private void dataInchart()
        {    
                this.lenght = dbCountGridContent();
          
            for (int i = 0; i < this.lenght; i++)
            {
                var date = dataGridPdrfReading.Rows[i].Cells[0].Value.ToString();
                var consumption = dataGridPdrfReading.Rows[i].Cells[2].Value.ToString();
                
                chart_pdf_water.Series["water"].Points.AddXY(date, consumption);

                //chart_pdf_water.Series["water"].Label = "Consumption";
            }
            
        }// end of the method

        private int dbCountGridContent()
        {
            this.query = @"SELECT COUNT(utilitiesReadingId) as num_count
                           FROM " + this.tableName + " WHERE utilitiesTypeId = " + comboBoxSearchUtility.SelectedValue;
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

        private void refreshGraph()
        {
            for (int i = 0; i < this.lenght; i++)
            {
                int a = 0;
                chart_pdf_water.Series["water"].Points.RemoveAt(a);              
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
        private int dbCountElectric()
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














       

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            
        }// view date search





























    }// end fo the class
}// end of the namespace
