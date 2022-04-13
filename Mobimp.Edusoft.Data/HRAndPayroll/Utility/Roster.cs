using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Utility
{
    public class Roster
    {
        public class RosterData : BaseData
        {
            [DataMember]
            public Int64 ID { get; set; }
            [DataMember]
            public Int32 ShiftID { get; set; }
            [DataMember]
            public Int32 MonthID { get; set; }
            [DataMember]
            public string EmployeeName { get; set; }
            [DataMember]
            public string Shift { get; set; }
            [DataMember]
            public string EmpName { get; set; }
            [DataMember]
            public string ShifTime { get; set; }
        }
        public class RosterDatatoExcel
        {
            [DataMember]
            public Int64 ID { get; set; }
            [DataMember]
            public string EmployeeName { get; set; }
            [DataMember]
            public string Shift { get; set; }
            [DataMember]
            public string ShifTime { get; set; }
        }

    }
}
