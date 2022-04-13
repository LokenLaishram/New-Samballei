using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInvUtility
{
    public class UnitData : BaseData
    {
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public string UnitCode { get; set; }
        [DataMember]
        public string UnitName { get; set; }
       
       
    }
    public class UnitDatatoXL
    {
        [DataMember]
        public string UnitCode { get; set; }
        [DataMember]
        public string UnitName { get; set; }
       
    }
}
