using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QMgmtRTO.WebLayer.RTOAdmin
{
    /// <summary>
    /// Summary description for FileCS
    /// </summary>
    public class FileCS : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            int id = int.Parse(context.Request.QueryString["id"]);
            byte[] bytes;
            string contentType;
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            string name;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data, ContentType FROM tbl_video_upload_demoroom WHERE id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        name = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
            context.Response.ContentType = contentType;
            context.Response.BinaryWrite(bytes);
            context.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}