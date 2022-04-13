using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduTransport
{
    public class VehicleData : BaseData
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
        public decimal TransportFeeAmount { get; set; }
        [DataMember]
        public decimal TransportExemptedAmount { get; set; }
        [DataMember]
        public decimal Fare { get; set; }
        [DataMember]
        public int TransportType { get; set; }
        [DataMember]
        public int TransportStudentTypeID { get; set; }
        [DataMember]
        public string TransportStudentTypeName { get; set; }
        [DataMember]
        public string TransportName { get; set; }
        [DataMember]
        public string RouteNo { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string DriverName { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string CareOf { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Licence { get; set; }
        [DataMember]
        public byte[] Driverphoto { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public bool IsPhotoUploaded { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string RouteCode { get; set; }
        [DataMember]
        public string RouteName { get; set; }
    }

    public class VehicleDatatoExcel
    {
        [DataMember]
        public string DriverName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string TransportName { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string Licence { get; set; }
    }
}
