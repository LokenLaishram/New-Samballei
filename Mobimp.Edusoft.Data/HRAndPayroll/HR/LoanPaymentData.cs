using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.HRAndPayroll.HR
{
    public class LoanPaymentData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string LoanPaymentNo { get; set; }
        [DataMember]
        public string LoanReturnNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int LoanTypeID { get; set; }
        [DataMember]
        public string LoanType { get; set; }
        [DataMember]
        public int LoanStatusID { get; set; }
        [DataMember]
        public string LoanStatus { get; set; }
        [DataMember]
        public int IsProcess { get; set; }
        [DataMember]
        public decimal LoanAmount { get; set; }
        [DataMember]
        public decimal ReturnAmount { get; set; }
        [DataMember]
        public decimal TotalReturnAmount { get; set; }
        [DataMember]
        public decimal BalanceAmount { get; set; }
        [DataMember]
        public decimal LastBalanceAmount { get; set; }
        [DataMember]
        public decimal DueAmount { get; set; }
        [DataMember]
        public string Remark { get; set; }        
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        

    }
}
