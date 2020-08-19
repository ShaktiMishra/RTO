using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.Entities
{
    public class RTOService
    {

        #region Service Properties - With Naming conventions SPM 22072020
        public int ServiceID_INT { get; set; }
        public string ServiceName_VCR { get; set; }
       
        public string ServiceShortName_VCR { get; set; }
        public string ServiceType_VCR { get; set; }
        public DateTime ServiceCreateDate_DAT { get; set; }
        public DateTime ServiceModifyDate_DAT { get; set; }        
        public int ServiceActiveStatus_INT { get; set; }
        #endregion


        #region Service AssignMapping Properties - With Naming conventions SPM 22072020
        public int CenterID_INT { get; set; }
        public string CenterCode_VCR { get; set; }
        public int StaffID_INT { get; set; }
        public string StaffName_VCR { get; set; }
        public int CounterID_INT { get; set; }
        public string CounterName_VCR { get; set; }
        #endregion

        #region
        public string CurrServiceName_VCR { get; set; }
        public string CurrCounterCode_VCR { get; set; }
        public string CurrStaffCode_VCR { get; set; }
        #endregion

        //#region Properties with Naming Conventions - SPM 19072020

        //public int ServiceID_INT { get; set; }
        //public string ServiceName_VCR { get; set; }
        //public string ServiceShortName_VCR { get; set; }
        //public DateTime ServiceCreateDate_DAT { get; set; }
        //public DateTime ServiceModifyDate_DAT { get; set; }
        //public int ServiceStatus_INT { get; set; }


        //#endregion


        #region LL Exam Call
        public string llfromtoken { get; set; }
        public string lltotoken { get; set; }
        public string lldate { get; set; }
        public string lltime { get; set; }
        #endregion

    }
}
