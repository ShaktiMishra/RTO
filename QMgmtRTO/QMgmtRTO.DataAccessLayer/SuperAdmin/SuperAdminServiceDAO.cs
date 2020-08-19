using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QMgmtRTO.Entities;


namespace QMgmtRTO.DataAccessLayer.SuperAdmin
{
    public class SuperAdminServiceDAO : DataAccessLayer.Common.DAO
    {
        Entities.RTOService servObj = new Entities.RTOService();

        #region S0 SuperAdmin gets all Services table - SPM - 14Jul2020
        public DataTable SuperAdminGetAllServicesDAL()
        {

            DataTable dt1;
            RTOService servObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter para1;
                    para1 = new SqlParameter("@Event", "Select");
                    dt1 = ExecuteSPDataTable(db, "RTO_spServiceDetails", para1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt1;
        }
        #endregion

        #region S1.1 Verifies if ServiceName exists in the database - SPM 18072020
        public int SuperAdminVerifyServiceNameRecordDAO(string serviceName)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "VerifyName");
                    paras[1] = new SqlParameter("@ServiceName_VCR", serviceName);

                    NonQueryResult = ExecuteSPScalar(db, "RTO_spServiceDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }

            return NonQueryResult;
        }
        #endregion

        #region S1.1 Verifies if ServiceShName exists in the database - SPM 18072020
        public int SuperAdminVerifyServiceShNameRecordDAO(string serviceShName)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "VerifyShName");
                    paras[1] = new SqlParameter("@ServiceShortName_VCR", serviceShName);

                    NonQueryResult = ExecuteSPScalar(db, "RTO_spServiceDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }

            return NonQueryResult;
        }
        #endregion



        #region S1.2 Adds a service to the table - SPM 18072020
        public int SuperAdminAddServiceDAL(RTOService servObj1)
        {

        int NonQueryResult = 0;
        
        try
        {
            using (IDbConnection db = GetConnection())
            {

                SqlParameter[] paras = new SqlParameter[4];

                paras[0] = new SqlParameter("@Event", "Add");
                paras[1] = new SqlParameter("@ServiceName_VCR", servObj1.ServiceName_VCR);
                paras[2] = new SqlParameter("@ServiceShortName_VCR", servObj1.ServiceShortName_VCR);
                paras[3] = new SqlParameter("@ServiceType_VCR", servObj1.ServiceType_VCR);
                

                NonQueryResult = ExecuteSPNonQuery(db, "RTO_spServiceDetails", paras);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to verify credentials" + ex);
                }

            if (NonQueryResult != 0)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }
        #endregion


        #region S2 SuperAdmin Delete Service 20Jul2020
        public int SuperAdminDeleteServiceDAL(string getid)
        {            

            int NonQueryResult = 0;
            RTOCentre centObj1 = new RTOCentre();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "Delete");
                    paras[1] = new SqlParameter("@ServiceID_INT", getid);

                    NonQueryResult = ExecuteSPNonQuery(db, "RTO_spServiceDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return NonQueryResult;

        }
        #endregion

        #region S3.1 SuperAdmin Fetches DataTable to edit Service - SPM - 20Jul2020
        public DataTable SuperAdminEditServiceDAL(string getid)
        {
            DataTable dt1;
            RTOService servObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "Edit");
                    paras[1] = new SqlParameter("@ServiceID_INT", getid);

                    dt1 = ExecuteSPDataTable(db, "RTO_spServiceDetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt1;
        }
        #endregion

        #region C3.2 Updates Service details - SPM 20072020

        public int SuperAdminUpdateServiceDAL(RTOService servObj1)
        {
            int NonQueryResult = 0;
            string centreModifyTime = System.DateTime.Now.ToString();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[5];
                    paras[0] = new SqlParameter("@Event", "Update");
                    paras[1] = new SqlParameter("@ServiceID_INT", servObj1.ServiceID_INT);
                    paras[2] = new SqlParameter("@ServiceName_VCR", servObj1.ServiceName_VCR);
                    paras[3] = new SqlParameter("@ServiceShortName_VCR", servObj1.ServiceShortName_VCR);
                    paras[4] = new SqlParameter("@ServiceType_VCR", servObj1.ServiceType_VCR);
                    

                    NonQueryResult = ExecuteSPNonQuery(db, "RTO_spServiceDetails", paras);
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
