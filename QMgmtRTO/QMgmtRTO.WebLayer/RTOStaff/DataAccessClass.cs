using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QMgmtRTO.WebLayer.RTOStaff
{
    public class DataAccessClass
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RTOConnectionString"].ConnectionString);
        public int ExecuteNonQuery(string sqery)
        {
            int retn = 0;
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand(sqery, con);
                retn = cm.ExecuteNonQuery();
                con.Close();
            }
            catch
            { }
            return retn;
        }

        public DataTable getdataTable(string sqery)
        {

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqery, con);
                dt.Clear();
                dt.Reset();
                da.Fill(dt);
                con.Close();
            }
            catch
            { }
            return dt;
        }
        public DataSet getdataset(string sqery)
        {

            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqery, con);
                ds.Clear();
                ds.Reset();
                da.Fill(ds);
                con.Close();
            }
            catch
            { }
            return ds;
        }
    }
}