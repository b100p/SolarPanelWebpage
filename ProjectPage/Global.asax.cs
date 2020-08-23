using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ProjectPage
{
    public class Global : HttpApplication
    {
        public int count = 0;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["Date"] = DateTime.Today.ToShortDateString();
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            count = count + 1;
            Session["count"]= count;
        }
        protected void Session_End(object sender, EventArgs e)
        {
            Session.Abandon();
            count = count - 1;
            Session["count"]= count;
        }
    }
}