using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduFeeUtility
{
    public class ChartData: BaseData
    {
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public double PassPc { get; set; }
        [DataMember]
        public double ScoreMarks { get; set; }
    }

}
