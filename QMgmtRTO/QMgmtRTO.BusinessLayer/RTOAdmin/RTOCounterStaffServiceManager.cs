using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QMgmtRTO.DataAccessLayer;

namespace QMgmtRTO.BusinessLayer.RTOAdmin
{
    public class RTOCounterStaffServiceManager
    {
        #region Create Counter

        public Entities.RTOCounter CounterAddBLL(string txtcountername, string txtdevicecode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOCounter entObj1 = new Entities.RTOCounter();
            entObj1 = accDAO1.CounterAddDAL(txtcountername, txtcountername);
            return entObj1;
        }
        #endregion

        #region create registration -pravanjan nayak

        public System.Data.DataTable serviceupdateBLL(Int16 id, string CentreCode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            //entObj1 = accDAO1.FillserviceDAL();

            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.serviceupdateDAL(id, CentreCode);
            return dt1;

        }

        public int servicedeleteBLL(Int16 id, string centreCode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.servicedeleteDAL(id, centreCode);
            return entObj1;

        }

        #endregion



        #region -Admin Choose Service details BLL Pravanjan Nayak
        //Admine Set Display Time
        public int AdminSetDisplayTimedBLL(string centerCode, int min)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.AdminSetDisplayTimedDAL(centerCode, min);
            return entObj1;

        }

