using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Display_DL_Dispaly_for_Result : System.Web.UI.Page
{
    DataAccessClass da = new DataAccessClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
    public void bindgrid()
    {
        try
        {
            string datenow = DateTime.Now.ToString("d/M/yyyy");

            DataTable dt = da.getdataTable("select dpd.`s.` as token,dpd.`Appl No.` as applno,dpd.`Applicant` as appli,dpd.`Mobile No.` as mobno,dpd.`Slot Date` as stdt,dpd.`Slot Time` as sttim, dr.Vehicle, dr.Result from tbl_dl_result as dr inner join tbl_dl_daily_pdf_data as dpd on (dr.`Applicant_No`=dpd.`Appl No.`) and (dr.`Vehicle` =dpd.`Vehicle`) where dr.`Result_date`='" + datenow.ToString() + "' order by dr.`id` desc  limit 15");

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch { }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblresult = (e.Row.FindControl("lblresult") as Label);

                foreach (TableCell cell in e.Row.Cells)
                {
                    if (lblresult.Text == "PASS")
                    {
                        cell.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        cell.BackColor = Color.OrangeRed;
                    }
                }
            }
        }
        catch { }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            bindgrid();
        }
        catch { }
    }
}