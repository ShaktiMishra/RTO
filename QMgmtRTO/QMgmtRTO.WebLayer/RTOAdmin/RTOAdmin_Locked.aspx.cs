using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOAdmin
{
    public partial class RTOAdmin_Locked : System.Web.UI.Page
    {

        //DataAccessClass dl = new DataAccessClass();
        //BussinessLogicLayer bl = new BussinessLogicLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string Password = bl.Encryptdata(txtpassword.Text);
        //        DataTable dt = dl.getdataTable("select * from tbl_Staff where Password='" + Password + "' and Status !=0 and Type='Admin'");
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["Type"].ToString() == "Admin")
        //            {
        //                Response.Redirect("~/ADMIN/Dashboard.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Login Credential!');", true);
        //                return;
        //            }
        //        }
        //    }
        //    catch { }
        //}

    }
}