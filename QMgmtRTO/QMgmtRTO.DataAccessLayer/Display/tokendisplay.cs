using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.DataAccessLayer.Display
{
    public class tokendisplay:DataAccessLayer.Common.DAO
    {
        //#region Tokendisplay DAO -Avisek Samantaray
        public DataTable GetTokenDetailsDAL(string Service,string centerCode)
        {
            DataTable dt1 = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@ApplicantBookedService_VCR", Service);
                    paras[1] = new SqlParameter("@CentreCode_VCR", centerCode);
                    paras[2] = new SqlParameter("@Event", "DisplayDetails");

                    dt1 = ExecuteSPDataTable(db, "RTO_spTokenDisplay", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to tokendisplay" + ex);
            }
            return dt1;
        }


        public DataTable SGetTokenDetailsDAL(string Service, string centerCode)
        {
            DataTable dt1 = new DataTable();
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    SqlParameter[] paras = new SqlParameter[3];
                    paras[0] = new SqlParameter("@ApplicantBookedService_VCR", Service);
                    paras[1] = new SqlParameter("@CentreCode_VCR", centerCode);
                    paras[2] = new SqlParameter("@Event", "STokenDetails");

                    dt1 = ExecuteSPDataTable(db, "RTO_spTokenDisplay", paras);
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Unable to tokendisplay" + ex);
            }
            return dt1;
        }

    }
}
