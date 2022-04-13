using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.HRAndPayroll.HR
{
    public class ManualAttendanceData : BaseData
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
        public DateTime Date { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public int AttendanceStatusID { get; set; }
        [DataMember]
        public string AttendanceStatus { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public int TotalNoEmployee { get; set; }
        [DataMember]
        public int TotalNoPresent { get; set; }
        [DataMember]
        public int TotalNoAbsent { get; set; }
        [DataMember]
        public int TotalNoLeave { get; set; }
        [DataMember]
        public DateTime InTime { get; set; }
        [DataMember]
        public DateTime OutTime { get; set; }
        [DataMember]
        public DateTime WorkingHour { get; set; }
        [DataMember]
        public string InOutRemark { get; set; }
        [DataMember]
        public string ShifTime { get; set; }
        [DataMember]
        public int DateDay { get; set; }
        [DataMember]
        public int Day1 { get; set; }
        [DataMember]
        public int Day2 { get; set; }
        [DataMember]
        public int Day3 { get; set; }
        [DataMember]
        public int Day4 { get; set; }
        [DataMember]
        public int Day5 { get; set; }
        [DataMember]
        public int Day6 { get; set; }
        [DataMember]
        public int Day7 { get; set; }
        [DataMember]
        public int Day8 { get; set; }
        [DataMember]
        public int Day9 { get; set; }
        [DataMember]
        public int Day10 { get; set; }
        [DataMember]
        public int Day11 { get; set; }
        [DataMember]
        public int Day12 { get; set; }
        [DataMember]
        public int Day13 { get; set; }
        [DataMember]
        public int Day14 { get; set; }
        [DataMember]
        public int Day15 { get; set; }
        [DataMember]
        public int Day16 { get; set; }
        [DataMember]
        public int Day17 { get; set; }
        [DataMember]
        public int Day18 { get; set; }
        [DataMember]
        public int Day19 { get; set; }
        [DataMember]
        public int Day20 { get; set; }
        [DataMember]
        public int Day21 { get; set; }
        [DataMember]
        public int Day22 { get; set; }
        [DataMember]
        public int Day23 { get; set; }
        [DataMember]
        public int Day24 { get; set; }
        [DataMember]
        public int Day25 { get; set; }
        [DataMember]
        public int Day26 { get; set; }
        [DataMember]
        public int Day27 { get; set; }
        [DataMember]
        public int Day28 { get; set; }
        [DataMember]
        public int Day29 { get; set; }
        [DataMember]
        public int Day30 { get; set; }
        [DataMember]
        public int Day31 { get; set; }

        [DataMember]
        public string Day1Status { get; set; }
        [DataMember]
        public string Day2Status { get; set; }
        [DataMember]
        public string Day3Status { get; set; }
        [DataMember]
        public string Day4Status { get; set; }
        [DataMember]
        public string Day5Status { get; set; }
        [DataMember]
        public string Day6Status { get; set; }
        [DataMember]
        public string Day7Status { get; set; }
        [DataMember]
        public string Day8Status { get; set; }
        [DataMember]
        public string Day9Status { get; set; }
        [DataMember]
        public string Day10Status { get; set; }
        [DataMember]
        public string Day11Status { get; set; }
        [DataMember]
        public string Day12Status { get; set; }
        [DataMember]
        public string Day13Status { get; set; }
        [DataMember]
        public string Day14Status { get; set; }
        [DataMember]
        public string Day15Status { get; set; }
        [DataMember]
        public string Day16Status { get; set; }
        [DataMember]
        public string Day17Status { get; set; }
        [DataMember]
        public string Day18Status { get; set; }
        [DataMember]
        public string Day19Status { get; set; }
        [DataMember]
        public string Day20Status { get; set; }
        [DataMember]
        public string Day21Status { get; set; }
        [DataMember]
        public string Day22Status { get; set; }
        [DataMember]
        public string Day23Status { get; set; }
        [DataMember]
        public string Day24Status { get; set; }
        [DataMember]
        public string Day25Status { get; set; }
        [DataMember]
        public string Day26Status { get; set; }
        [DataMember]
        public string Day27Status { get; set; }
        [DataMember]
        public string Day28Status { get; set; }
        [DataMember]
        public string Day29Status { get; set; }
        [DataMember]
        public string Day30Status { get; set; }
        [DataMember]
        public string Day31Status { get; set; }
        [DataMember]
        public int TotalEmployeePresent { get; set; }
        [DataMember]
        public int TotalEmployeeAbsent { get; set; }
        [DataMember]
        public int TotalEmployeeLeave { get; set; }
        [DataMember]
        public int TotalEmployeeHalfDay { get; set; }
        [DataMember]
        public bool IsUpdated { get; set; }
        [DataMember]
        public string InOutTime { get; set; }
        [DataMember]
        public Int32 TotalPresent { get; set; }
        [DataMember]
        public Int32 TotalAbsent { get; set; }
        [DataMember]
        public Int32 TotalLeave { get; set; }
        [DataMember]
        public Int32 TotalHalfDay { get; set; }
    }
    public class AttendanceDataToExcel
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string Month { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public string ShifTime { get; set; }
        [DataMember]
        public string AttendanceStatus { get; set; }
        [DataMember]
        public string InOutTime { get; set; }
        [DataMember]
        public string Reason { get; set; }

    }
    public class AttendanceDashboardDataToExcel
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string Month { get; set; }
        [DataMember]
        public Int32 TotalPresent { get; set; }
        [DataMember]
        public Int32 TotalAbsent { get; set; }
        [DataMember]
        public Int32 TotalLeave { get; set; }
        [DataMember]
        public Int32 TotalHalfDay { get; set; }
        [DataMember]
        public string Date_1 { get; set; }
        [DataMember]
        public string Date_2 { get; set; }
        [DataMember]
        public string Date_3 { get; set; }
        [DataMember]
        public string Date_4 { get; set; }
        [DataMember]
        public string Date_5 { get; set; }
        [DataMember]
        public string Date_6 { get; set; }
        [DataMember]
        public string Date_7 { get; set; }
        [DataMember]
        public string Date_8 { get; set; }
        [DataMember]
        public string Date_9 { get; set; }
        [DataMember]
        public string Date_10 { get; set; }
        [DataMember]
        public string Date_11 { get; set; }
        [DataMember]
        public string Date_12 { get; set; }
        [DataMember]
        public string Date_13 { get; set; }
        [DataMember]
        public string Date_14 { get; set; }
        [DataMember]
        public string Date_15 { get; set; }
        [DataMember]
        public string Date_16 { get; set; }
        [DataMember]
        public string Date_17 { get; set; }
        [DataMember]
        public string Date_18 { get; set; }
        [DataMember]
        public string Date_19 { get; set; }
        [DataMember]
        public string Date_20 { get; set; }
        [DataMember]
        public string Date_21 { get; set; }
        [DataMember]
        public string Date_22 { get; set; }
        [DataMember]
        public string Date_23 { get; set; }
        [DataMember]
        public string Date_24 { get; set; }
        [DataMember]
        public string Date_25 { get; set; }
        [DataMember]
        public string Date_26 { get; set; }
        [DataMember]
        public string Date_27 { get; set; }
        [DataMember]
        public string Date_28 { get; set; }
        [DataMember]
        public string Date_29 { get; set; }
        [DataMember]
        public string Date_30 { get; set; }
        [DataMember]
        public string Date_31{ get; set; }

    }
}
