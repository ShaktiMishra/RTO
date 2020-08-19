using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.BusinessLayer.SuperAdmin
{
    public class SuperAdminServiceManager
    {

        DataAccessLayer.SuperAdmin.SuperAdminServiceDAO servDAO = new DataAccessLayer.SuperAdmin.SuperAdminServiceDAO();


        #region S0 SuperAdmin gets all Services table - SPM - 20Jul2020

        public DataTable SuperAdminGetAllServicesBLL()
        {
            return servDAO.SuperAdminGetAllServicesDAL();
        }
        #endregion        

        #region S1.1 Verifies if ServiceName exists in the database - SPM 20072020

        public int SuperAdminVerifyServiceNameRecordBLL(string servName)
        {
            return servDAO.SuperAdminVerifyServiceNameRecordDAO(servName);
        }
        #endregion

        #region S1.1 Verifies if ServiceShName exists in the database - SPM 20072020

        public int SuperAdminVerifyServiceShNameRecordBLL(string servShName)
        {
            return servDAO.SuperAdminVerifyServiceShNameRecordDAO(servShName);
        }
        #endregion

        #region S1.2 Adds a Service to the table - SPM 20072020

        public int SuperAdminAddServiceBLL(string serviceName, string serviceShortName, string ServiceType) 
        {            
            Entities.RTOService servObj = new Entities.RTOService();

            servObj.ServiceName_VCR = serviceName;
            servObj.ServiceShortName_VCR = serviceShortName;
            servObj.ServiceType_VCR = ServiceType;

            return servDAO.SuperAdminAddServiceDAL(servObj);

        }
        #endregion

        #region S2 SuperAdmin Delete Service 20Jul2020

        public int SuperAdminDeleteServiceBLL(string getid)
        {
            return servDAO.SuperAdminDeleteServiceDAL(getid);
        }
        #endregion

        #region S3.1 Fetches Service Details to Edit - SPM 20072020
        public DataTable SuperAdminEditServiceBLL(string getid)
        {
            return servDAO.SuperAdminEditServiceDAL(getid);
        }
        #endregion

        #region S3.2 Updates Service details - SPM 19072020
        public int SuperAdminUpdateServiceBLL(string id, string serviceName, string serviceShortName, string ServiceType)
        {            

            Entities.RTOService servObj = new Entities.RTOService();

            servObj.ServiceID_INT = Convert.ToInt32(id);
            servObj.ServiceName_VCR = serviceName;
            servObj.ServiceShortName_VCR = serviceShortName;
            servObj.ServiceType_VCR = ServiceType;

            return servDAO.SuperAdminUpdateServiceDAL(servObj);
        }
        #endregion

    }
}
