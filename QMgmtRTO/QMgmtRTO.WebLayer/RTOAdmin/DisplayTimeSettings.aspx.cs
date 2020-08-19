using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOAdmin
{
    public partial class DisplayTimeSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndisplaytime_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager serviceMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                int min = 0;
                string Ttype = ddldisplaytime.SelectedValue;
                string Time = txtdisplaytime.Text;
                if (Ttype == "1")
                {
                    min = 60 * Convert.ToInt32(Time);
                }
                else
                {
                    min = Convert.ToInt32(Time);
                }
                string centercode = Session["CenterCode"].ToString();
                int inserttime = serviceMgr.AdminSetDisplayTimedBLL(centercode, min);
                if (inserttime > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('Display Time Set SuccessFully');</script>");
                    txtdisplaytime.Text = "";
                }
            }
            catch { }
        }
    }
}