using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QMgmtRTO.Entities;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace QMgmtRTO.DataAccessLayer.SuperAdmin
{
    public class SuperAdminCentreDAO : DataAccessLayer.Common.DAO
    {
        Entities.RTOCentre entObj = new Entities.RTOCentre();
        
        # region SuperAdmin Dashboard Page Call
        public DataSet SuperAdminGetCentreDAL()
        {
            //QMgmtRTO.DataAccessLayer.Common.DAO da = new QMgmtRTO.DataAccessLayer.Common.DAO();

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                //dt = da.sgetdataTable("select count(*) as TS from centerdetails_db where ActiveStatus='1'");
                //dt = sgetdataTable("select count(*) as TS from centerdetails_db where ActiveStatus='1'");
                ds.Tables.Add(dt);
            }
            catch
            { }

            
            return ds;

        }
        #endregion

        #region C0 SuperAdmin gets all centres table - SPM - 14Jul2020
        public DataTable SuperAdminGetAllCentresDAL()
        {

            DataTable dt1;
            RTOCentre centObj1 = new RTOCentre();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter para1;
                    para1 = new SqlParameter("@Event", "Select");
                    dt1 = ExecuteSPDataTable(db, "RTO_spCentreDetails", para1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt1;
        }
        #endregion

        #region C1.1 Verifies if Centre exists in the database - SPM 18072020
        public int SuperAdminVerifyCentreRecordDAO(string centreName)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "Verify");
                    paras[1] = new SqlParameter("@CentreName_VCR", centreName);

                    NonQueryResult = ExecuteSPScalar(db, "RTO_spCentreDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }

            return NonQueryResult;


            //throw new NotImplementedException();
        }
        #endregion

        #region C1.2 Adds a centre to the table - SPM 18072020
        public int SuperAdminAddCentreDAL(RTOCentre entObj1)
        {

        int NonQueryResult = 0;
        int EmailSendResult = 0;
        try
        {
            using (IDbConnection db = GetConnection())
            {

                SqlParameter[] paras = new SqlParameter[8];

                paras[0] = new SqlParameter("@Event", "Add");
                paras[1] = new SqlParameter("@CentreCode_VCR", entObj1.CentreCode_VCR);
                paras[2] = new SqlParameter("@CentreLogo_VCR", entObj1.CentreLogo_VCR);
                paras[3] = new SqlParameter("@CentreName_VCR", entObj1.CentreName_VCR);
                paras[4] = new SqlParameter("@CentreEmailID_VCR", entObj1.CentreEmailID_VCR);
                paras[5] = new SqlParameter("@CentreMobileNo_VCR", entObj1.CentreMobileNo_VCR);
                paras[6] = new SqlParameter("@CentreAddress_VCR", entObj1.CentreAddress_VCR);
                paras[7] = new SqlParameter("@CentrePINCode_VCR", entObj1.CentrePINCode_VCR);

                NonQueryResult = ExecuteSPNonQuery(db, "RTO_spCentreDetails", paras);
                EmailSendResult = SendEmailDAL(entObj1.CentreCode_VCR, entObj1.CentreName_VCR, entObj1.CentreEmailID_VCR);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to verify credentials" + ex);
                }

            if (NonQueryResult != 0 && EmailSendResult != 0)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }
        #endregion

        #region C1.3 Sends email after centre creation - SPM 18072020
        public int SendEmailDAL(string centercode, string centername, string email)
        {
            int emailSendSuccess = 0;

            try
            {

                //string link = "http://localhost/RTO/SetPassword.aspx?SuperAdmin-" + center_code + "-" + Sdate + "-" + center_code + "-C";


                string link = "http://192.168.10.117/RTO/SetPassword.aspx?Admin-" + centercode + "-" + centername;

                string subject = "Welcome TO RTO";
                string description = "A unique link to set your password has been generated for you. To set your password, click the following link and follow the instructions.  " + link;
                string endPrt1 = "Regards,";
                string endPrt2 = "Team RTO";



                string body = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Email_Format/WelcomeMail.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", centername);
                body = body.Replace("{subject}", subject);
                body = body.Replace("{description}", description);
                body = body.Replace("{endPrt1}", endPrt1);
                body = body.Replace("{endPrt2}", endPrt2);

                this.SendHtmlFormattedEmail(email, subject, body);

                emailSendSuccess = 1;

            }


            catch(Exception e)
            {
                emailSendSuccess = 0;
            }

            return emailSendSuccess;

        }

        #endregion

        #region C2 SuperAdmin Delete Centre 19Jul2020
        public int SuperAdminDeleteCentreDAL(string getid)
        {
            //dt = da.sgetdataTable("select * from centerdetails_db where ActiveStatus='1' order by CenterName Asc");

            //DataTable dt1;
            int NonQueryResult = 0;
            RTOCentre centObj1 = new RTOCentre();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "Delete");
                    paras[1] = new SqlParameter("@CentreID_INT", getid);

                    NonQueryResult = ExecuteSPNonQuery(db, "RTO_spCentreDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return NonQueryResult;

        }
        #endregion

        #region C3.1 SuperAdmin Fetches DataTable to Edit Centre - SPM - 14Jul2020
        public DataTable SuperAdminEditCentreDAL(string getid)
        {
            DataTable dt1;
            RTOCentre centObj1 = new RTOCentre();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "Edit");
                    paras[1] = new SqlParameter("@CentreID_INT", getid);

                    dt1 = ExecuteSPDataTable(db, "RTO_spCentreDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt1;
        }
        #endregion

        #region C3.2 Updates the centre details - SPM 19072020

        public int SuperAdminUpdateCentreDAL(RTOCentre entObj1)
        {
            int NonQueryResult = 0;
            string centreModifyTime = System.DateTime.Now.ToString();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[9];
                    paras[0] = new SqlParameter("@Event", "Update");
                    paras[1] = new SqlParameter("@CentreID_INT", entObj1.CentreID_INT);
                    paras[2] = new SqlParameter("@CentreCode_VCR", entObj1.CentreCode_VCR);
                    paras[3] = new SqlParameter("@CentreLogo_VCR", entObj1.CentreLogo_VCR);
                    paras[4] = new SqlParameter("@CentreName_VCR", entObj1.CentreName_VCR);
                    paras[5] = new SqlParameter("@CentreEmailID_VCR", entObj1.CentreEmailID_VCR);
                    paras[6] = new SqlParameter("@CentreMobileNo_VCR", entObj1.CentreMobileNo_VCR);
                    paras[7] = new SqlParameter("@CentreAddress_VCR", entObj1.CentreAddress_VCR);
                    paras[8] = new SqlParameter("@CentrePINCode_VCR", entObj1.CentrePINCode_VCR);

                    NonQueryResult = ExecuteSPNonQuery(db, "RTO_spCentreDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return NonQueryResult;
        }
        #endregion            

    }
}
