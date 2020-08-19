using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOStaff
{
    public partial class LL_Exam_Call : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            currday.Text = System.DateTime.Now.ToString("dd");
            currmonth.Text = System.DateTime.Now.ToString("MMMM");
            bindTokenCompleted();
            bindTokenWaiting();
        }
        public void bindTokenCompleted()
        {
            try
            {
                //string datenow = DateTime.Now.ToString("dd/MM/yyyy");

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                DataTable dt = new DataTable();

                dt = accMgr.gettotalTokenNumberCompleted();
                lbltotcompatbio.Text = dt.Rows[0]["c"].ToString();
            }
            catch { }
        }
        public void bindTokenWaiting()
        {
            try
            {
                //string datenow = DateTime.Now.ToString("dd/MM/yyyy");

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                DataTable dt = new DataTable();

                dt = accMgr.gettotalTokenNumberWaiting();
                lbltotwaitnearbio.Text = dt.Rows[0]["cc"].ToString();
            }
            catch { }
        }
        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                string datenow = DateTime.Now.ToString("dd/MM/yyyy");
                string timenow = DateTime.Now.ToString("HH:mm ss");

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOService entObj = new Entities.RTOService();
                DataTable dt = new DataTable();
                dt = accMgr.getLLTokenNumberCompleted(datenow);
                if (dt.Rows.Count > 0)
                {
                    entObj = accMgr.UpdateLLExamTokenBLL(datenow);
                    insertLLToken();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Called Successfully');", true);

                    txtfromno.Text = "";
                    txttono.Text = "";
                }
                else
                {
                    insertLLToken();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Called Successfully');", true);
                    txtfromno.Text = "";
                    txttono.Text = "";
                }

            }
            catch { }
        }
        public void insertLLToken()
        {
            try
            {
                string datenow = DateTime.Now.ToString("dd/MM/yyyy");
                string timenow = DateTime.Now.ToString("HH:mm ss");

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                Entities.RTOService entObj = new Entities.RTOService();
                entObj = accMgr.InsertLLExamTokenBLL(txtfromno.Text, txttono.Text, datenow, timenow);
            }
            catch
            { }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                getdatafromto();
            }
            catch { }
        }

        public void getdatafromto()
        {
            try
            {
                string datenow = DateTime.Now.ToString("dd/MM/yyyy");

                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                DataTable dt = new DataTable();
                dt = accMgr.getfromtoTokenNumber(datenow);

                if (dt.Rows.Count > 0)
                {
                    lblfrom.Text = dt.Rows[0]["from_token"].ToString();
                    lblto.Text = dt.Rows[0]["to_token"].ToString();
                }
            }
            catch { }
        }
    }
}