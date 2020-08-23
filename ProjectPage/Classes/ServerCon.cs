using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPage.Classes
{
    public class ServerCon
    {
        private string server = "77.75.95.65";
        private string database = "tempdb";
        private string uid = "fypuser";
        private string password = "CCNE@2020";
        private string connectionstring;
        public ServerCon()
        {
        }
        public MySqlConnection Con()
        {
            MySqlConnection cn;
            cn = new MySqlConnection(connectionstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";");
            return cn;
        }
    }
}