using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Utility
{
    public class LoanTypeData : BaseData
    {
        [DataMember]
        public int LoanID { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public string XmlLoanTypeList { get; set; }
        [DataMember]
        public int LoanTenure { get; set; }
        [DataMember]
        public Double InterestRate { get; set; }
    }
    public class LoanTypeDatatoExcel
    {
        [DataMember]
        public string LoanCode { get; set; }
        [DataMember]
        public string LoanName { get; set; }
        [DataMember]
        public int LoanTenure { get; set; }
        [DataMember]
        public Double InterestRate { get; set; }
    }
}
