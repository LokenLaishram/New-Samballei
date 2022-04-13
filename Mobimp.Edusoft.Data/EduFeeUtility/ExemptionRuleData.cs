using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class ExemptionRuleData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int ExemptionID { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public decimal FeeAmount_New { get; set; }
        [DataMember]
        public decimal FeeAmount_Old { get; set; }
        [DataMember]
        public decimal ExemptedAmount_New { get; set; }
        [DataMember]
        public decimal ExemptedAmount_Old { get; set; }
        [DataMember]
        public decimal NetAmount_New { get; set; }
        [DataMember]
        public decimal NetAmount_Old { get; set; }
        [DataMember]
        public bool IsActivate { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public int PaymentID { get; set; }
    }
    public class TransportExemptionRuleData : BaseData
    {
        [DataMember]
        public int ExemptionID { get; set; }
        [DataMember]
        public int FeeID { get; set; }
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public decimal Fare { get; set; }
        [DataMember]
        public decimal ExemptedAmount { get; set; }
        [DataMember]
        public decimal NetFare { get; set; }
    }
}
