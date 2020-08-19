using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace QMgmtRTO.WebLayer
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // [WebMethod]
        //[System.Web.Script.Services.ScriptMethod()]
        //public static string Passwordsend(string emailid)
        //{
        //    string msg = "";
        //    DataAccessClass da = new DataAccessClass();
        //    try
        //    {
        //        DataTable dtCenter = da.sgetdataTable("select * from centerdetails_db where Email='" + emailid + "'");
        //        System.Web.HttpContext.Current.Session["dbName"] = dtCenter.Rows[0]["DatabaseName"].ToString();
        //        string date = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");
        //        string[] k = date.Split(' ');
        //        string Sdate = k[0] + "-" + k[1] + "-" + k[2] + "-RegionalTransportOffice";
        //        DataTable dt = da.getdataTable("select * from tbl_staff  where Staff_mail='" + emailid + "' and Staff_status='1'");
        //        string Centercode = dtCenter.Rows[0]["CenterCode"].ToString();
        //        if (dt.Rows.Count > 0)
        //        {
        //            string Name = dt.Rows[0]["Staff_Name"].ToString();
        //            string staffcode = dt.Rows[0]["Staff_Code"].ToString();
        //            string link = "http://192.168.10.117/RTO/SetPassword.aspx?User-" + staffcode + "-" + Sdate + "-" + Centercode;
        //            string subject = "Welcome TO RTO";
        //            string description = "A unique link to set your password has been generated for you. To set your password, click the following link and follow the instructions.  " + link;
        //            string endPrt1 = "Regards,";
        //            string endPrt2 = "Team RTO";
        //            da.welcomemail(Name, emailid, subject, description, endPrt1, endPrt2);
        //            msg = "success";
        //        }
        //        else { msg = "Usuccess"; }
        //    }
        //    catch
        //    { }
        //    string JSONString = string.Empty;
        //    JSONString = JsonConvert.SerializeObject(msg);
        //    return JSONString;
        //}


    }
}