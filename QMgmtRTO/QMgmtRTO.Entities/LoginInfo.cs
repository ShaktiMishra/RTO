using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.Entities
{
   public  class LoginInfo
    {
        #region Properties

        public string Login_Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string CenterCode { get; set; } 
        public string Type { get; set; }
        public string Status { get; set; }
        #endregion
    }
}
