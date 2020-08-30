using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;
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
    public partial class Manage : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                cn = serv.Con();
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users;", cn);
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataValueField ="idusers";
                DropDownList1.DataTextField ="usersname";
                DropDownList1.DataBind();
                cn.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users where idusers='"+DropDownList1.SelectedValue+"';", cn);
            var res = cmd.ExecuteReader();
            res.Read();
            TextBox1.Text = res[0].ToString();
            TextBox2.Text = res[1].ToString();
            TextBox3.Text = en.Decrypt(res[3].ToString());
            TextBox4.Text = res[2].ToString();
            CheckBox1.Checked = Convert.ToBoolean(res[4]);
            btnedit.Visible = true;
            btndelete.Visible = true;
            cn.Close();

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            cn = serv.Con();
            MySqlCommand cmd = new MySqlCommand();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            if (btnadd.Text == "New")
            {
                btnadd.Text = "Add";
                clear();
                cmd = new MySqlCommand("SELECT max(idusers) FROM users", cn);
                TextBox1.Text = (Convert.ToInt32(cmd.ExecuteScalar()) + 1).ToString();
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
                btnedit.Visible = false;
                btndelete.Visible = false;
                cn.Close();
            }
            else if(btnadd.Text == "Add")
            {
                btnadd.Text = "New";
                cmd = new MySqlCommand("insert into users values("+TextBox1.Text+",'"+TextBox2.Text+"','"+TextBox4.Text+"','"+en.Encrypts(TextBox3.Text)+"','"+CheckBox1.Checked+"')", cn);
                cmd.ExecuteNonQuery();
                clear();
                cmd = new MySqlCommand("SELECT * FROM users;", cn);
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataValueField = "idusers";
                DropDownList1.DataTextField = "usersname";
                DropDownList1.DataBind();
                cn.Close();

            }
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE users SET email = '"+TextBox2.Text+"'  ,usersname ='"+TextBox4.Text+"',password='"+en.Encrypts(TextBox3.Text)+"',admin='"+CheckBox1.Checked+"' WHERE idusers = "+TextBox1.Text+";", cn);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("SELECT * FROM users;", cn);
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataValueField = "idusers";
            DropDownList1.DataTextField = "usersname";
            DropDownList1.DataBind();
            clear();
            cn.Close();
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("Delete From users WHERE idusers = " + TextBox1.Text + ";", cn);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("SELECT * FROM users;", cn);
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataValueField = "idusers";
            DropDownList1.DataTextField = "usersname";
            DropDownList1.DataBind();
            clear();
            cn.Close();
        }
        public void clear()
        {
            for (int index = 0; index < Page.Form.Controls.Count; index++)
            {
                switch (Page.Form.Controls[index].GetType().ToString())
                {
                    case "TextBox":
                        (Page.Form.Controls[index] as TextBox).Text = "";
                        break;
                    case "CheckBox":
                        (Page.Form.Controls[index] as CheckBox).Checked = false;
                        break;
                }
            }
        }
    }
}