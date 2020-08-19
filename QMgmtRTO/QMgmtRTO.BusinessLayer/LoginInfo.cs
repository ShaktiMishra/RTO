using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.BusinessLayer
{
    public  class LoginInfo
    {

        Entities.LoginInfo objlogin = new Entities.LoginInfo();  //SPM cmtd 22072020

        //avisek check login details

        public Entities.LoginInfo VerifyLoginBLL(string email, string password)
        {
            DataAccessLayer.VerifyLoginDAL loginDAO = new DataAccessLayer.VerifyLoginDAL();
            Entities.LoginInfo entObj1 = new Entities.LoginInfo();

            //entObj1 = accDAO1.VerifyLoginDAL(txtsupusername, txtsuppassword);

            entObj1 = loginDAO.VerifyLogin(email, password);

            return entObj1;

        }




    }
}
