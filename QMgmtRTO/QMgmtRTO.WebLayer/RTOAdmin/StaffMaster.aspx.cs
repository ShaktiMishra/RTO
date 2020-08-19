using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOAdmin
{
    public partial class StaffMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string centercode = Session["CenterCode"].ToString();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtStaffname.Text = "";
                txtMobileNo.Text = "";
                txtemail.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffname.Text != "" && txtMobileNo.Text != "" && txtemail.Text != "")
                {
                    string stname = txtStaffname.Text;
                    string email = txtemail.Text;
                    string centercode = Session["CenterCode"].ToString();
                    Random r = new Random();
                    string randomcode = r.Next(100000, 999999).ToString();
                    string staffcode = centercode + "_" + stname[0].ToString() + "" + randomcode;

                    string dt = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");
                    string[] k = dt.Split(' ');
                    string Sdate = k[0] + "-" + k[1] + "-" + k[2] + "-RegionalTransportOffice";


                    BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                    Entities.Account entObj = new Entities.Account();

                    
                    entObj = accMgr.StaffAddBLL(txtStaffname.Text, txtMobileNo.Text, txtemail.Text, staffcode, centercode);

                    string link = "http://192.168.10.117/RTO/SetPassword.aspx?User-" + staffcode + "-" + Sdate + "-" + centercode;
                    string subject = "Welcome TO RTO";
                    string description = "A unique link to set your password has been generated for you. To set your password, click the following link and follow the instructions.  " + link;
                    string endPrt1 = "Regards,";
                    string endPrt2 = "Team RTO";

                    welcomemail(stname, email, subject, description, endPrt1, endPrt2);


                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved Successfully');", true);
                    txtStaffname.Text = "";
                    txtMobileNo.Text = "";
                    txtemail.Text = "";
                    txtStaffname.Focus();
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill All The Blank Field !!!!!!');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void welcomemail(string Name, string emailId, string subject, string description, string endPrt1, string endPrt2)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/RTOAdmin/Email_Format/WelcomeMail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", Name);
            body = body.Replace("{subject}", subject);
            body = body.Replace("{description}", description);
            body = body.Replace("{endPrt1}", endPrt1);
            body = body.Replace("{endPrt2}", endPrt2);

            this.SendHtmlFormattedEmail(emailId, subject, body);
        }


        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            string[] cred = mailcredential();
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(cred[0].ToString());
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = cred[1].ToString();
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(cred[2].ToString(), cred[3].ToString());
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = Convert.ToInt32(cred[4].ToString());
                smtp.Send(mailMessage);
            }
        }

        public string[] mailcredential()
        {
            string[] cred = new string[5];
            cred[0] = "webtownsolution123@gmail.com";//from mail
            cred[1] = "smtp.gmail.com";//smtp.host
            cred[2] = "webtownsolution123@gmail.com";//Username
            cred[3] = "123@123#";//password
            cred[4] = "587";//port Number
            return cred;
        }
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string getAllStaffDetails()
        {
            BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
            Entities.Account entObj = new Entities.Account();
            DataTable dt = new DataTable();
            string centercode = HttpContext.Current.Session["CenterCode"].ToString();
            dt = accMgr.displayStaffBLL(centercode);

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public static string deletetabledata(int id)
        {

            BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
            int dlt;
            string msg;
            DataTable dt = new DataTable();
            // string staffcode = "1";
            string Centerid = HttpContext.Current.Session["CenterCode"].ToString();
            dlt = accMgr.staffdeleteBLL(id, Centerid);
            if (dlt > 0)
            {
                msg = "success";
            }
            else

            {
                msg = "unsuccess";
            }

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string stname = txtStaffname.Text;
                string email = txtemail.Text;
                string centercode = Session["CenterCode"].ToString();
                Random r = new Random();
                string randomcode = r.Next(100000, 999999).ToString();
                string staffcode = centercode + "_" + stname[0].ToString() + "" + randomcode;

                string dt = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");
                string[] k = dt.Split(' ');
                string Sdate = k[0] + "-" + k[1] + "-" + k[2] + "-RegionalTransportOffice";

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.Account entObj = new Entities.Account();

                int id = Convert.ToInt32(hidden1.Value);

                entObj = accMgr.StaffUpdateBLL(txtStaffname.Text, txtMobileNo.Text, txtemail.Text, staffcode, id, centercode);


                string link = "http://192.168.10.117/RTO/SetPassword.aspx?User-" + staffcode + "-" + Sdate + "-" + centercode;
                string subject = "Welcome TO RTO";
                string description = "A unique link to set your password has been generated for you. To set your password, click the following link and follow the instructions.  " + link;
                string endPrt1 = "Regards,";
                string endPrt2 = "Team RTO";

                welcomemail(stname, email, subject, description, endPrt1, endPrt2);


                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated Successfully');", true);
                txtStaffname.Text = "";
                txtMobileNo.Text = "";
                txtemail.Text = "";
                txtStaffname.Focus();
                btnsubmit.Visible = true;
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}