using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduUtility
{
    public class LeaveTypeData : BaseData
    {
        [DataMember]
        public int LeaveID { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string leavetype { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int Nodays { get; set; }
        [DataMember]
        public int Applicablefor { get; set; }
        [DataMember]
        public string LeaveApplicablefor { get; set; }
    }
    public class LeaveTypeDatatoExcel
    {
        [DataMember]
        public int LeaveID { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string leavetype { get; set; }
    }
}
