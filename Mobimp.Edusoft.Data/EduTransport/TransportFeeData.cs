using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduTransport
{
    public class TransportFeeData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int TransportID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public decimal Fare { get; set; }
        [DataMember]
        public int TransportType { get; set; }
        [DataMember]
        public string TransportName { get; set; }
        [DataMember]
        public string RouteNo { get; set; }
        [DataMember]
        public decimal TransportFeeAmount { get; set; }
        [DataMember]
        public int TransportStudentTypeID { get; set; }
        [DataMember]
        public decimal TransportExemptedAmount { get; set; }
        [DataMember]
        public int VehicleID { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string DriverName { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string TransportStudentTypeName { get; set; }
        [DataMember]
        public int ExemptionStatus { get; set; }
        [DataMember]
        public int IsActivate { get; set; }
        [DataMember]
        public string VehicleDetails { get; set; }
    }

    public class TransportFeeDatatoExcel
    {
        [DataMember]
        public string RouteNo { get; set; }
        [DataMember]
        public string TransportName { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public string TransportStudentTypeName { get; set; }
        [DataMember]
        public string TransportFeeAmount { get; set; }
        [DataMember]
        public string TransportExemptedAmount { get; set; }
        [DataMember]
        public string Fare { get; set; }
    }
}
