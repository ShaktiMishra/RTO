using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.Display
{

    public partial class Edisplay : System.Web.UI.Page
    {

        public static string datenow = DateTime.Now.ToString("dd/M/yyyy");
        //public string centercode="";
        public string[] URLCCode;
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
                string URL = HttpContext.Current.Request.Url.AbsoluteUri;
                string centercode = "";
                if (URL.Contains('-'))
                {
                    string[] URLCCode = URL.Split('-');
                    centercode = URLCCode[1];
                    if (centercode != string.Empty)
                    {
                        BusinessLayer.Display.EntranceManager accMgr = new BusinessLayer.Display.EntranceManager();
                        Entities.Display entObj = new Entities.Display();
                        string ServiceType = "";
                        DataTable dt = new DataTable();
                        dt = accMgr.GetDisplayTimeBLL(centercode);
                        string DisplayCenterTime = dt.Rows[0]["CentreTimeSet_INT"].ToString(); //30 min

                        DataTable dt1 = new DataTable();
                        dt1 = accMgr.GetSlotDetailsBLL(centercode);
                        if (dt1.Rows.Count > 0)
                        {
                            string slottime = dt1.Rows[0]["TokenSlotTime_VCR"].ToString();
                            string[] slottime1 = slottime.Split('-'); //8.30-9.30
                            int setmins = Convert.ToInt32(DisplayCenterTime);
                            DateTime convtslottime = DateTime.ParseExact(slottime1[0].ToString(), "HH.mm", System.Globalization.CultureInfo.CurrentCulture);
                            DateTime displayslottime = convtslottime.AddMinutes(-setmins);
                            string Reqslottime = displayslottime.ToString("hh.mm tt");
                            string displaytime = Reqslottime;  //8.00 AM

                            DateTime convtnextslottime = DateTime.ParseExact(slottime1[1].ToString(), "HH.mm", System.Globalization.CultureInfo.CurrentCulture);
                            DateTime displaynextslottime = convtnextslottime.AddMinutes(-setmins); //9.00
                            DateTime Time = DateTime.Now;

                            DataTable SWslotdata = accMgr.GetSWSlotDetailsBLL(slottime, centercode);
                            int NoOfService = SWslotdata.Rows.Count;

                            for (int i = 0; NoOfService > i; i++)
                            {
                                ServiceType = SWslotdata.Rows[i]["ApplicantBookedService_VCR"].ToString();

                                DataTable DLslotdata = accMgr.GetTokenDetailsBLL(ServiceType, slottime, centercode);

                                if (Time >= displayslottime && Time <= displaynextslottime)
                                {
                                    if (ServiceType == "DL")
                                    {
                                        if (DLslotdata.Rows.Count > 0)
                                        {
                                            int k = DLslotdata.Rows.Count;
                                            string start = DLslotdata.Rows[0]["TokenNo_INT"].ToString();
                                            string end = DLslotdata.Rows[k - 1]["TokenNo_INT"].ToString();
                                            string series = start + "-" + end;
                                            dllbltoken.Text = series;
                                        }
                                        else
                                        {
                                            dllbltoken.Text = "NA";
                                        }
                                    }

                                    if (ServiceType == "LL")
                                    {
                                        if (DLslotdata.Rows.Count > 0)
                                        {
                                            int k = DLslotdata.Rows.Count;
                                            string start = DLslotdata.Rows[0]["TokenNo_INT"].ToString();
                                            string end = DLslotdata.Rows[k - 1]["TokenNo_INT"].ToString();
                                            string series = start + "-" + end;
                                            lllbltoken.Text = series;
                                        }
                                        else
                                        {
                                            lllbltoken.Text = "NA";
                                        }
                                    }

                                }

                            }
                            if (Time >= displaynextslottime)
                            {

                                int P = accMgr.UpdateslotStatusBLL(slottime, ServiceType, centercode);

                            }

                        }
                        else
                        {
                            dllbltoken.Text = "NA";
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correst URL Address !!!');", true);
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
}