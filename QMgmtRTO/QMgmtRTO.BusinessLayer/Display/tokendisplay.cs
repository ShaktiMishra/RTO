using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.BusinessLayer.Display
{
     public class tokendisplay
    {

         public System.Data.DataTable GetDisplayTokenBLL(string service,string centercode)
         {
             DataAccessLayer.Display.tokendisplay token = new DataAccessLayer.Display.tokendisplay();
             Entities.Display entObj1 = new Entities.Display();
             System.Data.DataTable dt = new System.Data.DataTable();
             dt = token.GetTokenDetailsDAL(service,centercode);
             return dt;

         }
         public System.Data.DataTable SGetDisplayTokenBLL(string service, string centercode)
         {
             DataAccessLayer.Display.tokendisplay token = new DataAccessLayer.Display.tokendisplay();
             Entities.Display entObj1 = new Entities.Display();
             System.Data.DataTable dt = new System.Data.DataTable();
             dt = token.SGetTokenDetailsDAL(service, centercode);
             return dt;

         }
    }
}
