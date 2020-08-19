using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Display_Demo_Room_Display : System.Web.UI.Page
{
    public string Files { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // Set Video Files List Value as Json string array to Files property
            Files = FileList();
        }
    }
    private string FileList()
    {
        // Folder Name from Your Project
        string folderName = "../Videos";
        // Get all Videos files from Folder
        DirectoryInfo info = new DirectoryInfo(Server.MapPath(folderName));
        // Set the Path as Folder Name and file name
        List<string> files = info.GetFiles().Select(p => string.Format("{0}/{1}", folderName, p.Name)).ToList();
        // return Json Array as string
        return (new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(files));
    }
}