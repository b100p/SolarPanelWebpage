using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPage
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manage.Visible = false ;
            Label1.Text = DateTime.Now.Year.ToString();
            if (Convert.ToBoolean(Session["admin"]) == true)
            {
                manage.Visible = true;
            }
            counts.Text= "Logged in users: " + Session["count"].ToString();
            startdate.Text ="Site been up and running since: " + Application["Date"].ToString();
            if (Convert.ToBoolean(Session["logged"]) == false)
            {
                logout.Visible = false;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {

            Session["logged"] = false;
            manage.Visible = false;
            Response.Redirect("~/");

            
        }
    }
}