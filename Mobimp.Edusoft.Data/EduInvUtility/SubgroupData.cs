using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    [Serializable]
    public class SubgroupData : BaseData
    {
        [DataMember]
        public string Groupname { get; set; }
        [DataMember]
        public string Subgroupname { get; set; }
        [DataMember]
        public int Subgroupid { get; set; }
        [DataMember]
        public int Groupid { get; set; }

    }
    public class SubgroupDatatoXL
    {
        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public string Subgroupname { get; set; }
    }
}
