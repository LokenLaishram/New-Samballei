using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class OneTimePaymentData : BaseData
    {
        [DataMember]
        public int OnetimeID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public int PaymentID { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public decimal FeeAmount_New { get; set; }
        [DataMember]
        public decimal FeeAmount_Old { get; set; }
        [DataMember]
        public bool IsActivate { get; set; }
        [DataMember]
        public int AddRow { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int SessionID { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public decimal TotalNewFeeAmount { get; set; }
        [DataMember]
        public decimal TotalOldFeeAmount { get; set; }
        [DataMember]
        public decimal DiscountLimit { get; set; }
        [DataMember]
        public string DueDate { get; set; }
        [DataMember]
        public decimal Fine { get; set; }
        [DataMember]
        public int ID { get; set; }
    }
}
