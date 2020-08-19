using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Text;
using System.Threading.Tasks;
using QMgmtRTO.Entities;
using System.Data.SqlClient;
using System.Data;



namespace QMgmtRTO.DataAccessLayer.RTOAdmin
{
    //class RTOCounterStaffServiceDAO

    public class RTOCounterStaffServiceDAO : DataAccessLayer.Common.DAO
    {


        public RTOCounter CounterAddDAL(string txtcountername, string txtdevicecode)
        {
            Random r = new Random();
            string countercode = r.Next(100000, 999999).ToString();

            RTOCounter entObj1 = new RTOCounter();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];
                    paras[0] = new SqlParameter("@CounterName_VCR", txtcountername);
                    paras[1] = new SqlParameter("@CounterCode_VCR", countercode);
                    paras[2] = new SqlParameter("@DeviceCode_VCR", txtdevicecode);
                    paras[3] = new SqlParameter("@Event", "Add");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spCounterDetails", paras))
                    {
                        while (reader.Read())
                        {
                            entObj1.CounterName_VCR = reader[1].ToString();
                            entObj1.CounterCode_VCR = reader[2].ToString();
                            entObj1.DeviceCode_VCR = reader[3].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }

        public DataTable serviceupdateDAL(Int16 id, string CentreCode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@ChooseServiceID_INT", id);
                    paras[1] = new SqlParameter("@CentreID_INT", CentreCode);
                    paras[2] = new SqlParameter("@Event", "Edit");
                    dt = ExecuteSPDataTable(db, "RTO_spAdminChooseService", paras);


                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            //return entObj1;
            return dt;
        }

        public int servicedeleteDAL(Int16 id, string CentreCode)
        {
            int val;
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@ChooseServiceID_INT", id);
                    paras[1] = new SqlParameter("@CentreCode_VCR", CentreCode);
                    paras[2] = new SqlParameter("@Event", "Delete");

                    val = ExecuteSPNonQuery(db, "RTO_spAdminChooseService", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }


        #region -Admin Choose Service details DAL Pravanjan Nayak
        //Admine Set Display Time
        public int AdminSetDisplayTimedDAL(string CenterCode,int min)
        {
            int val;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@CentreCode_VCR", CenterCode);
                    paras[1] = new SqlParameter("@CentreTimeSet_INT", min);
                    paras[2] = new SqlParameter("@Event", "SetDTime");


                    val = ExecuteSPNonQuery(db, "RTO_spCentreDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }

        public DataTable FillserviceDAL()
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter para1 = new SqlParameter();
                    para1 = new SqlParameter("@Event", "Select");
                    dt = ExecuteSPDataTable(db, "RTO_spServiceDetails", para1);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable displayserviceDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "adminService");
                    dt = ExecuteSPDataTable(db, "RTO_spAdminChooseService", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public int admindltserviceDAL(string CenterCode)
        {
            int val;
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", CenterCode);
                    paras[1] = new SqlParameter("@Event", "adminSrvcdlt");


                    val = ExecuteSPNonQuery(db, "RTO_spAdminChooseService", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }

        public int AdminVerifyServiceDAO(string ServiceName, int ServiceId, string CenterCode)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];

                    paras[0] = new SqlParameter("@Event", "VerifyService");
                    paras[1] = new SqlParameter("@ServiceName_VCR", ServiceName);
                    paras[2] = new SqlParameter("@ServiceID_INT", ServiceId);
                    paras[3] = new SqlParameter("@CentreCode_VCR", CenterCode);

                    NonQueryResult = ExecuteSPScalar(db, "RTO_spAdminChooseService", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }

            return NonQueryResult;
        }
        public int AdminVerifyCounterDAO(string txtcountername, string txtdevicecode, string centercode)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];

                    paras[0] = new SqlParameter("@Event", "VerifyCounter");
                    paras[1] = new SqlParameter("@CounterName_VCR", txtcountername);
                    paras[2] = new SqlParameter("@DeviceCode_VCR", txtdevicecode);
                    paras[3] = new SqlParameter("@CentreCode_VCR", centercode);

                    NonQueryResult = ExecuteSPScalar(db, "RTO_spCounterDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }

            return NonQueryResult;
        }
        public int adminchooseserviceDAL(string ServiceName, int ServiceId, string CenterCode)
        {
            int val;
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];
                    paras[0] = new SqlParameter("@ServiceID_INT", ServiceId);
                    paras[1] = new SqlParameter("@ServiceName_VCR", ServiceName);
                    paras[2] = new SqlParameter("@CentreCode_VCR", CenterCode);
                    paras[3] = new SqlParameter("@Event", "Add");

                    val = ExecuteSPNonQuery(db, "RTO_spAdminChooseService", paras);

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return val;
        }

        #endregion


        #region -Assigned DLL Pravanjan Nayak

        public DataTable FillstaffDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "Select");

