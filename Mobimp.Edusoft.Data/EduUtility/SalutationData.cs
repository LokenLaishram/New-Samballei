using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class SalutationData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int SalutationID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    public class SalutationDataExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
}
