using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    [Serializable]
    public class GroupData : BaseData
    {
        [DataMember]
        public int Groupid { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Groupname { get; set; }
    }
    public class GroupDatatoXL
    {
        public string Code { get; set; }
        [DataMember]
        public string Groupname { get; set; }
    }
}
