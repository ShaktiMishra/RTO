using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.DataAccessLayer
{
    public class ReportsDAO : Common.DAO
    {
        public DataTable GetCentreListDAL()
        {

            DataTable dt1;
            
            try
            {
                using (IDbConnection db = GetConnection())
                {


                    SqlParameter[] paras = new SqlParameter[2];

                    paras[0] = new SqlParameter("@Event", "GetCentres");
                    paras[1] = new SqlParameter("@Authorisation", "SA");

                    dt1 = ExecuteSPDataTable(db, "RTO_spGenerateReports", paras);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to fetch centre names" + ex);
            }
            return dt1;

            //throw new NotImplementedException();
        }

        public DataTable GetCentreReportDAL(string centrename)
        {
            DataTable dt1;

            try
            {
                using (IDbConnection db = GetConnection())
                {


                    SqlParameter[] paras = new SqlParameter[3];

                    paras[0] = new SqlParameter("@Event", "GetCentreReport");
                    paras[1] = new SqlParameter("@Authorisation", "SA");
                    paras[2] = new SqlParameter("@CentreName_VCR", centrename);

                    dt1 = ExecuteSPDataTable(db, "RTO_spGenerateReports", paras);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to fetch centre names" + ex);
            }
            return dt1;
        }
    }
}
