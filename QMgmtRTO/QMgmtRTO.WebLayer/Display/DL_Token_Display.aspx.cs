using QMgmtRTO.WebLayer.RTOStaff;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.Display
{
    public partial class DL_Token_Display : System.Web.UI.Page
    {
        DataAccessClass dl = new DataAccessClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bindtoken();
                bindtoken1();
            }
            catch { }
        }

        public void bindtoken()
        {
            try
            {
                string datenow = DateTime.Now.ToString("dd/MM/yyyy");

                DataTable dtLMV = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='out' and pending_status='c' and Vehicle_type='LMV' order by Token_no desc ");

                if (dtLMV.Rows.Count > 0)
                {
                    lbl_tokenLMV.Text = dtLMV.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_tokenLMV.Text = "NA";
                }


                DataTable dtMCWG = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='out' and pending_status='c' and Vehicle_type='MCWG' order by Token_no desc ");

                if (dtMCWG.Rows.Count > 0)
                {
                    lbl_tokenMCWG.Text = dtMCWG.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_tokenMCWG.Text = "NA";
                }

                DataTable dtMCWOG = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='out' and pending_status='c' and Vehicle_type='MCWOG' order by Token_no desc ");

                if (dtMCWOG.Rows.Count > 0)
                {
                    lbl_tokenMCWOG.Text = dtMCWOG.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_tokenMCWOG.Text = "NA";
                }

                DataTable dtTRANS = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='out' and pending_status='c' and Vehicle_type='TRANS' order by Token_no desc ");

                if (dtTRANS.Rows.Count > 0)
                {
                    lbl_tokenTRANS.Text = dtTRANS.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_tokenTRANS.Text = "NA";
                }
            }
            catch { }
        }
        public void bindtoken1()
        {
            try
            {
                string datenow = DateTime.Now.ToString("dd/MM/yyyy");

                DataTable dtLMV = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='in' and pending_status='p' and Vehicle_type='LMV' order by Token_no desc ");

                if (dtLMV.Rows.Count > 0)
                {
                    lbl_lmvPending.Text = dtLMV.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_lmvPending.Text = "NA";
                }


                DataTable dtMCWG = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='in' and pending_status='p' and Vehicle_type='MCWG' order by Token_no desc ");

                if (dtMCWG.Rows.Count > 0)
                {
                    lbl_mcwgPending.Text = dtMCWG.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_mcwgPending.Text = "NA";
                }

                DataTable dtMCWOG = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='in' and pending_status='p' and Vehicle_type='MCWOG' order by Token_no desc ");

                if (dtMCWOG.Rows.Count > 0)
                {
                    lbl_mcwogPending.Text = dtMCWOG.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_mcwogPending.Text = "NA";
                }

                DataTable dtTRANS = dl.getdataTable("select top 1 * from tbl_dl_next_tkn_call where date='" + datenow + "' and Status='in' and pending_status='p' and Vehicle_type='TRANS' order by Token_no desc ");

                if (dtTRANS.Rows.Count > 0)
                {
                    lbl_transPending.Text = dtTRANS.Rows[0]["Token_no"].ToString();
                }
                else
                {
                    lbl_transPending.Text = "NA";
                }
            }
            catch { }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
        {
            bindtoken();
            bindtoken1();
        }
        catch { }
        }
    }
}