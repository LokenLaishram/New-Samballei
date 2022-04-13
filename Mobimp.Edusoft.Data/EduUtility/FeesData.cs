using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class FeesData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public string StreamName { get; set; }
        [DataMember]
        public decimal FeeAmount { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string FeeName { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int AdmissionTypeID { get; set; }
        [DataMember]
        public int StudentCategoryID { get; set; }
        [DataMember]
        public string AdmissionType { get; set; }
        [DataMember]
        public Int32 CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public decimal ExemptedAmount { get; set; }
        [DataMember]
        public decimal NetAmount { get; set; }
        [DataMember]
        public string xmlfeelist { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public string FeeCode { get; set; }
        
        [DataMember]
        public int PaymentID { get; set; }
        [DataMember]
        public string PaymentName { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string ExcelStatus { get; set; }
        [DataMember]
        public decimal LateFine { get; set; }
        [DataMember]
        public DateTime FineDate { get; set; }
        [DataMember]
        public decimal DueAmount { get; set; }
        [DataMember]
        public bool DueAllowed { get; set; }
        [DataMember]
        public string Months { get; set; }
        [DataMember]
        public int FeeAllowed { get; set; }
        [DataMember]
        public string Class { get; set; }
    }
    public class FeeTypeDatatoExcel
    {
        [DataMember]
        public string AdmissionType { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public decimal ExemptedAmount { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
    }
    public class FeeTypetoExcel
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public string FeeCode { get; set; }
        [DataMember]
        public string FeeName { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string ExcelStatus { get; set; }
    }


}
