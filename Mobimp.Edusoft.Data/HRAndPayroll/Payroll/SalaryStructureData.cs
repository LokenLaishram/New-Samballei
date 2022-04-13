using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Payroll
{
    public class SalaryStructureData : BaseData
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
        public string Designation { get; set; }
        [DataMember]
        public decimal BasicSalary { get; set; }
        [DataMember]
        public decimal TA { get; set; }
        [DataMember]
        public decimal Proxy { get; set; }
        [DataMember]
        public decimal Absent { get; set; }
        [DataMember]
        public decimal EPF { get; set; }
        [DataMember]
        public decimal DA { get; set; }
        [DataMember]
        public decimal SalaryAmount { get; set; }
        [DataMember]
        public decimal TotalSalaryAmount { get; set; }
        [DataMember]
        public int TotalEployee { get; set; }
    }
}
