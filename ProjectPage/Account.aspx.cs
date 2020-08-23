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
    public partial class Account : System.Web.UI.Page
    {
        Encrypt en = new Encrypt();
        MySqlConnection cn;
        ServerCon serv = new ServerCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["logged"]) == false)
            {
                Response.Redirect("~/");
            }
            CheckBox1.Enabled = false;

            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users where idusers='" + Session["idusers"].ToString() + "';", cn);
            var res = cmd.ExecuteReader();
            res.Read();
            TextBox2.Text = res[1].ToString();
            TextBox4.Text = res[2].ToString();
            CheckBox1.Checked = Convert.ToBoolean(res[4]);
            cn.Close();
        }
        protected void changepswd_Click(object sender, EventArgs e)
        {
            if(changepswd.Text== "Change Password")
            {
                changepswd.Text = "Save";
                passwd1.Visible = passwd2.Visible = passwd3.Visible = true;
            }
            else if(changepswd.Text=="Save")
            {
                cn = serv.Con();
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                MySqlCommand cmd = new MySqlCommand("select password from users where idusers =" + Session["idusers"].ToString(), cn);
                var res = cmd.ExecuteScalar();
                cn.Close();
                cn.Open();
                if (en.Decrypt(res.ToString()) == TextBox3.Text.Trim())
                {
                    cmd = new MySqlCommand("UPDATE users SET email = '" + TextBox2.Text + "'  ,usersname ='" + TextBox4.Text + "',password='" + en.Encrypts(TextBox5.Text) + "' WHERE idusers = " + Session["idusers"].ToString() + ";", cn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Password')</script>");
                }
                cn.Close();
                changepswd.Text = "Change Password";
                passwd1.Visible = passwd2.Visible = passwd3.Visible = false;
            }
        }
    }
}