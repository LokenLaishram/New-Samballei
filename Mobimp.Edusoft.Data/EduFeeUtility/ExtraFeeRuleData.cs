using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class ExtraFeeRuleData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int SessionID { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int AddRow { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public String Miscellaneous { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public bool IsActivate { get; set; }
        [DataMember]
        public int IsOptional { get; set; }
        [DataMember]
        public int IsMisc { get; set; }
    }
       
}
