using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using QMgmtRTO.Entities;
using System.Data.SqlClient;
using System.IO;

namespace QMgmtRTO.DataAccessLayer
{
    public class AccountManagerDAO : DataAccessLayer.Common.DAO
    {

        DataTable dt = new DataTable();
        Account entObj = new Account();
        #region Login credential DAL --Pravanjan Nayak

        public DataTable SuperadmindetailsDLL()
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter para1 = new SqlParameter();
                    para1 = new SqlParameter("@Event", "Select");

                    dt = ExecuteSPDataTable(db, "RTO_spSuperAdminDetails", para1);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public int UpdatedetailsSuperadminDAL(string Name, string Emailid, string Address, string PhNo)
        {
            int NonQueryResult = 0;
            int EmailSendResult = 0;
            Account entObj1 = new Account();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SuperAdminName_VCR", Name),
                    new SqlParameter("@SuperAdminEmailID_VCR", Emailid),
                    new SqlParameter("@SuperAdminMobileNo_VCR", PhNo),
                    new SqlParameter("@SuperAdminAddress_VCR", Address),
                    
                    new SqlParameter("@Event", "Update")
                };

                    NonQueryResult = ExecuteSPNonQuery(db, "RTO_spSuperAdminDetails", paras);
                    //EmailSendResult = SendEmailDAL(Name, Emailid);
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

        public DataTable CheckLogindetailsBLL(string email, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {                   
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@LoginEmailID_VCR", email);
                    paras[1] = new SqlParameter("@LoginPassword_VCR", password);
                    paras[2] = new SqlParameter("@Event", "checklogin");

                    dt = ExecuteSPDataTable(db, "RTO_spLogincredential", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable ForgetemailDAL(string Emailid)
        {
            int EmailSendResult = 0;
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@LoginEmailID_VCR", Emailid);
                    paras[1] = new SqlParameter("@Event", "Forgetemail");

                    dt = ExecuteSPDataTable(db, "RTO_spLogincredential", paras);
                    string Name = dt.Rows[0]["LoginType_VCR"].ToString();
                    string LoginCode = dt.Rows[0]["LoginCode_VCR"].ToString();



                    EmailSendResult = SendForgetemailDAL(Name, Emailid,LoginCode);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public int SendForgetemailDAL(string EName, string Emailid,string LoginCode)
        {
            int emailSendSuccess = 0;

            try
            {

                string date = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");
                string[] k = date.ToString().Split(' ');
                string Sdate = k[0] + "-" + k[1] + "-" + k[2] + "-RegionalTransportOffice";
                string Name = EName;
                string email = Emailid;

                String str = LoginCode;
                string Id = "";
                string centercode = "";
                if (str.Contains('_'))
                {
                    string[] Sid = LoginCode.Split('-');
                    centercode = Sid[0];
                    Id = Sid[1];
                }
                else
                {
                    centercode = LoginCode;
                    Id = LoginCode;
                }

                string link = "http://192.168.10.117/RTO/SetPassword.aspx?RTO-" + Id + "-" + Sdate + "-" + centercode;
                string subject = "Welcome TO RTO";
                string description = "A unique link to set your password has been generated for you. To set your password, click the following link and follow the instructions.  " + link;
                string endPrt1 = "Regards,";
                string endPrt2 = "Team RTO";
                //welcomemail(Name, Email, subject, description, endPrt1, endPrt2);



                string body = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Email_Format/WelcomeMail.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", Name);
                body = body.Replace("{subject}", subject);
                body = body.Replace("{description}", description);
                body = body.Replace("{endPrt1}", endPrt1);
                body = body.Replace("{endPrt2}", endPrt2);

                this.SendHtmlFormattedEmail(email, subject, body);

                emailSendSuccess = 1;

            }


            catch (Exception e)
            {
                emailSendSuccess = 0;
            }

            return emailSendSuccess;

        }

        #endregion

        #region SuperAdmin Registrations DAL --Pravanjan Nayak

        public int SuperAdminRegistrationDAL(string Name, string Emailid, string Address, string PhNo)
        {
            int NonQueryResult = 0;
            int EmailSendResult = 0;
            Account entObj1 = new Account();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SuperAdminName_VCR", Name),
                    new SqlParameter("@SuperAdminEmailID_VCR", Emailid),
                    new SqlParameter("@SuperAdminMobileNo_VCR", PhNo),
                    new SqlParameter("@SuperAdminAddress_VCR", Address),
                    
                    new SqlParameter("@Event", "Add")
                };

                    NonQueryResult = ExecuteSPNonQuery(db, "RTO_spSuperAdminDetails", paras);
                    EmailSendResult = SendEmailDAL(Name, Emailid);
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

        public int SendEmailDAL(string txtname, string txtemail)
        {
            int emailSendSuccess = 0;

            try
            {

                string date = System.DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm tt");
                string[] k = date.ToString().Split(' ');
                string Sdate = k[0] + "-" + k[1] + "-" + k[2] + "-RegionalTransportOffice";
                string Name = txtname;
                string email = txtemail;

                string link = "http://192.168.10.117/RTO/SetPassword.aspx?SuperAdmin-SU1" + "-" + Sdate + "-" + "SU1";
                string subject = "Welcome TO RTO";
                string description = "A unique link to set your password has been generated for you. To set your password, click the following link and follow the instructions.  " + link;
                string endPrt1 = "Regards,";
                string endPrt2 = "Team RTO";
                //welcomemail(Name, Email, subject, description, endPrt1, endPrt2);



                string body = string.Empty;
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Email_Format/WelcomeMail.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", Name);
                body = body.Replace("{subject}", subject);
                body = body.Replace("{description}", description);
                body = body.Replace("{endPrt1}", endPrt1);
                body = body.Replace("{endPrt2}", endPrt2);

                this.SendHtmlFormattedEmail(email, subject, body);

                emailSendSuccess = 1;

            }


            catch (Exception e)
            {
                emailSendSuccess = 0;
            }

            return emailSendSuccess;

        }

        public DataTable checkemailDAL(string Emailid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@SuperAdminEmailID_VCR", Emailid);
                    paras[1] = new SqlParameter("@Event", "Checkemail");

                    dt = ExecuteSPDataTable(db, "RTO_spSuperAdminDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable checkcontactnoDAL(string PhNo)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@SuperAdminMobileNo_VCR", PhNo);
                    paras[1] = new SqlParameter("@Event", "CheckPhNo");

                    dt = ExecuteSPDataTable(db, "RTO_spSuperAdminDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable CheckSuperadmindetailsDAL()
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter para1 = new SqlParameter();
                    para1 = new SqlParameter("@Event", "CheckSadmin");

                    dt = ExecuteSPDataTable(db, "RTO_spSuperAdminDetails", para1);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        #endregion

    }
}
