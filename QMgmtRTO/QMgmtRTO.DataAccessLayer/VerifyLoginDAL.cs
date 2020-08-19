using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QMgmtRTO.Entities;

namespace QMgmtRTO.DataAccessLayer
{
   public  class VerifyLoginDAL:DataAccessLayer.Common.DAO
    {

       DataTable dt = new DataTable();
       LoginInfo el = new LoginInfo();


        //23072020 Avisek
       public LoginInfo VerifyLogin(string email,string pass)
       {
           
           try
           {
               dt = sgetdataTable("select * from RTO_tblLoginCredential where LoginEmailID_VCR='" + email + "' and LoginPassword_VCR='" + pass + "' and LoginActiveStatus_INT=1");
               if (dt.Rows.Count > 0)
               {


                   el.EmailId = dt.Rows[0]["LoginEmailID_VCR"].ToString();
                   el.Password = dt.Rows[0]["LoginPassword_VCR"].ToString();
                   el.Type = dt.Rows[0]["LoginType_VCR"].ToString();
                   el.Login_Id = dt.Rows[0]["LoginID_INT"].ToString();
                   el.CenterCode = dt.Rows[0]["LoginCode_VCR"].ToString();

               }
               
           }
               
           catch
           { }
           return el;
       }


        //23072020 Avisek
        public int Updatepasw(string psw, string loginid)
        {
            int val;

            val = sExecuteNonQuery("Update RTO_tblLoginCredential set LoginPassword_VCR='" + psw + "' where LoginCode_VCR='" + loginid + "'  and LoginActiveStatus_INT='1'");


            return val;
        }



    }
}
