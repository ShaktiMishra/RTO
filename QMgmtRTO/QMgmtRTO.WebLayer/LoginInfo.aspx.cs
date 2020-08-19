using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMgmtRTO.WebLayer
{
    public partial class LoginInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                dvsignup.Style["display"] = "none";
                dvlogin.Style["display"] = "block";
                dvforget.Style["display"] = "none";
                txtusername.Focus();
            }
            //BusinessLayer.AccountManager accMgr = new BusinessLayer.AccountManager();
            //Entities.Account entObj = new Entities.Account();

            //try
            //{
            //    DataTable dt = new DataTable();
            //    dt = accMgr.CheckSuperadmindetailsBLL();
            //    if (dt.Rows.Count > 0)
            //    {
            //        Response.Write("<script language='javascript'>window.alert('SuperAdmin Already Registered');</script>");

            //    }
            //    else
            //    {

            //    }
            //}
            //catch { }
        }
        #region Login credential --Pravanjan Nayak

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            BusinessLayer.AccountManager accMgr = new BusinessLayer.AccountManager();
            Entities.Account entObj = new Entities.Account();
            BusinessLayer.PasswordEncryp pwd = new BusinessLayer.PasswordEncryp();
            try
            {
                string pws = txtpassword.Text;
                string email = txtusername.Text;
                string password = pwd.Encryptdata(pws);
                DataTable dtlogin = new DataTable();
                dtlogin = accMgr.CheckLogindetailsBLL(email, password);
                if (dtlogin.Rows.Count > 0)
                {
                    string Type = dtlogin.Rows[0]["LoginType_VCR"].ToString();
                    string Login_Id = dtlogin.Rows[0]["LoginID_INT"].ToString();
                    string CCode = dtlogin.Rows[0]["LoginCode_VCR"].ToString();
                    string CenterCode = "";
                    string Id = "";
                    if (CCode.Contains("_"))     //Split RTO_tblLoginCredential LoginCode_VCR to  center code And Id
                    {
                        string[] findCenterCode = CCode.Split('_');
                        CenterCode = findCenterCode[0];  //Center Code
                        Id = findCenterCode[1];  //User id like Staff id
                    }
                    else
                    {
                        CenterCode = CCode;
                        Id = CCode;
                    }
                    //Code for-----------You have active session some where.Do you Want to Logout from Other Active Session
                    int ActiveStatus = Convert.ToInt32(dtlogin.Rows[0]["LoginActiveStatus_INT"].ToString());
                    if (ActiveStatus != 1)
                    {
                        return;
                    }
                    // Session Declare
                    HttpContext.Current.Session["LoginID_INT"] = Login_Id;
                    HttpContext.Current.Session["CenterCode"] = CenterCode;
                    HttpContext.Current.Session["LoginType"] = Type;
                    HttpContext.Current.Session["Id"] = Id;   //User id like Staff id
                    HttpContext.Current.Session["LoginCode_VCR"] = CCode;
                    if (Type == "SuperAdmin")
                    {
                        Response.Redirect("~/SuperAdmin/SuperAdmin_Dashboard.aspx");
                    }
                    else if (Type == "Admin")
                    {
                        Response.Redirect("~/RTOAdmin/RTOAdminDashboard.aspx");
                    }
                    else if (Type == "user")
                    {
                        if (Id == "p505783")
                        {
                            Response.Redirect("~/RTOStaff/LL_Exam_Call.aspx");
                        }
                        else if (Id == "a244301")
                        {
                            Response.Redirect("~/RTOStaff/DL_Exam_Call.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/RTOStaff/RTOStaffDashboard.aspx");
                        }
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Invalid Login Credentials !!!');</script>");

                }
            }
            catch
            { }
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            BusinessLayer.AccountManager accMgr = new BusinessLayer.AccountManager();
            Entities.Account entObj = new Entities.Account();
            try
            {
                // Check Super Admin Register Or Not...............................................
                DataTable dtAccontcheck = new DataTable();
                dtAccontcheck = accMgr.CheckSuperadmindetailsBLL();
                if (dtAccontcheck.Rows.Count > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('SuperAdmin Already Registered');window.location='Logininfo.aspx';</script>");
                    return;

                }
                // Check Email Address Present Or Not...............................................
                string Emailid = txtemail.Text;
                DataTable dtmailchk = new DataTable();
                dtmailchk = accMgr.CheckemailBLL(Emailid);
                if (dtmailchk.Rows.Count > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('Email Id Already Exists');</script>");
                    txtemail.Text = "";
                    txtemail.Focus();
                    dvsignup.Style["display"] = "block";
                    dvlogin.Style["display"] = "none";
                    dvforget.Style["display"] = "none";
                    return;
                }
                // Check Mobile Number Present Or Not...............................................
                string PhNo = txtmob.Text;
                DataTable dtmobchk = new DataTable();
                dtmobchk = accMgr.CheckcontactnoBLL(PhNo);
                if (dtmobchk.Rows.Count > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('Mobile Number Already Exists');</script>");
                    txtmob.Text = "";
                    txtmob.Focus();
                    dvsignup.Style["display"] = "block";
                    dvlogin.Style["display"] = "none";
                    dvforget.Style["display"] = "none";
                    return;
                }
                // Insert Super Admin details...............................................
                string Name = txtname.Text;
                string Address = txtaddress.Text;
                int insrtsadmn = accMgr.SuperadminRegistrationsBLL(Name, Emailid, Address, PhNo);
                if (insrtsadmn > 0)
                {
                    Response.Write("<script language='javascript'>window.alert('Thanks! Your account has been created successfully.');</script>");
                    dvsignup.Style["display"] = "none";
                    dvlogin.Style["display"] = "block";
                    dvforget.Style["display"] = "none";
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('Sorry! Error in account creation.');</script>");
                    dvsignup.Style["display"] = "block";
                    dvlogin.Style["display"] = "none";
                    dvforget.Style["display"] = "none";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnforgetpsw_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.AccountManager accMgr = new BusinessLayer.AccountManager();
                Entities.Account entObj = new Entities.Account();
                string Emailid = txtfemail.Text;
                if (Emailid != string.Empty)
                {
                    DataTable dtmailchk = new DataTable();
                    dtmailchk = accMgr.ForgetemailBLL(Emailid);
                    if (dtmailchk.Rows.Count > 0)
                    {
                        Response.Write("<script language='javascript'>window.alert('Please check your inbox, we have sent you reset password url');</script>");
                        txtfemail.Text = "";
                        dvsignup.Style["display"] = "none";
                        dvlogin.Style["display"] = "block";
                        dvforget.Style["display"] = "none";
                        txtusername.Focus();
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>window.alert('Your email does not exist. Please enter a valid email.');</script>");
                    }
                }
            }
            catch { }
        }

        #endregion
    }
}