using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Display_Gallery_Dispaly : System.Web.UI.Page
{
    DataAccessClass da = new DataAccessClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = System.DateTime.Now.ToString();
            GetseriesLLtokenNo();
            GetseriesDLtokenNo();
        }
    }
    public void GetseriesLLtokenNo()
    {
        try
        {
            string datenow = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable dt = da.getdataTable("SELECT * FROM tbl_entrance where date='" + datenow + "' and  Status='in' and Service='LL' group by Token Asc");
            if (dt.Rows.Count > 0)
            {
                int k = dt.Rows.Count;
                string start = dt.Rows[0]["Token"].ToString();
                string end = dt.Rows[k - 1]["Token"].ToString();
                string series = start + "-" + end;
                //if (start == end)
                //{
                //    GetcurrenLLttokenNo();
                //}
                //else
                //{
                lllbltoken.Text = series;
                //}
            }
            else { GetcurrenLLttokenNo(); }

            DataTable dtf = da.getdataTable("SELECT * FROM tbl_token where Scdate='" + datenow + "' and instatus='in' and Service_Short_Name='LL' group by TokenNo desc limit 1");
            if (dtf.Rows.Count > 0)
            {
                lllgbltoken.Text = dtf.Rows[0]["TokenNo"].ToString();

                DataTable dts = da.getdataTable("SELECT * FROM tbl_entrance where date='" + datenow + "' and Status='c' and Service='LL' group by Token Asc");
                if (dts.Rows.Count > 0)
                {
                    int k = dts.Rows.Count;
                    string start = dts.Rows[0]["Token"].ToString();
                    string end = dts.Rows[k - 1]["Token"].ToString();
                    string series = start + "-" + end;
                    if (start == end)
                    {
                        GetcurrenLLttokenNo();
                    }
                    else
                    {
                        lllgbltoken.Text = series;
                    }
                }
            }
        }
        catch { }
    }
    public void GetcurrenLLttokenNo()
    {
        try
        {
            string datenow = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable dt = da.getdataTable("SELECT * FROM tbl_token where Scdate='" + datenow + "' and instatus='in' and Service_Short_Name='LL' group by TokenNo desc limit 1");
            if (dt.Rows.Count > 0)
            {
                lllbltoken.Text = dt.Rows[0]["TokenNo"].ToString();
            }
        }
        catch { }
    }


    public void GetseriesDLtokenNo()
    {
        try
        {
            string datenow = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable dt = da.getdataTable("SELECT * FROM tbl_entrance where date='" + datenow + "' and  Status='in' and Service='DL' group by Token Asc");
            if (dt.Rows.Count > 0)
            {
                int k = dt.Rows.Count;
                string start = dt.Rows[0]["Token"].ToString();
                string end = dt.Rows[k - 1]["Token"].ToString();
                string series = start + "-" + end;
                if (start == end)
                {
                    GetcurrenDLttokenNo();
                }
                else
                {
                    dllbltoken.Text = series;
                }
            }
            else { GetcurrenDLttokenNo(); }

            DataTable dtd = da.getdataTable("SELECT * FROM tbl_token where Scdate='" + datenow + "' and instatus='in' and Service_Short_Name='DL' group by TokenNo desc limit 1");
            if (dtd.Rows.Count > 0)
            {
                dllbgltoken.Text = dtd.Rows[0]["TokenNo"].ToString();
                DataTable dts = da.getdataTable("SELECT * FROM tbl_entrance where date='" + datenow + "' and Status='c' and Service='DL' group by Token Asc");
                if (dts.Rows.Count > 0)
                {
                    int k = dts.Rows.Count;
                    string start = dts.Rows[0]["Token"].ToString();
                    string end = dts.Rows[k - 1]["Token"].ToString();
                    string series = start + "-" + end;
                    if (start == end)
                    {
                        GetcurrenLLttokenNo();
                    }
                    else
                    {
                        dllbgltoken.Text = series;
                    }
                }
            }
        }
        catch { }
    }
    public void GetcurrenDLttokenNo()
    {
        try
        {
            string datenow = DateTime.Now.ToString("dd/MM/yyyy");
            DataTable dt = da.getdataTable("SELECT * FROM tbl_token where Scdate='" + datenow + "' and instatus='in' and Service_Short_Name='DL' group by TokenNo desc limit 1");
            if (dt.Rows.Count > 0)
            {
                dllbltoken.Text = dt.Rows[0]["TokenNo"].ToString();
            }
        }
        catch { }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            GetseriesLLtokenNo();
            GetseriesDLtokenNo();
        }
        catch { }
    }
}