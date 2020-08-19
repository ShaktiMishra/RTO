using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QMgmtRTO.DataAccessLayer;

namespace QMgmtRTO.BusinessLayer
{
    public class AccountManager
    {

        #region Login credential DAL --Pravanjan Nayak

        public System.Data.DataTable SuperadmindetailsBLL()
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            Entities.Account entObj1 = new Entities.Account();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.SuperadmindetailsDLL();
            return dt1;

        }

        public int UpdatedetailsSuperadminBLL(string Name, string Emailid, string Address, string PhNo)
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            int entObj1;
            entObj1 = accDAO1.UpdatedetailsSuperadminDAL(Name, Emailid, Address, PhNo);
            return entObj1;

        }

        public System.Data.DataTable CheckLogindetailsBLL(string email,string password)
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            Entities.Account entObj1 = new Entities.Account();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.CheckLogindetailsBLL(email, password);
            return dt1;

        }

        public System.Data.DataTable ForgetemailBLL(string Emailid)
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            Entities.Account entObj1 = new Entities.Account();


            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.ForgetemailDAL(Emailid);
            return dt1;

        }
        #endregion

        #region SuperAdmin Registrations BLL --Pravanjan Nayak

        public int SuperadminRegistrationsBLL(string Name, string Emailid, string Address, string PhNo)
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            int entObj1;
            entObj1 = accDAO1.SuperAdminRegistrationDAL(Name, Emailid, Address, PhNo);
            return entObj1;

        }

        public System.Data.DataTable CheckemailBLL(string Emailid)
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            Entities.Account entObj1 = new Entities.Account();


            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.checkemailDAL(Emailid);
            return dt1;

        }

        public System.Data.DataTable CheckcontactnoBLL(string PhNo)
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            Entities.Account entObj1 = new Entities.Account();


            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.checkcontactnoDAL(PhNo);
            return dt1;

        }

        public System.Data.DataTable CheckSuperadmindetailsBLL()
        {
            DataAccessLayer.AccountManagerDAO accDAO1 = new DataAccessLayer.AccountManagerDAO();
            Entities.Account entObj1 = new Entities.Account();
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = accDAO1.CheckSuperadmindetailsDAL();
            return dt1;

        }

        #endregion
    }
}
