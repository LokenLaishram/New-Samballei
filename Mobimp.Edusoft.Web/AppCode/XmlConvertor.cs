using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Campusoft.Data.EduExam;
using Mobimp.Edusoft.Data.EduSMS;
using Mobimp.Edusoft.Data.EduLibrary;
using Mobimp.Edusoft.Data.EduFeeUtility;
using Mobimp.Campusoft.Data.EduUtility;
using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
using Mobimp.Campusoft.Data.HRAndPayroll.Payroll;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Campusoft.Data.EduTransport;
using Mobimp.Campusoft.BussinessProcess.EduTransport;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.Data.EduAccount;
using static Mobimp.Campusoft.Data.HRAndPayroll.Utility.Roster;
using Mobimp.Campusoft.Data.StudentPortal;
using Mobimp.Edusoft.Data.ELearning;

namespace Mobimp.Edusoft.Web.AppCode
{
    public static class XmlConvertor
    {
        public static StringBuilder ClasswiseSubjectListtoXML(List<ClasswiseSubjectData> subejectlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ClasswiseSubjectData obj in subejectlist)
            {
                str.Append("<SubjectList SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" UserId = \"" + obj.UserId.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" CompanyID = \"" + obj.CompanyID.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" IsActive = \"" + obj.IsActive + "\" ");
                str.Append(" />");
            }
            return str;
        }

