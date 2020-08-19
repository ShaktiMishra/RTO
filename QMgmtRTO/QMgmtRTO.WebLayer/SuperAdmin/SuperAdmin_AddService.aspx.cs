using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.SuperAdmin
{
    public partial class SuperAdmin_AddService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region S0 Gets all Services SPM 20072020
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string getAllService()
        {
            Entities.RTOService servObj = new Entities.RTOService();
            BusinessLayer.SuperAdmin.SuperAdminServiceManager servMgr = new BusinessLayer.SuperAdmin.SuperAdminServiceManager();


            DataTable dt = new DataTable();
            try
            {
                //dt = da.sgetdataTable("select * from Tbl_Service where Service_Status='1' order by Service_Name asc");

                dt = servMgr.SuperAdminGetAllServicesBLL();


                dt.Columns[0].ColumnName = "col0";//sl
                dt.Columns[1].ColumnName = "col1";//nam
                dt.Columns[2].ColumnName = "col2";//shnam
                dt.Columns[3].ColumnName = "col3";//cr dt
                dt.Columns[4].ColumnName = "col4";//mod dt
                dt.Columns[5].ColumnName = "col5";//act stats


                //dt = servObj..sgetdataTable("select * from Tbl_Service where Service_Status='1' order by Service_Name asc");

            }
            catch (Exception e)
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }
        #endregion

        

        #region S1,S3.2 Add or Update a Service in the table - SPM 20072020
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string saveservicename(getdata data) //cmtd SPM20072020 
        //public static string saveservicename(object data) //cmtd SPM20072020
        //public static string saveservicename(Entities. data)
        //public static string saveservicename(string ServiceName, string ServiceShortName, string btnvalue, string Bid)
        {            
            string msg = "";

            //DataAccessClass da = new DataAccessClass();
            BusinessLayer.SuperAdmin.SuperAdminServiceManager servMgr = new BusinessLayer.SuperAdmin.SuperAdminServiceManager();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                string ServiceName = data.ServiceName;
                string ServiceShortName = data.shtservicename;
                string ServiceType = data.Type;
                string btnvalue = data.btnvalue; //SPM 20072020
                string Bid = data.Bid;

                if (btnvalue == "0")
                {

                    //int insert = da.sExecuteNonQuery("insert into tbl_service (Service_Name,Service_Short_Name,Service_Status,create_date,modify_date)values('" + ServiceName.ToUpper() + "','" + ServiceShortName.ToUpper() + "',1,'" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "')");
                    //cmtd SPM -20072020

                    int insert = servMgr.SuperAdminAddServiceBLL(ServiceName.ToUpper(), ServiceShortName.ToUpper(), ServiceType);
                    
                    //int insert = da.sExecuteNonQuery("insert into tbl_service (Service_Name,Service_Short_Name,Service_Status,create_date,modify_date)values('" + ServiceName.ToUpper() + "','" + ServiceShortName.ToUpper() + "',1,'" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "')");
                    //cmtd above SPM 20072020

                    if (insert > 0)
                    {

                        msg = "success";
                    }
                    else
                    {
                        msg = "Fail";
                    }
                }
                else if (btnvalue == "1")
                {
                    //int update = da.sExecuteNonQuery("update Tbl_Service set Service_Name='" + ServiceName.ToUpper() + "',Service_Short_Name='" + ServiceShortName.ToUpper() + "'  where Service_Id='" + data.Bid + "'");
                    //cmtd abv SPM 20072020

                    int update = servMgr.SuperAdminUpdateServiceBLL(Bid, ServiceName.ToUpper(), ServiceShortName.ToUpper(), ServiceType);

                    if (update > 0)
                    {

                        msg = "Usuccess";
                    }
                    else
                    {
                        msg = "Fail";
                    }
                }

            }
            catch(Exception e) { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;

        }
        #endregion

        #region S3.1 Get Service to edit the table - SPM 20072020
        [WebMethod]
        public static string updatetbldata(string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            BusinessLayer.SuperAdmin.SuperAdminServiceManager servMgr = new BusinessLayer.SuperAdmin.SuperAdminServiceManager();
            Entities.RTOCentre centObj = new Entities.RTOCentre();

            try
            {
                string getid = id;
                //dt = da.sgetdataTable("select * from centerdetails_db where Cid='" + getid + "' and ActiveStatus='1'");


                dt = servMgr.SuperAdminEditServiceBLL(getid);

                //dt = da.sgetdataTable("select * from Tbl_Service where Service_Id='" + getid + "' and Service_Status='1'");
                //cmtd abv SPM20072020 

                ds.Tables.Add(dt);
                dt.Columns[0].ColumnName = "col0";//sl
                dt.Columns[1].ColumnName = "col1";//nam
                dt.Columns[2].ColumnName = "col2";//shnam
                dt.Columns[3].ColumnName = "col3";//stype
                dt.Columns[4].ColumnName = "col4";//cr dt
                dt.Columns[5].ColumnName = "col5";//mod dt
                dt.Columns[6].ColumnName = "col6";//act stats

            }
            catch
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ds);
            return JSONString;
        }
        #endregion

        #region S2 Deletes Service -SPM 20072020
        [WebMethod]        
        public static string deltetabledata(string id)
        {
            DataSet ds = new DataSet();
            BusinessLayer.SuperAdmin.SuperAdminServiceManager servMgr = new BusinessLayer.SuperAdmin.SuperAdminServiceManager();
            Entities.RTOService centObj = new Entities.RTOService();

            DataTable dt = new DataTable();
            string msg = "";            

                try
                {
                string getid = id;
                //dt = da.sgetdataTable("select * from centerdetails_db where Cid='" + getid + "' and ActiveStatus='1'");

                //dt = centMgr.SuperAdminUpdateCentreBLL(getid);

                dt = servMgr.SuperAdminEditServiceBLL(getid);
                //int retn = da.sExecuteNonQuery("update centerdetails_db set ActiveStatus='0' where Cid='" + getid + "' and ActiveStatus='1'");
                int retn = servMgr.SuperAdminDeleteServiceBLL(getid);

                ds.Tables.Add(dt);
                //string sts=dt.Rows[0]["status"].ToString();

                //int retn = da.sExecuteNonQuery("update Tbl_Service set Service_Status='" + 0 + "' where Service_Id='" + getid + "'");
                
                
                
                if (retn > 0)
                {

                    msg = "success";
                }
                else
                {
                    msg = "Fail";
                }

            }
            catch(Exception e)
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(msg);
            return JSONString;
        }
        #endregion

        #region S1.1 Verify shortservicename existence - SPM 20072020
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string Checkshortservicename(Userc user)
        //public static string Checkshortservicename(string serviceshortname)
        {
            //DataAccessClass da = new DataAccessClass();

            BusinessLayer.SuperAdmin.SuperAdminServiceManager servMgr = new BusinessLayer.SuperAdmin.SuperAdminServiceManager();

            string getRec = "0";
            try
            {
                //DataTable dtUsrNmLg = da.sgetdataTable("SELECT * from Tbl_service where Service_Short_Name='" + user.serviceshortname + "' and Service_Status='1'");
                //SPM 20072020

                //int chkServiceList = servMgr.SuperAdminVerifyServiceRecordBLL(serviceshortname);
                int chkServiceList = servMgr.SuperAdminVerifyServiceShNameRecordBLL(user.serviceshortname);


                //if (dtUsrNmLg.Rows.Count > 0) //SPM 20072020
                if (chkServiceList != 0)
                {
                    getRec = "1";
                }
            }
            catch (Exception e)
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(getRec);
            return JSONString;
        }
        #endregion


        #region S1.2 Verify servicename existence - SPM 20072020
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static string Checkservicename(Users user)
        //public static string Checkservicename(string servicename)
        {
            BusinessLayer.SuperAdmin.SuperAdminServiceManager servMgr = new BusinessLayer.SuperAdmin.SuperAdminServiceManager();

            string getRec = "0";
            try
            {
                //DataTable dtUsrNmLg = da.sgetdataTable("SELECT * from Tbl_service where Service_Short_Name='" + user.serviceshortname + "' and Service_Status='1'");
                //SPM 20072020

                int chkServiceList = servMgr.SuperAdminVerifyServiceNameRecordBLL(user.servicename);


                //if (dtUsrNmLg.Rows.Count > 0) //SPM 20072020
                if (chkServiceList != 0)
                {
                    getRec = "1";
                }
            }
            catch(Exception e)
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(getRec);
            return JSONString;
        }
        #endregion


        public class Users
        {
            public string servicename { get; set; }
        }
        public class getdata
        {
            public string ServiceName { get; set; }
            public string shtservicename { get; set; }
            public string Type { get; set; }
            public string Bid { get; set; }
            public string btnvalue { get; set; }
        }

        public class Userc
        {
            public string serviceshortname { get; set; }
        }


    }
}