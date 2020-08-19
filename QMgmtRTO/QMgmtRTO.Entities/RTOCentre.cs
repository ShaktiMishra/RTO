using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.Entities
{
    public class RTOCentre
    {
        #region Properties

        public int CentreID_INT { get; set; }
        public string CentreCode_VCR { get; set; }
        public string CentreLogo_VCR { get; set; }
        public string CentreName_VCR { get; set; }
        public string CentreEmailID_VCR { get; set; }
        public string CentreMobileNo_VCR { get; set; }
        public string CentreAddress_VCR { get; set; }
        public string CentrePINCode_VCR { get; set; }        
        public DateTime CentreCreateDate_DAT { get; set; }        
        public string CentreActiveStatus_INT { get; set; }
        public string CentreLoginStatus_INT { get; set; }
        public int CentreTimeSet_INT { get; set; }
        
        #endregion
    }
}
