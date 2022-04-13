using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class InclusiveRuleData : BaseData
    {
        [DataMember]

        public int ID { get; set; }
        [DataMember]
        public int InclusiveID { get; set; }
        [DataMember]
        public int MonthlyID { get; set; }
        [DataMember]
        public string Particulars { get; set; }
         [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public bool IsActivate { get; set; }
        [DataMember]
        public int OtherFeeTypeID { get; set; }
        [DataMember]
        public int MonthID { get; set; }

    }
}
