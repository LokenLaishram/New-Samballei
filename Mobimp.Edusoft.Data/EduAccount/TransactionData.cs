using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduAccount
{
    public class TransactionData :BaseData
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
        public string TransactionNo  { get; set; }
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
        public int ToLedgerID { get; set; }
        [DataMember]
        public string ToLedgerName { get; set; }
        [DataMember]
        public string TransactionNaration { get; set; }
        [DataMember]
        public decimal TransactionAmount { get; set; }
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
        public string jsondata { get; set; }      
        [DataMember]
        public int FinancialyearID { get; set; }
        [DataMember]
        public int AccountStatusID { get; set; }
        [DataMember]
        public string AccountStatus { get; set; }

    }
}
