using MySql.Data.MySqlClient;
using ProjectPage.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPage
{
    public partial class Request : System.Web.UI.Page
    {
        MySqlConnection cn;
        ServerCon serv = new ServerCon();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void req_Click(object sender, EventArgs e)
        {
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd = new MySqlCommand("insert into request values('" + TextBox2.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}