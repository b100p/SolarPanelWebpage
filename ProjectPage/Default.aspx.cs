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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["logged"])==true)
            {
                Response.Redirect("~/MainPage.aspx");
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Encrypt en = new Encrypt();
            MySqlConnection cn;
            ServerCon serv = new ServerCon();
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from users where usersname=@user", cn);
            cmd.Parameters.AddWithValue("@user", username.Text.ToLower().Trim());
            var res = cmd.ExecuteReader();

            if (res.HasRows)
            {
                res.Read();
                if (en.Decrypt(res[3].ToString()) == pswd.Text.Trim())
                {
                    Session["logged"] = true;
                    Session["idusers"] = res[0].ToString();
                    Session["User"] = res[2].ToString();
                    Session["admin"] = res[4].ToString();
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
                
        }
    }
}