using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduAccount
{
    public class StatementData :BaseData
    {
        [DataMember]
        public Int64 TransactionID { get; set; }
        [DataMember]
        public int AccountGroupID { get; set; }
        [DataMember]
        public string AccountGroupName { get; set; }
        [DataMember]
        public Int64 AccountLedgerID { get; set; }
        [DataMember]
        public string AccountLedgerName { get; set; }
        [DataMember]
        public int AccountNatureID { get; set; }
        [DataMember]
        public string AccountNatureName { get; set; }
        [DataMember]
        public int GroupTypeID { get; set; }
        [DataMember]
        public string GroupTypeName { get; set; }
        [DataMember]
        public decimal OpeningBalance { get; set; }

        //---Account Transaction----//

        [DataMember]
        public string VoucherNo { get; set; }
        [DataMember]
        public string TransactionNo { get; set; }
        [DataMember]
        public DateTime TransactionDate { get; set; }
        [DataMember]
        public int TransactionTypeID { get; set; }
        [DataMember]
        public string TransactionTypeName { get; set; }
        [DataMember]
        public int FromLedgerID { get; set; }
        [DataMember]
        public string FromLedgerName { get; set; }
      
        [DataMember]
        public string TrasactionNaration { get; set; }
        [DataMember]
        public decimal TrasactionAmount { get; set; }
        [DataMember]
        public string OverallNaration { get; set; }
        [DataMember]
        public int PaymentModeID { get; set; }
        [DataMember]
        public string PaymentModeName { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string Invoice { get; set; }
        [DataMember]
        public string ChequeNo { get; set; }
        [DataMember]
        public decimal TotalDebit { get; set; }
        [DataMember]
        public decimal TotalCredit { get; set; }
        [DataMember]
        public decimal TotalIncome { get; set; }
        [DataMember]
        public decimal TotalExpenditure { get; set; }
        [DataMember]
        public decimal CashIncome { get; set; }
        [DataMember]
        public decimal BankIncome { get; set; }
        [DataMember]
        public decimal Expenditure { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public int FinancialyearID { get; set; }
        [DataMember]
        public int AccountStatusID { get; set; }
        [DataMember]
        public string AccountStatus { get; set; }
        [DataMember]
        public int CollectedByID { get; set; }
    }
}
