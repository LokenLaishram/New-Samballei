using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFees
{
    [Serializable]
    public class MonthlyFeeStatementData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
    }
}
