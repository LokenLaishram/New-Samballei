using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Payroll
{
    public class OutsideDutyManagerData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public int YearID { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public decimal ConvenienceFee { get; set; }
        [DataMember]
        public string Remark { get; set; }

    }
}
