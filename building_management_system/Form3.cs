using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace building_management_system
{
    public partial class Form3 : Form
    {
        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader mdr;
        Image file;
        ClassValidations validate = new ClassValidations();
       

        private string query;
        private string tableName = "dbt_personal_information";
        private string u_id;
        private string u_position;    


        private bool slide = false;
        private int width;
        private int limit = 39, ctrExpand = 0, ctrProfile = 0;
        private int max = 150;
        private string button;
        private bool clickedExpand = false;
        private string btnTextValue;
        string[] homeBtnText = new string[9] { "Building Information", "Floor Number", "Floor Category", "Job Position", "Submeter", "Tenants", "Personnel", "Utilities Type", "Reading" };
        public Form3()
        {
           
            InitializeComponent();           
            displayUserInfo();
            this.buttons_design(true, 39);
            // this.uC_welcome1.Show();         
            buttonsEnables(clickedExpand);
            defaultBtnDashboardDo();
            dateAndTime();            
        }
        private void TimerTime_Tick(object sender, EventArgs e)
        {
            TimerTime.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        public void dateAndTime()
        {          
            labelDateTime.Text = DateTime.Now.ToLongDateString();
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }// current date and time



        private void Form3_Load(object sender, EventArgs e)
        {
            //System.Windows.Forms.Application.ExitThread();
        }// close the appication

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label_logo_text_Click(object sender, EventArgs e)
        {
            labelWarning.ForeColor = Color.Aqua;
        }//
        private void label_logo_text_mouseOut_Click(object sender, EventArgs e)
        {
            labelWarning.ForeColor = Color.White;
        }//
        private void label_hover_Click(object sender, EventArgs e)
        {
            
        }//
        private void label1_hover_Click()
        {
            btnDashboard1.ForeColor = Color.Black;       
            btnDashboard1.BackColor = Color.White;

            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label2_hover_Click()
        {
            btnDashboard2.ForeColor = Color.Black;
            btnDashboard2.BackColor = Color.White;

            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;            
            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label3_hover_Click()
        {
            btnDashboard3.ForeColor = Color.Black;
            btnDashboard3.BackColor = Color.White;

            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;           
            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label4_hover_Click()
        {
            btnDashboard4.ForeColor = Color.Black;
            btnDashboard4.BackColor = Color.White;

            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;            
            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label5_hover_Click()
        {
            btnDashboard5.ForeColor = Color.Black;
            btnDashboard5.BackColor = Color.White;

            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;           
            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label6_hover_Click()
        {
            btnDashboard6.ForeColor = Color.Black;
            btnDashboard6.BackColor = Color.White;

            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;           
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label7_hover_Click()
        {
            btnDashboard7.ForeColor = Color.Black;
            btnDashboard7.BackColor = Color.White;

            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;       
            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label8_hover_Click()
        {
            btnDashboard8.ForeColor = Color.Black;
            btnDashboard8.BackColor = Color.White;

            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;           
            btnDashboard9.ForeColor = Color.White;
            btnDashboard9.BackColor = Color.Transparent;

        }//
        private void label9_hover_Click()
        {
            btnDashboard9.ForeColor = Color.Black;
            btnDashboard9.BackColor = Color.White;

            btnDashboard8.ForeColor = Color.White;
            btnDashboard8.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;
            btnDashboard6.ForeColor = Color.White;
            btnDashboard6.BackColor = Color.Transparent;
            btnDashboard5.ForeColor = Color.White;
            btnDashboard5.BackColor = Color.Transparent;
            btnDashboard4.ForeColor = Color.White;
            btnDashboard4.BackColor = Color.Transparent;
            btnDashboard3.ForeColor = Color.White;
            btnDashboard3.BackColor = Color.Transparent;
            btnDashboard2.ForeColor = Color.White;
            btnDashboard2.BackColor = Color.Transparent;
            btnDashboard1.ForeColor = Color.White;
            btnDashboard1.BackColor = Color.Transparent;
            btnDashboard7.ForeColor = Color.White;
            btnDashboard7.BackColor = Color.Transparent;           

        }//

        //private void btn_expand_form3_Click(object sender, EventArgs e)
        //{
        // luma no fucntion delete this
        // }
        
        private void btn_general_form3_Click(object sender, EventArgs e)
        {
            btn_general_form3.BackColor = Color.Gainsboro;
            btn_general_form3.ForeColor = Color.Black;
            btn_profile_form3.BackColor = Color.Transparent;
            btn_profile_form3.ForeColor = Color.FromArgb(230, 218, 241);
            btn_Home_form3.BackColor = Color.Transparent;
            btn_Home_form3.ForeColor = Color.FromArgb(230, 218, 241);
            // new general
            this.button = "Dashboard";
            //this.change_label(button);
            ctrProfile++;
            if (ctrProfile <= 1)
            {
                defaultTextBtn();
            }
            else
            {
                panel_steady_slide_form_3.Hide();
                ctrProfile = 0;
            }

        }

        private void btn_expand_form3_Click_1(object sender, EventArgs e)
        {
            btn_Home_form3.BackColor = Color.Transparent;
            btn_general_form3.BackColor = Color.Transparent;
            btn_profile_form3.BackColor = Color.Transparent;
            btn_Home_form3.ForeColor = Color.FromArgb(230, 218, 241);
            btn_general_form3.ForeColor = Color.FromArgb(230, 218, 241);
            btn_profile_form3.ForeColor = Color.FromArgb(230, 218, 241);
            // new expand
            ctrExpand++;
            if (ctrExpand <= 1)
            {
                this.width = panel_mini_sliding_form3.Width; //get the current width value of the panel
                this.run_slide(width);
                clickedExpand = true;
                buttonsEnables(clickedExpand);
            }
            else
            {
                //defaultBtnDashboardDo();
                this.width = panel_mini_sliding_form3.Width; //get the current width value of the panel
                this.run_slide(width);
                clickedExpand = false;
                buttonsEnables(clickedExpand);
                ctrExpand = 0;
            }
            
        }
        
        private void btn_home_form3_Click(object sender, EventArgs e)
        {
            btn_Home_form3.BackColor = Color.Gainsboro;
            btn_Home_form3.ForeColor = Color.Black;
            btn_general_form3.BackColor = Color.Transparent;
            btn_general_form3.ForeColor = Color.FromArgb(230, 218, 241);
            btn_profile_form3.BackColor = Color.Transparent;
            btn_profile_form3.ForeColor = Color.FromArgb(230, 218, 241);
            this.button = "Inputs";
            ctrProfile++;
            if (ctrProfile <= 1)
            {
                defaultTextBtn();
            }
            else
            {
                panel_steady_slide_form_3.Hide();
                ctrProfile = 0;
            }

        }// button method


        private void btn_profile_form3_Click(object sender, EventArgs e)
        {
            btn_profile_form3.BackColor = Color.Gainsboro;
            btn_profile_form3.ForeColor = Color.Black;
            btn_general_form3.BackColor = Color.Transparent;
            btn_general_form3.ForeColor = Color.FromArgb(230, 218, 241);
            btn_Home_form3.BackColor = Color.Transparent;
            btn_Home_form3.ForeColor = Color.FromArgb(230, 218, 241);
            this.button = "Profile";
            ctrProfile++;
            if(ctrProfile <= 1)
            {
                defaultTextBtn();
            }
            else
            {
                panel_steady_slide_form_3.Hide();
                ctrProfile = 0;
            }

        }// button method

        private void btn_team_form3_Click(object sender, EventArgs e)
        {
            this.button = "team";
           
        }// button method

        private void btn_events_scheds_form3_Click(object sender, EventArgs e)
        {
            this.button = "schedule";
           
        }

        private void btn_jobs_form3_Click(object sender, EventArgs e)
        {
            this.button = "works";
           
        }// button method

        private void btn_settings_form3_Click(object sender, EventArgs e)
        {
            this.button = "settings";
            
           
        }// button method

        private void btn_files_form3_Click(object sender, EventArgs e)
        {
            this.button = "files";
            
                             
        }// button method
        
        public void buttonsEnables( bool state)
        {
            btn_general_form3.Enabled = state;
            btn_Home_form3.Enabled = state;
            btn_profile_form3.Enabled = state;          
            //btn_settings_form3.Enabled = state;
            //btn_files_form3.Enabled = state;          
        }// end of the method

        public void btnDashboardDo(string btnTextValue)
        {
            
            switch (btnTextValue)
            {
                case "Account Settings":
                    {

                        uC_view_profile1.Dispose();
                        this.uC_view_profile1 = new UC_view_profile();
                        this.panel1.Controls.Add(this.uC_view_profile1);
                        this.uC_view_profile1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uC_view_profile1.Location = new System.Drawing.Point(0, 0);
                        this.uC_view_profile1.Name = "uC_view_profile1";
                        this.uC_view_profile1.Size = new System.Drawing.Size(1084, 659);
                        this.uC_view_profile1.TabIndex = 1;

                        panel_admin_profile1.Show();
                        uC_view_profile1.Hide();                       
                        uC_buildingInformation1.Hide();
                        //uC_FloorNumber1.Hide();
                        //uC_FloorCategory1.Hide();
                        uC_JobPosition1.Hide();
                        uC_Submeter1.Hide();
                        uC_tenants1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();
                       
                        break;
                    }
                case "View Profile":
                    {
                        uC_view_profile1.Dispose();
                        this.uC_view_profile1 = new UC_view_profile();
                        this.panel1.Controls.Add(this.uC_view_profile1);
                        this.uC_view_profile1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uC_view_profile1.Location = new System.Drawing.Point(0, 0);
                        this.uC_view_profile1.Name = "uC_view_profile1";
                        this.uC_view_profile1.Size = new System.Drawing.Size(1084, 659);
                        this.uC_view_profile1.TabIndex = 1;

                        uC_view_profile1.Show();
                        panel_admin_profile1.Hide();
                        uC_buildingInformation1.Hide();
                        //uC_FloorNumber1.Hide();
                        //uC_FloorCategory1.Hide();
                        uC_JobPosition1.Hide();
                        uC_Submeter1.Hide();
                        uC_tenants1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();
                        
                        break;
                    }
                case "Building Information":
                    {
                        uC_buildingInformation1.Show();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        //uC_FloorNumber1.Hide();
                        //uC_FloorCategory1.Hide();
                        uC_JobPosition1.Hide();
                        uC_Submeter1.Hide();
                        uC_tenants1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();

                        break;
                    }
                case "Floor Number":
                    {
                        //uC_FloorNumber1.Show();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        //uC_FloorCategory1.Hide();
                        uC_JobPosition1.Hide();
                        uC_Submeter1.Hide();
                        uC_tenants1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();

                        break;
                    }
                case "Floor Category":
                    {
                        //uC_FloorCategory1.Show();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        uC_JobPosition1.Hide();
                        uC_Submeter1.Hide();
                        uC_tenants1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();

                        break;
                    }
                case "Job Position":
                    {
                        uC_JobPosition1.Show();
                        //uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        uC_Submeter1.Hide();
                        uC_tenants1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();

                        break;
                    }
                case "Submeter":
                    {
                                             
                        uC_Submeter1.Show();
                        uC_JobPosition1.Hide();
                        //uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        uC_tenants1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();

                        break;
                    }
                case "Tenants":
                    {
                        uC_tenants1.Dispose();
                        this.uC_tenants1 = new UC_tenants();
                        this.panel1.Controls.Add(this.uC_tenants1);
                        this.uC_tenants1.AutoScroll = true;
                        this.uC_tenants1.AutoSize = true;
                        this.uC_tenants1.BackColor = System.Drawing.Color.White;
                        this.uC_tenants1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uC_tenants1.Location = new System.Drawing.Point(0, 0);
                        this.uC_tenants1.Name = "uC_tenants1";
                        this.uC_tenants1.Size = new System.Drawing.Size(1084, 659);
                        this.uC_tenants1.TabIndex = 7;



                        uC_tenants1.Show();
                        uC_Submeter1.Hide();
                        uC_JobPosition1.Hide();
                       // uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        uC_personnel1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();
                       
                        break;
                    }
                case "Personnel":
                    {
                        uC_personnel1.Dispose();
                        this.uC_personnel1 = new UC_personnel();
                        this.panel1.Controls.Add(this.uC_personnel1);
                        this.uC_personnel1.AutoScroll = true;
                        this.uC_personnel1.BackColor = System.Drawing.Color.White;
                        this.uC_personnel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        this.uC_personnel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uC_personnel1.Location = new System.Drawing.Point(0, 0);
                        this.uC_personnel1.Name = "uC_personnel1";
                        this.uC_personnel1.Size = new System.Drawing.Size(1084, 659);
                        this.uC_personnel1.TabIndex = 8;

                        uC_personnel1.Show();
                        uC_tenants1.Hide();
                        uC_Submeter1.Hide();
                        uC_JobPosition1.Hide();
                        //uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        uC_utilititesType1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();
                        
                        break;
                    }
                case "Utilities Type":
                    {
                        uC_utilititesType1.Show();
                        uC_personnel1.Hide();
                        uC_tenants1.Hide();
                        uC_Submeter1.Hide();
                        uC_JobPosition1.Hide();
                        //uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        uC_reading1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();

                        break;
                    }
                case "Utilities Reading":
                    {
                        uC_reading1.Dispose();
                        this.uC_reading1 = new UC_reading();
                        this.panel1.Controls.Add(this.uC_reading1);
                        this.uC_reading1.AutoScroll = true;
                        this.uC_reading1.BackColor = System.Drawing.Color.White;
                        this.uC_reading1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uC_reading1.Location = new System.Drawing.Point(0, 0);
                        this.uC_reading1.Name = "uC_reading1";
                        this.uC_reading1.Size = new System.Drawing.Size(1084, 659);
                        this.uC_reading1.TabIndex = 10;

                        uC_reading1.Show();
                        uC_utilititesType1.Hide();
                        uC_personnel1.Hide();
                        uC_tenants1.Hide();
                        uC_Submeter1.Hide();
                        uC_JobPosition1.Hide();
                        //uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        uC_graph1.Hide();// hide the graphs
                        uC_printingPdfReport1.Hide();
                        
                        break;
                    }
                case "Reading Graph Reports":
                    {
                        uC_graph1.Dispose();         
                        this.uC_graph1 = new UC_graph();
                        this.panel1.Controls.Add(this.uC_graph1);
                        this.uC_graph1.AutoScroll = true;
                        this.uC_graph1.BackColor = System.Drawing.Color.White;
                        this.uC_graph1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.uC_graph1.Location = new System.Drawing.Point(0, 0);
                        this.uC_graph1.Name = "uC_graph1";
                        this.uC_graph1.Size = new System.Drawing.Size(1084, 659);
                        this.uC_graph1.TabIndex = 11;

                        uC_graph1.Show();
                        uC_printingPdfReport1.Hide();
                        uC_reading1.Hide();
                        uC_utilititesType1.Hide();
                        uC_personnel1.Hide();
                        uC_tenants1.Hide();
                        uC_Submeter1.Hide();
                        uC_JobPosition1.Hide();
                       // uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();
                        break;
                    }
                case "Generate Reports":
                    {
                        uC_printingPdfReport1.Show();
                        uC_graph1.Hide();
                        uC_reading1.Hide();
                        uC_utilititesType1.Hide();
                        uC_personnel1.Hide();
                        uC_tenants1.Hide();
                        uC_Submeter1.Hide();
                        uC_JobPosition1.Hide();
                        //uC_FloorCategory1.Hide();
                        //uC_FloorNumber1.Hide();
                        uC_buildingInformation1.Hide();
                        uC_view_profile1.Hide();
                        panel_admin_profile1.Hide();

                        break;
                    }
            }
        }// end of the method

        public void defaultBtnDashboardDo()
        {          
            btnDashboard1.Hide();
            btnDashboard2.Hide();
            panel_steady_slide_form_3.Hide();
            uC_graph1.Show();
            btnDashboardDo("Reading Graph Reports");
        }// end of the method
        

        public void defaultTextBtn()
        {          
            if (this.button == "Profile")
            {
                panel_steady_slide_form_3.Show();
                label_logo_text.Text = this.button;
                btnDashboard1.Text = "Account Settings";
                btnDashboard2.Text = "View Profile";
                btnDashboard1.Show();
                btnDashboard2.Show();
                btnDashboard3.Hide();
                btnDashboard4.Hide();
                btnDashboard5.Hide();
                btnDashboard6.Hide();
                btnDashboard7.Hide();
                btnDashboard8.Hide();
                btnDashboard9.Hide();

            }
            else if (this.button == "Inputs")
            {

                if (this.u_position != "Admin")
                {
                    panel_steady_slide_form_3.Show();
                    label_logo_text.Text = this.button;
                    btnDashboard1.Text = "Utilities Reading";
                    btnDashboard2.Hide();
                    btnDashboard3.Hide();
                    btnDashboard4.Hide();
                    btnDashboard5.Hide();
                    btnDashboard6.Hide();
                    btnDashboard7.Hide();
                    btnDashboard8.Hide();
                    btnDashboard9.Hide();
                    btnDashboard1.Show();

                }
                else if(this.u_position == "Admin")
                {
                    //btnDefaults();
                    panel_steady_slide_form_3.Show();
                    label_logo_text.Text = this.button;
                    btnDashboard1.Text = "Building Information";
                    btnDashboard2.Text = "Job Position";
                    btnDashboard3.Text = "Submeter";
                    btnDashboard4.Text = "Tenants";
                    btnDashboard5.Text = "Personnel";
                    btnDashboard6.Text = "Utilities Type";
                    btnDashboard7.Text = "Utilities Reading";
                    btnDashboard8.Hide();
                    btnDashboard9.Hide();
                    btnDashboard1.Show();
                    btnDashboard2.Show();
                    btnDashboard3.Show();
                    btnDashboard4.Show();
                    btnDashboard5.Show();
                    btnDashboard6.Show();
                    btnDashboard7.Show();
                    
                }

            }else if(this.button == "Dashboard")
            {
                panel_steady_slide_form_3.Show();
                label_logo_text.Text = this.button;
                btnDashboard1.Text = "Reading Graph Reports";
                btnDashboard2.Text = "Generate Reports";
                btnDashboard1.Show();
                btnDashboard2.Show();
                btnDashboard3.Hide();
                btnDashboard4.Hide();
                btnDashboard5.Hide();
                btnDashboard6.Hide();
                btnDashboard7.Hide();
                btnDashboard8.Hide();
                btnDashboard9.Hide();
            }
        }// edn of the method

        public void btnDefaults()
        {
            btnDashboard1.Hide();
            btnDashboard2.Hide();
        }// end of method

        private void run_slide(int width)
        {   

            if (this.slide) // if true
            {
                // bring it back on its original state
                
                panel_mini_sliding_form3.Width = width - this.max;              
                width = panel_mini_sliding_form3.Width;               
                this.buttons_design(this.slide, width);
                this.slide = false;
            }
            else // if false
            {

                panel_mini_sliding_form3.Width = this.limit + this.max;
                width = panel_mini_sliding_form3.Width;
                this.buttons_design(this.slide, width);
                this.slide = true;

            }
         
        }// end of function

        private void buttons_design(bool slide, int width)
        {

            if(slide)
            {
               
                // mini logo
                this.logo_mini_slide_form3.Width = width;

                //exoand button
                this.btn_expand_form3.Width = width;
                this.btn_expand_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btn_expand_form3.Text = null;

                // general button
                this.btn_general_form3.Width = width;
                this.btn_general_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.btn_general_form3.Text = null;

                // home button
                this.btn_Home_form3.Width = width;
                this.btn_Home_form3.Text = null;
                this.btn_Home_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // profile button
                this.btn_profile_form3.Width = width;
                this.btn_profile_form3.Text = null;
                this.btn_profile_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // settings button
                //this.btn_settings_form3.Width = width;
                //this.btn_settings_form3.Text = null;
                //this.btn_settings_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                //// supplies and files button
                //this.btn_files_form3.Width = width;
                //this.btn_files_form3.Text = null;
                //this.btn_files_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

            }
            else
            {
                // mini logo
                this.logo_mini_slide_form3.Width = width;

                // expand button
                this.btn_expand_form3.Width = width;
                this.btn_expand_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.btn_expand_form3.Text = "Minimize";
                this.btn_expand_form3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // genral button
                this.btn_general_form3.Width = width;
                this.btn_general_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.btn_general_form3.Text = "Dashboard";
                this.btn_general_form3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // home button
                this.btn_Home_form3.Width = width;
                this.btn_Home_form3.Text = "Inputs";
                this.btn_Home_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.btn_Home_form3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                //uC_welcome1
                // profile button
                this.btn_profile_form3.Width = width;
                this.btn_profile_form3.Text = "Profile";
                this.btn_profile_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.btn_profile_form3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               
                // settings button
                //this.btn_settings_form3.Width = width;
                //this.btn_settings_form3.Text = "Settings";
                //this.btn_settings_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                //this.btn_settings_form3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                //// supplies and files button
                //this.btn_files_form3.Width = width;
                //this.btn_files_form3.Text = "Files";
                //this.btn_files_form3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                //this.btn_files_form3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            }// end if else

        }// end of function
        
        public void displayUserInfo()
        {
            try
            {
                this.query = "SELECT dbt_personalInfoId, personalInfoFirstName, dbt_jobPosition, login_status FROM dbt_personal_information WHERE login_status = 1";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.mdr = this.command.ExecuteReader();
                    if (this.mdr.Read())
                    {
                        this.u_id = this.mdr.GetString("dbt_personalInfoId");
                        labelUsername.Text = this.mdr.GetString("personalInfoFirstName") + "     ";
                        this.u_position = this.mdr.GetString("dbt_jobPosition");
                    }
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

        private void update_loginStatusToLogout()
        {
            try
            {
                query = "UPDATE " + this.tableName +
                            @" SET login_status = @data1 WHERE dbt_personalInfoId = " + this.u_id;

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.command.Parameters.AddWithValue("@data1", 2);
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
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

        

        private void uC_view_profile1_Load(object sender, EventArgs e)
        {

        }// button method

        private void uC_welcome1_Load(object sender, EventArgs e)
        {

        }// button method

        private void panel_steady_slide_form_3_Paint(object sender, PaintEventArgs e)
        {

        }// button method

        private void btnDashboard1_Click(object sender, EventArgs e)
        {
            label1_hover_Click();
            btnTextValue = btnDashboard1.Text;
            btnDashboardDo(btnTextValue);
            
        }// button method

        private void btnDashboard2_Click_1(object sender, EventArgs e)
        {
            label2_hover_Click();
            btnTextValue = btnDashboard2.Text;
            btnDashboardDo(btnTextValue);
        }// button method

        private void btnDashboard3_Click(object sender, EventArgs e)
        {
            label3_hover_Click();
            btnTextValue = btnDashboard3.Text;
            btnDashboardDo(btnTextValue);
           
        }

        private void btnDashboard4_Click(object sender, EventArgs e)
        {
            label4_hover_Click();
            btnTextValue = btnDashboard4.Text;
            btnDashboardDo(btnTextValue);
            
        }

        private void btnDashboard5_Click(object sender, EventArgs e)
        {
            label5_hover_Click();
            btnTextValue = btnDashboard5.Text;
            btnDashboardDo(btnTextValue);
            
        }

        private void btnDashboard6_Click(object sender, EventArgs e)
        {
            label6_hover_Click();
            btnTextValue = btnDashboard6.Text;
            btnDashboardDo(btnTextValue);
        }
        private void btnDashboard7_Click(object sender, EventArgs e)
        {
            label7_hover_Click();
            btnTextValue = btnDashboard7.Text;
            btnDashboardDo(btnTextValue);
           
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void labelWarning_Click(object sender, EventArgs e)
        {
            update_loginStatusToLogout();          
            Form1 login = new Form1();
            login.Show();
            this.Hide();       
        }// button label log out

        private void btnDashboard8_Click(object sender, EventArgs e)
        {
            label8_hover_Click();
            btnTextValue = btnDashboard8.Text;
            btnDashboardDo(btnTextValue);
           
        }

        private void btnDashboard9_Click(object sender, EventArgs e)
        {
            label9_hover_Click();
            btnTextValue = btnDashboard9.Text;
            btnDashboardDo(btnTextValue);          
        }

       

    }// end of the class





   
}// namespace
