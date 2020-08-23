using MySql.Data.MySqlClient;
using ProjectPage.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ProjectPage
{
    public partial class MainPage : System.Web.UI.Page
    {
        
        MySqlConnection cn;
        ServerCon serv = new ServerCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["logged"]) == false)
            {
                Response.Redirect("~/");
            }
            List<string> drp = new List<string>();
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("select  Local_Time from solarpanel limit 10000", cn);
            var res = cmd.ExecuteReader();
            while (res.Read())
            {
                drp.Add(DateTime.Parse(res[0].ToString()).ToString("MM/dd/yy"));
            }
            if (!Page.IsPostBack)
            {
                DropDownList1.DataSource = drp.Distinct();
                DropDownList1.DataBind();
            }
            cmd = new MySqlCommand("select  Local_Time from solarpanel limit 100000", cn);
            res.Close();
            drp.Clear();
            res = cmd.ExecuteReader();
            while (res.Read())
            {
                drp.Add(DateTime.Parse(res[0].ToString()).ToString("MM/yy"));
            }
            if (!Page.IsPostBack)
            {
                DropDownList3.Items.Add("Winter");
                DropDownList3.Items.Add("Spring");
                DropDownList3.Items.Add("Summer");
                DropDownList3.Items.Add("Autumn");
                DropDownList2.DataSource = drp.Distinct();
                DropDownList2.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tempdb.solarpanel where Local_Time like '%" + DropDownList1.SelectedValue + "%';", cn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Chart1.DataSource = dt;
            Chart1.DataBind();
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Line;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            string dat = DropDownList2.SelectedValue;
            string finaldate = dat.Insert(3, "%/");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tempdb.solarpanel where Local_Time like '%" + finaldate + "%';", cn);
            var res = cmd.ExecuteReader();
            DateTime date;
            double power=0;
            DateTime temp = new DateTime(2006, 1, 1);
            double i = 0;
            int j = 0;
            double avg = 1;
            string[] x = new string[10];
            double[] y = new double[10];
            bool once = false;
            while (res.Read())
            {
                i++;
                date = DateTime.Parse(res[0].ToString());
                power = Convert.ToDouble(res[1].ToString());
                if (!once)
                {
                    x = new string[DateTime.DaysInMonth(date.Year, date.Month)];
                    y = new double[DateTime.DaysInMonth(date.Year, date.Month)];
                    once = true;
                }
                if (date.Day == temp.Day)
                {
                    avg += power;  
                }
                else
                {
                    x[j] = temp.Day.ToString();
                    y[j] = avg / i;
                    j++;
                    avg = 0;
                    i = 0;
                    avg += power;
                    temp = temp.AddDays(1);
                }
            }
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            Chart1.ChartAreas[0].AxisY.Interval = 1;
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Column;
        }

        private string getSeason(DateTime date)
        {
            float value = (float)date.Month + date.Day / 100;   // <month>.<day(2 digit)>
            if (value < 3.21 || value >= 12.22) return "Winter";   // Winter
            if (value < 6.21) return "Spring"; // Spring
            if (value < 9.23) return "Summer"; // Summer
            return "Autumn";   // Autumn
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn = serv.Con();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tempdb.solarpanel;", cn);
            var res = cmd.ExecuteReader();
            DateTime date;
            double power = 0;
            DateTime temp = new DateTime(2006, 1, 1);
            double i = 0;
            int j = 0;
            double avg = 1;
            string[] x = new string[10];
            double[] y = new double[10];
            bool once = false;
            while (res.Read())
            {
                date = DateTime.Parse(res[0].ToString());
                power = Convert.ToDouble(res[1].ToString());
                if (getSeason(date) == DropDownList3.SelectedValue)
                {
                    i++;

                    if (!once)
                    {
                        if (DropDownList3.SelectedValue == "Winter")
                        {
                            x = new string[200];
                            y = new double[200];
                        }else if (DropDownList3.SelectedValue == "Autumn")
                        {
                            x = new string[100];
                            y = new double[100];
                        }
                        else if (DropDownList3.SelectedValue == "Autumn")
                        {
                            x = new string[100];
                            y = new double[100];
                        }
                        else if (DropDownList3.SelectedValue == "Summer")
                        {
                            x = new string[100];
                            y = new double[100];
                        }
                            once = true;
                    }
                    if (date.Day == temp.Day)
                    {
                        avg += power;
                    }
                    else
                    {
                        x[j] = temp.Month.ToString();
                        y[j] = avg / i;
                        j++;
                        avg = 0;
                        i = 0;
                        avg += power;
                        temp = temp.AddDays(1);
                    }
                }
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].AxisY.Interval = 1;
                Chart1.Series[0].Points.DataBindXY(x, y);
                Chart1.Series[0].ChartType = SeriesChartType.Line;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}