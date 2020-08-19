using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace QMgmtRTO.WebLayer.SuperAdmin
{
    public partial class SuperAdminDashboard : System.Web.UI.Page
    {

        //Entities.Account entObj = new Entities.Account();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        [WebMethod]
        public static string GetAllCenter()
        {

            BusinessLayer.SuperAdmin.SuperAdminCentreManager centMgr = new BusinessLayer.SuperAdmin.SuperAdminCentreManager();
            DataSet ds = new DataSet();

            try
            {
                ds = centMgr.SuperAdminGetCentreBLL();

            }
            catch
            { }
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ds);
            return JSONString;
        }
    }
}