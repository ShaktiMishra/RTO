using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.Display
{
    public partial class ServiceDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string urldata = HttpContext.Current.Request.RawUrl;
            string[] Utime = urldata.Split('-');
            string service = Utime[1];
            string ss = service.Replace("%20", " ");
            string centercode = Utime[2];
            

            bindtoken(ss,centercode);
        }


        public void bindtoken(string service,string centercode)
        {
            BusinessLayer.Display.tokendisplay bt = new BusinessLayer.Display.tokendisplay();
            try
            {
                int actualcount = 0;
                string str = "";
                int j = 0;
                string chk1stul = "";
                string chk2stul = "";
                string next = "";
                string current = "";
                string Upcoming = "";
                DataTable dt = new DataTable();
                //string service = "NEW LL";
                //string centercode = "BBS02";
                int tokencount = 0;

                dt = bt.SGetDisplayTokenBLL(service,centercode);


                if (dt.Rows.Count > 0)
                {
                    tokencount = dt.Rows.Count;
                    if (tokencount == 1)
                    {
                        current = dt.Rows[0]["TokenNo_INT"].ToString();
                        next = "NA";
                        Upcoming = "NA";
                    }
                    else if (tokencount == 2)
                    {
                        current = dt.Rows[0]["TokenNo_INT"].ToString();
                        next = dt.Rows[1]["TokenNo_INT"].ToString();
                        Upcoming = "NA";
                    }

                    else if (tokencount == 3)
                    {
                        current = dt.Rows[0]["TokenNo_INT"].ToString();
                        next = dt.Rows[1]["TokenNo_INT"].ToString();
                        Upcoming = dt.Rows[2]["TokenNo_INT"].ToString();
                    }
                    str += "<ul class=\"token-cont-row\">";
                    str += "<li class=\"flex-item\">" +
                                          "<div class=\"card\"><div class=\"body\"><div class=\"tok-box\"><div class=\"tok-head\">" +
                                       "<div class=\"tok-info\"><div class=\"tl2\"><h3>" + service + "</h3></div><div class=\"tl1\"><span> 1 </span>COUNTER</div>" +
                                       "</div></div><div class=\"tok-body\"><div class=\"tok-row\"><div class=\"all_div text-center\"><div class=\"cur_div\"><label>CURRENT</label>" +
                                        "<p>" + current + "</p></div><div class=\"nxt_div\"><label>NEXT</label><p>" + next + "</p></div><div class=\"nxt_div\"><label>UPCOMING</label><p>" + Upcoming + "</p>" +
                                         "</div></div></div></div></div></div></div></li>";


                    token.Text = str;
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (actualcount != 3 && actualcount != 6 && actualcount != 9)
                {
                    if (actualcount == 1 || actualcount == 4 || actualcount == 7)
                    {
                        sb.Append("".PadRight(64, ' ').Replace(" ", "&nbsp;"));
                        str += "<ul class=\"token-cont-row\">" +
                         "<li class=\"flex-item\">" +
                         sb.ToString() +
                                          "</li>" +
                                         "</ul>";
                        token.Text = str + sb.ToString();
                    }
                    else
                    {
                        sb.Append("".PadRight(71, ' ').Replace(" ", "&nbsp;"));
                        str += "<ul class=\"token-cont-row\">" +
                         "<li class=\"flex-item\">" +
                         sb.ToString() +
                                          "</li>" +
                                         "</ul>";
                        token.Text = str + sb.ToString();
                    }
                }

            }
            catch
            {

            }
        }
    }
}