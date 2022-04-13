using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduLibrary
{
    public class RackSubGroupData : BaseData
    {
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int SubGroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string XmlSubGrouplist { get; set; }

    }
    public class RackSubGroupDatatoExcel
    {
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
    }
}
