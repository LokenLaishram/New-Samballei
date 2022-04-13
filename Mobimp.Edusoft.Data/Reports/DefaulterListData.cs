using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.Reports
{
    public class DefaulterListData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public string DStatus { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public Decimal FeeAmount { get; set; }
        [DataMember]
        public Decimal FineAmount { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public string MonthNames { get; set; }
        [DataMember]
        public int IsActive { get; set; }
        [DataMember]
        public string AdmissioNo { get; set; }
        [DataMember]
        public string FineRemarks { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public int StudentCategoryID { get; set; }
        [DataMember]
        public decimal TotalFees { get; set; }
        [DataMember]
        public decimal TotalFine { get; set; }
        [DataMember]
        public string AdmissionNo { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int ActionTypes { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }

    }
}
