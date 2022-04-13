using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduStudent
{
    [Serializable]
    public class StudentData : BaseData
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string MotherTongue { get; set; }
        [DataMember]
        public int BelogToBPLoptionID { get; set; }
        [DataMember]
        public string BelongToBPLoptionName { get; set; }
        [DataMember]
        public string BirthRegNo { get; set; }
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
        public string EnrollmentNo { get; set; }
        [DataMember]
        public int cCountryID { get; set; }
        [DataMember]
        public int cStateID { get; set; }
        [DataMember]
        public int cPIN { get; set; }
        [DataMember]
        public string cLandMark { get; set; }
        [DataMember]
        public int cDistrictID { get; set; }
        [DataMember]
        public string Aadhar { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public int GsexID { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public string ExcelDOB { get; set; }
        [DataMember]
        public string ExcelAD { get; set; }
        [DataMember]
        public string GmobileNo { get; set; }
        [DataMember]
        public string GphoneNo { get; set; }
        [DataMember]
        public string cMobileNo { get; set; }
        [DataMember]
        public string cPhoneNo { get; set; }
        [DataMember]
        public string pMobileNo { get; set; }
        [DataMember]
        public string pPhoneNo { get; set; }
        [DataMember]
        public string StudentPhoto { get; set; }
        [DataMember]
        public string cAddress { get; set; }
        [DataMember]
        public string pAddress { get; set; }
        [DataMember]
        public int pCountryID { get; set; }
        [DataMember]
        public int pStateID { get; set; }
        [DataMember]
        public int pDistrictID { get; set; }
        [DataMember]
        public int pPIN { get; set; }
        [DataMember]
        public string pLandMark { get; set; }
        [DataMember]
        public int CastID { get; set; }
        [DataMember]
        public int GCastID { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public int SalutationID { get; set; }
        [DataMember]
        public int GsalutationID { get; set; }
        [DataMember]
        public int ReligionID { get; set; }
        [DataMember]
        public int GreligionID { get; set; }
        [DataMember]
        public string EmaildID { get; set; }
        [DataMember]
        public string GsexName { get; set; }
        [DataMember]
        public string cCountry { get; set; }
        [DataMember]
        public string pCountry { get; set; }
        [DataMember]
        public string cState { get; set; }
        [DataMember]
        public string pState { get; set; }
        [DataMember]
        public string cDistrict { get; set; }
        [DataMember]
        public string pDistrict { get; set; }
        [DataMember]
        public string Religion { get; set; }
        [DataMember]
        public string Geligion { get; set; }
        [DataMember]
        public string CastName { get; set; }
        [DataMember]
        public string GCastName { get; set; }
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string Gsalutation { get; set; }
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
        public int GrelationshipID { get; set; }
        [DataMember]
        public string Grelationship { get; set; }
        [DataMember]
        public int GoccupationID { get; set; }
        [DataMember]
        public string Goccupation { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public string StreamName { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int OptSubjectID { get; set; }
        [DataMember]
        public int AltSubjectID { get; set; }
        [DataMember]
        public int MainSubjectID { get; set; }
        [DataMember]
        public string OptSubjectName { get; set; }
        [DataMember]
        public string AltSubjectName { get; set; }
        [DataMember]
        public string MainSubjectName { get; set; }
        [DataMember]
        public int IsNew { get; set; }
        [DataMember]
        public string XmlSubjectlist { get; set; }
        [DataMember]
        public string XmlPhotolist { get; set; }
        [DataMember]
        public string XmlStudentlist { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public string Occupation { get; set; }
        [DataMember]
        public string GurdianName { get; set; }
        [DataMember]
        public string Greligion { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public DateTime DeltedeDatefrom { get; set; }
        [DataMember]
        public DateTime DletedDateto { get; set; }
        [DataMember]
        public int IsNewall { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Mothername { get; set; }
        [DataMember]
        public int Msalutation { get; set; }
        [DataMember]
        public int NationalityID { get; set; }
        [DataMember]
        public int MotheroccupationID { get; set; }
        [DataMember]
        public string MotherOccupation { get; set; }
        [DataMember]
        public int Istakingtransport { get; set; }
        [DataMember]
        public int TransportTypeID { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public int BloogroupID { get; set; }
        [DataMember]
        public string Bloogroup { get; set; }
        [DataMember]
        public string TransportType { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public string Mothersalutation { get; set; }
        [DataMember]
        public int HouseID { get; set; }
        [DataMember]
        public int Present { get; set; }
        [DataMember]
        public int Absents { get; set; }
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
        public int Leave { get; set; }
        [DataMember]
        public string House { get; set; }
        [DataMember]
        public DateTime AdmissionDate { get; set; }
        [DataMember]
        public string AdmissionDateTime { get; set; }
        [DataMember]
        public string IDmarks { get; set; }
        [DataMember]
        public Int64 Isessioninitialheight { get; set; }
        [DataMember]
        public Int64 Isessioninitialweight { get; set; }
        [DataMember]
        public Int64 Isessioninendingheight { get; set; }
        [DataMember]
        public Int64 Isessionendingweight { get; set; }
        [DataMember]
        public Int64 IIsessioninitialheight { get; set; }
        [DataMember]
        public Int64 IIsessioninitialweight { get; set; }
        [DataMember]
        public Int64 IIsessioninendingheight { get; set; }
        [DataMember]
        public Int64 IIsessionendingweight { get; set; }
        [DataMember]
        public string Allerrgic { get; set; }
        [DataMember]
        public Int64 Rootno { get; set; }
        [DataMember]
        public Int64 OwnerNo { get; set; }
        [DataMember]
        public Decimal Income { get; set; }
        [DataMember]
        public byte[] StudentImage { get; set; }
        [DataMember]
        public int StudentCategory { get; set; }
        [DataMember]
        public string LastSchoolName { get; set; }
        [DataMember]
        public string LastClass { get; set; }
        [DataMember]
        public string LastSection { get; set; }
        [DataMember]
        public int LastRollno { get; set; }
        [DataMember]
        public string LastMark { get; set; }
        [DataMember]
        public int TariffID { get; set; }
        [DataMember]
        public bool Istransfer { get; set; }
        [DataMember]
        public bool IsHostelregister { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int AttendanceID { get; set; }
        [DataMember]
        public string LastAttendance { get; set; }
        [DataMember]
        public string IFSC { get; set; }
        [DataMember]
        public string AC { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public int IsAdmissionDone { get; set; }
        [DataMember]
        public bool IsPhotoUploaded { get; set; }
        [DataMember]
        public int AcademicSessionID { get; set; }
        [DataMember]
        public int TotalPreviusStudent { get; set; }
        ///////////SCHOOLFEECOLLECTION/////////////////
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
        public int IsTransportStudent { get; set; }
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
        /////////////////////////////////////////////////
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public int BloodGroupID { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int TotalAdmissioncount { get; set; }
        [DataMember]
        public int TotalAdmissionpedning { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string RealPassword { get; set; }
        [DataMember]
        public string CasteName { get; set; }
        //// UDISE
        [DataMember]
        public string SchoolName { get; set; }
        [DataMember]
        public string SchoolDistrictName { get; set; }
        [DataMember]
        public int MotherTongueID { get; set; }
        [DataMember]
        public int LastClassID { get; set; }
        [DataMember]
        public int PreviousSchoolID { get; set; }
        [DataMember]
        public int ExamResultStatusID { get; set; }
        [DataMember]
        public float LastAnnualExamPercentage { get; set; }
        [DataMember]
        public int SchoolingStatusID { get; set; }
        [DataMember]
        public int CurClassID { get; set; }
        [DataMember]
        public string Attendance { get; set; }
        [DataMember]
        public int InstructionMediumID { get; set; }
    }
    public class onlineregistrationtoExcel
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string DOB { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string BelongToBPL { get; set; }
        [DataMember]
        public string Caste { get; set; }
        [DataMember]
        public string Religion { get; set; }
        [DataMember]
        public string MotherTongue { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string FatherOcupation { get; set; }
        [DataMember]
        public string RelationshipWithGuardian { get; set; }
        [DataMember]
        public string Mothername { get; set; }
        [DataMember]
        public string MothersOccupation { get; set; }
        [DataMember]
        public Decimal ParentsIncome { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int PIN { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string EmailID { get; set; }
    }
    public class GetTodaysDateDetails : BaseData
    {
        [DataMember]
        public DateTime TodayDate { get; set; }
        [DataMember]
        public string DaysName { get; set; }
    }
    public class ExcelAssignStudentpassword
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
    }
    public class Characterdata : BaseData
    {
        [DataMember]
        public int isCreated { get; set; }
        [DataMember]
        public int CCID { get; set; }
        [DataMember]
        public string CCNo { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string RegistrationNo { get; set; }
        [DataMember]
        public string Year_of_Registration { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int Ctype { get; set; }
        [DataMember]
        public string CName { get; set; }
        [DataMember]
        public string Division { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public int Ranking { get; set; }
        [DataMember]
        public DateTime Dateofissue { get; set; }
        [DataMember]
        public string Characters { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public bool Tocreate { get; set; }
        [DataMember]
        public string xmlcertificatestudentlist { get; set; }
        [DataMember]
        public string HSCROLLNO { get; set; }
    }
    public class Expenditure : BaseData
    {
        public Int64 ID { get; set; }
        [DataMember]
        public string ExpNo { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string RegistrationNo { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int StudentCategrory { get; set; }
        [DataMember]
        public decimal ExpenditureAmount { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public DateTime AdmissionDate { get; set; }
        
    }
    public class ProvisionalTransfer : BaseData
    {
        public int ID { get; set; }
        [DataMember]
        public string CNo { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string RegistrationNo { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int HSCRollno { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int StudentCategrory { get; set; }
        [DataMember]
        public DateTime CDate { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string MotherName { get; set; }
        [DataMember]
        public int SecuredMark { get; set; }
        [DataMember]
        public int CapturedMark { get; set; }
        [DataMember]
        public int CertificateType { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public string Division { get; set; }

    }
    public class StudentAttendance : BaseData
    {
        public string Sfirstname { get; set; }
        [DataMember]
        public string Smiddlename { get; set; }
        [DataMember]
        public string Slastname { get; set; }
        [DataMember]
        public Int64 AdmissionID { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public Int64 StudentCategory { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public DateTime AttendanceDate { get; set; }
        [DataMember]
        public string XmlStudenAttendancelist { get; set; }
        [DataMember]
        public string Attendance { get; set; }
        [DataMember]
        public int AttendanceID { get; set; }
        [DataMember]
        public string Remarkks { get; set; }
        [DataMember]
        public int UserloginID { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public string DaysName { get; set; }
        [DataMember]
        public int WorkingDays { get; set; }
        [DataMember]
        public int PresentDays { get; set; }
        [DataMember]
        public int NoAbsentDays { get; set; }
        [DataMember]
        public int NoLeaveDays { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int StudentCategoryID { get; set; }
        [DataMember]
        public int Present { get; set; }
        [DataMember]
        public int Absents { get; set; }
        [DataMember]
        public int Leave { get; set; }
    }
    //Excel 
    public class ExcelStudentList
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string AdmissionType { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string House { get; set; }
        [DataMember]
        public string DOB { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string BirthRegNo { get; set; }
        [DataMember]
        public string BelongToBPL { get; set; }
        [DataMember]
        public string Caste { get; set; }
        [DataMember]
        public string Religion { get; set; }
        [DataMember]
        public string MotherTongue { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string FatherNameORGuardianName { get; set; }
        [DataMember]
        public string FatherORGuardianOccupation { get; set; }
        [DataMember]
        public string RelationshipWithGuardian { get; set; }
        [DataMember]
        public string Mothername { get; set; }
        [DataMember]
        public string MothersOccupation { get; set; }
        [DataMember]
        public Decimal ParentsIncome { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public int PIN { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string AadharNo { get; set; }
        [DataMember]
        public string AdmissionDate { get; set; }
        [DataMember]
        public string IFSC { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string EmailID { get; set; }
    }
    public class ExcelAssignRollNo
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
    }
    public class ExcelStdDetailsEditor
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        //[DataMember]
        //public string AdmissionType { get; set; }
        [DataMember]
        public string StudentType { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string Mothername { get; set; }
        [DataMember]
        public string House { get; set; }
        [DataMember]
        public string DOB { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
    }
    public class ExcelSubjectManager
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Alternative1 { get; set; }
        [DataMember]
        public string Alternative2 { get; set; }
        [DataMember]
        public string Alternative3 { get; set; }
    }
    public class ExcelUploadPhoto
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
    public class ExcelManualAttendance
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int Attendance { get; set; }
    }
    public class ExcelParticularDayAttendance
    {
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Attendance { get; set; }
        [DataMember]
        public string Remarks { get; set; }
    }
    public class ExcelAttendanceDetailsList
    {
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Attendance { get; set; }
        [DataMember]
        public string Remarks { get; set; }
    }
    public class StudentProfileData : BaseData
    {
        [DataMember]
        public string CType { get; set; }
        [DataMember]
        public int CTypeID { get; set; }
    }
    public class StudentDetailData : BaseData
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int Roll { get; set; }
        [DataMember]
        public int Prevfeestatus { get; set; }
    }
    public class AutoRollData : BaseData
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string AT_Section { get; set; }
        [DataMember]
        public Int32 AT_Roll { get; set; }
        [DataMember]
        public string CR_Section { get; set; }
        [DataMember]
        public Int32 CR_Roll { get; set; }
        [DataMember]
        public string DefaultSlot { get; set; }
        [DataMember]
        public int ClassSerial { get; set; }
        [DataMember]
        public int ClassRank { get; set; }
        [DataMember]
        public DateTime BillDateTime_ASC { get; set; }
        [DataMember]
        public int AllotedStatus { get; set; }
        [DataMember]
        public int TotalPreviusStudent { get; set; }
       

    }
    public class ExcelAutoRollData
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string DefaultSlot { get; set; }
        [DataMember]
        public int ClassSerial { get; set; }
        [DataMember]
        public int ClassRank { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string AT_Section { get; set; }
        [DataMember]
        public Int32 AT_Roll { get; set; }
        [DataMember]
        public string CR_Section { get; set; }
        [DataMember]
        public Int32 CR_Roll { get; set; }
        [DataMember]
        public DateTime BillDateTime_ASC { get; set; }

    }
}
