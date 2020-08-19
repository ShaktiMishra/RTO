using QMgmtRTO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.DataAccessLayer.SuperAdmin
{
    public class RTOServiceDAO : DataAccessLayer.Common.DAO
    {
        public int AddserviceDAL(string ServiceName, string ServiceShortName, string date,string btnval)
        {
            int val;
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    if (btnval == "Add Service")
                    {
                        SqlParameter[] paras = new SqlParameter[6];
                        paras[0] = new SqlParameter("@Service_Name", ServiceName);
                        paras[1] = new SqlParameter("@Service_Short_Name", ServiceShortName);
                        paras[2] = new SqlParameter("@Create_date", date);
                        paras[3] = new SqlParameter("@Modify_date", null);
                        paras[4] = new SqlParameter("@Service_Status", 1);
                        paras[5] = new SqlParameter("@Event", "Add");

                        val = ExecuteNonQueryResult(db, "Sp_ServiceDetails", paras);
                    }
                    else
                    {
                        SqlParameter[] paras = new SqlParameter[6];
                        paras[0] = new SqlParameter("@Service_Name", ServiceName);
                        paras[1] = new SqlParameter("@Service_Short_Name", ServiceShortName);
                        paras[2] = new SqlParameter("@Modify_date", date);
                        paras[3] = new SqlParameter("@Service_Status", 1);
                        paras[3] = new SqlParameter("@Service_Id", 1);
                        paras[4] = new SqlParameter("@Event", "Update");

                        val = ExecuteNonQueryResult(db, "Sp_ServiceDetails", paras);
                    }

                    
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }

        public DataTable displayserviceDAL()
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter para1 = new SqlParameter();
                    para1 = new SqlParameter("@Event", "Selectall");
                    dt = ExecuteSPDataTable(db, "Sp_ServiceDetails", para1);


                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            //return entObj1;
            return dt;
        }

        public DataTable serviceupdateDAL(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@Service_Id ", id);
                    paras[1] = new SqlParameter("@Event", "Edit");
                    dt = ExecuteSPDataTable(db, "Sp_ServiceDetails", paras);


                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            //return entObj1;
            return dt;
        }

        public int servicedeleteDAL(string id)
        {
            int val;
            RTOService entObj1 = new RTOService();
            try
            {
                using (IDbConnection db = GetConnection())
                {

                    SqlParameter[] paras = new SqlParameter[2];
                    paras[0] = new SqlParameter("@Service_Id", id);
                    paras[1] = new SqlParameter("@Event", "delete");

                    val = ExecuteNonQueryResult(db, "Sp_ServiceDetails", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to verify credentials" + ex);
            }


            return val;
        }
    }
}
