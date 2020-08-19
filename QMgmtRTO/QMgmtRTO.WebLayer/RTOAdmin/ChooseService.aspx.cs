using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOAdmin
{
    public partial class ChooseService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChooseServise();
            }
        }

        public void ChooseServise()
        {
            try
            {
               BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOService entObj = new Entities.RTOService();
                DataTable dt = new DataTable();
                dt = accMgr.FillserviceBLL();
                if (dt.Rows.Count > 0)
                {
                    ServiceCheckBoxList.DataSource = dt;
                    ServiceCheckBoxList.DataTextField = "ServiceName_VCR";
                    ServiceCheckBoxList.DataValueField = "ServiceID_INT";
                    ServiceCheckBoxList.DataBind();

                }
            }
            catch { }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string displayselectedService()
        {
            BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
            Entities.RTOService entObj = new Entities.RTOService();
            string centercode = HttpContext.Current.Session["CenterCode"].ToString();
            DataTable dt = new DataTable();
            dt = accMgr.displayserviceBLL(centercode);

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager serviceMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                int serviceentObj = 0;
                string CenterCode = Session["CenterCode"].ToString();
                //string CenterCode ="C_";
                string Btntype = btnSubmit.Text;
                int servicecount = ServiceCheckBoxList.Items.Cast<ListItem>().Count(li => li.Selected);
                if (servicecount != 0)
                {
                    if (btnSubmit.Text == "Update")
                    {
                        serviceentObj = serviceMgr.admindltserviceBLL(CenterCode);
                    }

                    foreach (ListItem lst in ServiceCheckBoxList.Items)
                    {
                        if (lst.Selected == true)
                        {
                            string ServiceName = lst.Text;
                            int ServiceId = Convert.ToInt32(lst.Value);
                            string date = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");
                            int chkServiceList = serviceMgr.AdminVerifyServiceBLL(ServiceName, ServiceId, CenterCode);
                            if (chkServiceList == 0)
                            {
                                serviceentObj = serviceMgr.adminchooseserviceBLL(ServiceName, ServiceId, CenterCode);
                            }
                            else
                            {
                                lst.Selected = false;
                            }
                        }

                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Please Choose Sevice Name');</script>");
                    return;
                }
                if (serviceentObj > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('Service Details Added SuccessFully');</script>");
                    ServiceCheckBoxList.ClearSelection();
                    ServiceCheckBoxListAll.Checked = false;
                    btnSubmit.Text = "Submit";
                }
            }
            catch { }
        }

        protected void ServiceCheckBoxListAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in ServiceCheckBoxList.Items)
                {
                    item.Selected = ServiceCheckBoxListAll.Checked;
                }
            }
            catch { }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnSubmit.Text = "Update";
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOService entObj = new Entities.RTOService();
                DataTable dt = new DataTable();
                string centercode = Session["CenterCode"].ToString();
                dt = accMgr.displayserviceBLL(centercode);

                foreach (ListItem item in ServiceCheckBoxList.Items)
                {
                    string values = item.Text.ToString();
                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["ServiceName_VCR"].ToString();
                        if (values == id)
                        {
                            item.Selected = true;
                        }
                    }
                }

            }
            catch { }
        }
    }
}