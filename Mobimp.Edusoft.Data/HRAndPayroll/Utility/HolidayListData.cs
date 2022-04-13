using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Utility
{
    [Serializable]
    public class HolidayListData: BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
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
        public int DayID { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public int IsHoliday { get; set; }
        [DataMember]
        public string HolidayStatus { get; set; }
        [DataMember]
        public string Reason { get; set; }

    }
    public class HolidayListDataToExcel
    {
        [DataMember]
        public int SlNo { get; set; }  
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string Month { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public string HolidayStatus { get; set; }
        [DataMember]
        public string Reason { get; set; }

    }
}
