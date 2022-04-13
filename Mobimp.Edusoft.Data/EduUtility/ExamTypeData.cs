using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduUtility
{
    public class ExamTypeData : BaseData
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public double FullMark { get; set; }
        [DataMember]
        public double PassMark { get; set; }
        [DataMember]
        public double TotalMark { get; set; }
        [DataMember]
        public double TotalPassMark { get; set; }
        [DataMember]
        public double PM { get; set; }
        [DataMember]
        public double PRpassMark { get; set; }
        [DataMember]
        public string XmlMarksdetaillist { get; set; }
        [DataMember]
        public double UTmark { get; set; }
        [DataMember]
        public double UTpassmark { get; set; }
        [DataMember]
        public double PWmark { get; set; }
        [DataMember]
        public double PWpassmark { get; set; }
        [DataMember]
        public double HAmark { get; set; }
        [DataMember]
        public double HApassmark { get; set; }
        [DataMember]
        public int chkstudent { get; set; }
        [DataMember]
        public int chksubject { get; set; }
        [DataMember]
        public int chkaltsubject { get; set; }
        [DataMember]
        public int chkoptsubject { get; set; }
        [DataMember]
        public int chkmark { get; set; }
        [DataMember]
        public int chkmarkentry { get; set; }
        [DataMember]
        public int chkresult { get; set; }
        [DataMember]
        public int Chkresultpublish { get; set; }
        [DataMember]
        public int NoOfStudent { get; set; }
        [DataMember]
        public int NoOfSubject { get; set; }
        [DataMember]
        public int NoOfAlt { get; set; }
        [DataMember]
        public int NoOfOpt { get; set; }
    }
    public class ExamsubjectData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CLassID { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int Nostudent { get; set; }
        [DataMember]
        public int Noapplied { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public double FullMark { get; set; }
        [DataMember]
        public double PassMark { get; set; }
        [DataMember]
        public double PW_FM { get; set; }
        [DataMember]
        public double PW_PM { get; set; }
        [DataMember]
        public double UT_FM { get; set; }
        [DataMember]
        public double UT_PM { get; set; }
        [DataMember]
        public double HA_FM { get; set; }
        [DataMember]
        public double HA_PM { get; set; }
        [DataMember]
        public int PW_entry_status { get; set; }
        [DataMember]
        public int PW_EntryBy { get; set; }
        [DataMember]
        public DateTime PW_EntryDate { get; set; }
        [DataMember]
        public int UT_entry_status { get; set; }
        [DataMember]
        public int UT_EntryBy { get; set; }
        [DataMember]
        public DateTime UT_EntryDate { get; set; }
        [DataMember]
        public int grade_entry_status { get; set; }
        [DataMember]
        public int grade_EntryBy { get; set; }
        [DataMember]
        public DateTime grade_EntryDate { get; set; }
        [DataMember]
        public int HA_entry_status { get; set; }
        [DataMember]
        public int HA_EntryBy { get; set; }
        [DataMember]
        public DateTime HA_EntryDate { get; set; }
        [DataMember]
        public int PWEntryCount { get; set; }
        [DataMember]
        public int GRADEEntryCount { get; set; }
        [DataMember]
        public int UTEntryCount { get; set; }
        [DataMember]
        public int IsGradeSubject { get; set; }
        [DataMember]
        public int TWD { get; set; }
        [DataMember]
        public int Attendance { get; set; }
    }
    public class ExammarkentryData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CLassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int Roll { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public double FullMark { get; set; }
        [DataMember]
        public double PassMark { get; set; }
        [DataMember]
        public double PW_FM { get; set; }
        [DataMember]
        public double PW_PM { get; set; }
        [DataMember]
        public double PW_SM { get; set; }
        [DataMember]
        public double UT_FM { get; set; }
        [DataMember]
        public double UT_PM { get; set; }
        [DataMember]
        public double UT_SM { get; set; }
        [DataMember]
        public double HA_FM { get; set; }
        [DataMember]
        public double HA_PM { get; set; }
        [DataMember]
        public double HA_SM { get; set; }
        [DataMember]
        public string EnteredBy { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public int IsAbsentPW { get; set; }
        [DataMember]
        public int IsAbsentUT { get; set; }
        [DataMember]
        public int IsAbsentHA { get; set; }
        [DataMember]
        public int IsAbsentGrade { get; set; }
        [DataMember]
        public int Isfail { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int UTNoEntryCount { get; set; }
        [DataMember]
        public int PWNoEntryCount { get; set; }
        [DataMember]
        public int HANoEntryCount { get; set; }
        [DataMember]
        public int GradeNoEntryCount { get; set; }
        [DataMember]
        public int checkHAmarkentry { get; set; }
        [DataMember]
        public int ChkUTmarkentry { get; set; }
        [DataMember]
        public int ChkPWmarkentry { get; set; }
        [DataMember]
        public int ChkGrademarkentry { get; set; }
        [DataMember]
        public string MarkingType { get; set; }
        [DataMember]
        public int IsGradeSubject { get; set; }
        [DataMember]
        public int IsSubSubject { get; set; }
        [DataMember]
        public string Grade_SM { get; set; }
        [DataMember]
        public int Attendance { get; set; }
        [DataMember]
        public int TWD { get; set; }

    }
    public class ExamresultData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CLassID { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int Roll { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public DateTime DeclaredOn { get; set; }
        [DataMember]
        public int PublishedStatus { get; set; }
        [DataMember]
        public Double PassPC { get; set; }
        [DataMember]
        public int MarkEntryStatus { get; set; }
        [DataMember]
        public int PendingCount { get; set; }
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int ClassIDCopy { get; set; }
        [DataMember]
        public int ExamIDCopy { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int Activate { get; set; }
        [DataMember]
        public int ActivateExamRule { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }

    }
    public class Examdata : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int StudentCategoryID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int IsMarkCount { get; set; }
        [DataMember]
        public int IsScience { get; set; }
        [DataMember]
        public int IsSocialScience { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public string SubDivisions { get; set; }
        [DataMember]
        public string BAttendance { get; set; }
        [DataMember]
        public int IsPass { get; set; }
        [DataMember]
        public int IsRE { get; set; }
        [DataMember]
        public int MainSubjectID { get; set; }
        [DataMember]
        public int OptSubjectID { get; set; }
        [DataMember]
        public int AltSubjectID { get; set; }
        [DataMember]
        public bool IsOptional { get; set; }
        [DataMember]
        public bool IsAltSubject { get; set; }
        [DataMember]
        public bool ChekOptional { get; set; }
        [DataMember]
        public int isfailcount { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public string Div { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int IsAbsent { get; set; }
        [DataMember]
        public int TotalWorkingDay { get; set; }
        [DataMember]
        public int Attendance { get; set; }
        [DataMember]
        public int SubjectType { get; set; }
        [DataMember]
        public int CountFail { get; set; }
        [DataMember]
        public int CountAbsent { get; set; }
        [DataMember]
        public double Pc { get; set; }
        [DataMember]
        public int Ranks { get; set; }
        [DataMember]
        public string xmlexammarklist { get; set; }
        [DataMember]
        public string subxmlexammarklist { get; set; }
        [DataMember]
        public string XMLranklist { get; set; }
        [DataMember]
        public string ResultStatus { get; set; }
        [DataMember]
        public double FullMark { get; set; }
        [DataMember]
        public double PassMark { get; set; }
        [DataMember]
        public double TotalMark { get; set; }
        [DataMember]
        public double SUTmark { get; set; }
        [DataMember]
        public double SPWmark { get; set; }
        [DataMember]
        public double SHAmark { get; set; }
        [DataMember]
        public double TotalSmark { get; set; }
        [DataMember]
        public double TotalPassMark { get; set; }
        [DataMember]
        public double TotalMarkObtain { get; set; }
        [DataMember]
        public string Division { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int MarkingType { get; set; }
        [DataMember]
        public double UTmark { get; set; }
        [DataMember]
        public double UTpassmark { get; set; }
        [DataMember]
        public double subUTmark { get; set; }
        [DataMember]
        public int subsubjecid { get; set; }
        [DataMember]
        public double subUTpassmark { get; set; }
        [DataMember]
        public double PWmark { get; set; }
        [DataMember]
        public double PWpassmark { get; set; }
        [DataMember]
        public double HAmark { get; set; }
        [DataMember]
        public double HApassmark { get; set; }
        [DataMember]
        public double TotalTheoryObtain { get; set; }
        [DataMember]
        public double TotalPraticalObtain { get; set; }
        [DataMember]
        public int PrioValue { get; set; }
        [DataMember]
        public string XMLattendlist { get; set; }
        [DataMember]
        public int TopStudent { get; set; }
        [DataMember]
        public int IsWitheld { get; set; }
        [DataMember]
        public int IsPromoted { get; set; }
        [DataMember]
        public int Isabsent { get; set; }
        [DataMember]
        public int IsabsentPW { get; set; }
        [DataMember]
        public int CertificateType { get; set; }
        [DataMember]
        public string CType { get; set; }
        [DataMember]
        public int CTypeID { get; set; }
        [DataMember]
        public string xmlCTPCertificatelist { get; set; }
        [DataMember]
        public string BDivision { get; set; }
        [DataMember]
        public int BDivisionID { get; set; }
        [DataMember]
        public int IsCertificateCreate { get; set; }
        [DataMember]
        public int BRollNo { get; set; }
        [DataMember]
        public string DateLeft { get; set; }
        [DataMember]
        public int From { get; set; }
        [DataMember]
        public int To { get; set; }
        [DataMember]
        public string subjName { get; set; }
        [DataMember]
        public int subcount { get; set; }
        [DataMember]
        public int IsMinorSubject { get; set; }
        [DataMember]
        public int IsGradeSubject { get; set; }
        [DataMember]
        public int Isactivate { get; set; }
        [DataMember]
        public int IsSubSubject { get; set; }
        [DataMember]
        public string MarkObtain { get; set; }
        [DataMember]
        public string YearPass { get; set; }
        [DataMember]
        public string RegistrationNo { get; set; }
        [DataMember]
        public int PromotedClassID { get; set; }
        [DataMember]
        public int PromotedAcademicID { get; set; }
        [DataMember]
        public string PromotedAcademicName { get; set; }
    }
    public class PromoteSrudent : BaseData
    {
        [DataMember]
        public int StudentCategoryID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string xmlpromotestudentlist { get; set; }
        [DataMember]
        public int PromoteClassID { get; set; }
        [DataMember]
        public int PromoteAcademicID { get; set; }
        [DataMember]
        public bool IsPass { get; set; }
    }
    public class PrintresulttoExcel
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
    }
    public class ExamDatatoExcel
    {
        [DataMember]
        public string AcademicSessionName { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string IsScience { get; set; }
        [DataMember]
        public string IsSocialScience { get; set; }
        [DataMember]
        public string IsMarkCount { get; set; }
        [DataMember]
        public string TheoryFullMark { get; set; }
        [DataMember]
        public string TheoryPassMark { get; set; }
        [DataMember]
        public string PWmark { get; set; }
        [DataMember]
        public string PWpassmark { get; set; }
        [DataMember]
        public string HAmark { get; set; }
        [DataMember]
        public string HApassmark { get; set; }
        [DataMember]
        public string PrioValue { get; set; }
    }
    public class ExamVerificationDatatoExcel
    {
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string TotalStudents { get; set; }
        [DataMember]
        public string TotalSubjects { get; set; }
        [DataMember]
        public string AltStudentSubject { get; set; }
        [DataMember]
        public string OptStudentSubject { get; set; }
        [DataMember]
        public int TotalFullMark { get; set; }
        [DataMember]
        public int TotalPassMark { get; set; }
    }
    public class ExamDetailtoExcel
    {
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string FullMark { get; set; }
        [DataMember]
        public string PassMark { get; set; }

    }
    public class SubjectMarkRangetoExcel
    {
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public double SecuredMark { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string Section { get; set; }
    }
    public class ExcelExamMark
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string CA_Mark { get; set; }
        [DataMember]
        public string WA_Mark { get; set; }
    }
    public class AttendanceData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public Int32 RollNo { get; set; }
        [DataMember]
        public Int32 ExamID { get; set; }
        [DataMember]
        public Int32 TotalWorkingDays { get; set; }
        [DataMember]
        public Int32 TotalPresent { get; set; }
        [DataMember]
        public Double PC { get; set; }
        [DataMember]
        public int SectionID { get; set; }
    }
    public class OnlineExamresultData : BaseData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int ExamID { get; set; }
        [DataMember]
        public string ExamName { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public int Ispublished { get; set; }
        [DataMember]
        public int Excludedefaulter { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int DueStatus { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int RollNo { get; set; }
    }
}