        public static StringBuilder ProcessVerificationtoXML(List<ExamTypeData> ProcessList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamTypeData obj in ProcessList)
            {
                str.Append("<Process ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" chkstudent = \"" + obj.chkstudent.ToString() + "\" ");
                str.Append(" chksubject = \"" + obj.chksubject.ToString() + "\" ");
                str.Append(" chkoptsubject = \"" + obj.chkoptsubject.ToString() + "\" ");
                str.Append(" chkaltsubject = \"" + obj.chkaltsubject.ToString() + "\" ");
                str.Append(" chkmarkentry = \"" + obj.chkmarkentry.ToString() + "\" ");
                str.Append(" chkmark = \"" + obj.chkmark.ToString() + "\" ");
                str.Append(" chkresult = \"" + obj.chkresult.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder EmployeeAttendancelisttoXML(List<EmployeeAttendanceData> Attendancelist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (EmployeeAttendanceData obj in Attendancelist)
            {
                str.Append("<EmployeeAttendnaceList EmployeeID = \"" + obj.EmployeeID.ToString() + "\" ");
                str.Append(" Attendance = \"" + obj.Attendance.ToString() + "\" ");
                str.Append(" AddedDate = \"" + obj.AddedDate.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder SubjectListtoXML(List<SubjectAllocationData> Classlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (SubjectAllocationData obj in Classlist)
            {
                str.Append("<Subject SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" Rating = \"" + obj.Rating.ToString() + "\" ");
                str.Append(" AllocatedSections = \"" + obj.AllocatedSections.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder AssignsubjectlisttoXML(List<TeacherWisePeriod> subjectlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (TeacherWisePeriod obj in subjectlist)
            {
                str.Append("<Subject SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" TeacherID = \"" + obj.TeacherID.ToString() + "\" ");
                str.Append(" DayID = \"" + obj.DayID.ToString() + "\" ");
                str.Append(" PeriodNo = \"" + obj.PeriodNo.ToString() + "\" ");
                str.Append(" SubSubjectID = \"" + obj.SubSubjectID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder OnlinepaymenttoXML(List<FeepaymentData> OneTimeFeeList)
        {
            StringBuilder str = new StringBuilder();
            foreach (FeepaymentData obj in OneTimeFeeList)
            {
                str.Append("<OnlinePayment ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" FeeTypeID = \"" + obj.FeeTypeID.ToString() + "\" ");
                str.Append(" MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" Particulars = \"" + obj.Particulars.ToString() + "\" ");
                str.Append(" FeeAmount = \"" + obj.FeeAmount.ToString() + "\" ");
                str.Append(" FineAmount = \"" + obj.FineAmount.ToString() + "\" ");
                str.Append(" ExemptedAmount = \"" + obj.ExemptionAmount.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder OnlinepaymentStoXML(List<PaymentData> OneTimeFeeList)
        {
            StringBuilder str = new StringBuilder();
            foreach (PaymentData obj in OneTimeFeeList)
            {
                str.Append("<OnlinePayment ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" FeeTypeID = \"" + obj.FeeTypeID.ToString() + "\" ");
                str.Append(" MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" Particulars = \"" + obj.Particulars.ToString() + "\" ");
                str.Append(" FeeAmount = \"" + obj.FeeAmount.ToString() + "\" ");
                str.Append(" FineAmount = \"" + obj.FineAmount.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }


        public static StringBuilder TeacherlisttoXML(List<TeacherWisePeriod> Teacherlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (TeacherWisePeriod obj in Teacherlist)
            {
                str.Append("<Teacher TeacherID = \"" + obj.TeacherID.ToString() + "\" ");
                str.Append(" SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" GroupID = \"" + obj.GroupID.ToString() + "\" ");
                str.Append(" NoPeriodDistributed = \"" + obj.NoPeriodDistributed.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder periodtoxml(List<ClasswisePeriodPlannerData> Classlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ClasswisePeriodPlannerData obj in Classlist)
            {
                str.Append("<Period ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" Sunday = \"" + obj.Sunday.ToString() + "\" ");
                str.Append(" Monday = \"" + obj.Monday.ToString() + "\" ");
                str.Append(" Tuesday = \"" + obj.Tuesday.ToString() + "\" ");
                str.Append(" Wednesday = \"" + obj.Wednesday.ToString() + "\" ");
                str.Append(" Thursday = \"" + obj.Thursday.ToString() + "\" ");
                str.Append(" Friday = \"" + obj.Friday.ToString() + "\" ");
                str.Append(" Saturday = \"" + obj.Saturday.ToString() + "\" ");
                str.Append(" DefaultPeriod = \"" + obj.DefaultPeriod.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" TeacherID = \"" + obj.TeacherID.ToString() + "\" ");
                str.Append(" SubjectwisePeriod = \"" + obj.SubjectwisePeriod.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ActivatedlisttoXML(List<StudentData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in studentlist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder timetableslottoxml(List<TimetableslotData> Slotlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (TimetableslotData obj in Slotlist)
            {
                str.Append("<Slot SlotID = \"" + obj.SlotID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" SlotType = \"" + obj.SlotType.ToString() + "\" ");
                str.Append(" Duration = \"" + obj.Duration.ToString() + "\" ");
                str.Append(" GroupdID = \"" + obj.GroupdID.ToString() + "\" ");
                str.Append(" Session = \"" + obj.Session.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder PageDatatoXML(List<RolesData> List)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (RolesData obj in List)
            {
                str.Append("<Page ID= \"" + obj.PageID.ToString() + "\" ");
                str.Append(" PageStatus = \"" + obj.PageStatus.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ClasswiseRanktoXML(List<Examdata> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Examdata obj in subjectmark)
            {
                str.Append("<Rank ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" Ranks = \"" + obj.Ranks.ToString() + "\" ");
                str.Append(" Attendance = \"" + obj.Attendance.ToString() + "\" ");
                str.Append(" TotalWorkingDay = \"" + obj.TotalWorkingDay.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder PromotedStudentlistToXML(List<PromoteSrudent> Studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (PromoteSrudent obj in Studentlist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" PromoteClassID = \"" + obj.PromoteClassID.ToString() + "\" ");
                str.Append(" PromoteAcademicID = \"" + obj.PromoteAcademicID.ToString() + "\" ");
                str.Append(" IsPass = \"" + obj.IsPass.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder SubjectMarkstoXML(List<Examdata> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Examdata obj in subjectmark)
            {
                str.Append("<SubjectMarks ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ExamID = \"" + obj.ExamID.ToString() + "\" ");
                str.Append(" SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" UTmark = \"" + obj.UTmark.ToString() + "\" ");
                str.Append(" UTpassmark = \"" + obj.UTpassmark.ToString() + "\" ");
                str.Append(" PWmark = \"" + obj.PWmark.ToString() + "\" ");
                str.Append(" PWpassmark = \"" + obj.PWpassmark.ToString() + "\" ");
                str.Append(" HAmark = \"" + obj.HAmark.ToString() + "\" ");
                str.Append(" HApassmark = \"" + obj.HApassmark.ToString() + "\" ");
                str.Append(" PrioValue = \"" + obj.PrioValue.ToString() + "\" ");
                str.Append(" IsMarkCount = \"" + obj.IsMarkCount.ToString() + "\" ");
                str.Append(" IsScience = \"" + obj.IsScience.ToString() + "\" ");
                str.Append(" IsSocialScience = \"" + obj.IsSocialScience.ToString() + "\" ");
                str.Append(" IsGradeSubject = \"" + obj.IsGradeSubject.ToString() + "\" ");
                str.Append(" IsMinorSubject = \"" + obj.IsMinorSubject.ToString() + "\" ");
                str.Append(" Isactivate = \"" + obj.Isactivate.ToString() + "\" ");
                str.Append(" OptSubjectID = \"" + obj.OptSubjectID.ToString() + "\" ");
                str.Append(" AltSubjectID = \"" + obj.AltSubjectID.ToString() + "\" ");
                str.Append(" isfailcount = \"" + obj.isfailcount.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder SubSubjectMarkstoXML(List<Examdata> subsubjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Examdata obj in subsubjectmark)
            {

                //child 
                str.Append("<SubSubjectMarks SUTmark = \"" + obj.SUTmark.ToString() + "\" ");
                str.Append(" subjectid = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" ExamID = \"" + obj.ExamID.ToString() + "\" ");
                str.Append(" SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" UTmark = \"" + obj.UTmark.ToString() + "\" ");
                str.Append(" UTpassmark = \"" + obj.UTpassmark.ToString() + "\" ");
                str.Append(" PWmark = \"" + obj.PWmark.ToString() + "\" ");
                str.Append(" PWpassmark = \"" + obj.PWpassmark.ToString() + "\" ");
                str.Append(" HAmark = \"" + obj.HAmark.ToString() + "\" ");
                str.Append(" HApassmark = \"" + obj.HApassmark.ToString() + "\" ");
                str.Append(" PrioValue = \"" + obj.PrioValue.ToString() + "\" ");
                // str.Append(" IsMarkCount = \"" + obj.IsMarkCount.ToString() + "\" ");               
                str.Append(" IsGradeSubject = \"" + obj.IsGradeSubject.ToString() + "\" ");
                str.Append(" IsMinorSubject = \"" + obj.IsMinorSubject.ToString() + "\" ");
                str.Append(" Isactivate = \"" + obj.Isactivate.ToString() + "\" ");
                str.Append(" isfailcount = \"" + obj.isfailcount.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StudentListtoXML(List<StudentData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in studentlist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" AdmissionDateTime = \"" + obj.AdmissionDateTime.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StudentpasswordttoXML(List<StudentData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in studentlist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" UserPassword = \"" + obj.UserPassword.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder EmployeePasswordToXML(List<EmployeeData> EmpList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (EmployeeData obj in EmpList)
            {
                str.Append("<EmpList EmployeeID = \"" + obj.EmployeeID.ToString() + "\" ");
                str.Append(" UserPassword = \"" + obj.UserPassword.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ClassListtoXML(List<ClassallocationData> Classlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ClassallocationData obj in Classlist)
            {
                str.Append("<Class ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StudentSubjectListtoXML(List<StudentData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in studentlist)
            {
                str.Append("<SubjectList StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                //str.Append(" MainSubjectID = \"" + obj.MainSubjectID.ToString() + "\" ");
                str.Append(" AltSubjectID = \"" + obj.AltSubjectID.ToString() + "\" ");
                str.Append(" OptSubjectID = \"" + obj.OptSubjectID.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder RostertoXML(List<RosterData> rosterlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (RosterData obj in rosterlist)
            {
                str.Append("<Roster EmployeeID = \"" + obj.EmployeeID.ToString() + "\" ");
                str.Append(" ShiftID = \"" + obj.ShiftID.ToString() + "\" ");
                str.Append(" MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StudentPhototoXML(List<StudentData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in studentlist)
            {
                str.Append("<StudentPhotolist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" StudentPhoto = \"" + obj.StudentPhoto.ToString() + "\" ");
                str.Append(" StudentImage = \"" + obj.StudentImage.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ClasswiseExamtMarkstoXML(List<Examdata> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Examdata obj in subjectmark)
            {
                str.Append("<SubjectMarks ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ExamID = \"" + obj.ExamID.ToString() + "\" ");
                str.Append(" StudentCategoryID = \"" + obj.StudentCategoryID.ToString() + "\" ");
                str.Append(" SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" FullMark = \"" + obj.FullMark.ToString() + "\" ");
                str.Append(" PassMark = \"" + obj.PassMark.ToString() + "\" ");
                //str.Append(" TheoryMark = \"" + obj.TheoryMark.ToString() + "\" ");
                //str.Append(" PM = \"" + obj.PM.ToString() + "\" ");
                //str.Append(" PracticalMark = \"" + obj.PracticalMark.ToString() + "\" ");
                //str.Append(" TotalObtainSubjectWise = \"" + obj.TotalObtainSubjectWise.ToString() + "\" ");
                //str.Append(" IsPass = \"" + obj.IsPass.ToString() + "\" ");
                //str.Append(" IsAbsent = \"" + obj.IsAbsent.ToString() + "\" ");
                //str.Append(" IsMainSubject = \"" + obj.IsMainSubject.ToString() + "\" ");
                str.Append(" IsOptional = \"" + obj.IsOptional.ToString() + "\" ");
                str.Append(" IsAltSubject = \"" + obj.IsAltSubject.ToString() + "\" ");
                str.Append(" ChekOptional = \"" + obj.ChekOptional.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                //str.Append(" UserId = \"" + obj.UserId.ToString() + "\" ");
                //str.Append(" Isoptinal = \"" + obj.Isoptinal.ToString() + "\" ");
                //str.Append(" CompanyID = \"" + obj.CompanyID.ToString() + "\" ");
                //str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder SubjectWiseMarkstoXML(List<Examdata> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Examdata obj in subjectmark)
            {
                str.Append("<SubjectMarks StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" SPWmark = \"" + obj.SPWmark.ToString() + "\" ");
                str.Append(" SUTmark = \"" + obj.SUTmark.ToString() + "\" ");
                str.Append(" SHAmark = \"" + obj.SHAmark.ToString() + "\" ");
                str.Append(" Grade = \"" + obj.Grade.ToString() + "\" ");
                str.Append(" IsPass = \"" + obj.IsPass.ToString() + "\" ");
                str.Append(" Isabsent = \"" + obj.Isabsent.ToString() + "\" ");
                str.Append(" IsRE  = \"" + obj.IsRE.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder onlineresulttoXML(List<OnlineExamresultData> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (OnlineExamresultData obj in subjectmark)
            {
                str.Append("<onlneresult ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" ExamID = \"" + obj.ExamID.ToString() + "\" ");
                str.Append(" Ispublished = \"" + obj.Ispublished.ToString() + "\" ");
                str.Append(" Excludedefaulter = \"" + obj.Excludedefaulter.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder SubjectWiseMarkstoXML(List<ExammarkentryData> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExammarkentryData obj in subjectmark)
            {
                str.Append("<SubjectMarks StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" Roll = \"" + obj.Roll.ToString() + "\" ");
                str.Append(" PW_FM = \"" + obj.PW_FM.ToString() + "\" ");//full mark
                str.Append(" PW_PM = \"" + obj.PW_PM.ToString() + "\" ");//pass mark
                str.Append(" PW_SM = \"" + obj.PW_SM.ToString() + "\" ");//mark obtain
                str.Append(" UT_FM = \"" + obj.UT_FM.ToString() + "\" ");//full mark
                str.Append(" UT_PM = \"" + obj.UT_PM.ToString() + "\" ");//pass mark
                str.Append(" UT_SM = \"" + obj.UT_SM.ToString() + "\" ");//mark obtain
                str.Append(" Grade_SM = \"" + obj.Grade_SM.ToString() + "\" ");//grade obtain
                str.Append(" IsAbsentPW = \"" + obj.IsAbsentPW.ToString() + "\" ");
                str.Append(" IsAbsentUT = \"" + obj.IsAbsentUT.ToString() + "\" ");
                str.Append(" IsAbsentGrade = \"" + obj.IsAbsentGrade.ToString() + "\" ");
                str.Append(" ChkPWmarkentry = \"" + obj.ChkPWmarkentry.ToString() + "\" ");
                str.Append(" ChkUTmarkentry = \"" + obj.ChkUTmarkentry.ToString() + "\" ");
                str.Append(" ChkGrademarkentry = \"" + obj.ChkGrademarkentry.ToString() + "\" ");
                str.Append(" TWD = \"" + obj.TWD.ToString() + "\" ");
                str.Append(" Attendance = \"" + obj.Attendance.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder FeeAmountListtoXML(List<FeesData> feesData)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (FeesData obj in feesData)
            {
                str.Append("<FeeDetails ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" AdmissionTypeID = \"" + obj.AdmissionTypeID.ToString() + "\" ");
                str.Append(" StudentTypeID = \"" + obj.StudentTypeID.ToString() + "\" ");
                str.Append(" FeeAmount = \"" + obj.FeeAmount.ToString() + "\" ");
                str.Append(" ExemptedAmount = \"" + obj.ExemptedAmount.ToString() + "\" ");
                str.Append(" FeeTypeID = \"" + obj.FeeTypeID.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder TransportStudentListtoXML(List<StudentData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in studentlist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" Istakingtransport = \"" + obj.Istakingtransport.ToString() + "\" ");
                str.Append(" TransportTypeID = \"" + obj.TransportTypeID.ToString() + "\" ");
                str.Append(" Rootno = \"" + obj.Rootno.ToString() + "\" ");
                str.Append(" MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" EndMonthID = \"" + obj.EndMonthID.ToString() + "\" ");
                str.Append(" TariffID = \"" + obj.TariffID.ToString() + "\" ");
                str.Append(" DestinationID = \"" + obj.DestinationID.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder SubjectListtoXML(List<SubjectData> SubjectList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (SubjectData obj in SubjectList)
            {
                str.Append("<SubjectList SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" SubjectCategoryID = \"" + obj.SubjectCategoryID.ToString() + "\" ");
                str.Append(" IsGrade = \"" + obj.IsGrade.ToString() + "\" ");
                str.Append(" IsOptional = \"" + obj.IsOptional.ToString() + "\" ");
                str.Append(" IsAlternative = \"" + obj.IsAlternative.ToString() + "\" ");
                str.Append(" IsMain = \"" + obj.IsMain.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ExamMArksListtoXML(List<ExamTypeData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamTypeData obj in studentlist)
            {
                str.Append("<Exam ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" FullMark = \"" + obj.FullMark.ToString() + "\" ");
                str.Append(" PassMark = \"" + obj.PassMark.ToString() + "\" ");
                str.Append(" PM = \"" + obj.PM.ToString() + "\" ");
                str.Append(" PRpassMark = \"" + obj.PRpassMark.ToString() + "\" ");
                str.Append(" TotalMark = \"" + obj.TotalMark.ToString() + "\" ");
                str.Append(" TotalPassMark = \"" + obj.TotalPassMark.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder AttendancelisttoXML(List<StudentAttendance> Attendancelist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentAttendance obj in Attendancelist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" AdmissionID = \"" + obj.AdmissionID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                str.Append(" AttendanceID = \"" + obj.AttendanceID.ToString() + "\" ");
                str.Append(" StudentCategoryID = \"" + obj.StudentCategoryID.ToString() + "\" ");
                str.Append(" UserloginID = \"" + obj.UserloginID.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" Remarks = \"" + obj.Remarks.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder RegdlisttoXML(List<StudentData> Attendancelist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in Attendancelist)
            {
                str.Append("<Regdlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" RegdNo = \"" + obj.RegdNo.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        //Manual Attendence
        public static StringBuilder ClasswiseAttendtoXML(List<AttendanceData> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (AttendanceData obj in subjectmark)
            {
                str.Append("<Attend StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" TotalPresent = \"" + obj.TotalPresent.ToString() + "\" ");
                str.Append(" TotalWorkingDays = \"" + obj.TotalWorkingDays.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ClasswiseRankResulttoXML(List<Examdata> subjectmark)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Examdata obj in subjectmark)
            {
                str.Append("<Rank ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" Ranks = \"" + obj.Ranks.ToString() + "\" ");
                str.Append(" Attendance = \"" + obj.Attendance.ToString() + "\" ");
                str.Append(" IsWitheld = \"" + obj.IsWitheld.ToString() + "\" ");
                str.Append(" TotalWorkingDay = \"" + obj.TotalWorkingDay.ToString() + "\" ");
                str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        //////////////////SCHOOLFEESCOLLECTION///////////////////////
        public static StringBuilder MonthFeePaidStatuslistToXML(List<FeeCollectionData> FeeStatuslist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (FeeCollectionData obj in FeeStatuslist)
            {
                str.Append("<FeeStatuslist MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" FeeAmount = \"" + obj.FeeAmount.ToString() + "\" ");
                str.Append(" ExemptedAmount = \"" + obj.ExemptedAmount.ToString() + "\" ");
                str.Append(" FineAmount = \"" + obj.FineAmount.ToString() + "\" ");
                str.Append(" TotalAmount = \"" + obj.TotalAmount.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder DueFeePaidStatuslistToXML(List<FeeCollectionData> FeeStatuslist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (FeeCollectionData obj in FeeStatuslist)
            {
                str.Append("<DueFeeStatuslist FeeDueAmount = \"" + obj.FeeDueAmount.ToString() + "\" ");
                str.Append(" FeeType = \"" + obj.FeeType.ToString() + "\" ");
                str.Append(" FeeTypeID = \"" + obj.FeeTypeID.ToString() + "\" ");
                str.Append(" CollectedDueAmount = \"" + obj.CollectedDueAmount.ToString() + "\" ");
                str.Append(" TotalDueAmount = \"" + obj.TotalDueAmount.ToString() + "\" ");

                str.Append(" />");
            }
            return str;
        }
        //////////////////Certificate//////////////////////////////////
        public static StringBuilder certificateStudentlistToXML(List<Characterdata> Studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Characterdata obj in Studentlist)
            {
                if (obj.Tocreate == true)
                {
                    str.Append("<CertiStudentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                    str.Append(" Tocreate = \"" + obj.Tocreate.ToString() + "\" ");
                    str.Append(" Characters = \"" + obj.Characters.ToString() + "\" ");
                    str.Append(" HSCROLLNO = \"" + obj.HSCROLLNO.ToString() + "\" ");
                    str.Append(" Dateofissue = \"" + obj.Dateofissue.ToString() + "\" ");
                    str.Append(" Division = \"" + obj.Division.ToString() + "\" ");
                    str.Append(" Ranking = \"" + obj.Ranking.ToString() + "\" ");
                    str.Append(" Grade = \"" + obj.Grade.ToString() + "\" ");
                    str.Append(" RegistrationNo = \"" + obj.RegistrationNo.ToString() + "\" ");
                    str.Append(" Year_of_Registration = \"" + obj.Year_of_Registration.ToString() + "\" ");
                    str.Append(" />");
                }
            }
            return str;
        }

        ///////////////////////////////////////STUDENT EDITOR////////////////////////
        public static StringBuilder StudentIDDetailstoXML(List<StudentData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StudentData obj in studentlist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" DOB = \"" + obj.DOB.ToString() + "\" ");
                str.Append(" StudentName = \"" + obj.StudentName.ToString() + "\" ");
                str.Append(" FatherName = \"" + obj.FatherName.ToString() + "\" ");
                str.Append(" MotherName = \"" + obj.MotherName.ToString() + "\" ");
                str.Append(" MobileNumber = \"" + obj.MobileNumber.ToString() + "\" ");
                str.Append(" BloodGroup = \"" + obj.BloodGroup.ToString() + "\" ");
                str.Append(" BloodGroupID = \"" + obj.BloodGroupID.ToString() + "\" ");
                str.Append(" Address = \"" + obj.Address.ToString() + "\" ");
                str.Append(" AddedBy = \"" + obj.AddedBy.ToString() + "\" ");
                str.Append(" AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" HouseID = \"" + obj.HouseID.ToString() + "\" ");
                str.Append(" StudentTypeID = \"" + obj.StudentTypeID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        ////////////////////////////////////////////////////////////////////
        public static StringBuilder CTPCertificatelistXML(List<Examdata> Studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Examdata obj in Studentlist)
            {
                str.Append("<Studentlist StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" BDivision = \"" + obj.BDivision.ToString() + "\" ");
                str.Append(" BRollNo = \"" + obj.BRollNo.ToString() + "\" ");
                str.Append(" BAttendance = \"" + obj.BAttendance.ToString() + "\" ");
                str.Append(" DateLeft = \"" + obj.DateLeft.ToString() + "\" ");
                str.Append(" SubDivisions = \"" + obj.SubDivisions.ToString() + "\" ");
                //str.Append(" COHSEMDivisionID = \"" + obj.COHSEMDivisionID.ToString() + "\" ");
                str.Append(" IsPass = \"" + obj.IsPass.ToString() + "\" ");
                str.Append(" YearPass = \"" + obj.YearPass.ToString() + "\" ");
                str.Append(" RegistrationNo = \"" + obj.RegistrationNo.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        ////////Hostel Purchase Record
        public static StringBuilder ServiceItemListXML(List<ItemData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ItemData obj in ItemList)
            {
                str.Append("<ServiceItemList ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" ItemName = \"" + obj.ItemName.ToString() + "\" ");
                str.Append(" ItemRate = \"" + obj.ItemRate.ToString() + "\" ");
                str.Append(" ItemQty = \"" + obj.ItemQty.ToString() + "\" ");
                str.Append(" TotalAmount = \"" + obj.TotalAmount.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ActivatedclasstoXML(List<ClassData> classlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ClassData obj in classlist)
            {
                str.Append("<classlist ClassID = \"" + obj.ClassID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ActivatedsubjecttoXML(List<SubjectData> subjectlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (SubjectData obj in subjectlist)
            {
                str.Append("<subjectlist SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ActivatedsubjecttoXML(List<ClasswiseSubjectData> subjectlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ClasswiseSubjectData obj in subjectlist)
            {
                str.Append("<subjectlist SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }

        public static StringBuilder ExamRankTieRuletoXML(List<ExamRankTieRuleData> lstruledata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamRankTieRuleData obj in lstruledata)
            {
                str.Append("<ExamRabkTie ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" TypeID = \"" + obj.typeid.ToString() + "\" ");
                str.Append(" Priority = \"" + obj.Priority.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ExamDivisionRuletoXML(List<ExamDivisionRuleData> lstruledata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamDivisionRuleData obj in lstruledata)
            {
                str.Append("<ExamDivision ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" Division = \"" + obj.DivisionName.ToString() + "\" ");
                str.Append(" PCFrom = \"" + obj.PCFrom.ToString() + "\" ");
                str.Append(" PCUpTo = \"" + obj.PCUpTo.ToString() + "\" ");
                str.Append(" NoOfAbsent = \"" + obj.NoOfAbsent.ToString() + "\" ");
                str.Append(" NoOfAbsentUpto = \"" + obj.NoOfAbsentUpto.ToString() + "\" ");
                str.Append(" NoOfFailed = \"" + obj.NoOfFailed.ToString() + "\" ");
                str.Append(" NoOfFailedUpto = \"" + obj.NoOfFailedUpto.ToString() + "\" ");
                str.Append(" NoOfFailedAbsent = \"" + obj.NoOfFailedAbsent.ToString() + "\" ");
                str.Append(" NoOfFailedAbsentUpto = \"" + obj.NoOfFailedAbsentUpto.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ExamRuletoXML(List<ExamDivisionRuleData> lstruledata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamDivisionRuleData obj in lstruledata)
            {
                str.Append("<ExamRule ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" TypeID = \"" + obj.TypeID.ToString() + "\" ");
                str.Append(" Activate = \"" + obj.Activate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ExamFailPassRuletoXML(List<ExamDivisionRuleData> lstruledata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamDivisionRuleData obj in lstruledata)
            {
                str.Append("<ExamFailPass ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" Result = \"" + obj.Result.ToString() + "\" ");
                str.Append(" PCFrom = \"" + obj.PCFrom.ToString() + "\" ");
                str.Append(" PCUpTo = \"" + obj.PCUpTo.ToString() + "\" ");
                str.Append(" NoOfAbsent = \"" + obj.NoOfAbsent.ToString() + "\" ");
                str.Append(" NoOfAbsentUpto = \"" + obj.NoOfAbsentUpto.ToString() + "\" ");
                str.Append(" NoOfFailed = \"" + obj.NoOfFailed.ToString() + "\" ");
                str.Append(" NoOfFailedUpto = \"" + obj.NoOfFailedUpto.ToString() + "\" ");
                str.Append(" NoOfFailedAbsent = \"" + obj.NoOfFailedAbsent.ToString() + "\" ");
                str.Append(" NoOfFailedAbsentUpto = \"" + obj.NoOfFailedAbsentUpto.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ExamRemarkRuletoXML(List<ExamDivisionRuleData> lstruledata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamDivisionRuleData obj in lstruledata)
            {
                str.Append("<ExamRemark ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" Remark = \"" + obj.RemarkName.ToString() + "\" ");
                str.Append(" PCFrom = \"" + obj.PCFrom.ToString() + "\" ");
                str.Append(" PCUpTo = \"" + obj.PCUpTo.ToString() + "\" ");
                str.Append(" NoOfAbsent = \"" + obj.NoOfAbsent.ToString() + "\" ");
                str.Append(" NoOfAbsentUpto = \"" + obj.NoOfAbsentUpto.ToString() + "\" ");
                str.Append(" NoOfFailed = \"" + obj.NoOfFailed.ToString() + "\" ");
                str.Append(" NoOfFailedUpto = \"" + obj.NoOfFailedUpto.ToString() + "\" ");
                str.Append(" NoOfFailedAbsent = \"" + obj.NoOfFailedAbsent.ToString() + "\" ");
                str.Append(" NoOfFailedAbsentUpto = \"" + obj.NoOfFailedAbsentUpto.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ExamGradeRuletoXML(List<ExamDivisionRuleData> lstruledata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ExamDivisionRuleData obj in lstruledata)
            {
                str.Append("<ExamGrade ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" PCFrom = \"" + obj.PCFrom.ToString() + "\" ");
                str.Append(" PCUpTo = \"" + obj.PCUpTo.ToString() + "\" ");
                str.Append(" MarkFrom = \"" + obj.MarkFrom.ToString() + "\" ");
                str.Append(" MarkUpTo = \"" + obj.MarkUpto.ToString() + "\" ");
                str.Append(" GradeValue = \"" + obj.Grade.ToString() + "\" ");

                str.Append(" />");
            }
            return str;
        }

        ////////SMS///////
        public static StringBuilder xmlStudentSmsData(List<SmsData> lstruledata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (SmsData obj in lstruledata)
            {
                str.Append("<ListSMSData RecipientUniqueID = \"" + obj.RecipientUniqueID.ToString() + "\" ");
                str.Append(" RecipientName = \"" + obj.RecipientName.ToString() + "\" ");
                str.Append(" MobileNo = \"" + obj.MobileNo.ToString() + "\" ");
                str.Append(" SmsCost = \"" + obj.SmsCost.ToString() + "\" ");
                str.Append(" SentSMS = \"" + obj.DeliveredSMS.ToString() + "\" ");
                str.Append(" CharCount = \"" + obj.CharCount.ToString() + "\" ");
                str.Append(" ResponseID = \"" + obj.ResponseID.ToString() + "\" ");
                str.Append(" StatusID = \"" + obj.StatusID.ToString() + "\" ");
                str.Append(" Status = \"" + obj.Status.ToString() + "\" ");
                if (obj.SendTo == 1)
                {
                    str.Append(" ClassID = \"" + obj.ClassID.ToString() + "\" ");
                    str.Append(" SectionID = \"" + obj.SectionID.ToString() + "\" ");
                    str.Append(" RollNo = \"" + obj.RollNo.ToString() + "\" ");
                    str.Append(" FatherName = \"" + obj.FatherName.ToString() + "\" ");
                    str.Append(" MotherName = \"" + obj.MotherName.ToString() + "\" ");
                }
                if (obj.SendTo == 2)
                {
                    str.Append(" DesignationID = \"" + obj.DesignationID.ToString() + "\" ");
                    str.Append(" StaffTypeID = \"" + obj.StaffTypeID.ToString() + "\" ");
                }

                str.Append(" />");
            }
            return str;
        }

        //---------Library-----//
        public static StringBuilder BookIssueListXML(List<IssueBookData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (IssueBookData obj in ItemList)
            {
                str.Append("<BookIssueList HID = \"" + obj.HID.ToString() + "\" ");
                str.Append(" Books = \"" + obj.Books.ToString() + "\" ");
                str.Append(" Qty = \"" + obj.Qty.ToString() + "\" ");
                str.Append(" IssueDate = \"" + obj.IssueDate.ToString() + "\" ");
                str.Append(" ReturnDate = \"" + obj.ReturnDate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder BookReturnListXML(List<ReturnBookData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ReturnBookData obj in ItemList)
            {
                str.Append("<BookReturnList HID = \"" + obj.HID.ToString() + "\" ");
                str.Append(" Qty = \"" + obj.Qty.ToString() + "\" ");
                str.Append(" IssueID = \"" + obj.IssueID.ToString() + "\" ");
                str.Append(" IsReturn = \"" + obj.IsReturn.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }

        //---------------------FeeUtility------------------//
        public static StringBuilder ExtraRuletoXML(List<ExtraFeeRuleData> ExtraRuleList)
        {
            StringBuilder str = new StringBuilder();
            foreach (ExtraFeeRuleData obj in ExtraRuleList)
            {
                str.Append("<ExtraRule SubjectID = \"" + obj.SubjectID.ToString() + "\" ");
                str.Append(" Miscellaneous = \"" + obj.Miscellaneous.ToString() + "\" ");
                str.Append(" Amount = \"" + obj.Amount.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder DetailFeetoXML(List<FeeDetailRulesData> DetailFeeList)
        {
            StringBuilder str = new StringBuilder();
            foreach (FeeDetailRulesData obj in DetailFeeList)
            {
                str.Append("<DetailFee ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" PaymentTypeID = \"" + obj.PaymentTypeID.ToString() + "\" ");
                str.Append(" FeeNewStudent = \"" + obj.FeeNewStudent.ToString() + "\" ");
                str.Append(" FeeOldStudent = \"" + obj.FeeOldStudent.ToString() + "\" ");
                str.Append(" IsStudentTypeApply = \"" + obj.IsStudentTypeApply.ToString() + "\" ");
                str.Append(" FeeHeirarchy = \"" + obj.FeeHeirarchy.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder OneTimeFeetoXML(List<OneTimePaymentData> OneTimeFeeList)
        {
            StringBuilder str = new StringBuilder();
            foreach (OneTimePaymentData obj in OneTimeFeeList)
            {
                str.Append("<OneTimeFee OnetimeID = \"" + obj.OnetimeID.ToString() + "\" ");
                str.Append(" Particulars = \"" + obj.Particulars.ToString() + "\" ");
                str.Append(" FeeAmount_New = \"" + obj.FeeAmount_New.ToString() + "\" ");
                str.Append(" FeeAmount_Old = \"" + obj.FeeAmount_Old.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder MonthlyPaymenttoXML(List<MonthlyPaymentData> MonthPaymentList)
        {
            StringBuilder str = new StringBuilder();
            foreach (MonthlyPaymentData obj in MonthPaymentList)
            {
                str.Append("<MonthlyPayment MonthlyID = \"" + obj.MonthlyID.ToString() + "\" ");
                str.Append(" FeeAmount_New = \"" + obj.FeeAmount_New.ToString() + "\" ");
                str.Append(" FeeAmount_Old = \"" + obj.FeeAmount_Old.ToString() + "\" ");
                str.Append(" Exemption = \"" + obj.Exemption.ToString() + "\" ");
                str.Append(" EMI = \"" + obj.EMI.ToString() + "\" ");
                str.Append(" Computerfee = \"" + obj.Computerfee.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder EMIPaymenttoXML(List<EMIPaymentData> EMIPaymentList)
        {
            StringBuilder str = new StringBuilder();
            foreach (EMIPaymentData obj in EMIPaymentList)
            {
                str.Append("<EMIPayment MonthlyID = \"" + obj.MonthlyID.ToString() + "\" ");
                str.Append(" FeeAmount_New = \"" + obj.FeeAmount_New.ToString() + "\" ");
                str.Append(" FeeAmount_Old = \"" + obj.FeeAmount_Old.ToString() + "\" ");
                str.Append(" Exemption = \"" + obj.Exemption.ToString() + "\" ");
                str.Append(" DueDate = \"" + obj.DueDate.ToString() + "\" ");
                str.Append(" Fine = \"" + obj.Fine.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ExemptiontoXML(List<ExemptionRuleData> ExemptionList)
        {
            StringBuilder str = new StringBuilder();
            foreach (ExemptionRuleData obj in ExemptionList)
            {
                str.Append("<Exemption ExemptionID = \"" + obj.ExemptionID.ToString() + "\" ");
                str.Append(" StudentTypeID = \"" + obj.StudentTypeID.ToString() + "\" ");
                str.Append(" FeeAmount_New = \"" + obj.FeeAmount_New.ToString() + "\" ");
                str.Append(" FeeAmount_Old = \"" + obj.FeeAmount_Old.ToString() + "\" ");
                str.Append(" ExemptedAmount_New = \"" + obj.ExemptedAmount_New.ToString() + "\" ");
                str.Append(" ExemptedAmount_Old = \"" + obj.ExemptedAmount_Old.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder InclusiveOtherFeetoXML(List<InclusiveRuleData> InclusiveList)
        {
            StringBuilder str = new StringBuilder();
            foreach (InclusiveRuleData obj in InclusiveList)
            {
                str.Append("<InclusiveOtherFee InclusiveID = \"" + obj.InclusiveID.ToString() + "\" ");
                str.Append(" OtherFeeTypeID = \"" + obj.OtherFeeTypeID.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder InclusiveMonthtoXML(List<InclusiveRuleData> InclusiveList)
        {
            StringBuilder str = new StringBuilder();
            foreach (InclusiveRuleData obj in InclusiveList)
            {
                str.Append("<InclusiveMonth MonthID = \"" + obj.MonthlyID.ToString() + "\" ");
                str.Append(" OtherFeeTypeID = \"" + obj.OtherFeeTypeID.ToString() + "\" ");
                str.Append(" TotalFeeAmount = \"" + obj.TotalFeeAmount.ToString() + "\" ");
                str.Append(" IsActivate = \"" + obj.IsActivate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        //------------------------------End FeeUtility--------------------------------------
        //------------------------------Start HR And Payroll--------------------------------

        public static StringBuilder HolidayListToXml(List<HolidayListData> HolidayList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (HolidayListData obj in HolidayList)
            {
                str.Append("<HolidayList ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" YearID = \"" + obj.YearID.ToString() + "\" ");
                str.Append(" Year = \"" + obj.Year.ToString() + "\" ");
                str.Append(" MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" Month = \"" + obj.Month.ToString() + "\" ");
                str.Append(" Reason = \"" + obj.Reason.ToString() + "\" ");
                str.Append(" IsHoliday = \"" + obj.IsHoliday.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }

        public static StringBuilder SalaryStructureListToXml(List<SalaryStructureData> SalaryStructureList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (SalaryStructureData obj in SalaryStructureList)
            {
                str.Append("<SalaryStructure ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" YearID = \"" + obj.YearID.ToString() + "\" ");
                str.Append(" EmployeeID = \"" + obj.EmployeeID.ToString() + "\" ");
                str.Append(" BasicSalary = \"" + obj.BasicSalary.ToString() + "\" ");
                str.Append(" TA = \"" + obj.TA.ToString() + "\" ");
                str.Append(" Proxy = \"" + obj.Proxy.ToString() + "\" ");
                str.Append(" Absent = \"" + obj.Absent.ToString() + "\" ");
                str.Append(" EPF = \"" + obj.EPF.ToString() + "\" ");
                str.Append(" DA = \"" + obj.DA.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }

        public static StringBuilder OutsideDutyListToXml(List<OutsideDutyManagerData> OutsideDutyList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (OutsideDutyManagerData obj in OutsideDutyList)
            {
                str.Append("<OutsideDutyList ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" Reason = \"" + obj.Reason.ToString() + "\" ");
                str.Append(" ConvenienceFee = \"" + obj.ConvenienceFee.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }

        public static StringBuilder AttendanceListToXml(List<ManualAttendanceData> AttendanceList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ManualAttendanceData obj in AttendanceList)
            {
                str.Append("<AttendanceList ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" Date = \"" + obj.Date.ToString() + "\" ");
                str.Append(" AttendanceStatusID = \"" + obj.AttendanceStatusID.ToString() + "\" ");
                str.Append(" AttendanceStatus = \"" + obj.AttendanceStatus.ToString() + "\" ");
                str.Append(" Reason = \"" + obj.Reason.ToString() + "\" ");
                str.Append(" EmployeeID = \"" + obj.EmployeeID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }

        public static StringBuilder LeaveRequestListToXml(List<LeaveRequestData> LRList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (LeaveRequestData obj in LRList)
            {
                str.Append("<LeaveRequestList YearID = \"" + obj.YearID.ToString() + "\" ");
                str.Append(" Year = \"" + obj.Year.ToString() + "\" ");
                str.Append(" MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" Month = \"" + obj.Month.ToString() + "\" ");
                str.Append(" Reason = \"" + obj.Reason.ToString() + "\" ");
                str.Append(" RequestedDate = \"" + obj.RequestedDate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder LeaveApproveListToXml(List<LeaveRequestData> LRList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (LeaveRequestData obj in LRList)
            {
                str.Append("<LeaveList YearID = \"" + obj.YearID.ToString() + "\" ");
                str.Append(" MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" Reason = \"" + obj.Reason.ToString() + "\" ");
                str.Append(" RequestedDate = \"" + obj.RequestedDate.ToString() + "\" ");
                str.Append(" IsApproved = \"" + obj.IsApproved.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        //------------------------------End HR And Payroll--------------------------------
        public static StringBuilder MonthlyTransportFeetoXML(List<TransportData> lstdata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (TransportData obj in lstdata)
            {
                str.Append("<MonthlyTransportFee StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" FeeAmount = \"" + obj.FeeAmount.ToString() + "\" ");
                str.Append(" Exemption = \"" + obj.Exemption.ToString() + "\" ");
                str.Append(" NetAmount = \"" + obj.NetAmount.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder TransportMonthlyFeeSettingtoXML(List<TransportData> lstdata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (TransportData obj in lstdata)
            {
                str.Append("<TransportMonthlyFeeSetting MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" Activate = \"" + obj.Activate.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder MonthlyTransportFeeMastertoXML(List<TransportData> lstdata)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (TransportData obj in lstdata)
            {
                str.Append("<MonthlyTransportFee StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" FeeAmount = \"" + obj.FeeAmount.ToString() + "\" ");
                str.Append(" Exemption = \"" + obj.Exemption.ToString() + "\" ");
                str.Append(" NetAmount = \"" + obj.NetAmount.ToString() + "\" ");

                str.Append(" />");
            }
            return str;
        }
        //---------Inventory -----------------------
        public static StringBuilder ItemPriceListtoXML(List<Data.EduInvUtility.ItemPriceData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (Data.EduInvUtility.ItemPriceData obj in ItemList)
            {
                str.Append("<ItemPriceList ItemPriceID = \"" + obj.ItemPriceID.ToString() + "\" ");
                str.Append(" Itemid = \"" + obj.Itemid.ToString() + "\" ");
                str.Append(" Price = \"" + obj.Price.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder WorkOrderItemListXML(List<WorkOrderData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (WorkOrderData obj in ItemList)
            {
                str.Append("<WorkOrderItemList ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" Size = \"" + obj.Size.ToString() + "\" ");
                str.Append(" NoOfPage = \"" + obj.NoOfPage.ToString() + "\" ");
                str.Append(" NoOfCopies = \"" + obj.NoOfCopies.ToString() + "\" ");
                str.Append(" NoOfIssuePaper = \"" + obj.NoOfIssuePaper.ToString() + "\" ");
                str.Append(" SubGroupID = \"" + obj.SubGroupID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StockEntryListXML(List<WorkOrderData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (WorkOrderData obj in ItemList)
            {
                str.Append("<StockEntryList ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" NowReceived = \"" + obj.NowReceived.ToString() + "\" ");
                str.Append(" PreTotalReceived = \"" + obj.PreTotalReceived.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StockEntryWithoutPOListXML(List<StockEntryWithoutPOData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StockEntryWithoutPOData obj in ItemList)
            {
                str.Append("<StockEntryWithoutPOList GroupID = \"" + obj.GroupID.ToString() + "\" ");
                str.Append(" SubGroupID = \"" + obj.SubGroupID.ToString() + "\" ");
                str.Append(" VendorTypeID = \"" + obj.VendorTypeID.ToString() + "\" ");
                str.Append(" VendorID = \"" + obj.VendorID.ToString() + "\" ");
                str.Append(" ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" Quantity = \"" + obj.Quantity.ToString() + "\" ");
                str.Append(" ConvertingUnitID = \"" + obj.ConvertingUnitID.ToString() + "\" ");
                str.Append(" NetQuantity = \"" + obj.NetQuantity.ToString() + "\" ");
                str.Append(" Price = \"" + obj.Price.ToString() + "\" ");
                str.Append(" YearID = \"" + obj.YearID.ToString() + "\" ");
                str.Append(" YearName = \"" + obj.YearName.ToString() + "\" ");
                str.Append(" EquivalentQty = \"" + obj.EquivalentQty.ToString() + "\" ");
                str.Append(" TotalPrice = \"" + obj.TotalPrice.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ItemCondemListXML(List<ItemCondemnationData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ItemCondemnationData obj in ItemList)
            {
                str.Append("<ItemCondemList StockNo = \"" + obj.StockNo.ToString() + "\" ");
                str.Append(" VendorID = \"" + obj.VendorID.ToString() + "\" ");
                str.Append(" ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" UnitID = \"" + obj.UnitID.ToString() + "\" ");
                str.Append(" Price = \"" + obj.Price.ToString() + "\" ");
                str.Append(" NetRecievedQty = \"" + obj.NetRecievedQty.ToString() + "\" ");
                str.Append(" NetBalanceQty = \"" + obj.NetBalanceQty.ToString() + "\" ");
                str.Append(" CondemnQty = \"" + obj.CondemnQty.ToString() + "\" ");
                str.Append(" CondemnTypeID = \"" + obj.CondemnTypeID.ToString() + "\" ");
                str.Append(" CondemnType = \"" + obj.CondemnType.ToString() + "\" ");
                str.Append(" CondemnRemark = \"" + obj.CondemnRemark.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StockIssueListtoXML(List<StockIssueData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (StockIssueData obj in ItemList)
            {
                str.Append("<StockIssueList VendorTypeID = \"" + obj.VendorTypeID.ToString() + "\" ");
                str.Append(" VendorID = \"" + obj.VendorID.ToString() + "\" ");
                str.Append(" ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" UnitID = \"" + obj.UnitID.ToString() + "\" ");
                str.Append(" AvailableQty = \"" + obj.AvailableQty.ToString() + "\" ");
                str.Append(" IssueQty = \"" + obj.IssueQty.ToString() + "\" ");
                str.Append(" ExpiryDates = \"" + obj.ExpiryDates.ToString() + "\" ");
                str.Append(" StockNo = \"" + obj.StockNo.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder ItemReturnListtoXML(List<ItemReturnData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ItemReturnData obj in ItemList)
            {
                str.Append("<ItemReturnList VendorTypeID = \"" + obj.VendorTypeID.ToString() + "\" ");
                str.Append(" VendorID = \"" + obj.VendorID.ToString() + "\" ");
                str.Append(" ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" UnitID = \"" + obj.UnitID.ToString() + "\" ");
                str.Append(" ReturnQty = \"" + obj.ReturnQty.ToString() + "\" ");
                str.Append(" ExpiryDates = \"" + obj.ExpiryDates.ToString() + "\" ");
                str.Append(" IssueNo = \"" + obj.IssueNo.ToString() + "\" ");
                str.Append(" StockNo = \"" + obj.StockNo.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder IndentGenerationlisttoXML(List<IndentGenerationData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (IndentGenerationData obj in ItemList)
            {
                str.Append("<IndentGenerationlist ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" IndentQty = \"" + obj.IndentQty.ToString() + "\" ");
                str.Append(" Price = \"" + obj.Price.ToString() + "\" ");
                str.Append(" TotalPrice = \"" + obj.TotalPrice.ToString() + "\" ");
                str.Append(" StockNo = \"" + obj.StockNo.ToString() + "\" ");
                str.Append(" AcademicSessionName = \"" + obj.AcademicSessionName.ToString() + "\" ");
                str.Append(" GroupID = \"" + obj.GroupID.ToString() + "\" ");
                str.Append(" SubGroupID = \"" + obj.SubGroupID.ToString() + "\" ");
                str.Append(" BatchYearID = \"" + obj.BatchYearID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder IndentSaleListtoXML(List<IndentSaleData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (IndentSaleData obj in ItemList)
            {
                str.Append("<IndentSaleList ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" Price = \"" + obj.Price.ToString() + "\" ");
                str.Append(" TotalPrice = \"" + obj.TotalPrice.ToString() + "\" ");
                str.Append(" AvailableQty = \"" + obj.AvailableQty.ToString() + "\" ");
                str.Append(" IssueQty = \"" + obj.IssueQty.ToString() + "\" ");
                str.Append(" StockNo = \"" + obj.StockNo.ToString() + "\" ");
                str.Append(" BatchYearID = \"" + obj.BatchYearID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder StockReleaseListtoXML(List<IndentSaleData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (IndentSaleData obj in ItemList)
            {
                str.Append("<StockReleaseList ItemID = \"" + obj.ItemID.ToString() + "\" ");
                str.Append(" AvailableQty = \"" + obj.AvailableQty.ToString() + "\" ");
                str.Append(" NetApprovedQty = \"" + obj.NetApprovedQty.ToString() + "\" ");
                str.Append(" GdTotalReleasedQty = \"" + obj.GdTotalReleasedQty.ToString() + "\" ");
                str.Append(" NetDueRelease = \"" + obj.NetDueRelease.ToString() + "\" ");
                str.Append(" StockNo = \"" + obj.StockNo.ToString() + "\" ");
                str.Append(" BatchYearID = \"" + obj.BatchYearID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder AccountTransListXML(List<TransactionData> ItemList)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (TransactionData obj in ItemList)
            {
                str.Append("<AccountTransList FromLedgerID = \"" + obj.FromLedgerID.ToString() + "\" ");
                str.Append(" FromLedgerName = \"" + obj.FromLedgerName.ToString() + "\" ");
                str.Append(" ToLedgerID = \"" + obj.ToLedgerID.ToString() + "\" ");
                str.Append(" ToLedgerName = \"" + obj.ToLedgerName.ToString() + "\" ");
                str.Append(" TrasactionAmount = \"" + obj.TransactionAmount.ToString() + "\" ");
                str.Append(" TrasactionNaration = \"" + obj.TransactionNaration.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }

        //Student Fee Status // Payment
        public static StringBuilder StudentPaymentlistToXML(List<FeeData> StudentPaymentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (FeeData obj in StudentPaymentlist)
            {
                str.Append("<StudentPaymentlist ParticularID = \"" + obj.ParticularID.ToString() + "\" ");
                str.Append(" Particulars = \"" + obj.Particulars.ToString() + "\" ");
                str.Append(" FeeAmount = \"" + obj.FeeAmount.ToString() + "\" ");
                str.Append(" FineAmount = \"" + obj.FineAmount.ToString() + "\" ");
                str.Append(" NetAmount = \"" + obj.NetAmount.ToString() + "\" ");
                str.Append(" DueAmount = \"" + obj.DueAmount.ToString() + "\" ");
                str.Append(" PaidAmount = \"" + obj.Paid.ToString() + "\" ");
                str.Append(" Structure = \"" + obj.Structure.ToString() + "\" ");
                str.Append(" OneTimeStructureID = \"" + obj.OneTimeStructureID.ToString() + "\" ");
                str.Append(" InclusiveFromFeeTypeID = \"" + obj.InclusiveFromFeeTypeID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }


        //Yearly Wise Income
        public static StringBuilder AcademicSessionlistToXML(List<FeeData> xmlacademicsessionlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (FeeData obj in xmlacademicsessionlist)
            {
                str.Append("<AcademicSession AcademicSessionID = \"" + obj.AcademicSessionID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder FeeTypelistToXML(List<FeeData> xmlfeetypelist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (FeeData objs in xmlfeetypelist)
            {
                str.Append("<FeeType FeeTypeID = \"" + objs.MonthID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder MonthlistToXML(List<FeeData> xmlmonthlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (FeeData obj in xmlmonthlist)
            {
                str.Append("<Month MonthID = \"" + obj.MonthID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        public static StringBuilder TransExemptiontoXML(List<TransportExemptionRuleData> ExemptionList)
        {
            StringBuilder str = new StringBuilder();
            foreach (TransportExemptionRuleData obj in ExemptionList)
            {
                str.Append("<TransExemption ExemptionID = \"" + obj.ExemptionID.ToString() + "\" ");
                str.Append(" StudentTypeID = \"" + obj.StudentTypeID.ToString() + "\" ");
                str.Append(" NetFare = \"" + obj.NetFare.ToString() + "\" ");
                str.Append(" ExemptedAmount = \"" + obj.ExemptedAmount.ToString() + "\" ");
                str.Append(" FeeID = \"" + obj.FeeID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
        ///////////////////////////////////////////////////////////////////////////
        /// E-Learning Attendance Update
        public static StringBuilder E_LearningStudentAttendance(List<ELearningData> studentlist)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("<?xml version=\"1.0\"?>");
            //str.Append("<Root>");
            foreach (ELearningData obj in studentlist)
            {
                str.Append("<StudentList ID = \"" + obj.ID.ToString() + "\" ");
                str.Append(" StudentID = \"" + obj.StudentID.ToString() + "\" ");
                str.Append(" AttendanceID = \"" + obj.AttendanceID.ToString() + "\" ");
                str.Append(" />");
            }
            return str;
        }
    }
}