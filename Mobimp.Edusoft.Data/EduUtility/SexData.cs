using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class SexData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class SexTypeDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
}
