using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.BusinessLayer.SuperAdmin
{
   public class RTOServicesManager
    {
       public int AddserviceBLL(string ServiceName,string ServiceShortName,string date,string btnval)
       {
           DataAccessLayer.SuperAdmin.RTOServiceDAO accDAO1 = new DataAccessLayer.SuperAdmin.RTOServiceDAO();
           int entObj1;
           entObj1 = accDAO1.AddserviceDAL(ServiceName, ServiceShortName, date,btnval);
           return entObj1;

       }

       public System.Data.DataTable displayserviceBLL()
       {
           DataAccessLayer.SuperAdmin.RTOServiceDAO accDAO1 = new DataAccessLayer.SuperAdmin.RTOServiceDAO();
           Entities.RTOService entObj1 = new Entities.RTOService();
           //entObj1 = accDAO1.FillserviceDAL();

           System.Data.DataTable dt1 = new System.Data.DataTable();
           dt1 = accDAO1.displayserviceDAL();
           return dt1;

       }

       public System.Data.DataTable serviceupdateBLL(string id)
       {
           DataAccessLayer.SuperAdmin.RTOServiceDAO accDAO1 = new DataAccessLayer.SuperAdmin.RTOServiceDAO();
           Entities.RTOService entObj1 = new Entities.RTOService();
           //entObj1 = accDAO1.FillserviceDAL();

           System.Data.DataTable dt1 = new System.Data.DataTable();
           dt1 = accDAO1.serviceupdateDAL(id);
           return dt1;

       }

       public int servicedeleteBLL(string id)
       {
           DataAccessLayer.SuperAdmin.RTOServiceDAO accDAO1 = new DataAccessLayer.SuperAdmin.RTOServiceDAO();
           int entObj1;
           entObj1 = accDAO1.servicedeleteDAL(id);
           return entObj1;

       }
    }
}
