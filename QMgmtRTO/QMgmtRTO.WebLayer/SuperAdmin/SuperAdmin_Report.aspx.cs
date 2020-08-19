using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.SuperAdmin
{
    public partial class SuperAdminReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcentrelist();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            BusinessLayer.ReportsManager repMgr = new BusinessLayer.ReportsManager();

            DataTable dt = new DataTable();

            dt = repMgr.GetCentreReportBLL(DropDownList1.SelectedValue);


            GridView1.DataSource = dt;
            GridView1.DataBind();

            //DropDownList1.DataSource = dt;
            //DropDownList1.DataBind();
            //DropDownList1.DataTextField = "CentreName_VCR";
            //DropDownList1.DataValueField = "CentreName_VCR";
            //DropDownList1.DataBind();


        }

        protected void loadcentrelist()
        {

            BusinessLayer.ReportsManager repMgr = new BusinessLayer.ReportsManager();

            DataTable dt = new DataTable();

            dt = repMgr.GetCentreListBLL();



            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "CentreName_VCR";
            DropDownList1.DataValueField = "CentreName_VCR";
            DropDownList1.DataBind();

            //DropDownList1.Items.Add(new ListItem("-Select-", string.Empty));
            //DropDownList1.SelectedItem.Value = "-Select-";


        }

    }
}