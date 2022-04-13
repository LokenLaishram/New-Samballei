using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduFeeUtility
{
    public class StudentTypeData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int StudenttypeID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int TransportStudenttypeID { get; set; }
    }
    public class MainStdTypeDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }

    public class TransportStdTypeDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }

    public class BoardingStdTypeDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
}
