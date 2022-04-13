using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
   public class DistrictData: BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int DistrictID { get; set; }
        [DataMember]
        public int StateID { get; set; }
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class DistrictDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Details { get; set; }
    }
}
