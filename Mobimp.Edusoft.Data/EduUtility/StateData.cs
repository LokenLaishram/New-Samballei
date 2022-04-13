using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class StateData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int StateID { get; set; }
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class StateDatatoExcel
    {
        [DataMember]
        public string StateID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
}
