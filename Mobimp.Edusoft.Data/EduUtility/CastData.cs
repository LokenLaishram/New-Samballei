using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class CastData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int CastID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class CastDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Details { get; set; }
    }
}
