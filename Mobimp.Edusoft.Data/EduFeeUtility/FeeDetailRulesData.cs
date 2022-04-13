using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class FeeDetailRulesData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public int FeeStructureStatus { get; set; }
        [DataMember]
        public decimal FeeNewStudent { get; set; }
        [DataMember]
        public decimal FeeOldStudent { get; set; }
        [DataMember]
        public int IsStudentTypeApply { get; set; }
        [DataMember]
        public int ExemptionRuleStatus { get; set; }
        [DataMember]
        public int InclusiveRuleStatus { get; set; }
        [DataMember]
        public int FeeHeirarchy { get; set; }
        [DataMember]
        public bool IsActivate { get; set; }
        [DataMember]
        public int SessionID { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int NoEMI { get; set; }


    }
}