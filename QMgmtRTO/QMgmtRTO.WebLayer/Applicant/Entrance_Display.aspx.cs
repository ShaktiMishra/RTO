using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Display_Entrance_Display : System.Web.UI.Page
{
    DataAccessClass da = new DataAccessClass();
    public static string datenow = DateTime.Now.ToString("dd/M/yyyy");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showslottime();
        }
    }
    public void showslottime()
    {
        try
        {
            DataTable dt = da.getdataTable("SELECT * FROM display_time_setting");
            string[] settime = dt.Rows[0]["Time"].ToString().Split(' '); //ex= 5 min


            //string datenow = DateTime.Now.ToString("yyyy-dd-MM");
            DataTable DLslot = da.getdataTable("SELECT top 1 count(slotTime) as NoSlot,slotTime FROM tbl_token_create where date='" + datenow + "' and Status='1' group by slotTime");
            if (DLslot.Rows.Count > 0)
            {
                string slottime = DLslot.Rows[0]["slotTime"].ToString(); // Ex=08.30-09.30
                string[] sslottime = slottime.Split('-');
                string displaytime = "";

                if (settime[1].ToString() == "Hours")
                {
                    int sethours = Convert.ToInt32(settime[0].ToString());
                    DateTime Hconvtslottime = DateTime.ParseExact(sslottime[0].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime Hdisplayslottime = Hconvtslottime.AddHours(-sethours);
                    string Reqslottime = Hdisplayslottime.ToString("hh.mm tt");
                    displaytime = Reqslottime;

                    DateTime Hconvtnextslottime = DateTime.ParseExact(sslottime[0].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime Hdisplaynextslottime = Hconvtnextslottime.AddHours(-sethours);
                    DateTime HTime = DateTime.Now;

                    if (HTime >= Hdisplayslottime && HTime <= Hdisplaynextslottime)
                    {
                        DataTable DLslotdata = da.getdataTable("SELECT * FROM tbl_token_create where Date='" + datenow + "' and slotTime='" + slottime + "'");
                        if (DLslotdata.Rows.Count > 0)
                        {
                            int k = DLslotdata.Rows.Count;
                            string start = DLslotdata.Rows[0]["id"].ToString();
                            string end = DLslotdata.Rows[k - 1]["id"].ToString();
                            string series = start + "-" + end;
                            dllbltoken.Text = series;
                            //dldisplaytime.Text = displaytime;
                        }
                        else
                        {
                            dllbltoken.Text = "NA";
                            //dldisplaytime.Text = "NA";
                        }
                    }


                }
                else
                {
                    int setmins = Convert.ToInt32(settime[0].ToString());
                    DateTime convtslottime = DateTime.ParseExact(sslottime[0].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime displayslottime = convtslottime.AddMinutes(-setmins);
                    string Reqslottime = displayslottime.ToString("hh.mm tt");
                    displaytime = Reqslottime;  //8.25 AM

                    DateTime convtnextslottime = DateTime.ParseExact(sslottime[1].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime displaynextslottime = convtnextslottime.AddMinutes(-setmins);
                    DateTime Time = DateTime.Now;

                    if (Time >= displayslottime && Time <= displaynextslottime)
                    {
                        DataTable DLslotdata = da.getdataTable("SELECT * FROM tbl_token_create where Date='" + datenow + "' and slotTime='" + slottime + "'");
                        if (DLslotdata.Rows.Count > 0)
                        {
                            int k = DLslotdata.Rows.Count;
                            string start = DLslotdata.Rows[0]["id"].ToString();
                            string end = DLslotdata.Rows[k - 1]["id"].ToString();
                            string series = start + "-" + end;
                            dllbltoken.Text = series;
                            // dldisplaytime.Text = displaytime;
                        }
                        else
                        {
                            dllbltoken.Text = "NA";
                            // dldisplaytime.Text = "NA";
                        }
                    }
                    if (Time >= displaynextslottime)
                    {
                        int P = da.ExecuteNonQuery("Update tbl_token_create set Status='0' where Date='" + datenow + "' and slotTime='" + slottime + "' ");
                    }
                }
            }
            else
            {
                dllbltoken.Text = "NA";
                // dldisplaytime.Text = "NA";
            }

            //Code For LL...............................................................................................................................



            DataTable LLslot = da.getdataTable("SELECT TOP 1 count(slotTime) as NoSlot,slotTime FROM tbl_lltoken_create where date='" + datenow + "' and Status='1' group by slotTime");
            if (LLslot.Rows.Count > 0)
            {
                string LLslottime = LLslot.Rows[0]["slotTime"].ToString(); // Ex=08.30-09.30
                string[] LLsslottime = LLslottime.Split('-');
                string displaytime = "";

                if (settime[1].ToString() == "Hours")
                {
                    int LLsethours = Convert.ToInt32(settime[0].ToString());
                    DateTime LLHconvtslottime = DateTime.ParseExact(LLsslottime[0].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime LLHdisplayslottime = LLHconvtslottime.AddHours(-LLsethours);
                    string LLReqslottime = LLHdisplayslottime.ToString("hh.mm tt");
                    displaytime = LLReqslottime;

                    DateTime LLHconvtnextslottime = DateTime.ParseExact(LLsslottime[1].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime LLHdisplaynextslottime = LLHconvtnextslottime.AddHours(-LLsethours);
                    DateTime LLHTime = DateTime.Now;

                    if (LLHTime >= LLHdisplayslottime && LLHTime <= LLHdisplaynextslottime)
                    {
                        DataTable LLslotdata = da.getdataTable("SELECT * FROM tbl_lltoken_create where Date='" + datenow + "' and slotTime='" + LLslottime + "'");
                        if (LLslotdata.Rows.Count > 0)
                        {
                            int k = LLslotdata.Rows.Count;
                            string start = LLslotdata.Rows[0]["id"].ToString();
                            string end = LLslotdata.Rows[k - 1]["id"].ToString();
                            string series = start + "-" + end;
                            lllbltoken.Text = series;
                            //lldisplaytime.Text = displaytime;
                        }
                        else
                        {
                            lllbltoken.Text = "NA";
                            //lldisplaytime.Text = "NA";
                        }
                    }
                    if (LLHTime >= LLHdisplaynextslottime)
                    {
                        int P = da.ExecuteNonQuery("Update tbl_lltoken_create set Status='0' where Date='" + datenow + "' and slotTime='" + LLslottime + "' ");
                    }

                }
                else
                {
                    int LLsetmins = Convert.ToInt32(settime[0].ToString());
                    DateTime LLconvtslottime = DateTime.ParseExact(LLsslottime[0].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime LLdisplayslottime = LLconvtslottime.AddMinutes(-LLsetmins);
                    string LLReqslottime = LLdisplayslottime.ToString("hh.mm tt");
                    displaytime = LLReqslottime;  //8.25 AM

                    DateTime LLconvtnextslottime = DateTime.ParseExact(LLsslottime[1].ToString(), "hh.mm", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime LLdisplaynextslottime = LLconvtnextslottime.AddMinutes(-LLsetmins);
                    DateTime LLTime = DateTime.Now;

                    if (LLTime >= LLdisplayslottime && LLTime <= LLdisplaynextslottime)
                    {
                        DataTable LLslotdata = da.getdataTable("SELECT * FROM tbl_lltoken_create where Date='" + datenow + "' and slotTime='" + LLslottime + "'");
                        if (LLslotdata.Rows.Count > 0)
                        {
                            int k = LLslotdata.Rows.Count;
                            string start = LLslotdata.Rows[0]["id"].ToString();
                            string end = LLslotdata.Rows[k - 1]["id"].ToString();
                            string series = start + "-" + end;
                            lllbltoken.Text = series;
                            //lldisplaytime.Text = displaytime;
                        }
                        else
                        {
                            lllbltoken.Text = "NA";
                            //lldisplaytime.Text = "NA";
                        }
                    }
                    if (LLTime >= LLdisplaynextslottime)
                    {
                        int P = da.ExecuteNonQuery("Update tbl_lltoken_create set Status='0' where Date='" + datenow + "' and slotTime='" + LLslottime + "' ");
                    }
                }
            }
            else
            {
                lllbltoken.Text = "NA";
                //dldisplaytime.Text = "NA";
            }
        }
        catch { }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            showslottime();
        }
        catch { }
    }
}