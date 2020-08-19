using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.DataAccessLayer.Display
{
    public class EntranceDAO : DataAccessLayer.Common.DAO
    {
        #region Entrance DLL -Pravanjan Nayak

        public DataTable GetDisplayTimeDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "Select");

                    dt = ExecuteSPDataTable(db, "RTO_spCentreDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable GetTokenDetailsDAL(string ServiceType, string slottime, string centercode)
        {
            DataTable dt1 = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@TokenSlotTime_VCR", slottime);
                    paras[2] = new SqlParameter("@ApplicantBookedService_VCR", ServiceType);
                    paras[3] = new SqlParameter("@Event", "TokenDetails");

                    dt1 = ExecuteSPDataTable(db, "RTO_spTokendetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt1;
        }

        public DataTable GetSWSlotDetailsDAL(string slottime, string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@TokenSlotTime_VCR", slottime);
                    paras[2] = new SqlParameter("@Event", "SWSlotDetails");

                    dt = ExecuteSPDataTable(db, "RTO_spTokendetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable GetSlotDetailsDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "SlotDetails");

                    dt = ExecuteSPDataTable(db, "RTO_spTokendetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public int UpdateslotStatusDAL(string slottime, string ServiceType, string centercode)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];

                    paras[0] = new SqlParameter("@Event", "UpdateslotStatus");
                    paras[1] = new SqlParameter("@TokenSlotTime_VCR", slottime);
                    paras[2] = new SqlParameter("@ApplicantBookedService_VCR", ServiceType);
                    paras[3] = new SqlParameter("@CentreCode_VCR", centercode);

                    NonQueryResult = ExecuteSPScalar(db, "RTO_spTokendetails", paras);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }

            return NonQueryResult;
        }


        public DataTable GetQRDisplayTimeDAL(string centercode)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@Event", "Select");

                    dt = ExecuteSPDataTable(db, "RTO_spCentreDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public DataTable GetQRTokenDetailsDAL(string centercode, string applno, DateTime date, string service)
        {
            DataTable dt1 = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[5];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@ApplicationNo_VCR", applno);
                    paras[2] = new SqlParameter("@TokenSlotDate_DAT", date);
                    paras[3] = new SqlParameter("@ApplicantBookedService_VCR", service);
                    paras[4] = new SqlParameter("@Event", "QRTokenDetails");

                    dt1 = ExecuteSPDataTable(db, "RTO_spTokendetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt1;
        }

        public DataTable GetQRSlotDetailsDAL(string centercode, string applno, DateTime date, string service)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[5];
                    paras[0] = new SqlParameter("@CentreCode_VCR", centercode);
                    paras[1] = new SqlParameter("@ApplicationNo_VCR", applno);
                    paras[2] = new SqlParameter("@TokenSlotDate_DAT", date);
                    paras[3] = new SqlParameter("@ApplicantBookedService_VCR", service);
                    paras[4] = new SqlParameter("@Event", "QRSlotDetails");

                    dt = ExecuteSPDataTable(db, "RTO_spTokendetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }
            return dt;
        }

        public int QRUpdatesTokenDetailsDAL(string applno, string centercode, string currentStatus)
        {
            int NonQueryResult = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[4];

                    paras[0] = new SqlParameter("@Event", "QRUpdatesTokenDetails");
                    paras[1] = new SqlParameter("@ApplicationNo_VCR", applno);
                    paras[2] = new SqlParameter("@CurrTokenState_VCR", currentStatus);
                    paras[3] = new SqlParameter("@CentreCode_VCR", centercode);

                    NonQueryResult = ExecuteSPNonQuery(db, "RTO_spTokendetails", paras);
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
