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
    public partial class CounterMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string centercode = Session["CenterCode"].ToString();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string dt = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");
                //string centercode = "C";
                string centercode = Session["CenterCode"].ToString();

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOCounter entObj = new Entities.RTOCounter();


                int chkcountlist = accMgr.AdminVerifyCounterBLL(txtcountername.Text, txtdevicecode.Text, centercode);
                if (chkcountlist == 0)
                {
                    entObj = accMgr.CounterAddBLL(txtcountername.Text, txtdevicecode.Text, centercode);

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved Successfully');", true);
                    txtcountername.Text = "";
                    txtdevicecode.Text = "";
                    txtcountername.Focus();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something Went Wrong!!!!!!!!!!!!');", true);
                }
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtcountername.Text = "";
                txtdevicecode.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string getAllCounterDetails()
        {
            BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
            Entities.RTOCounter entObj = new Entities.RTOCounter();
            DataTable dt = new DataTable();
            string centercode = HttpContext.Current.Session["CenterCode"].ToString();
            //string centercode = Session["CenterCode"].ToString();
            dt = accMgr.displayCounterBLL(centercode);

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
            //string Centerid = "1";
            string Centerid = HttpContext.Current.Session["CenterCode"].ToString();
            dlt = accMgr.counterdeleteBLL(id, Centerid);
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
                string dt = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOCounter entObj = new Entities.RTOCounter();

                int id = Convert.ToInt32(hidden1.Value);
                string centercode = Session["CenterCode"].ToString();
                entObj = accMgr.CounterUpdateBLL(txtcountername.Text, txtdevicecode.Text, dt, id, centercode);

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated Successfully');", true);
                txtcountername.Text = "";
                txtdevicecode.Text = "";
                txtcountername.Focus();
                btnsubmit.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}