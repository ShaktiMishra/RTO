﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.RTOAdmin
{
    public partial class RTOAdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Centercode = Session["CenterCode"].ToString();
        }
    }
}