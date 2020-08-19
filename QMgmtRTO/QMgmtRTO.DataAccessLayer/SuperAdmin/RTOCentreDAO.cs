using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QMgmtRTO.Entities;
using System.Data;

namespace QMgmtRTO.DataAccessLayer.SuperAdmin
{
    public class RTOCentreDAO
    {


        Entities.RTOCentre entObj = new Entities.RTOCentre();
                       

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










    }
}
