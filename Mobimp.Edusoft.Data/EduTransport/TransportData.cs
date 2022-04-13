using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Campusoft.Data.EduTransport
{

    public class TransportData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 TransportRegistrationNo { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string Sfirstname { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Routename { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public Int64 RootID { get; set; }
        [DataMember]
        public int SubRootID { get; set; }
        [DataMember]
        public int VihicleID { get; set; }
        [DataMember]
        public Int64 TransportFeeTypeID { get; set; }
        [DataMember]
        public string TransportFeeTypeName { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public Decimal Fare { get; set; }
        [DataMember]
        public Int64 TransportStudentTypeID { get; set; }
        [DataMember]
        public string TransportStudentTypeName { get; set; }
        [DataMember]
        public Int64 TransportTypeID { get; set; }
        [DataMember]
        public string TransportTypeName { get; set; }
        [DataMember]
        public string DriverName { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public Int64 UserloginID { get; set; }
        [DataMember]
        public Decimal DepositAmount { get; set; }
        [DataMember]
        public string SessionName { get; set; }
        [DataMember]
        public Decimal TransportDepositAmount { get; set; }
        [DataMember]
        public Decimal TransportDueAmount { get; set; }
        [DataMember]
        public int StartMonthID { get; set; }
        [DataMember]
        public string MonthNames { get; set; }
        [DataMember]
        public int EndMonthID { get; set; }
        [DataMember]
        public int RemarkID { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public DateTime WithdrawlDate { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public decimal FeeAmount { get; set; }
        [DataMember]
        public decimal NetAmount { get; set; }
        [DataMember]
        public decimal Exemption { get; set; }
        [DataMember]
        public string RouteName { get; set; }
        [DataMember]
        public string SubRouteName { get; set; }
        [DataMember]
        public string TransportStudentType { get; set; }
        [DataMember]
        public int Activate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public DateTime ActivateDate { get; set; }
        [DataMember]
        public string MonthName { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int DestinationID { get; set; }
        [DataMember]
        public string Monthlist { get; set; }
    }

    public class TransDataExcel
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string AdmissionType { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
    }
}
