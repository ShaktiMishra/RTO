using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMgmtRTO.Entities
{
    public class Display
    {
        #region Pravanjan Nayak

        public int TokenID_INT { get; set; }
        public int TokenNo_INT { get; set; }
        public string ApplicationNo_VCR { get; set; }
        public string CentreCode_VCR { get; set; }

        public string ApplicantName_VCR { get; set; }
        public string ApplicantSWDof_VCR { get; set; }
        public string ApplicantMobileNo_VCR { get; set; }
        public string ApplicantVehicle_VCR { get; set; }
        public DateTime ApplicantBookedDate_DAT { get; set; }
        public string ApplicantBookedService_VCR { get; set; }
        public string ApplicantBookedMode_VCR { get; set; }
        public string ApplicantResult_VCR { get; set; }

        public int TokenActiveStatus_INT { get; set; }
        public DateTime TokenSlotDate_DAT { get; set; }
        public DateTime TokenStartTime_DAT { get; set; }
        public DateTime TokenEndTime_DAT { get; set; }
        public string TokenSlotTime_VCR { get; set; }
        public string TokenTotServiceTime_VCR { get; set; }

        public string CurrServiceName_VCR { get; set; }
        public string CurrCounterCode_VCR { get; set; }
        public string CurrStaffCode_VCR { get; set; }
        public string CurrTokenState_VCR { get; set; }



        #endregion


    }
}
