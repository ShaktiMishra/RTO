using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOAdmin
{
    public partial class RTOAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie LoginCookie = Request.Cookies["Id"];
            //if (LoginCookie != null)
            //{
            //    string name = LoginCookie != null ? LoginCookie.Value.Split('=')[1] : "undefined";
            //}
            //else
            //{
            //    Response.Redirect("../Logininfo.aspx");
            //}
        }

        protected void btnlogout_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //HttpCookie LoginCookie = Request.Cookies["Id"];
                //LoginCookie.Expires = DateTime.Now.AddDays(-1);
                //Response.Cookies.Add(LoginCookie);
                Response.Redirect("../Logininfo.aspx");
            }
            catch { }
        }
        protected void btnlogin2_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //HttpCookie LoginCookie = Request.Cookies["Id"];
                //LoginCookie.Expires = DateTime.Now.AddDays(-1);
                //Response.Cookies.Add(LoginCookie);
                Response.Redirect("../Logininfo.aspx");
            }
            catch { }
        }

    }
}