using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class PaymentTypeData:BaseData
    {
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
    }
    public class PaymentTypeDataToExcel
    {
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
    }
}
