using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_management_system
{
    class DatabaseConnection
    {

        public string dbName = "final;";
        public string server = "localhost;";
        public string password = "";
        public string username = "root;";
        public string connectionString = null;

        public string stringConnection()
        {
            this.connectionString = ("server = " + this.server + "database = " + this.dbName + "uid = " + this.username + "password = " + this.password);
            return this.connectionString;
        }// end of the method
    }
}
