using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QMgmtRTO.BusinessLayer;

namespace QMgmtRTO.WebLayer.Display
{
    public partial class TokenDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string urldata = HttpContext.Current.Request.Url.AbsoluteUri;
                string[] Utime = urldata.Split('-');
                string service = Utime[1];
                string centercode = Utime[2];

                bindtoken1(service,centercode);
            }
        }

        public void bindtoken1(string service,string centercode)
        {
            BusinessLayer.Display.tokendisplay bt = new BusinessLayer.Display.tokendisplay();
            try
            {
                DataTable dt = new DataTable(); //use for LL
                DataTable dtd = new DataTable();//use for DL
                string STR = "";
                string STR1 = "";
                string STR2 = "";
                string STR3 = "";

                //string service = "NEW LL";
                //string centercode = "BLS06";

                //string datenow = DateTime.Now.ToString("dd/MM/yyyy");
                dt = bt.GetDisplayTokenBLL(service,centercode);

                if (dt.Rows.Count > 0)
                {
                    int num = Convert.ToInt32(dt.Rows[0]["TokenNo_INT"].ToString());

                    if (num % 2 == 0)
                    {
                        STR += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dt.Rows[0]["CounterName_VCR"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">"+service+"</strong><br/> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dt.Rows[0]["TokenNo_INT"].ToString() + "</strong></div></div>";

                        token.Visible = true;
                        token2.Visible = false;
                        token.Text = STR;
                    }
                    else
                    {
                        STR2 += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dt.Rows[0]["CounterName_VCR"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">"+service+"</strong><br/> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dt.Rows[0]["TokenNo_INT"].ToString() + "</strong></div></div>";

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

































                //for LL..............................................

                //dt = dl.getdataTable("select TOP 1  e.Token,t.CounterNumber from tbl_entrance e inner join tbl_token t on (e.Applicationno=t.Application_Number) where e.date='" + datenow + "' and e.Status='out' and e.Service='LL' order by t.Token_Id desc");

                //if (dt.Rows.Count > 0)
                //{
                //    int num = Convert.ToInt32(dt.Rows[0]["Token"].ToString());

                //    if (num % 2 == 0)
                //    {
                //        STR += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dt.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Learners License(LL)</strong><br/> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dt.Rows[0]["Token"].ToString() + "</strong></div></div>";

                //        token.Visible = true;
                //        token2.Visible = false;
                //        token.Text = STR;
                //    }
                //    else
                //    {
                //        STR2 += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dt.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Learners License(LL)</strong><br/> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dt.Rows[0]["Token"].ToString() + "</strong></div></div>";

                //        token2.Visible = true;
                //        token.Visible = false;
                //        token2.Text = STR2;
                //    }
                //}
                //else
                //{
                //    //token.Text = "NA";
                //    //token2.Text = "NA";
                //}


                ////for DL....................................................................

                //dtd = dl.getdataTable("select TOP 1  e.Token,t.CounterNumber from tbl_entrance e inner join tbl_token t on (e.Applicationno=t.Application_Number) where e.date='" + datenow + "' and e.Status='out' and e.Service='DL' order by t.Token_Id desc");

                //if (dtd.Rows.Count > 0)
                //{
                //    int num1 = Convert.ToInt32(dtd.Rows[0]["Token"].ToString());

                //    if (num1 % 2 == 0)
                //    {
                //        STR1 += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dtd.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Driving License(DL)</strong><br /> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dtd.Rows[0]["Token"].ToString() + "</strong></div></div>";

                //        token1.Visible = true;
                //        token3.Visible = false;
                //        token1.Text = STR1;
                //    }
                //    else
                //    {
                //        STR3 += "<div class=\"tile-header dvd dvd-btm\"><div class=\"text-center\"><h1 class=\"custom-font\"><strong class=\"st-class\">" + dtd.Rows[0]["CounterNumber"].ToString() + "</strong></h1></div></div> <div class=\"tile-body h\"><div class=\"text-center\"><strong class=\"st-class1\">Driving License(DL)</strong><br /> <strong class=\"st-class1\">Token Number</strong><br /><strong class=\"st-class12\">" + dtd.Rows[0]["Token"].ToString() + "</strong></div></div>";

                //        token3.Visible = true;
                //        token1.Visible = false;
                //        token3.Text = STR3;
                //    }
                //}
                //else
                //{
                //    //token1.Text = "NA";
                //    //token3.Text = "NA";
                //}
            }
            catch { }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //bindtoken1();
        }
    }
}