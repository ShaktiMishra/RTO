using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Data.Common;


namespace QMgmtRTO.DataAccessLayer.Common
{
    /// <summary>
    /// Class that represents the common abstraction for all database related activities
    /// </summary>

    public abstract class DAO
    {

    /// <Summary>
    /// Implementing changed architechture using Stored Procedures - Shakti 09Jul2020
    /// </Summary>

    #region New Implementation of architecture with stored procedures - Shakti 09Jul2020


    #region GetConnection -opens DB connection -SPM 23072020
    protected IDbConnection GetConnection()
    {
        DbConnection conn1=null;
        try
        {
        string providerName = ConfigurationManager.ConnectionStrings["RTOConnectionString"].ProviderName;
        string connString1 = ConfigurationManager.ConnectionStrings["RTOConnectionString"].ConnectionString;
        conn1 = DbProviderFactories.GetFactory(providerName).CreateConnection();
        conn1.Close();
        conn1.ConnectionString = connString1;
        conn1.Open();
            
        }

        catch(Exception e)
        {
            string s = e.ToString();
        }
        return conn1;
    }
    #endregion

    #region ExecuteSPDataSet -returns DataSet -SPM 23072020
    protected DataSet ExecuteSPDataSet(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
    {
        IDbCommand cmd = null;
        cmd = DbConnection.CreateCommand();
        cmd.CommandText = StoredProcedureName;
        cmd.CommandType = CommandType.StoredProcedure;

        if (Parameters != null)
        {
            foreach (var item in Parameters)
            { cmd.Parameters.Add(item); }
        }

        DataSet dataSet = new DataSet();
        IDbDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = cmd;
        dataAdapter.Fill(dataSet);

        return dataSet;
    }
    #endregion

    #region ExecuteSPReader -returns IDataReader -SPM 23072020        
    protected IDataReader ExecuteSPReader(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
    {
        IDbCommand cmd = null;
        try
        {
                

            cmd = DbConnection.CreateCommand();                
            cmd.CommandText = StoredProcedureName;                
            cmd.CommandType = CommandType.StoredProcedure;                
            foreach (var item in Parameters)
            { cmd.Parameters.Add(item); }
        }

        catch (Exception e)
        {
            string p = e.ToString();
        }

    return cmd.ExecuteReader();
    }
    #endregion

    #region ExecuteSPNonQuery -returns int for Update/Delete -SPM 23072020       

    protected int ExecuteSPNonQuery(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
    {
        IDbCommand cmd = null;

        cmd = DbConnection.CreateCommand();
        cmd.CommandText = StoredProcedureName;
        cmd.CommandType = CommandType.StoredProcedure;

        if (Parameters != null)
        {
            foreach (var item in Parameters)
            { cmd.Parameters.Add(item); } //SPM 22072020

            //cmd.Parameters.Add(Parameters);
        }
            
        return cmd.ExecuteNonQuery();

    }
    #endregion

    #region ExecuteSPDataTable -returns DataTable for Read -SPM 23072020
    protected DataTable ExecuteSPDataTable(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
    {
        IDbCommand cmd = null;

        cmd = DbConnection.CreateCommand();
        cmd.CommandText = StoredProcedureName;
        cmd.CommandType = CommandType.StoredProcedure;


        if (Parameters != null)
        {
            foreach (var item in Parameters)
            { cmd.Parameters.Add(item); }
        }
        DataTable dt = new DataTable();

        using (SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd))
        {
            da.Fill(dt);
        }

        return dt;
    }
    #endregion       

    #region ExecuteSPScalar -returns int value for Verify -SPM 19072020        
    protected int ExecuteSPScalar(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
    {
        IDbCommand cmd = null;

        cmd = DbConnection.CreateCommand();
        cmd.CommandText = StoredProcedureName;
        cmd.CommandType = CommandType.StoredProcedure;

        foreach (var item in Parameters)
        { cmd.Parameters.Add(item); }

        return (int)cmd.ExecuteScalar();
    }
    #endregion

    #region Send Email Region - SPM 18072020

    protected void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
    {
        string[] cred = mailcredential();
        using (MailMessage mailMessage = new MailMessage())
        {
            mailMessage.From = new MailAddress(cred[0].ToString());
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(recepientEmail));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = cred[1].ToString();
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(cred[2].ToString(), cred[3].ToString());
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = Convert.ToInt32(cred[4].ToString());
            smtp.Send(mailMessage);
        }
    }

    public string[] mailcredential()
    {
        string[] cred = new string[5];
        cred[0] = "webtownsolution123@gmail.com";//from mail 

        cred[1] = "smtp.gmail.com";//smtp.host
        cred[2] = "webtownsolution123@gmail.com";//Username

        cred[3] = "123@123#";//password

        cred[4] = "587";//port Number
        return cred;
    }


        #endregion

        #endregion






        //23072020 Avisek
        public int sExecuteNonQuery(string sqery)
        {
            SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["RTOConnectionString"].ConnectionString);
            SqlConnection con = new SqlConnection();
            int retn = 0;
            try
            {
                scon.Close();
                scon.Open();
                SqlCommand cm = new SqlCommand(sqery, scon);
                retn = cm.ExecuteNonQuery();
                scon.Close();
            }
            catch
            { }
            return retn;
        }

        //Avisek 23072020
        public DataTable sgetdataTable(string sqery)
        {
            SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["RTOConnectionString"].ConnectionString);
            SqlConnection con = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {
                scon.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqery, scon);
                dt.Clear();
                dt.Reset();
                da.Fill(dt);
                scon.Close();

            }
            catch
            { }
            return dt;
        }




