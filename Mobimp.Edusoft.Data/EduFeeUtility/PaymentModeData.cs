using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class PaymentModeData:BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int PaymentModeID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class PaymentModeDatatoExcel
    {
        [DataMember]
        public int PaymentModeID { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
}
