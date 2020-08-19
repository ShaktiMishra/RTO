using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.BusinessLayer
{
    public class ReportsManager
    {
        public DataTable GetCentreListBLL()
        {

            DataAccessLayer.ReportsDAO repDAO = new DataAccessLayer.ReportsDAO();

            return repDAO.GetCentreListDAL();

            //throw new NotImplementedException();
        }

        public DataTable GetCentreReportBLL(string centrename)
        {
            DataAccessLayer.ReportsDAO repDAO = new DataAccessLayer.ReportsDAO();

            return repDAO.GetCentreReportDAL(centrename);
            //throw new NotImplementedException();
        }
    }
}
