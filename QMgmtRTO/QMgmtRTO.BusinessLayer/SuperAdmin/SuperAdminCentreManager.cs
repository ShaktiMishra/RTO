using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.BusinessLayer.SuperAdmin
{
    public class SuperAdminCentreManager
    {

        DataAccessLayer.SuperAdmin.SuperAdminCentreDAO centDAO = new DataAccessLayer.SuperAdmin.SuperAdminCentreDAO();


        #region SuperAdmin Dashboard Page Call
        public DataSet SuperAdminGetCentreBLL()
        {
            return centDAO.SuperAdminGetCentreDAL();
        }
        #endregion

        #region C0 SuperAdmin gets all centres table - SPM - 19Jul2020

        public DataTable SuperAdminGetAllCentresBLL()
        {
            
            return centDAO.SuperAdminGetAllCentresDAL();

            //throw new NotImplementedException();
        }
        #endregion        

        #region C1.1 Verifies if Centre exists in the database - SPM 18072020

        public int SuperAdminVerifyCentreRecordBLL(string centName)
        {
            return centDAO.SuperAdminVerifyCentreRecordDAO(centName);

            //throw new NotImplementedException();
        }
        #endregion

        #region C1.2 Adds a centre to the table - SPM 18072020

        public int SuperAdminAddCentreBLL(string centreCode, string centreName, string centreEmail, string centreMobile, string centreAddress, string centrePIN)
        {

            
            string centreLogo = centreCode;

            Entities.RTOCentre centObj = new Entities.RTOCentre();

            centObj.CentreCode_VCR = centreCode;
            centObj.CentreLogo_VCR = centreLogo;
            centObj.CentreName_VCR = centreName;
            centObj.CentreEmailID_VCR = centreEmail;
            centObj.CentreMobileNo_VCR = centreMobile;
            centObj.CentreAddress_VCR = centreAddress;
            centObj.CentrePINCode_VCR = centrePIN;
            //centObj.CentreMsgTime_INT = 12;

            return centDAO.SuperAdminAddCentreDAL(centObj);           

        }
        #endregion

        #region C2 SuperAdmin Delete Centre 19Jul2020

        public int SuperAdminDeleteCentreBLL(string getid)
        {
            return centDAO.SuperAdminDeleteCentreDAL(getid);
        }
        #endregion

        #region C3.1 Fetches Centre Details to Edit - SPM 19072020
        public DataTable SuperAdminEditCentreBLL(string getid)
        {
            return centDAO.SuperAdminEditCentreDAL(getid);
        }
        #endregion

        #region C3.2 Updates the centre details - SPM 19072020
        public int SuperAdminUpdateCentreBLL(string id, string centreCode, string centreName, string centreEmail, string centreMobile, string centreAddress, string centrePIN)
        {
            string centreLogo = centreCode;

            Entities.RTOCentre centObj = new Entities.RTOCentre();

            centObj.CentreID_INT = Convert.ToInt32(id);
            centObj.CentreCode_VCR = centreCode;
            centObj.CentreLogo_VCR = centreLogo;
            centObj.CentreName_VCR = centreName;
            centObj.CentreEmailID_VCR = centreEmail;
            centObj.CentreMobileNo_VCR = centreMobile;
            centObj.CentreAddress_VCR = centreAddress;
            centObj.CentrePINCode_VCR = centrePIN;
            //centObj.CentreMsgTime_INT = 12;

            return centDAO.SuperAdminUpdateCentreDAL(centObj);
        }
        #endregion


    }
}
