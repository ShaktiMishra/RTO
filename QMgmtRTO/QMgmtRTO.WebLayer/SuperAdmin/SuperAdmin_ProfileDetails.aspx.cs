using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer.SuperAdmin
{
    public partial class SuperAdmin_ProfileDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Superadmindetails();
            }
        }
        public void Superadmindetails()
        {
            try
            {
                BusinessLayer.AccountManager accMgr = new BusinessLayer.AccountManager();
                Entities.Account entObj = new Entities.Account();
                BusinessLayer.PasswordEncryp pwd = new BusinessLayer.PasswordEncryp();
                DataTable dt = new DataTable();
                dt = accMgr.SuperadmindetailsBLL();
                if (dt.Rows.Count > 0)
                {
                    string Name = dt.Rows[0]["SuperAdminName_VCR"].ToString();
                    string Email = dt.Rows[0]["SuperAdminEmailID_VCR"].ToString();
                    string Phone = dt.Rows[0]["SuperAdminMobileNo_VCR"].ToString();
                    string Address = dt.Rows[0]["SuperAdminAddress_VCR"].ToString();
                    txtname.Text = Name;
                    txtemail.Text = Email;
                    txtemail.ReadOnly = true;
                    txtphone.Text = Phone;
                    txtaddress.Text = Address;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtname.Text;
                string Emailid = txtemail.Text;
                string PhNo = txtphone.Text;
                string Address = txtaddress.Text;
                BusinessLayer.AccountManager accMgr = new BusinessLayer.AccountManager();
                int UpdateSadmin = accMgr.UpdatedetailsSuperadminBLL(Name, Emailid, Address, PhNo);
                Response.Write("<script language='javascript'>window.alert('SuperAdmin Details Updated successfully.');</script>");

            }
            catch (Exception ex)
            {

            }

        }
    }
}