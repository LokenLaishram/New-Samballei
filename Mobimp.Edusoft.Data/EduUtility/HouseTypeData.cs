using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduFeeUtility
{
    public class HouseTypeData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int HouseID { get; set; }
        [DataMember]
        public string HouseName { get; set; }
    }
    public class HouseTypeDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string HouseName { get; set; }
    }
}
