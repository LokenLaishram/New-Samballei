using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduAccount
{
    public class AccountGroupData : BaseData
    {
        [DataMember]
        public int AccountGroupID { get; set; }
        [DataMember]
        public string AccountGroupName { get; set; }
        [DataMember]
        public int UnderGroupID { get; set; }
        [DataMember]
        public string UnderGroupName { get; set; }
        [DataMember]
        public int AccountNatureID { get; set; }
        [DataMember]
        public string AccountNatureName { get; set; }
        [DataMember]
        public int GroupTypeID { get; set; }
        [DataMember]
        public string GroupTypeName { get; set; }
    }
    public class AccountGroupDatatoXL
    {
        [DataMember]
        public string AccountGroupName { get; set; }
        [DataMember]
        public string UnderGroupName { get; set; }
        [DataMember]
        public string AccountNatureName { get; set; }
        [DataMember]
        public string GroupTypeName { get; set; }

    }
}
