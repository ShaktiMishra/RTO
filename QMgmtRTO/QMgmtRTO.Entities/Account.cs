using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.Entities
{
    public class Account
    {


        //#region Properties
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }

        //public string Email { get; set; }
        //public string ConfirmPassword { get; set; }
        //public string Contact { get; set; }
        //public string Address { get; set; }
        //public string Name { get; set; }
        //public string CreateDate { get; set; }
        //public string Modifydate { get; set; }

        //public string AccType { get; set; }
        //public string Status { get; set; }
        //public string EmpCode { get; set; }

        //public int QueryResultCount { get; set; }

        ////public int queryResult { get; set; }
        ////public string logid { get; set; }

        //#endregion //old implementation SPM18072020 // re-cmtd SPM 22072020


        #region Properties with Naming Conventions - SPM 18072020

        public int AccountID_INT { get; set; }
        public string AccountCode_VCR { get; set; }
        public string AccountName_VCR { get; set; }
        public string AccountPassword_VCR { get; set; }
        public string AccountEmailID_VCR { get; set; }

        public string AccountMobileNo_VCR { get; set; }
        public DateTime AccountCreateDate_DAT { get; set; }
        public DateTime AccountModifyDate_DAT { get; set; }
        public string AccountType_VCR { get; set; }
        public int AccountActiveStatus_INT { get; set; }
        public int AccountLoginStatus_INT { get; set; }

        public string AccountCentrerCode { get; set; } //06082020

        #endregion



    }
}
