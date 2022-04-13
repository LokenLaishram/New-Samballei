using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduFees
{
    [Serializable]
    public class FeeData : BaseData
    {
        [DataMember]
        public int IsAdmissionDone { get; set; }
        [DataMember]
        public Int64 Rootno { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string AdmissionType { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public int DestinationID { get; set; }
        [DataMember]
        public string RegdNo { get; set; }
        [DataMember]
        public string StudentCode { get; set; }
        [DataMember]
        public Int64 AdmissionID { get; set; }
        [DataMember]
        public string AdmissionNo { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public string GmobileNo { get; set; }
        [DataMember]
        public string pMobileNo { get; set; }
        [DataMember]
        public string StudentPhoto { get; set; }
        [DataMember]
        public string pAddress { get; set; }
        [DataMember]
        public int CastID { get; set; }
        [DataMember]
        public int GCastID { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public string Religion { get; set; }
        [DataMember]
        public string Geligion { get; set; }
        [DataMember]
        public string CastName { get; set; }
        [DataMember]
        public string Sfirstname { get; set; }
        [DataMember]
        public string Smiddlename { get; set; }
        [DataMember]
        public string Slastname { get; set; }
        [DataMember]
        public string Gfirstname { get; set; }
        [DataMember]
        public string Gmiddlename { get; set; }
        [DataMember]
        public string Glastname { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int ClassID { get; set; }

        [DataMember]
        public int classid { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int IsNew { get; set; }
        [DataMember]
        public int IsNewall { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Mothername { get; set; }
        [DataMember]
        public bool Istakingtransport { get; set; }
        [DataMember]
        public int TransportTypeID { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string TransportType { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int EndMonthID { get; set; }
        [DataMember]
        public Int64 Isregister { get; set; }
        [DataMember]
        public Decimal DepositAmount { get; set; }
        [DataMember]
        public int PaymentType { get; set; }
        [DataMember]
        public DateTime AdmissionDate { get; set; }
        [DataMember]
        public bool IsHostelregister { get; set; }

        ///////////SCHOOLFEECOLLECTION/////////////////
        [DataMember]
        public Decimal TotalPaidAmount { get; set; }
        [DataMember]
        public Decimal FeeAmount { get; set; }
        [DataMember]
        public string AdmissionFeeStatus { get; set; }
        [DataMember]
        public Decimal TotalStudentDueAmount { get; set; }
        [DataMember]
        public Decimal TotalCurrentDue { get; set; }

        [DataMember]
        public Decimal TotalUnPaidAmount { get; set; }
        [DataMember]
        public Decimal TotalSumPaidAmount { get; set; }
        [DataMember]
        public Decimal TotalSumUnPaidAmount { get; set; }
        ////hostel
        [DataMember]
        public Int64 RegistrationNo { get; set; }
        [DataMember]
        public string JanuaryFeeStatus { get; set; }
        [DataMember]
        public string FebruaryFeeStatus { get; set; }
        [DataMember]
        public string MarchFeeStatus { get; set; }
        [DataMember]
        public string AprilFeeStatus { get; set; }
        [DataMember]
        public string MayFeeStatus { get; set; }
        [DataMember]
        public string JuneFeeStatus { get; set; }
        [DataMember]
        public string JulyFeeStatus { get; set; }
        [DataMember]
        public string AugustFeeStatus { get; set; }
        [DataMember]
        public string SeptemberFeeStatus { get; set; }
        [DataMember]
        public string OctoberFeeStatus { get; set; }
        [DataMember]
        public string NovemberFeeStatus { get; set; }
        [DataMember]
        public string DecemberFeeStatus { get; set; }
        /////////////////////////////////////
        [DataMember]
        public int TransportStudentTypeID { get; set; }
        [DataMember]
        public string TransportStudentTypeName { get; set; }
        [DataMember]
        public int BoardingStudentTypeID { get; set; }
        [DataMember]
        public string BoardingStudentTypeName { get; set; }
        [DataMember]
        public int Istakingtransports { get; set; }
        [DataMember]
        public int IsBoardingStudent { get; set; }
        [DataMember]
        public int IsBoardingAdmissionDone { get; set; }
        [DataMember]
        public int FeetypeID { get; set; }
        [DataMember]
        public Int32 VehicleID { get; set; }
        [DataMember]
        public Int64 TransportFeeTypeID { get; set; }
        [DataMember]
        public Decimal Payable { get; set; }
        [DataMember]
        public Decimal Paid { get; set; }
        [DataMember]
        public Decimal Discount { get; set; }
        [DataMember]
        public Decimal Due { get; set; }
        public Decimal TotalPayable { get; set; }
        [DataMember]
        public Decimal TotalPaid { get; set; }
        [DataMember]
        public Decimal TotalDiscount { get; set; }
        [DataMember]
        public Decimal TotalDue { get; set; }
        [DataMember]
        public int FeeStatus { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Student { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public int ParticularID { get; set; }
        [DataMember]
        public Decimal NetAmount { get; set; }
        [DataMember]
        public Decimal DueAmount { get; set; }
        [DataMember]
        public Decimal PaidAmount { get; set; }
        [DataMember]
        public Decimal TotalNetAmount { get; set; }
        [DataMember]
        public Decimal FineAmount { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int PaymentTypeID { get; set; }
        [DataMember]
        public int PaymentModeID { get; set; }
        [DataMember]
        public string xmlstudentpaymentlist { get; set; }
        [DataMember]
        public Decimal TotalAmount { get; set; }
        [DataMember]
        public int BillNo { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public string Structure { get; set; }
        [DataMember]
        public int OneTimeStructureID { get; set; }
        [DataMember]
        public int InclusiveFromFeeTypeID { get; set; }
        [DataMember]
        public int SettleWithDiscount { get; set; }
        [DataMember]
        public string xmlacademicsessionlist { get; set; }
        [DataMember]
        public string xmlfeetypelist { get; set; }
        [DataMember]
        public string xmlmonthlist { get; set; }
    }
    public class ExcelFeeStatus
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public Decimal FeeAmount { get; set; }
        [DataMember]
        public string AdmissionFeeStatus { get; set; }
        [DataMember]
        public string JanuaryFeeStatus { get; set; }
        [DataMember]
        public string FebruaryFeeStatus { get; set; }
        [DataMember]
        public string MarchFeeStatus { get; set; }
        [DataMember]
        public string AprilFeeStatus { get; set; }
        [DataMember]
        public string MayFeeStatus { get; set; }
        [DataMember]
        public string JuneFeeStatus { get; set; }
        [DataMember]
        public string JulyFeeStatus { get; set; }
        [DataMember]
        public string AugustFeeStatus { get; set; }
        [DataMember]
        public string SeptemberFeeStatus { get; set; }
        [DataMember]
        public string OctoberFeeStatus { get; set; }
        [DataMember]
        public string NovemberFeeStatus { get; set; }
        [DataMember]
        public string DecemberFeeStatus { get; set; }
        [DataMember]
        public Decimal TotalSumPaidAmount { get; set; }
        [DataMember]
        public Decimal TotalSumUnPaidAmount { get; set; }
        [DataMember]
        public Decimal TotalCurrentDue { get; set; }
    }
    public class FeepaymentData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public decimal FeeAmount { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal Discountlimit { get; set; }
        [DataMember]
        public DateTime DiscountAvailDate { get; set; }
        [DataMember]
        public DateTime FineDate { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public decimal FineAmount { get; set; }
        [DataMember]
        public decimal DiscountAmount { get; set; }
        [DataMember]
        public decimal ExemptionAmount { get; set; }
        [DataMember]
        public decimal TotalPaidAmount { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string PaymentStatus { get; set; }
        [DataMember]
        public string PaidOn { get; set; }
        [DataMember]
        public int PaymentType { get; set; }
        [DataMember]
        public int MonthlyPaymentStatus { get; set; }
        [DataMember]
        public string NewClass { get; set; }
        [DataMember]
        public string NewSectionName { get; set; }
        [DataMember]
        public int NewRoll { get; set; }
        [DataMember]
        public int PrepaidDueDate { get; set; }
        [DataMember]
        public int PostpaidDueDate { get; set; }
        [DataMember]
        public int CurrentAdmissionStatus { get; set; }
        [DataMember]
        public string PaymentID { get; set; }
        [DataMember]
        public string OrderID { get; set; }
        [DataMember]
        public Int32 OptionalsubjectID { get; set; }
    }
    public class FeeStatusData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string BillNo { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public decimal TotalExemptedAmount { get; set; }
        [DataMember]
        public decimal TotalFineAmount { get; set; }
        [DataMember]
        public decimal TotalDiscountAmount { get; set; }
        [DataMember]
        public decimal TotalPaidAmount { get; set; }
        [DataMember]
        public decimal TotalDueAmount { get; set; }
        [DataMember]
        public decimal TotalSumAmount { get; set; }
        [DataMember]
        public decimal TotalSumExempted { get; set; }
        [DataMember]
        public decimal TotalSumFine { get; set; }
        [DataMember]
        public decimal TotalSumDiscount { get; set; }
        [DataMember]
        public decimal TotalSumPaid { get; set; }
        [DataMember]
        public decimal TotalSumDue { get; set; }
        [DataMember]
        public DateTime BillDate { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int PaymentMode { get; set; }
        [DataMember]
        public string Paymode { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int Paystatus { get; set; }
        [DataMember]
        public int AdmissionTypeID { get; set; }
        [DataMember]
        public String AdmissionType { get; set; }
        [DataMember]
        public String Billdatetime { get; set; }
    }
    public class FeeStatusDataExcel 
    {
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string BillNo { get; set; }
        [DataMember]
        public string BillDate { get; set; }
        [DataMember]
        public string Particulars { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public decimal TotalFineAmount { get; set; }
        [DataMember]
        public decimal TotalDiscountAmount { get; set; }
        [DataMember]
        public decimal TotalPaidAmount { get; set; }

    }
}
