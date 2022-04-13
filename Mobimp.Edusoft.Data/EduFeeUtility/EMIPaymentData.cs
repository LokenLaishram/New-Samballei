using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFeeUtility
{
    public class EMIPaymentData : BaseData
    {
        [DataMember]
        public int MonthlyID { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public decimal FeeAmount_New { get; set; }
        [DataMember]
        public decimal FeeAmount_Old { get; set; }
        [DataMember]
        public string DueDate { get; set; }
        [DataMember]
        public decimal Fine { get; set; }
        [DataMember]
        public bool IsActivate { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public int NoEmi { get; set; }
        [DataMember]

        public int PaymentID { get; set; }
        [DataMember]

        public int InstallmentOrderID { get; set; }
        [DataMember]
        public int SerialNo { get; set; }
        [DataMember]
        public int IsLastIndex { get; set; }
        [DataMember]
        public int IsPrePaid { get; set; }
        [DataMember]
        public int IsPostPaid { get; set; }
        [DataMember]
        public int IsOneTimePayment { get; set; }
        [DataMember]
        public decimal DiscountLimit { get; set; }
        [DataMember]
        public decimal Exemption { get; set; }
        [DataMember]
        public decimal TotalFeeAmount_New { get; set; }
        [DataMember]
        public decimal TotalFeeAmount_Old { get; set; }
        [DataMember]
        public int Activated { get; set; }

        [DataMember]
        public int ID { get; set; }


    }
}
