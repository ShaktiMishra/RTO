using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOStaff
{
    public partial class RTOStaffDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            lbldate.Text = string.Format("{0:f}", date);
            string centercode = Session["LoginCode_VCR"].ToString();
            string LoginId = Session["LoginID_INT"].ToString();
            bindservies();
            bindCurrentTokenNo();
            bindtotalServedTokenNo();
        }

        public void bindCurrentTokenNo()
        {
            try
            {
                if (HttpContext.Current.Session["LoginCode_VCR"] != null)
                {
                    BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                    DataTable dt = new DataTable();
                    dt = accMgr.getCurrentTokenNumberServing();
                    if (dt.Rows.Count > 0)
                    {
                        lblcurrenttokenserving.Text = dt.Rows[0]["TokenNo_INT"].ToString();
                    }
                    else
                    {
                        lblcurrenttokenserving.Text = "NA";
                    }
                }
                else
                {
                }
            }
            catch { }
        }
        public void bindtotalServedTokenNo()
        {
            try
            {
                if (HttpContext.Current.Session["LoginCode_VCR"] != null)
                {
                    BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                    DataTable dt = new DataTable();
                    dt = accMgr.gettotalTokenNumberServed();
                    if (dt.Rows.Count > 0)
                    {
                        lbltotraltokenserved.Text = dt.Rows[0]["TokenNo_INT"].ToString();

                    }
                    else
                    {
                        lbltotraltokenserved.Text = "NA";
                    }
                }
                else
                {
                }
            }
            catch { }
        }
        //Check Services assign for staff
        public void bindservies()
        {
            try
            {
                if (HttpContext.Current.Session["LoginCode_VCR"] != null)
                {
                    string STR = "";
                    BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                    Entities.RTOService entObj = new Entities.RTOService();
                    string centercode = Session["LoginCode_VCR"].ToString();
                    DataTable dt = new DataTable();
                    dt = accMgr.getServicesOfparticularStaff(centercode);

                    lblstaffname.Text = dt.Rows[0]["StaffName_VCR"].ToString();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            STR += "<div class=\"demandBox\"><h2>" + dt.Rows[i]["ServiceName_VCR"].ToString() + "</h2></div>";
                        }
                        litservices.Text = STR;
                    }
                    else { }
                }
            }
            catch
            { }

        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOService entObj = new Entities.RTOService();

                if (HttpContext.Current.Session["LoginCode_VCR"] != null)
                {
                    DataTable dt = new DataTable();
                    string staffcode = Session["LoginCode_VCR"].ToString();
                    string[] cencode = staffcode.Split('_');
                    string c_code = cencode[0].ToString();

                    dt = accMgr.GetStaffAssignedServicesCounterBLL(staffcode);
                    string services = "";
                    string counterid = dt.Rows[0]["CounterCode_VCR"].ToString();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string serv = dt.Rows[i]["ServiceName_VCR"].ToString();
                        services = services + "," + serv;
                    }
                    services = services.TrimStart(',').TrimEnd(',');

                    entObj = accMgr.UpdateTokenBLL(services, counterid, staffcode);

                    bindservies();
                    bindCurrentTokenNo();
                    bindtotalServedTokenNo();
                }
                else { }
            }
            catch { }
        }

    }
}