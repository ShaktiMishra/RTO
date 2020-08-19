using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer
{
    public partial class Setpassword : System.Web.UI.Page
    {
        public string[] Utime ;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //string urldata = HttpContext.Current.Request.Url.AbsoluteUri;
                //string[] Utime = urldata.Split('-');
                //string Sendtime = Utime[2] + " " + Utime[3] + " " + Utime[4];
                //DateTime Sendtime1 = DateTime.ParseExact(Sendtime, "dd/MM/yyyy h:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                //DateTime Sendtime2 = Sendtime1.AddHours(1);
                //string Reqslottime = Sendtime2.ToString("hh:mm tt");
                //string CTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                //DateTime CTTime = DateTime.ParseExact(CTime, "dd/MM/yyyy h:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                //if (CTTime >= Sendtime2)
                //{
                //    Response.Redirect("404.aspx");
                //}
                //else
                //{

                //}
            }
            catch { }
        }

        protected void btnsetpsw_Click(object sender, EventArgs e)
        {
            BusinessLayer.PasswordEncryp psw = new BusinessLayer.PasswordEncryp();
            try
            {
                string urldata = HttpContext.Current.Request.Url.AbsoluteUri;
                string[] Utime = urldata.Split('-');
                string scode=Utime[1];
                //string centerid=Utime[6];
                //string stype=Utime[7];
                string PASSWORD = txtpsw.Text;
                string CPASSWORD = txtcpsw.Text;
                string EPsw = psw.Encryptdata(PASSWORD);
                int Pws = psw.passwordsave(EPsw, scode);

                if (Pws > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('Thanks! Your Password has been set successfully.');window.location='../RTO/SetPassword.aspx?-thanku';</script>");
                }
               
            
            }
            catch
            { }
        }
    }
}