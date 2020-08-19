using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.Display
{
    public partial class LL_Exam_Series_Range_Dispaly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void bindtokenseries()
        {
            try
            {
                int from = 0;
                int to = 0;

                string datenow = DateTime.Now.ToString("dd/MM/yyyy");


                BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager accMgr = new BusinessLayer.RTOAdmin.RTOCounterStaffServiceManager();
                DataTable dt = new DataTable();

                dt = accMgr.getLLTokenNumberCompleted(datenow);
                if (dt.Rows.Count > 0)
                {
                    from = Convert.ToInt32(dt.Rows[0]["from_token"].ToString());
                    to = Convert.ToInt32(dt.Rows[0]["to_token"].ToString());

                    string series = from + "-" + to;

                    lbltokenseries.Text = series;
                }
                else
                {
                    lbltokenseries.Text = "NA";
                }

            }
            catch { }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bindtokenseries();
            }
            catch { }
        }
    }
}