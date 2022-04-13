using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.Common
{
    public class CommonData : BaseData
    {
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SyllabusName { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string ImgLocation { get; set; }
        [DataMember]
        public string SchoolName { get; set; }
        [DataMember]
        public string LogoLocation { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public string SchoolAddress { get; set; }
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public int StateID { get; set; }
        [DataMember]
        public int DistrictID { get; set; }
        [DataMember]
        public int PinNo { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public string RecognitionNo { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string FaxNo { get; set; }
        [DataMember]
        public string AcademicSesion { get; set; }
        [DataMember]
        public string Recognised { get; set; }
    }

    [DataContract(Name = "EnumActionType")]
    public enum EnumActionType
    {
        [EnumMember]
        Select, //0
        [EnumMember]
        Insert, //1
        [EnumMember]
        Update, //2
        [EnumMember]
        Delete, //3    
        [EnumMember]
        Activate, //3  

    }
}
