using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class ClassData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string Xmlclasslist { get; set; }

    }
    public class ClassDatatoExcel 
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Class { get; set; }
    }
}
