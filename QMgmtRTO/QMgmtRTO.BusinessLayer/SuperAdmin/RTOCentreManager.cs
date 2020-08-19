using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.BusinessLayer.SuperAdmin
{
    public class RTOCentreManager
    {

        DataAccessLayer.SuperAdmin.RTOCentreDAO centDAO = new DataAccessLayer.SuperAdmin.RTOCentreDAO();

    
        public DataSet SuperAdminGetCentreBLL()
        {

            return centDAO.SuperAdminGetCentreDAL();

        }





    }
}
