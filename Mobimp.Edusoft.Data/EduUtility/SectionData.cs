using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class SectionData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
    }
    public class SectionDatatoExcel
    {
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
    }
}
