using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class RouteData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string Xmlclasslist { get; set; }
        [DataMember]
        public string SubRoute { get; set; }
        [DataMember]
        public string Route { get; set; }
        [DataMember]
        public string Remarks { get; set; }



    }
    public class RouteDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Route { get; set; }
        [DataMember]
        public string SubRoute { get; set; }
        [DataMember]
        public string ddlRoute { get; set; }
    }
}
