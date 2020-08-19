using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace QMgmtRTO.WebLayer.SuperAdmin
{
    public partial class SuperAdmin_AddCentre : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        #region New Implementation - SPM 17Jul2020

        #region C0 Function to Fetch Centre details - SPM - 14Jul2020
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string getAllCenterDetails()
        {
            DataTable dt = new DataTable();

            BusinessLayer.SuperAdmin.SuperAdminCentreManager centMgr = new BusinessLayer.SuperAdmin.SuperAdminCentreManager();
            Entities.RTOCentre centObj = new Entities.RTOCentre();

            try
            {

                dt = centMgr.SuperAdminGetAllCentresBLL();


                dt.Columns[0].ColumnName = "col0";//sl
                dt.Columns[1].ColumnName = "col1";//code
                dt.Columns[2].ColumnName = "col2";//logo
                dt.Columns[3].ColumnName = "col3";//name
                dt.Columns[4].ColumnName = "col4";//email
                dt.Columns[5].ColumnName = "col5";//mob
                dt.Columns[6].ColumnName = "col6";//add
                dt.Columns[7].ColumnName = "col7";//pin
                dt.Columns[8].ColumnName = "col8";//cr dt
                dt.Columns[9].ColumnName = "col9";//md dt
                dt.Columns[10].ColumnName = "col10";//act stats
                dt.Columns[11].ColumnName = "col11";//lgn stats
                dt.Columns[12].ColumnName = "col12";//msg tm

            }
            catch
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        #endregion


        #region C1 Function to Add Centre - SPM - 14Jul2020

        protected void btncreatecenter_Click(object sender, EventArgs e)
        {
        //string servername = "";
        
        //string Sdate = "";         
            
            BusinessLayer.SuperAdmin.SuperAdminCentreManager centMgr = new BusinessLayer.SuperAdmin.SuperAdminCentreManager();
            
            string centerName = txtcenter.Text;
            string center_code = txtcentercode.Text.Replace(" ", "").ToUpper();
            string email = txtemail.Text;


            try
            {
                if (hdnbtn.Value == "0")
                {

                    if (txtcentercode.Text == "")
                    {
                        Response.Write("<script language='javascript'>window.alert('Center Code Can Not Be Blank');</script>");
                        txtcenter.Focus();
                        return;
                    }



                    if (txtcenter.Text == "")
                    {
                        Response.Write("<script language='javascript'>window.alert('Center Name Can Not Be Blank');</script>");
                        txtcenter.Focus();
                        return;
                    }
                    if (txtemail.Text == "")
                    {
                        Response.Write("<script language='javascript'>window.alert('Email Field Can Not Be Blank');</script>");
                        txtemail.Focus();
                        return;
                    }


                    if (txtmobile.Text == "")
                    {
                        Response.Write("<script language='javascript'>window.alert('Mobile No. Can Not Be Blank');</script>");
                        txtaddress.Focus();
                        return;
                    }


                    if (txtaddress.Text == "")
                    {
                        Response.Write("<script language='javascript'>window.alert('Address Field Can Not Be Blank');</script>");
                        txtaddress.Focus();
                        return;
                    }

                    if (txtpostal.Text == "")
                    {
                        Response.Write("<script language='javascript'>window.alert('postal Code Can Not Be Blank');</script>");
                        txtpostal.Focus();
                        return;
                    }



                    //string date = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");

                    //SPM commented 18072020
                    // string[] k = date.Split(' ');
                    //Sdate = k[0] + "-" + k[1] + "-" + k[2] + "-RegionalTransportOffice";
                    //Random r = new Random();
                    //string ran_num = r.Next(100000, 999999).ToString();
                    //center_code = txtcenter.Text.ToUpper() + "_" + ran_num;


                    //added SPM18072020
                    //center_code = txtcentercode.Text;

                    //Check Center Name Same

                    //SPM 15Jul2020
                    //DataTable dt = da.sgetdataTable("select * from centerdetails_db where CenterName='" + txtcenter.Text + "'");

                    //DataTable dt = new DataTable();

                    // string centName = txtcenter.Text;

                    //oldimple-SPM 18072020
                    //dt = centMgr.SuperAdminGetCentreBLL(centName);

                    


                    int chkCentreList = centMgr.SuperAdminVerifyCentreRecordBLL(centerName);
                                        
                    if (chkCentreList != 0)
                    {
                        txtcentercode.Text = "";
                        txtcenter.Text = "";
                        txtemail.Text = "";
                        txtaddress.Text = "";
                        txtpostal.Text = "";
                        txtmobile.Text = "";

                        hdnbtn.Value = "0";
                        //txtcenter.Focus();

                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Centre Already Created!');", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Centre Already Created!');", true);

                    }
                    else
                    {

                        

                        Entities.RTOCentre centObj1 = new Entities.RTOCentre();


                        int p = centMgr.SuperAdminAddCentreBLL(center_code, centerName, email , txtmobile.Text, txtaddress.Text ,txtpostal.Text);

                        if (p > 0)
                        {
                            txtcentercode.Text = "";
                            txtcenter.Text = "";
                            txtemail.Text = "";
                            txtaddress.Text = "";
                            txtpostal.Text = "";
                            txtmobile.Text = "";

                            hdnbtn.Value = "0";

                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Center Details Created Successfully');", true);
                            //Response.Redirect(Request.RawUrl);
                        }
                    }
                }
                else if (hdnbtn.Value == "1")
                {
                    //string Ucentercode = Hdncenter.Value; // SPM cmtd 18072020
                    string centerslno = Hdnslno.Value; // SPM cmtd 18072020

                    if (centerslno != "0")
                    {
                        //int update = da.sExecuteNonQuery("update centerdetails_db set Email='" + txtemail.Text + "',Address='" + txtaddress.Text + "',Pin='" + txtpostal.Text + "',AdminMobNumber='" + txtmobile.Text + "',CenterName='" + txtcenter.Text + "' where CenterCode='" + Ucentercode + "'");
                        //int update = centMgr.SuperAdminUpdateCentreBLL(txtemail.Text, txtaddress.Text, txtpostal.Text, txtmobile.Text, txtcenter.Text, Ucentercode);

                        int update = centMgr.SuperAdminUpdateCentreBLL(centerslno, center_code, centerName, email , txtmobile.Text, txtaddress.Text ,txtpostal.Text);


                        if (update != 0)
                        {
                            
                            txtcentercode.Text = "";
                            txtcenter.Text = "";
                            txtemail.Text = "";
                            txtaddress.Text = "";
                            txtpostal.Text = "";
                            txtmobile.Text = "";

                            hdnbtn.Value = "0";

                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Center Details Updated Successfully');", true);
                            //Response.Redirect(Request.RawUrl);

                        }
                    }

                }
            }
            catch(Exception ec)
            {
                string a = ec.ToString();
                //Response.Redirect(Request.RawUrl);

            }
        }
        #endregion

        #region C2 Function to Delete Centre - SPM - 14Jul2020
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string deltetabledata(string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string msg = "";

            BusinessLayer.SuperAdmin.SuperAdminCentreManager centMgr = new BusinessLayer.SuperAdmin.SuperAdminCentreManager();
            Entities.RTOCentre centObj = new Entities.RTOCentre();

            try
            {
                string getid = id;
                //dt = da.sgetdataTable("select * from centerdetails_db where Cid='" + getid + "' and ActiveStatus='1'");

                //dt = centMgr.SuperAdminUpdateCentreBLL(getid);

                dt = centMgr.SuperAdminEditCentreBLL(getid);
                //int retn = da.sExecuteNonQuery("update centerdetails_db set ActiveStatus='0' where Cid='" + getid + "' and ActiveStatus='1'");
                int retn = centMgr.SuperAdminDeleteCentreBLL(getid);

                ds.Tables.Add(dt);

                if (retn > 0)
                {
                    msg = "success";
                }
                else
                {
                    msg = "Fail";
                }
            }

            catch
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;

        }
        #endregion

        #region C3 Function to Update Centre details - SPM - 14Jul2020
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string updatecenterdata(string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            BusinessLayer.SuperAdmin.SuperAdminCentreManager centMgr = new BusinessLayer.SuperAdmin.SuperAdminCentreManager();
            Entities.RTOCentre centObj = new Entities.RTOCentre();

            try
            {
                string getid = id;
                //dt = da.sgetdataTable("select * from centerdetails_db where Cid='" + getid + "' and ActiveStatus='1'");


                dt = centMgr.SuperAdminEditCentreBLL(getid);

                ds.Tables.Add(dt);

                dt.Columns[0].ColumnName = "col0";//sl
                dt.Columns[1].ColumnName = "col1";//code
                dt.Columns[2].ColumnName = "col2";//logo
                dt.Columns[3].ColumnName = "col3";//name
                dt.Columns[4].ColumnName = "col4";//email
                dt.Columns[5].ColumnName = "col5";//mob
                dt.Columns[6].ColumnName = "col6";//add
                dt.Columns[7].ColumnName = "col7";//pin
                dt.Columns[8].ColumnName = "col8";//cr dt
                dt.Columns[9].ColumnName = "col9";//md dt
                dt.Columns[10].ColumnName = "col10";//act stats
                dt.Columns[11].ColumnName = "col11";//lgn stats
                dt.Columns[12].ColumnName = "col12";//msg tm  


            }

            catch
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ds);
            return JSONString;

        }
        #endregion

        #endregion








    }
}