using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace building_management_system
{
    class refreshQueries
    {

        MySqlConnection connect;
        MySqlCommand command;
        DatabaseConnection db = new DatabaseConnection();
        
        private string query;





        public void refreshAll()
        {
            refreshReadingContent_tables();
            refreshPersonnelInformation_tables();
            refreshPersonal_information();
            refreshTenants_tables();
            refreshGraphs();
        }

        /// <summary> 

        public void refreshReadingContent_tables()
        {
            // table dbt_utilities_assigned_personnel
            refresh_dbt_utilities_assigned_personnel();
            // dbt_utilities_type
            refresh_dbt_utilities_type();
            // dbt_tenants
            refresh_dbt_tenants();
        }// end of the method

        public void refreshPersonnelInformation_tables()
        {
            // dbt_job_position
            refresh_dbt_job_position();
        }// end of the method

        public void refreshPersonal_information()
        {
            // dbt_job_position
            refresh_dbt_job_position();
        }// end of the method

        public void refreshTenants_tables()
        {
            // dbt_submeter
            refresh_dbt_submeter();
        }// end of the method

        public void refreshGraphs()
        {
            // dbt_submeter
            refresh_dbt_utilities_reading();
        }// end of the method


        /// </summary>


        public void refresh_dbt_utilities_assigned_personnel()
        {
            try
            {
                this.query = "SELECT * FROM dbt_utilities_assigned_personnel;";

                this.connect = new MySqlConnection(db.stringConnection());
                using(this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // error handling  code here
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        public void refresh_dbt_utilities_type()
        {
            try
            {
                this.query = "SELECT * FROM dbt_utilities_type;";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // error handling  code here
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        public void refresh_dbt_tenants()
        {
            try
            {
                this.query = "SELECT * FROM dbt_tenants;";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // error handling  code here
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        public void refresh_dbt_job_position()
        {
            try
            {
                this.query = "SELECT * FROM dbt_job_position;";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // error handling  code here
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method
       
        public void refresh_dbt_submeter()
        {
            try
            {
                this.query = "SELECT * FROM dbt_submeter;";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // error handling  code here
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method

        public void refresh_dbt_utilities_reading()
        {
            try
            {
                this.query = "SELECT * FROM dbt_utilities_reading;";

                this.connect = new MySqlConnection(db.stringConnection());
                using (this.command = new MySqlCommand(this.query, this.connect))
                {
                    this.connect.Open();
                    this.command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // error handling  code here
            }
            finally
            {
                this.connect.Close();
            }
        }// end of the method


    }// end of the class
}
