using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduAdmin
{
    public class RolesData : BaseData
    {
        [DataMember]
        public string RoleCode { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public Int32 MenuHeaderID { get; set; }
        [DataMember]
        public Int32 PageID { get; set; }
        [DataMember]
        public Int32 PageStatus { get; set; }
        
    }
}
