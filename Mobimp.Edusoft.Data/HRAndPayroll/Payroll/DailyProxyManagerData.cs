using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Payroll
{
    public class DailyProxyManagerData : BaseData
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
        public decimal ProxyCharge { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Int64 ProxyForID { get; set; }
        [DataMember]
        public string ProxyForName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Reason { get; set; }    
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public DateTime DateFrom { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
    }
}