        public System.Data.DataTable FillserviceBLL()
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.FillserviceDAL();
            return dt1;

        }

        public System.Data.DataTable displayserviceBLL(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            //entObj1 = accDAO1.FillserviceDAL();

            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.displayserviceDAL(centercode);
            return dt1;

        }

        public int admindltserviceBLL(string CenterCode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.admindltserviceDAL(CenterCode);
            return entObj1;

        }

        DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO ServDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
        public int AdminVerifyServiceBLL(string ServiceName, int ServiceId, string CenterCode)
        {
            return ServDAO1.AdminVerifyServiceDAO(ServiceName, ServiceId, CenterCode);
        }

        public int adminchooseserviceBLL(string ServiceName, int ServiceId, string CenterCode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.adminchooseserviceDAL(ServiceName, ServiceId, CenterCode);
            return entObj1;

        }

        #endregion


        #region -Assigned BLL Pravanjan Nayak

        public System.Data.DataTable FillstaffBLL(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.Account entObj = new Entities.Account();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.FillstaffDAL(centercode);
            return dt1;

        }

        public System.Data.DataTable FillCounterBLL(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOCounter entObj1 = new Entities.RTOCounter();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.FillCounterDAL(centercode);
            return dt1;

        }

        public System.Data.DataTable FillAdminserviceBLL(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.FillAdminserviceDAL(centercode);
            return dt1;

        }

        public System.Data.DataTable displayAssignedBLL(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.displayAssignedDAL(centercode);
            return dt1;

        }

        public int AssignBLL(int ServiceId, int Staffid, int counterid, string centerCode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.AssignDAL(ServiceId, Staffid, counterid, centerCode);
            return entObj1;

        }

        DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO SSCDAO = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
        public int AssignverifySSCBLL(int ServiceId, int counterid, int Staffid, string centercode)
        {
            return SSCDAO.AssignverifySSCDAL(ServiceId, counterid, Staffid, centercode);
        }

        public System.Data.DataTable EditAssignedBLL(int id, string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.EditAssignedDAL(id, centercode);
            return dt1;

        }

        public int AssignservicedeleteBLL(int id, string centreCode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.AssignservicedeleteDAL(id, centreCode);
            return entObj1;

        }

        #endregion


        #region Promejee -16Jul2020 Counter Details

        #region Create Counter

        public Entities.RTOCounter CounterAddBLL(string txtcountername, string txtdevicecode, string centrecode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOCounter entObj1 = new Entities.RTOCounter();
            entObj1 = accDAO1.CounterAddDAL(txtcountername, txtdevicecode, centrecode);
            return entObj1;
        }
        #endregion

        #region update Counter

        public Entities.RTOCounter CounterUpdateBLL(string txtcountername, string txtdevicecode, string dt, int id, string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOCounter entObj1 = new Entities.RTOCounter();
            entObj1 = accDAO1.CounterUpdateDAL(txtcountername, txtdevicecode, dt, id, centercode);
            return entObj1;
        }
        #endregion
        #region update staff

        public Entities.Account StaffUpdateBLL(string txtStaffname, string txtMobileNo, string txtemail, string staffcode, int id, string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.Account entObj1 = new Entities.Account();
            entObj1 = accDAO1.staffUpdateDAL(txtStaffname, txtMobileNo, txtemail, staffcode, id, centercode);
            return entObj1;
        }
        #endregion
        #region Create Staff

        public Entities.Account StaffAddBLL(string txtStaffname, string txtMobileNo, string txtemail, string staffcode, string centrecode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.Account entObj1 = new Entities.Account();
            entObj1 = accDAO1.StaffAddDAL(txtStaffname, txtMobileNo, txtemail, staffcode, centrecode);
            return entObj1;
        }
        #endregion

        #region display counter datatable

        public System.Data.DataTable displayCounterBLL(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOCounter entObj1 = new Entities.RTOCounter();
            //entObj1 = accDAO1.FillserviceDAL();

            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.displayCounterDAL(centercode);
            return dt1;

        }

        #endregion
        #region display staff datatable

        public System.Data.DataTable displayStaffBLL(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.Account entObj1 = new Entities.Account();

            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.displayStaffDAL(centercode);
            return dt1;

        }

        #endregion

        #region delete counter
        public int counterdeleteBLL(int id, string Centerid)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.counterdeleteDAL(id, Centerid);
            return entObj1;

        }
        #endregion
        #region delete staff
        public int staffdeleteBLL(int id, string Centerid)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            int entObj1;
            entObj1 = accDAO1.staffdeleteDAL(id, Centerid);
            return entObj1;

        }
        #endregion

        #region verify counter
        DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO verifycounter = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();

        public int AdminVerifyCounterBLL(string txtcountername, string txtdevicecode, string centercode)
        {
            return verifycounter.AdminVerifyCounterDAO(txtcountername, txtdevicecode, centercode);
        }
        #endregion

        #endregion

        #region Promejee -04Aug2020 Get Services For Particular Staff

        public System.Data.DataTable getServicesOfparticularStaff(string centercode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.getstaffservices(centercode);
            return dt1;

        }

        public Entities.RTOService UpdateTokenBLL(string services, string counterid, string staffcode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            entObj1 = accDAO1.TokenUpdateDAL(services, counterid, staffcode);
            return entObj1;
        }


        public System.Data.DataTable GetStaffAssignedServicesCounterBLL(string staffcode)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = accDAO1.GetStaffAssignedServicesCounterDAL(staffcode);
            return dt;

        }

        public System.Data.DataTable getCurrentTokenNumberServing()
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.getcutokennumber();
            return dt1;

        }
        public System.Data.DataTable gettotalTokenNumberServed()
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.gettotaltokennumberserved();
            return dt1;

        }
        #endregion



        #region for LL exam Call  11-08-2020
        public System.Data.DataTable getLLTokenNumberCompleted(string datenow)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.getlltokennumber(datenow);
            return dt1;

        }

        public Entities.RTOService UpdateLLExamTokenBLL(string datenow)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj1 = new Entities.RTOService();
            entObj1 = accDAO1.TokenLLUpdateDAL(datenow);
            return entObj1;
        }

        public Entities.RTOService InsertLLExamTokenBLL(string txtfromno, string txttono, string datenow, string timenow)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            Entities.RTOService entObj = new Entities.RTOService();
            entObj = accDAO1.InsertLLExamTokenDAL(txtfromno, txttono, datenow, timenow);
            return entObj;
        }

        public System.Data.DataTable gettotalTokenNumberCompleted()
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.gettotaltokennumbercom();
            return dt1;

        }

        public System.Data.DataTable gettotalTokenNumberWaiting()
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.gettotaltokennumberwait();
            return dt1;

        }
        public System.Data.DataTable getfromtoTokenNumber(string datenow)
        {
            DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO accDAO1 = new DataAccessLayer.RTOAdmin.RTOCounterStaffServiceDAO();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = accDAO1.getfromtoTokenNumberft(datenow);
            return dt;
        }
        #endregion

    }
}
