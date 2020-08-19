using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.Display
{
    public partial class QR_Scan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtsearchqr.Focus();
        }

        protected void txtsearchqr_TextChanged(object sender, EventArgs e)
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
                        string[] ap = txtsearchqr.Text.Split('|');
                        string applno = ap[0];
                        

                        DateTime date = Convert.ToDateTime(ap[1]);
                        string service = ap[2];


                        BusinessLayer.Display.EntranceManager accMgr = new BusinessLayer.Display.EntranceManager();
                        Entities.Display entObj = new Entities.Display();
                        //string centercode = "OD33";
                        string ServiceType = "";
                        DataTable dt = new DataTable();
                        dt = accMgr.GetQRDisplayTimeBLL(centercode);
                        string DisplayCenterTime = dt.Rows[0]["CentreTimeSet_INT"].ToString(); //30 min

                        DataTable dt1 = new DataTable();
                        dt1 = accMgr.GetQRSlotDetailsBLL(centercode, applno, date, service);


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

                            if (Time >= displayslottime && Time <= displaynextslottime)
                            {
                                DataTable DLslotdata = accMgr.GetQRTokenDetailsBLL(centercode, applno, date, service);
                                ServiceType = DLslotdata.Rows[0]["ApplicantBookedService_VCR"].ToString();
                                if (ServiceType != "")
                                {
                                    DateTime time = DateTime.Now;
                                    string Intime = time.ToString("hh.mm tt").ToString();
                                    string currentStatus = "Entrance";
                                    int P = accMgr.QRUpdatesTokenDetailsBLL(applno, centercode, currentStatus);
                                    if (P != 0)
                                    {
                                        Lblapplname.Text = DLslotdata.Rows[0]["ApplicantName_VCR"].ToString();
                                        lblapplno.Text = DLslotdata.Rows[0]["ApplicationNo_VCR"].ToString();
                                        lbltokenno.Text = DLslotdata.Rows[0]["TokenNo_INT"].ToString();
                                        lblsrvcname.Text = DLslotdata.Rows[0]["ApplicantBookedService_VCR"].ToString();
                                        txtsearchqr.Text = "";
                                        txtsearchqr.Focus();
                                    }
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Slot Time Not Available In This Time');", true);
                                txtsearchqr.Text = "";
                                txtsearchqr.Focus();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Slot Time Not Available In This Time');", true);
                            txtsearchqr.Text = "";
                            txtsearchqr.Focus();
                        }
                    }
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correst URL Address !!!');", true);
                //    txtsearchqr.Text = "";
                //    txtsearchqr.Focus();
                //}
            }
            catch { }
        }
    }
}