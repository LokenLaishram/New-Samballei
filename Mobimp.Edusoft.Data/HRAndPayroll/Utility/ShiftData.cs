using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.Data.HRAndPayroll.Utility
{
    public class ShiftData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Shift { get; set; }
        [DataMember]
        public string StartFrom { get; set; }
        [DataMember]
        public string EndTo { get; set; }
        [DataMember]
        public int StartTime { get; set; }
        [DataMember]
        public int EndTime { get; set; }
        [DataMember]
        public string Remarks { get; set; }
    }
    public class ShiftDatatoExcel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Shift { get; set; }
        [DataMember]
        public string StartFrom { get; set; }
        [DataMember]
        public string EndTo { get; set; }
    }
}
