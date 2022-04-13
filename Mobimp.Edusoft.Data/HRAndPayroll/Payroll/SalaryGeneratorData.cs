using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Payroll
{
    public class SalaryGeneratorData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int DesignationID { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public int YearID { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public string Month { get; set; }
        [DataMember]       
        public int TotalNoPresent { get; set; }
        [DataMember]
        public int TotalNoAbsent { get; set; }
        [DataMember]
        public int TotalNoLeave { get; set; }

        [DataMember]
        public int TotalNoProxy { get; set; }
        [DataMember]
        public int TotalNoOutsideDuty { get; set; }
        [DataMember]
        public decimal BasicSalary { get; set; }
        [DataMember]
        public decimal BasicSalaryPerDay { get; set; }
        [DataMember]
        public decimal ProxyAmount { get; set; }
        [DataMember]
        public decimal OutsideDutyAmount { get; set; }
        [DataMember]
        public decimal TravellingAllowance { get; set; }
        [DataMember]
        public decimal DutyAllowance { get; set; }
        [DataMember]
        public decimal EPF { get; set; }
        [DataMember]
        public decimal LoanBalance { get; set; }
        [DataMember]
        public decimal LoanAdjust { get; set; }
        [DataMember]
        public decimal MiscellaneousDeduction { get; set; }
        [DataMember]
        public decimal SalaryAmount { get; set; }

    }
}