        #region XXX EXTRA REGION COMMENTED OUT. Don't yet delete -SPM 23072020


        #region XXX Extra SP function - cmtd - 1741 23072020
        /// <summary>
        /// Executes a storedprocedure with provided name and parameters and returns the DataTable.
        /// </summary>
        /// <returns></returns>
        //protected DataTable ExecuteStoredProcedureDataTable(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        //{
        //    IDbCommand cmd = null;


        //    {
        //        da.Fill(dt1);
        //    }

        //    //public DataTable spGetData()
        //    //{
        //    //    //string conn = "";
        //    //    //conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        //    //    //SqlConnection objsqlconn = new SqlConnection(conn);
        //    //    try
        //    //    {


        //    return dt1;

        //}
        //protected DataTable ExecuteStoredProcedureDataTable(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        //{
        //    IDbCommand cmd = null;

        //    cmd = DbConnection.CreateCommand();
        //    cmd.CommandText = StoredProcedureName;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    if (Parameters != null)
        //    {
        //        foreach (var item in Parameters)
        //        { cmd.Parameters.Add(item); }
        //    }
        //    DataTable dt1 = new DataTable();

        //    using (SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd))
        //    {
        //        da.Fill(dt1);
        //    }



        //    return dt1;

        //}


        /// <summary>
        /// Executes a storedprocedure with provided name and parameters and returns scalar value.
        /// </summary>
        /// <returns></returns>
        /// 
        #endregion


        #region XXX Extra
        /// <summary>
        /// Executes a storedprocedure with provided name and parameters and returns the datatable.
        /// </summary>
        /// <returns></returns>
        //protected DataTable ExecuteSPDataTable(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        //{
        //    IDbCommand cmd = null;
        //    cmd = DbConnection.CreateCommand();
        //    cmd.CommandText = StoredProcedureName;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd = DbConnection.CreateCommand();
        //    cmd.CommandText = StoredProcedureName;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    if (Parameters != null)
        //    {
        //        foreach (var item in Parameters)
        //        { cmd.Parameters.Add(item); }
        //    }
        //    DataTable dt1 = new DataTable();

        //    if (Parameters != null)
        //    {
        //        foreach (var item in Parameters)
        //        { cmd.Parameters.Add(item); }
        //    }
        //    DataTable dt = new DataTable();

        //    using (SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd))
        //    {
        //        da.Fill(dt);
        //    }



        //    using (SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd))

        //        return dt;
        //}
        #endregion

        #region XXX Extra ExecuteSPNonQueryResult -returns int for Update/Delete -SPM 23072020
        //protected int ExecuteSPNonQueryResult(IDbConnection DbConnection, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        //{
        //    IDbCommand cmd = null;

        //    cmd = DbConnection.CreateCommand();
        //    cmd.CommandText = StoredProcedureName;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    foreach (var item in Parameters)
        //    { cmd.Parameters.Add(item); }

        //    return cmd.ExecuteNonQuery();
        //}
        #endregion


        #region XXX Extra Old implementation prior to 9Jul2020
        //    #region Old implementation using query strings - SPM 09Jul2020

        //private string databasename = "";


        ////public SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        ////public SqlConnection con = new SqlConnection();

        ////public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlUser"].ConnectionString);
        //public void DataAccessClass()
        //{


        //SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);    
        //SqlConnection con = new SqlConnection();
        //    try
        //    {

        //        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        //        {
        //            if (HttpContext.Current.Session["dbName"] != null)
        //            {
        //                var underconstruction = HttpContext.Current.Session["dbName"];
        //                if (underconstruction != null)
        //                {
        //                    string oc = underconstruction.ToString();
        //                    con = new SqlConnection("Data Source=DESKTOP-DRRTKFN\\SERVER;Initial Catalog=" + oc + ";User ID=sa;Password=sql@2017;");
        //                    //if (oc != "false") Response.Redirect("~/Home.aspx");
        //                }
        //            }

        //        }


        //    }
        //    catch
        //    { 

        //    }
        //}

        ////public string _databasename
        ////{
        ////    get { return _databasename; }
        ////    set { _databasename = value; }


        ////}


