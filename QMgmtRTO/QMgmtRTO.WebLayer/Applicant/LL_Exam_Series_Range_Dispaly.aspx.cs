using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Display_LL_Exam_Series_Range_Dispaly : System.Web.UI.Page
{
    DataAccessClass da = new DataAccessClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bindtokenseries();
        }
        catch { }
    }
    public void bindtokenseries()
    {
        try
        {
            int from = 0;
            int to = 0;

            string datenow = DateTime.Now.ToString("dd/MM/yyyy");

            DataTable dt = da.getdataTable("select * from tbl_ll_exam_series_call where status='1' and date='" + datenow + "'");
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

            



            //DataTable dt1 = da.getdataTable("select *  from tbl_biometrictoken  where Bidate='" + datenow + "' and instatus='out' and Service_Name='LL' and LL_exam_calll_status ='EC' order by Token_Id asc limit " + no + "");

            //int k = dt1.Rows.Count;
            //string start = dt1.Rows[0]["TokenNo"].ToString();
            //string end = dt1.Rows[k - 1]["TokenNo"].ToString();
            //string series = start + "-" + end;

            //if (start == end)
            //{
            //    lbltokenseries.Text = "NA";
            //}
            //else
            //{
            //    lbltokenseries.Text = series;
            //}
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