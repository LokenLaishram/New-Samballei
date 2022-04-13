using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class RelationshipData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int RelationshipID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class RelationshipDataExcel
    {
        [DataMember]
        public string RelationshipCode { get; set; }
        [DataMember]
        public string RelationshipName { get; set; }
    }
}
