using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.Entities
{
   public class RTOCounter
    {
        #region Properties

        public int CounterID_INT { get; set; }
        public string CounterName_VCR { get; set; }
        public string CounterCode_VCR { get; set; }
        public string DeviceCode_VCR { get; set; }
        public string CentreCode_VCR { get; set; }
        public DateTime CounterCreateDate_DAT { get; set; }
        public DateTime CounterModifyDate_DAT { get; set; }
        public string CounterActiveStatus_INT { get; set; }

        #endregion

    }
}
