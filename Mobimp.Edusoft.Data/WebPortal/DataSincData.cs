using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Data.EduUtility;

namespace Mobimp.Edusoft.Data.WebPortal
{

    public class DataSincData : StudentData
    {
        [DataMember]
        public int ExamID { get; set; }

        [DataMember]
        public string Examname { get; set; }

        [DataMember]
        public string Output { get; set; }
    }
}

