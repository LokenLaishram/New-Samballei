using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class FeesTypeMasterData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string FeeCode { get; set; }
        [DataMember]
        public string FeeName { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string ExcelStatus { get; set; }
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
