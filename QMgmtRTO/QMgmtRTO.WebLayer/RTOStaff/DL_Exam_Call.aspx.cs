using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOStaff
{
    public partial class DL_Exam_Call : System.Web.UI.Page
    {
        DataAccessClass dl = new DataAccessClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    currday.Text = System.DateTime.Now.ToString("dd");
                    currmonth.Text = System.DateTime.Now.ToString("MMMM");
                }
            }
            catch { }
        }
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string call_next_token_no()
        {
            string msg = "";
            DataAccessClass da = new DataAccessClass();
            string datenow = DateTime.Now.ToString("dd-MM-yyyy");

            DataTable dt = da.getdataTable("select top 1 * from tbl_dl_next_tkn_call where Status='in' and pending_status='n' and date='" + datenow + "' order by Token_no asc");

            if (dt.Rows.Count > 0)
            {
                msg = dt.Rows[0]["Token_no"].ToString();
            }
            else
            {
                msg = "NEXT";
            }

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }



        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string Call_Next_Token(getdata data)
        {
            string msg = "";
            int up = 0;
            int tkno = 0;
            DataAccessClass da = new DataAccessClass();
            string datenow = DateTime.Now.ToString("dd-MM-yyyy");
            string timenow = DateTime.Now.ToString("hh.mm tt");

            try
            {
                DataTable dt = da.getdataTable("select top 1 * from tbl_dl_next_tkn_call where Status='in' and pending_status='n' and date='" + datenow + "' order by Token_no asc");
                if (dt.Rows.Count > 0)
                {
                    DataTable dtch = da.getdataTable("select * from tbl_dl_next_tkn_call where Status='out' and date='" + datenow + "' and Token_no='" + dt.Rows[0]["Token_no"].ToString() + "' order by Token_no asc");
                    if (dtch.Rows.Count > 0)
                    {
                        tkno = Convert.ToInt32(dtch.Rows[0]["Token_no"].ToString()) + 1;
                        DataTable dt1 = da.getdataTable("select * from tbl_dl_next_tkn_call where Status='in' and date='" + datenow + "' and Token_no='" + tkno + "' order by Token_no asc");

                        if (dt1.Rows.Count == 1)
                        {
                            up = da.ExecuteNonQuery("Update tbl_dl_next_tkn_call set Status='out',pending_status='c' where Token_no='" + tkno + "' and date='" + datenow + "'");
                            if (up > 0)
                            {
                                //int update_dl = da.ExecuteNonQuery("update tbl_dl_daily_pdf_data set Current_Status='AT DL TEST',time='" + timenow + "' where `Appl No.`='" + dt.Rows[0]["Appl_no"].ToString() + "'");


                                msg = "success";
                            }
                            else
                            {
                                msg = "Fail";
                            }
                        }
                        else if (dt1.Rows.Count > 1)
                        {
                            msg = "multiple button" + "_" + tkno.ToString();
                        }
                    }
                    else
                    {
                        DataTable dt1 = da.getdataTable("select * from tbl_dl_next_tkn_call where Status='in' and date='" + datenow + "' and Token_no='" + dt.Rows[0]["Token_no"].ToString() + "' order by Token_no asc");

                        if (dt1.Rows.Count == 1)
                        {
                            up = da.ExecuteNonQuery("Update tbl_dl_next_tkn_call set Status='out',pending_status='c' where Token_no='" + dt.Rows[0]["Token_no"].ToString() + "' and date='" + datenow + "'");
                            if (up > 0)
                            {
                                //int update_dl = da.ExecuteNonQuery("update tbl_dl_daily_pdf_data set Current_Status='AT DL TEST',time='" + timenow + "' where `Appl No.`='" + dt.Rows[0]["Appl_no"].ToString() + "'");

                                msg = "success";
                            }
                            else
                            {
                                msg = "Fail";
                            }
                        }
                        else if (dt1.Rows.Count > 1)
                        {
                            msg = "multiple button" + "_" + dt.Rows[0]["Token_no"].ToString();
                        }
                    }
                }
            }
            catch { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string multiplebutton(string data1)
        {

            DataAccessClass da = new DataAccessClass();
            string datenow = DateTime.Now.ToString("dd-MM-yyyy");

            DataTable dt1 = da.getdataTable("select Vehicle_type from tbl_dl_next_tkn_call where Status='in' and date='" + datenow + "' and Token_no='" + data1 + "' order by Token_no asc");

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt1);
            return JSONString;
        }


        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string call_MCWG(getdata data)
        {
            string msg = "";
            DataAccessClass da = new DataAccessClass();

            string datenow = DateTime.Now.ToString("dd-MM-yyyy");
            string timenow = DateTime.Now.ToString("hh.mm tt");

            int up_MCWG = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set Status='out',pending_status='c' where  date='" + datenow + "' and Vehicle_type='MCWG' and Token_no='" + data.tokn + "'");

            if (up_MCWG > 0)
            {
                DataTable dt = da.getdataTable("select * from tbl_dl_next_tkn_call where Status='in' and pending_status='n' and date='" + datenow + "' order by Token_no asc limit 1");

                //int update_dl = da.ExecuteNonQuery("update tbl_dl_daily_pdf_data set Current_Status='AT DL TEST',time='" + timenow + "' where `Appl No.`='" + dt.Rows[0]["Appl_no"].ToString() + "' and `Vehicle`='MCWG'");


                DataTable dtup_MCWG = da.getdataTable("select * from tbl_dl_next_tkn_call where Token_no='" + data.tokn + "' and Vehicle_type!='MCWG' and Status!='out' and  date='" + datenow + "'");

                if (dtup_MCWG.Rows.Count > 0)
                {
                    for (int i = 0; i < dtup_MCWG.Rows.Count; i++)
                    {
                        int up_MCWG1 = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set pending_status='p' where id='" + dtup_MCWG.Rows[i]["id"].ToString() + "'");
                    }
                }
                msg = "success";
            }
            else
            {
                msg = "Fail";
            }

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string call_LMV(getdata data)
        {
            string msg = "";
            DataAccessClass da = new DataAccessClass();

            string datenow = DateTime.Now.ToString("dd-MM-yyyy");
            string timenow = DateTime.Now.ToString("hh.mm tt");

            int up_LMV = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set Status='out',pending_status='c' where date='" + datenow + "' and Vehicle_type='LMV' and Token_no='" + data.tokn + "'");

            if (up_LMV > 0)
            {
                DataTable dt = da.getdataTable("select top 1 * from tbl_dl_next_tkn_call where Status='in' and pending_status='n' and date='" + datenow + "' order by Token_no asc ");

                //int update_dl = da.ExecuteNonQuery("update tbl_dl_daily_pdf_data set Current_Status='AT DL TEST',time='" + timenow + "' where `Appl No.`='" + dt.Rows[0]["Appl_no"].ToString() + "' and `Vehicle`='LMV'");

                DataTable dtup_LMV = da.getdataTable("select * from tbl_dl_next_tkn_call where Token_no='" + data.tokn + "' and Vehicle_type!='LMV' and Status!='out' and  date='" + datenow + "'");

                if (dtup_LMV.Rows.Count > 0)
                {
                    for (int i = 0; i < dtup_LMV.Rows.Count; i++)
                    {
                        int up_LMV1 = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set pending_status='p' where id='" + dtup_LMV.Rows[i]["id"].ToString() + "'");
                    }
                }
                msg = "success";
            }
            else
            {
                msg = "Fail";
            }

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string call_TRANS(getdata data)
        {
            string msg = "";
            DataAccessClass da = new DataAccessClass();

            string datenow = DateTime.Now.ToString("dd-MM-yyyy");
            string timenow = DateTime.Now.ToString("hh.mm tt");

            int up_TRANS = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set Status='out',pending_status='c' where date='" + datenow + "' and Vehicle_type='TRANS' and Token_no='" + data.tokn + "'");

            if (up_TRANS > 0)
            {
                DataTable dt = da.getdataTable("select top 1 * from tbl_dl_next_tkn_call where Status='in' and pending_status='n' and date='" + datenow + "' order by Token_no asc");

                //int update_dl = da.ExecuteNonQuery("update tbl_dl_daily_pdf_data set Current_Status='AT DL TEST',time='" + timenow + "' where `Appl No.`='" + dt.Rows[0]["Appl_no"].ToString() + "' and `Vehicle`='TRANS'");

                DataTable dtup_TRANS = da.getdataTable("select * from tbl_dl_next_tkn_call where Token_no='" + data.tokn + "' and Vehicle_type!='TRANS' and Status!='out' and  date='" + datenow + "'");

                if (dtup_TRANS.Rows.Count > 0)
                {
                    for (int i = 0; i < dtup_TRANS.Rows.Count; i++)
                    {
                        int up_TRANS1 = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set pending_status='p' where id='" + dtup_TRANS.Rows[i]["id"].ToString() + "'");
                    }
                }
                msg = "success";
            }
            else
            {
                msg = "Fail";
            }

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string call_MCWOG(getdata data)
        {
            string msg = "";
            DataAccessClass da = new DataAccessClass();

            string datenow = DateTime.Now.ToString("dd-MM-yyyy");
            string timenow = DateTime.Now.ToString("hh.mm tt");

            int up_MCWOG = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set Status='out',pending_status='c' where date='" + datenow + "' and Vehicle_type='MCWOG' and Token_no='" + data.tokn + "'");

            if (up_MCWOG > 0)
            {
                DataTable dt = da.getdataTable("select top 1 * from tbl_dl_next_tkn_call where Status='in' and pending_status='n' and date='" + datenow + "' order by Token_no asc ");

                //int update_dl = da.ExecuteNonQuery("update tbl_dl_daily_pdf_data set Current_Status='AT DL TEST',time='" + timenow + "' where `Appl No.`='" + dt.Rows[0]["Appl_no"].ToString() + "' and `Vehicle`='MCWOG'");

                DataTable dtup_MCWOG = da.getdataTable("select * from tbl_dl_next_tkn_call where Token_no='" + data.tokn + "' and Vehicle_type!='TRANS' and Status!='out' and  date='" + datenow + "'");

                if (dtup_MCWOG.Rows.Count > 0)
                {
                    for (int i = 0; i < dtup_MCWOG.Rows.Count; i++)
                    {
                        int up_MCWOG1 = da.ExecuteNonQuery("update tbl_dl_next_tkn_call set pending_status='p' where id='" + dtup_MCWOG.Rows[i]["id"].ToString() + "'");
                    }
                }
                msg = "success";
            }
            else
            {
                msg = "Fail";
            }


            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }
        public class getdata
        {
            public string Bid { get; set; }
            public string btnvalue { get; set; }
            public string tokn { get; set; }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}