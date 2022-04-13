using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.Data.HRAndPayroll.HR
{
    [Serializable]
    public class LeaveRequestData: BaseData
    {
        [DataMember]
        public string LeaveRequestNo { get; set; }
        [DataMember]
        public string LeaveType { get; set; }
        [DataMember]
        public string RequestedBy { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public int YearID { get; set; }
        [DataMember]
        public int LeaveID { get; set; }
        [DataMember]
        public int TotalDays { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public string Month { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime RequestedDate { get; set; }
        [DataMember]       
        public string Day { get; set; }
        [DataMember]
        public int IsHoliday { get; set; }                
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public int IsApproved { get; set; }
        [DataMember]
        public string IsApprovedStatus { get; set; }
        [DataMember]
        public int IsRequested { get; set; }
        [DataMember]
        public int PreviousLeavestatus { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string DeleteRemark { get; set; }
        [DataMember]
        public int RequestStatus { get; set; }
        [DataMember]
        public int ApprovalStatus { get; set; }
    }    
}
