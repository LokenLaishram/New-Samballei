using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class ExamSchedulerData : BaseData
    {
        [DataMember]
        public int ScheduleID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public string Starttime { get; set; }
        [DataMember]
        public string AStarttime { get; set; }
        [DataMember]
        public string AEndtime { get; set; }
        [DataMember]
        public int StartimeAffix { get; set; }
        [DataMember]
        public string Endtime { get; set; }
        [DataMember]
        public int EndtimeAffix { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
    }
}
