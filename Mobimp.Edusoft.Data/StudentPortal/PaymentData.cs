using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.Data.StudentPortal
{
    public class PaymentData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public decimal FeeAmount { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal Discountlimit { get; set; }
        [DataMember]
        public DateTime DiscountAvailDate { get; set; }
        [DataMember]
        public DateTime FineDate { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public decimal FineAmount { get; set; }
        [DataMember]
        public decimal ExemptionAmount { get; set; }
        [DataMember]
        public decimal TotalPaidAmount { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string PaymentStatus { get; set; }
        [DataMember]
        public int PaymentType { get; set; }
        [DataMember]
        public int MonthlyPaymentStatus { get; set; }
        [DataMember]
        public int PrepaidDueDate { get; set; }
        [DataMember]
        public int PostpaidDueDate { get; set; }
        [DataMember]
        public string PaidOn { get; set; }
        [DataMember]
        public int CurrentAdmissionStatus { get; set; }
        [DataMember]
        public string PaymentID { get; set; }
        [DataMember]
        public string OrderID { get; set; }
        [DataMember]
        public int Prevfeestatus { get; set; }
        
    }
}