        //public int ExecuteNonQuery(string sqery)
        //{
        //    SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        //    SqlConnection con = new SqlConnection();
        //    int retn = 0;
        //    try
        //    {

        //        con.Close();
        //        con.Open();
        //        SqlCommand cm = new SqlCommand(sqery, con);
        //        retn = cm.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch
        //    { }
        //    return retn;
        //}

        //public DataTable getdataTable(string sqery)
        //{
        //    SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        //    SqlConnection con = new SqlConnection();
        //    DataTable dt = new DataTable();
        //    try
        //    {

        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(sqery, con);
        //        dt.Clear();
        //        dt.Reset();
        //        da.Fill(dt);
        //        con.Close();

        //    }
        //    catch
        //    { }
        //    return dt;
        //}
        //public DataSet getdataset(string sqery)
        //{
        //    SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        //    SqlConnection con = new SqlConnection();
        //    DataSet ds = new DataSet();
        //    try
        //    {

        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(sqery, con);
        //        ds.Clear();
        //        ds.Reset();
        //        da.Fill(ds);
        //        con.Close();
        //    }
        //    catch
        //    { }
        //    return ds;
        //}
        ////public void welcomemail(string Name, string emailId, string subject, string description, string endPrt1, string endPrt2)
        ////{
        ////    SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        ////    SqlConnection con = new SqlConnection();
        ////    string body = string.Empty;
        ////    using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/ADMIN/Email_Format/WelcomeMail.html")))
        ////    {
        ////        body = reader.ReadToEnd();
        ////    }
        ////    body = body.Replace("{UserName}", Name);
        ////    body = body.Replace("{subject}", subject);
        ////    body = body.Replace("{description}", description);

        ////    body = body.Replace("{endPrt1}", endPrt1);
        ////    body = body.Replace("{endPrt2}", endPrt2);

        ////    this.SendHtmlFormattedEmail(emailId, subject, body);
        ////}


        ////protected void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        ////{
        ////    string[] cred = mailcredential();
        ////    using (MailMessage mailMessage = new MailMessage())
        ////    {
        ////        mailMessage.From = new MailAddress(cred[0].ToString());
        ////        mailMessage.Subject = subject;
        ////        mailMessage.Body = body;
        ////        mailMessage.IsBodyHtml = true;
        ////        mailMessage.To.Add(new MailAddress(recepientEmail));
        ////        SmtpClient smtp = new SmtpClient();
        ////        smtp.Host = cred[1].ToString();
        ////        smtp.EnableSsl = true;
        ////        NetworkCredential NetworkCred = new NetworkCredential(cred[2].ToString(), cred[3].ToString());
        ////        smtp.UseDefaultCredentials = true;
        ////        smtp.Credentials = NetworkCred;
        ////        smtp.Port = Convert.ToInt32(cred[4].ToString());
        ////        smtp.Send(mailMessage);
        ////    }
        ////}

        ////public string[] mailcredential()
        ////{
        ////    string[] cred = new string[5];
        ////    //cred[0] = "webtownsolution123@gmail.com";//from mail // SPMcmtd
        ////    cred[0] = "shaktihelps@gmail.com";//from mail // SPMcmtd
        ////    cred[1] = "smtp.gmail.com";//smtp.host
        ////    //cred[2] = "webtownsolution123@gmail.com";//Username // SPMcmtd
        ////    cred[2] = "shaktihelps@gmail.com";//Username // SPMcmtd
        ////    //cred[3] = "123@123#";//password //SPM cmtd 15Jul2020
        ////    cred[3] = "loveandlabour";//password //SPM cmtd 15Jul2020
        ////    cred[4] = "587";//port Number
        ////    return cred;
        ////}


        ////superadmin
        //public DataTable sgetdataTable(string sqery)
        //{
        //    SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        //    SqlConnection con = new SqlConnection();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        scon.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(sqery, scon);
        //        dt.Clear();
        //        dt.Reset();
        //        da.Fill(dt);
        //        scon.Close();

        //    }
        //    catch
        //    { }
        //    return dt;
        //}
        //public int sExecuteNonQuery(string sqery)
        //{
        //    SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        //    SqlConnection con = new SqlConnection();
        //    int retn = 0;
        //    try
        //    {
        //        scon.Close();
        //        scon.Open();
        //        SqlCommand cm = new SqlCommand(sqery, scon);
        //        retn = cm.ExecuteNonQuery();
        //        scon.Close();
        //    }
        //    catch
        //    { }
        //    return retn;
        //}

        //public DataSet sgetdataset(string sqery)
        //{
        //    SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
        //    SqlConnection con = new SqlConnection();
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        scon.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(sqery, scon);
        //        ds.Clear();
        //        ds.Reset();
        //        da.Fill(ds);
        //        scon.Close();
        //    }
        //    catch
        //    { }
        //    return ds;
        //}

        //#endregion
        #endregion

        #endregion

    }
}
