using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class SchoolDetailData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public int StateID { get; set; }
        [DataMember]
        public int DistrictID { get; set; }
        [DataMember]
        public int PinNo { get; set; }
        [DataMember]
        public string SchoolName { get; set; }
        [DataMember]
        public string LogoLocation { get; set; }
        [DataMember]
        public byte[] LogoLocationimage { get; set; }
        [DataMember]
        public string SchoolAddress { get; set; }
        [DataMember]
        public string RecognitionNo { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string FaxNo { get; set; }
    }
    public class SchoolDatatoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public int StateID { get; set; }
        [DataMember]
        public int DistrictID { get; set; }
        [DataMember]
        public int PinNo { get; set; }
        [DataMember]
        public string SchoolName { get; set; }
        [DataMember]
        public string LogoLocation { get; set; }
        [DataMember]
        public byte[] LogoLocationimage { get; set; }
        [DataMember]
        public string SchoolAddress { get; set; }
        [DataMember]
        public string RecognitionNo { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string FaxNo { get; set; }

    }
}
