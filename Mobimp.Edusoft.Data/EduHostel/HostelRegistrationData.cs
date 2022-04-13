using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Campusoft.Data.EduHostel
{
    [Serializable]
    public class HostelRegistrationData : BaseData
    {
        public string AdmissionNo { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public Int64 AdmissionID { get; set; }
        [DataMember]
        public int IsNew { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string BlockName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 IDS { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string Sfirstname { get; set; }
        [DataMember]
        public Int64 RegistrationNo { get; set; }
        [DataMember]
        public Int64 UserloginID { get; set; }
        [DataMember]
        public int BlockID { get; set; }
        [DataMember]
        public Decimal DepositAmount { get; set; }
        [DataMember]
        public Int64 WardenID { get; set; }
        [DataMember]
        public string WardenName { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public Decimal HostelDepositAmount { get; set; }
        [DataMember]
        public Decimal DueAmount { get; set; }
        [DataMember]
        public int DepositStatus { get; set; }
        [DataMember]
        public int DryID { get; set; }
        [DataMember]
        public string Dry { get; set; }
        [DataMember]
        public Decimal TotalDepsoitAmount { get; set; }
        [DataMember]
        public Decimal TotalDueAmount { get; set; }
        [DataMember]
        public Decimal TotalPaidAmount { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int RemarkID { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string MonthNames { get; set; }
        [DataMember]
        public DateTime EntranceDate { get; set; }
        [DataMember]
        public DateTime WithdrawlDate { get; set; }
        [DataMember]
        public int HstudentTypeID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public bool IsHostelregister { get; set; }
        [DataMember]
        public int PaymentType { get; set; }
        [DataMember]
        public int StudentCategory { get; set; }
        [DataMember]
        public int Istakingtransport { get; set; }
        [DataMember]
        public int IsBoardingStudent { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public Int32 Bed { get; set; }
    }
}
