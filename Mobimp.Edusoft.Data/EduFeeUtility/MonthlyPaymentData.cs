using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class MonthlyPaymentData : BaseData
    {
        [DataMember]
        public int MonthlyID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int SessionID { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public int PaymentID { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public int AddRow { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public decimal FeeAmount_New { get; set; }
        [DataMember]
        public decimal FeeAmount_Old { get; set; }
        [DataMember]
        public decimal Exemption { get; set; }
        [DataMember]
        public decimal TotalFeeAmount_New { get; set; }
        [DataMember]
        public decimal TotalFeeAmount_Old { get; set; }
        [DataMember]
        public decimal NetFeeAmount_New { get; set; }
        [DataMember]
        public decimal NetFeeAmount_Old { get; set; }
        [DataMember]
        public bool IsActivate { get; set; }
        [DataMember]
        public int Prepaid { get; set; }
        [DataMember]
        public int Postpaid { get; set; }
        [DataMember]
        public DateTime DiscountDate { get; set; }
        [DataMember]
        public decimal DiscountLimit { get; set; }
        [DataMember]
        public decimal Fine { get; set; }
        [DataMember]
        public int IsOneTimePayment { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int EMI { get; set; }
        [DataMember]
        public decimal Computerfee { get; set; }
    }
}
