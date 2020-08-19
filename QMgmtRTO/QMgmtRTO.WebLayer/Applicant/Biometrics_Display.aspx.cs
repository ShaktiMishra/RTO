using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Display_Biometrics_Display : System.Web.UI.Page
{
    DataAccessClass dl = new DataAccessClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bindtoken1();
        }
        catch { }
    }

    public void bindtoken1()
    {
        try
        {
            DataTable dt = new DataTable(); //use for LL
            DataTable dtd = new DataTable();//use for DL
            string STR = "";
            string STR1 = "";
            string STR2 = "";
            string STR3 = "";

            string datenow = DateTime.Now.ToString("dd/MM/yyyy");


            //for LL..............................................

            dt = dl.getdataTable("select top 1 TokenNo,CounterNumber from tbl_biometrictoken  where Bidate='" + datenow + "' and instatus='out' and Service_Name='LL' order by Token_Id desc ");

            if (dt.Rows.Count > 0)
            {
                int num = Convert.ToInt32(dt.Rows[0]["TokenNo"].ToString());

                if (num % 2 == 0)
                {
                    STR += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dt.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Learners License(LL)</strong><br/> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dt.Rows[0]["TokenNo"].ToString() + "</strong></div></div>";
                    token.Visible = true;
                    token2.Visible = false;
                    token.Text = STR;
                }
                else
                {
                    STR2 += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dt.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Learners License(LL)</strong><br/> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dt.Rows[0]["TokenNo"].ToString() + "</strong></div></div>";
                    token2.Visible = true;
                    token.Visible = false;
                    token2.Text = STR2;
                }
            }
            else
            {
                //token.Text = "NA";
                //token2.Text = "NA";
            }


            //for DL....................................................................

            dtd = dl.getdataTable("select top 1 TokenNo,CounterNumber from tbl_biometrictoken where Bidate='" + datenow + "' and instatus='out' and Service_Name='DL' order by Token_Id desc");

            if (dtd.Rows.Count > 0)
            {
                int num1 = Convert.ToInt32(dtd.Rows[0]["TokenNo"].ToString());

                if (num1 % 2 == 0)
                {
                    STR1 += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dtd.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Driving License(LL)</strong><br /> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dtd.Rows[0]["TokenNo"].ToString() + "</strong></div></div>";
                    token1.Visible = true;
                    token3.Visible = false;
                    token1.Text = STR1;
                }
                else
                {
                    STR3 += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dtd.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Driving License(LL)</strong><br /> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dtd.Rows[0]["TokenNo"].ToString() + "</strong></div></div>";
                    token3.Visible = true;
                    token1.Visible = false;
                    token3.Text = STR3;
                }
            }
            else
            {
                //token1.Text = "NA";
                //token3.Text = "NA";
            }
        }
        catch { }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            bindtoken1();
        }
        catch { }
    }
}