                    dt = ExecuteSPDataTable(db, "RTO_spStaffdetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable FillCounterDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "Select");
                    dt = ExecuteSPDataTable(db, "RTO_spCounterDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable FillAdminserviceDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "ChadminService");

                    dt = ExecuteSPDataTable(db, "RTO_spAdminChooseService", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable displayAssignedDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "Select");

                    dt = ExecuteSPDataTable(db, "RTO_spAssignMapping", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public int AssignDAL(int ServiceId, int Staffid, int counterid, string centerCode)
        {
            int val;
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[6];
                    paras[0] = new SqlParameter("@ServiceID_INT", ServiceId);
                    paras[1] = new SqlParameter("@StaffID_INT", Staffid);
                    paras[2] = new SqlParameter("@CounterID_INT", counterid);
                    paras[3] = new SqlParameter("@CentreCode_VCR", centerCode);
                    paras[4] = new SqlParameter("@AssignActiveStatus_INT", 1);
                    paras[5] = new SqlParameter("@Event", "Add");

                    val = ExecuteSPNonQuery(db, "RTO_spAssignMapping", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return val;
        }

        public int AssignverifySSCDAL(int ServiceId, int counterid, int Staffid, string centercode)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[5];

                    paras[0] = new SqlParameter("@Event", "VerifyAssignSSC");
                    paras[1] = new SqlParameter("@StaffID_INT", Staffid);
                    paras[2] = new SqlParameter("@ServiceID_INT", ServiceId);
                    paras[3] = new SqlParameter("@CounterID_INT", counterid);
                    paras[4] = new SqlParameter("@CentreCode_VCR", centercode);

                    NonQueryResult = ExecuteSPScalar(db, "RTO_spAssignMapping", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }

            return NonQueryResult;
        }

        public DataTable EditAssignedDAL(int id, string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@AssignID_INT", id);
                    paras[1] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[2] = new SqlParameter("@Event", "Edit");

                    dt = ExecuteSPDataTable(db, "RTO_spAssignMapping", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public int AssignservicedeleteDAL(int id, string centreCode)
        {
            int val;
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@AssignID_INT", id);
                    paras[1] = new SqlParameter("@CentreCode_VCR", centreCode);
                    paras[2] = new SqlParameter("@Event", "Delete");

                    val = ExecuteSPNonQuery(db, "RTO_spAssignMapping", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }

        #endregion


        #region Promejee 16Jul2020

        public RTOCounter CounterAddDAL(string txtcountername, string txtdevicecode, string centrecode)
        {
            Random r = new Random();
            string countercode = r.Next(100000, 999999).ToString();

            //string centercode = "1";

            RTOCounter entObj1 = new RTOCounter();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[5];
                    paras[0] = new SqlParameter("@CounterName_VCR", txtcountername);
                    paras[1] = new SqlParameter("@CounterCode_VCR", countercode);
                    paras[2] = new SqlParameter("@DeviceCode_VCR", txtdevicecode);
                    paras[3] = new SqlParameter("@CentreCode_VCR", centrecode);
                    //paras[4] = new SqlParameter("@CounterCreateDate_DAT", dt);
                    paras[4] = new SqlParameter("@Event", "Add");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spCounterDetails", paras))
                    {
                        while (reader.Read())
                        {
                            entObj1.CounterName_VCR = reader[1].ToString();
                            entObj1.CounterCode_VCR = reader[2].ToString();
                            entObj1.DeviceCode_VCR = reader[3].ToString();
                            entObj1.CentreCode_VCR = reader[4].ToString();
                            entObj1.CounterCreateDate_DAT = Convert.ToDateTime(reader[5].ToString());

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }


        public RTOCounter CounterUpdateDAL(string txtcountername, string txtdevicecode, string dt, int idd, string centercode)
        {
            Random r = new Random();
            string countercode = r.Next(100000, 999999).ToString();

            //string centercode = "1";

            RTOCounter entObj1 = new RTOCounter();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[7];
                    paras[0] = new SqlParameter("@CounterID_INT", idd);
                    paras[1] = new SqlParameter("@CounterName_VCR", txtcountername);
                    paras[2] = new SqlParameter("@CounterCode_VCR", countercode);
                    paras[3] = new SqlParameter("@DeviceCode_VCR", txtdevicecode);
                    paras[4] = new SqlParameter("@CentreCode_VCR", centercode);
                    //paras[5] = new SqlParameter("@CounterModifyDate_DAT", dt);
                    paras[5] = new SqlParameter("@Event", "Update");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spCounterDetails", paras))
                    {
                        while (reader.Read())
                        {
                            entObj1.CounterID_INT = Convert.ToInt32(reader[1].ToString());
                            entObj1.CounterName_VCR = reader[2].ToString();
                            entObj1.CounterCode_VCR = reader[3].ToString();
                            entObj1.DeviceCode_VCR = reader[4].ToString();
                            entObj1.CentreCode_VCR = reader[5].ToString();
                            entObj1.CounterCreateDate_DAT = Convert.ToDateTime(reader[6].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }
        public Account staffUpdateDAL(string txtStaffname, string txtMobileNo, string txtemail, string staffcode, int idd, string centercode)
        {

            //Staff entObj1 = new Staff(); //SPM 22072020
            Account entObj1 = new Account();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[7];
                    paras[0] = new SqlParameter("@StaffID_INT", idd);
                    paras[1] = new SqlParameter("@StaffName_VCR", txtStaffname);
                    paras[2] = new SqlParameter("@StaffMobileNo_VCR", txtMobileNo);
                    paras[3] = new SqlParameter("@StaffCode_VCR", staffcode);
                    paras[4] = new SqlParameter("@StaffEmailID_VCR", txtemail);
                    paras[5] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[6] = new SqlParameter("@Event", "Update");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spStaffDetails", paras))
                    {
                        while (reader.Read())
                        {
                            entObj1.AccountID_INT = Convert.ToInt32(reader[1].ToString());
                            entObj1.AccountName_VCR = reader[2].ToString();
                            entObj1.AccountMobileNo_VCR = reader[3].ToString();
                            entObj1.AccountCode_VCR = reader[4].ToString();
                            entObj1.AccountEmailID_VCR = reader[5].ToString();
                            entObj1.AccountModifyDate_DAT = Convert.ToDateTime(reader[6].ToString());
                            entObj1.AccountCentrerCode = reader[7].ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }
        public Account StaffAddDAL(string txtStaffname, string txtMobileNo, string txtemail, string staffcode, string centrecode)
        {

            //Staff entObj1 = new Staff(); //cmtd SPM 22072020

            Account entObj1 = new Account();

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[6];
                    paras[0] = new SqlParameter("@StaffCode_VCR", staffcode);
                    paras[1] = new SqlParameter("@CentreCode_VCR", centrecode);
                    paras[2] = new SqlParameter("@StaffName_VCR", txtStaffname);
                    paras[3] = new SqlParameter("@StaffEmailID_VCR", txtemail);
                    paras[4] = new SqlParameter("@StaffMobileNo_VCR", txtMobileNo);
                    paras[5] = new SqlParameter("@Event", "Add");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spStaffDetails", paras))
                    {
                        while (reader.Read())
                        {
                            //entObj1.Staff_Name = reader[1].ToString();
                            //entObj1.Staff_Mob = reader[2].ToString();
                            //entObj1.Staff_Code = reader[3].ToString();
                            //entObj1.Staff_Email = reader[4].ToString();
                            //entObj1.Create_date = reader[5].ToString();

                            entObj1.AccountName_VCR = reader[1].ToString();
                            entObj1.AccountMobileNo_VCR = reader[2].ToString();
                            entObj1.AccountCode_VCR = reader[3].ToString();
                            entObj1.AccountEmailID_VCR = reader[4].ToString();
                            entObj1.AccountCreateDate_DAT = Convert.ToDateTime(reader[5].ToString());

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }


        public DataTable displayCounterDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@Event", "Select");
                    paras[1] = new SqlParameter("@CentreCode_VCR", centercode);


                    dt = ExecuteSPDataTable(db, "RTO_spCounterdetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            //return entObj1;
            return dt;
        }
        public DataTable displayStaffDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@Event", "Select");
                    paras[1] = new SqlParameter("@CentreCode_VCR", centercode);

                    dt = ExecuteSPDataTable(db, "RTO_spStaffDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            //return entObj1;
            return dt;
        }


        public int counterdeleteDAL(int id, string Centerid)
        {
            int val;
            RTOCounter entObj1 = new RTOCounter();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@CounterID_INT", id);
                    paras[1] = new SqlParameter("@CentreCode_VCR", Centerid);
                    paras[2] = new SqlParameter("@Event", "Delete");

                    val = ExecuteSPNonQuery(db, "RTO_spCounterDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }
        public int staffdeleteDAL(int id, string Centerid)
        {
            int val;
            //Staff entObj1 = new Staff();

            Account entObj1 = new Account();

            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@StaffID_INT", id);
                    paras[1] = new SqlParameter("@CentreCode_VCR", Centerid);
                    paras[2] = new SqlParameter("@Event", "Delete");

                    val = ExecuteSPNonQuery(db, "RTO_spStaffDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }

        #endregion


        #region Promejee 04Aug2020

        public DataTable getcutokennumber()
        {
            DataTable dt = new DataTable(); ;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[1];
                    
                    paras[0] = new SqlParameter("@Event", "Select");

                    dt = ExecuteSPDataTable(db, "RTO_spCallNextToken", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }
        public DataTable gettotaltokennumberserved()
        {
            DataTable dt = new DataTable(); ;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[1];

                    paras[0] = new SqlParameter("@Event", "Total");

                    dt = ExecuteSPDataTable(db, "RTO_spCallNextToken", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }
        public DataTable getstaffservices(string centercode)
        {
            DataTable dt = new DataTable(); ;
            try
            {
                string[] cencode = centercode.Split('_');
                string c_code = cencode[0].ToString();

                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@StaffCode_VCR", centercode);
                    paras[1] = new SqlParameter("@CentreCode_VCR", c_code);
                    paras[2] = new SqlParameter("@Event", "GetServicesOfStaff");

                    dt = ExecuteSPDataTable(db, "RTO_spAssignMapping", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }
        public DataTable GetStaffAssignedServicesCounterDAL(string staffcode)
        {
            DataTable dt = new DataTable(); ;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@StaffCode_VCR", staffcode);
                    paras[1] = new SqlParameter("@Event", "GetCounterANDServicesOfStaff");

                    dt = ExecuteSPDataTable(db, "RTO_spCallNextToken", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }
        public RTOService TokenUpdateDAL(string services, string counterid, string staffcode)
        {
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];
                    paras[0] = new SqlParameter("@CurrTokenState_VCR", services);
                    paras[1] = new SqlParameter("@CurrCounterCode_VCR", counterid);
                    paras[2] = new SqlParameter("@CurrStaffCode_VCR", staffcode);
                    paras[3] = new SqlParameter("@Event", "Update");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spCallNextToken", paras))
                    {
                        while (reader.Read())
                        {
                            entObj1.CurrServiceName_VCR = reader[1].ToString();
                            entObj1.CurrCounterCode_VCR = reader[2].ToString();
                            entObj1.CurrStaffCode_VCR = reader[3].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }

        #endregion


        #region promejee 11-08-2020
        public DataTable getlltokennumber(string datenow)
        {
            DataTable dt = new DataTable(); ;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@date", datenow);
                    paras[1] = new SqlParameter("@Event", "Select");

                    dt = ExecuteSPDataTable(db, "RTO_spLLCallNextToken", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public RTOService TokenLLUpdateDAL(string datenow)
        {

            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@date", datenow);
                    paras[1] = new SqlParameter("@Event", "Update");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spLLCallNextToken", paras))
                    {
                        while (reader.Read())
                        {
                            entObj1.lldate = reader[1].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }

        public RTOService InsertLLExamTokenDAL(string txtfromno, string txttono, string datenow, string timenow)
        {
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[5];
                    paras[0] = new SqlParameter("@from_token", txtfromno);
                    paras[1] = new SqlParameter("@to_token", txttono);
                    paras[2] = new SqlParameter("@date", datenow);
                    paras[3] = new SqlParameter("@time", timenow);
                    paras[4] = new SqlParameter("@Event", "Insert");

                    using (IDataReader reader = ExecuteSPReader(db, "RTO_spLLCallNextToken", paras))
                    {
                        while (reader.Read())
                        {
                            entObj1.llfromtoken = reader[1].ToString();
                            entObj1.lltotoken = reader[2].ToString();
                            entObj1.lldate = reader[3].ToString();
                            entObj1.lltime = reader[4].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return entObj1;
        }
        public DataTable gettotaltokennumbercom()
        {
            DataTable dt = new DataTable(); ;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[1];

                    paras[0] = new SqlParameter("@Event", "Complete");

                    dt = ExecuteSPDataTable(db, "RTO_spLLCallNextToken", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable gettotaltokennumberwait()
        {
            DataTable dt = new DataTable(); ;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[1];

                    paras[0] = new SqlParameter("@Event", "Waiting");

                    dt = ExecuteSPDataTable(db, "RTO_spLLCallNextToken", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }
        public DataTable getfromtoTokenNumberft(string datenow)
        {
            DataTable dt = new DataTable(); ;
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@date", datenow);
                    paras[1] = new SqlParameter("@Event", "GetCalledLLToken");

                    dt = ExecuteSPDataTable(db, "RTO_spLLCallNextToken", paras);
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