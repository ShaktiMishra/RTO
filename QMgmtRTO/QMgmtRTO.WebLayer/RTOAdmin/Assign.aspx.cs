using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class Assign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fillstaffname();
                FillCountername();
                ChooseAdminServise();
            }
        }

        public void Fillstaffname()
        {
            try
            {
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.Account entObj = new Entities.Account();
                string centercode = Session["CenterCode"].ToString();
                DataTable dt = new DataTable();
                dt = accMgr.FillstaffBLL(centercode);
                if (dt.Rows.Count > 0)
                {
                    ddlstaffname.DataSource = dt;
                    ddlstaffname.DataTextField = "StaffName_VCR";
                    ddlstaffname.DataValueField = "StaffID_INT";
                    ddlstaffname.DataBind();
                    ddlstaffname.Items.Insert(0, new ListItem("Select A Staff", "0"));
                }
                else { }

            }
            catch { }
        }

        public void FillCountername()
        {
            try
            {
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOCounter entObj = new Entities.RTOCounter();
                DataTable dt = new DataTable();
                string centercode = Session["CenterCode"].ToString();
                dt = accMgr.FillCounterBLL(centercode);
                if (dt.Rows.Count > 0)
                {
                    ddlCounteName.DataSource = dt;
                    ddlCounteName.DataTextField = "CounterName_VCR";
                    ddlCounteName.DataValueField = "CounterID_INT";
                    ddlCounteName.DataBind();
                    ddlCounteName.Items.Insert(0, new ListItem("Select A Counter", "0"));
                }
                else { }

            }
            catch { }
        }

        public void ChooseAdminServise()
        {
            try
            {
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOService entObj = new Entities.RTOService();
                DataTable dt = new DataTable();
                string centercode = Session["CenterCode"].ToString();
                dt = accMgr.FillAdminserviceBLL(centercode);
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
        public static string displayAssigneddata()
        {
            BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
            Entities.RTOService entObj = new Entities.RTOService();
            DataTable dt = new DataTable();
            string centercode = HttpContext.Current.Session["CenterCode"].ToString();
            dt = accMgr.displayAssignedBLL(centercode);

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public static string updatetbldata(int id)
        {

            BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
            Entities.RTOService entObj = new Entities.RTOService();
            DataTable dt = new DataTable();
            string centercode = HttpContext.Current.Session["CenterCode"].ToString();
            dt = accMgr.EditAssignedBLL(id, centercode);

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ds);
            return JSONString;
        }

        [WebMethod]
        public static string deletetabledata(string id)
        {

            BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
            int dlt;
            string msg;
            DataTable dt = new DataTable();
            string centreCode = HttpContext.Current.Session["CenterCode"].ToString();
            dlt = accMgr.AssignservicedeleteBLL(Convert.ToInt32(id), centreCode);
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager serviceMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                int serviceentObj = 0;
                string centercode = Session["CenterCode"].ToString();
                string Btntype = btnsubmit.Text;
                int servicecount = ServiceCheckBoxList.Items.Cast<ListItem>().Count(li => li.Selected);
                if (servicecount != 0)
                {
                    foreach (ListItem lst in ServiceCheckBoxList.Items)
                    {
                        if (lst.Selected == true)
                        {
                            string ServiceName = lst.Text;
                            int ServiceId = Convert.ToInt32(lst.Value);
                            int Staffid = Convert.ToInt32(ddlstaffname.SelectedItem.Value);
                            int counterid = Convert.ToInt32(ddlCounteName.SelectedItem.Value);
                            int chkSSC = serviceMgr.AssignverifySSCBLL(ServiceId, counterid, Staffid, centercode);
                            if (chkSSC == 0)
                            {
                                serviceentObj = serviceMgr.AssignBLL(ServiceId, Staffid, counterid, centercode);
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
                    Response.Write("<script language='javascript'>window.alert('Staff Assigned SuccessFully');</script>");
                    ServiceCheckBoxList.ClearSelection();
                    ServiceCheckBoxListAll.Checked = false;
                    ddlstaffname.SelectedValue = "0";
                    ddlCounteName.SelectedValue = "0";
                    btnsubmit.Text = "Submit";
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


    }
}