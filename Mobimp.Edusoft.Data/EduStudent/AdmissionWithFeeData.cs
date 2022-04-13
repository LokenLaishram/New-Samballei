using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduStudent
{
    [Serializable]
    public class AdmissionWithFeeData : BaseData
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public string StudentCode { get; set; }
        [DataMember]
        public Int64 AdmissionID { get; set; }
        [DataMember]
        public string AdmissionNo { get; set; }
        [DataMember]
        public int cCountryID { get; set; }
        [DataMember]
        public int cStateID { get; set; }
        [DataMember]
        public int cPIN { get; set; }
        [DataMember]
        public int cDistrictID { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public int GsexID { get; set; }
        [DataMember]
        public DateTime AdmissionDate { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public string GmobileNo { get; set; }
        [DataMember]
        public string cAddress { get; set; }
        [DataMember]
        public string GsexName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int IsNew { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int IsAdmissionDone { get; set; }
        [DataMember]
        public string AvailableStudentID { get; set; }
        [DataMember]
        public Int64 NextStudentID { get; set; }
    }
    public class AdmFeeData : BaseData
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public string AdmissionNo { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int IsAdmissionDone { get; set; }
        ///////////SCHOOLFEECOLLECTION/////////////////
        [DataMember]
        public int AdmissionTypeID { get; set; }
        [DataMember]
        public Decimal FeeAmount { get; set; }
        [DataMember]
        public Decimal ExemptedAmount { get; set; }
        [DataMember]
        public Decimal FineAmount { get; set; }
        [DataMember]
        public Decimal TotalFeeAmount { get; set; }
        [DataMember]
        public Decimal TotalStudentDueAmount { get; set; }
        [DataMember]
        public Decimal TotalCurrentDue { get; set; }
        [DataMember]
        public int FeetypeID { get; set; }
        [DataMember]
        public Decimal PaidAmount { get; set; }
        [DataMember]
        public Decimal PayableAmount { get; set; }
        [DataMember]
        public Decimal DueAmount { get; set; }
        [DataMember]
        public Decimal DiscountAmount { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public DateTime AdmissionDate { get; set; }
    }
}
