using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Campusoft.Data.EduHostel
{
    [Serializable]
    public class HostelVisitorData : BaseData
    {
        public string StudentName { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public Int64 ID { get; set; }
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
        public string CategoryName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public Int64 RegistrationNo { get; set; }
        [DataMember]
        public Int64 UserloginID { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string MonthNames { get; set; }
        [DataMember]
        public DateTime EntranceDate { get; set; }
        [DataMember]
        public DateTime WithdrawlDate { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Contact { get; set; }
        ///////hostel visit
        [DataMember]
        public string VisitPurpose { get; set; }
        [DataMember]
        public string VisitorName { get; set; }
        [DataMember]
        public string VisitTime { get; set; }
        [DataMember]
        public DateTime VisitDate { get; set; }
        [DataMember]
        public int HstudentTypeID { get; set; }
    }

    public class ExcelHostelVisitor
    {
        public Int64 StudentID { get; set; }
        [DataMember]
        public Int64 RegdNo { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string VisitorName { get; set; }
        [DataMember]
        public string PurposeOfVisit { get; set; }
        [DataMember]
        public string DateOfVisit { get; set; }
        [DataMember]
        public string TimeOfVisit { get; set; }

    }
}
