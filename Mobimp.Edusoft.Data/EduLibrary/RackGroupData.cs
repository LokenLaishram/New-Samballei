using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduLibrary
{
    public class RackGroupData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string XmlGrouplist { get; set; }

    }
    public class RackGroupDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string GroupName { get; set; }
    }
}
