using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduAccount
{
    public class AccountLedgerData : BaseData
    {
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
        [DataMember]
        public int Feetypeid { get; set; }
    }
    public class AccountLedgerDatatoXL
    {
        [DataMember]
        public string AccountGroupName { get; set; }
        [DataMember]
        public string LedgerName { get; set; }
        [DataMember]
        public string AccountNatureName { get; set; }
        [DataMember]
        public string GroupTypeName { get; set; }
        [DataMember]
        public decimal OpeningBalance { get; set; }

    }
}
