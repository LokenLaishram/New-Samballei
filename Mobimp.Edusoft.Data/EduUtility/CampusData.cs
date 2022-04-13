using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class CampusData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int CampusID { get; set; }
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
        [DataMember]
        public int WingID { get; set; }



    }
    public class CampusDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Campus { get; set; }
        [DataMember]
        public string SubRoute { get; set; }
        [DataMember]
        public string ddlRoute { get; set; }
        [DataMember]
        public string Wing { get; set; }
    }
}
