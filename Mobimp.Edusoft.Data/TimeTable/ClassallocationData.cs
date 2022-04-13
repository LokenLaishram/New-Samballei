using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.Data.TimeTable
{
    public class ClassallocationData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 TeacherID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int Maxperiodallowed { get; set; }
        [DataMember]
        public int ActualAlloted { get; set; }
        [DataMember]
        public string AllocatedClasses { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string AllocatedSubjects { get; set; }
        [DataMember]
        public Int32 AllocatedClassID { get; set; }
        [DataMember]
        public Int32 AllocatedSubjectID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int CountClass { get; set; }

    }
    public class SubjectAllocationData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 TeacherID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string AllocatedSubjects { get; set; }
        [DataMember]
        public Int32 AllocatedSubjectID { get; set; }
        [DataMember]
        public Int32 Rating { get; set; }
        [DataMember]
        public string AllocatedSections { get; set; }
    }
    public class ClassallocationtoExcel
    {
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int Maxperiodallowed { get; set; }
        [DataMember]
        public string AllocatedClasses { get; set; }
        [DataMember]
        public string AllocatedSubjects { get; set; }
    }
    public class PeriodPlannerData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 TeacherID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string ClassNames { get; set; }
        [DataMember]
        public int Maxperiodallowed { get; set; }
        [DataMember]
        public string AllocatedClasses { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string AllocatedSubjects { get; set; }
        [DataMember]
        public Int32 AllocatedClassID { get; set; }
        [DataMember]
        public Int32 AllocatedSubjectID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int NoChapter { get; set; }
        [DataMember]
        public int NoPeriodReqd { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int NoSection { get; set; }
        [DataMember]
        public string SectionList { get; set; }
        [DataMember]
        public string NetReqdPeriod { get; set; }
        [DataMember]
        public string TotalworkingDays { get; set; }
        [DataMember]
        public int NoperiodPerweekforsections { get; set; }
        [DataMember]
        public string AssignTeacherlist { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public int DayID { get; set; }
        [DataMember]
        public int MaxPeriod { get; set; }
        [DataMember]
        public int ActualAlloted { get; set; }
    }
    public class PeriodPlannertoExcel
    {
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int NoChapter { get; set; }
        [DataMember]
        public int NoPeriodReqd { get; set; }
        [DataMember]
        public int NoSection { get; set; }
        [DataMember]
        public string SectionList { get; set; }
        [DataMember]
        public string NetReqdPeriod { get; set; }
        [DataMember]
        public string TotalworkingDays { get; set; }
        [DataMember]
        public int NoperiodPerweekforsections { get; set; }
        [DataMember]
        public string AssignTeacherlist { get; set; }
    }
    public class TimetableruleData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Startfrom { get; set; }
        [DataMember]
        public string Startto { get; set; }
        [DataMember]
        public int Noperiods { get; set; }
        [DataMember]
        public string PeriodDuration { get; set; }
        [DataMember]
        public int Norecess { get; set; }
        [DataMember]
        public string RecessDuration { get; set; }
        [DataMember]
        public string Recessperiod { get; set; }
        [DataMember]
        public int NoSubjects { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public int Sunday { get; set; }
        [DataMember]
        public int Monday { get; set; }
        [DataMember]
        public int Tuesday { get; set; }
        [DataMember]
        public int Wednesday { get; set; }
        [DataMember]
        public int Thursday { get; set; }
        [DataMember]
        public int Friday { get; set; }
        [DataMember]
        public int Saturday { get; set; }
        [DataMember]
        public int TotalWeeklyperiod { get; set; }
        [DataMember]
        public string PeriodDetails { get; set; }

    }
    public class TimetableruleDatatoExcel
    {
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Startfrom { get; set; }
        [DataMember]
        public string Startto { get; set; }
        [DataMember]
        public int Noperiods { get; set; }
        [DataMember]
        public string PeriodDuration { get; set; }
        [DataMember]
        public int Norecess { get; set; }
        [DataMember]
        public string RecessDuration { get; set; }
    }
    public class ClasswisePeriodPlannerData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int MainSubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int TotalWeeklyPeriod { get; set; }
        [DataMember]
        public int Sunday { get; set; }
        [DataMember]
        public int Monday { get; set; }
        [DataMember]
        public int Tuesday { get; set; }
        [DataMember]
        public int Wednesday { get; set; }
        [DataMember]
        public int Thursday { get; set; }
        [DataMember]
        public int Friday { get; set; }
        [DataMember]
        public int Saturday { get; set; }
        [DataMember]
        public int Noperiods { get; set; }
        [DataMember]
        public int Norecess { get; set; }
        [DataMember]
        public int DefaultPeriod { get; set; }
        [DataMember]
        public int TeacherID { get; set; }
        [DataMember]
        public string Allotedteachers { get; set; }
        [DataMember]
        public int TotalAllotedTeacher { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int TotalTableWeeklyPeriod { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int SubjectwisePeriod { get; set; }
        [DataMember]
        public int SundayPeriod { get; set; }
        [DataMember]
        public int Modayperiod { get; set; }
        [DataMember]
        public int Tuesdayperiod { get; set; }
        [DataMember]
        public int Wednesdayperiod { get; set; }
        [DataMember]
        public int Thursdayperiod { get; set; }
        [DataMember]
        public int Fridayperiod { get; set; }
        [DataMember]
        public int Saturdayperiod { get; set; }
        [DataMember]
        public int Subsubjectwiseperiodcount { get; set; }
        [DataMember]
        public int Updatetype { get; set; }
    }
    public class ClasswiseResourcePlannerData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int TotalWeeklyPeriod { get; set; }
        [DataMember]
        public int Sunday { get; set; }
        [DataMember]
        public int Monday { get; set; }
        [DataMember]
        public int Tuesday { get; set; }
        [DataMember]
        public int Wednesday { get; set; }
        [DataMember]
        public int Thursday { get; set; }
        [DataMember]
        public int Friday { get; set; }
        [DataMember]
        public int Saturday { get; set; }
        [DataMember]
        public int Noperiods { get; set; }
        [DataMember]
        public int Norecess { get; set; }
        [DataMember]
        public int DefaultPeriod { get; set; }
        [DataMember]
        public int TeacherID { get; set; }
        [DataMember]
        public string Allotedteachers { get; set; }
        [DataMember]
        public int TotalAllotedTeacher { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int TotalTableWeeklyPeriod { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int TotalPeriod { get; set; }
        [DataMember]
        public int SubjectPerTeacherPerDay { get; set; }
        [DataMember]
        public int TeacherRequired { get; set; }
        [DataMember]
        public int ExtraPeriod { get; set; }
        [DataMember]
        public int TotalSunday { get; set; }
        [DataMember]
        public int TotalMonday { get; set; }
        [DataMember]
        public int TotalTuesday { get; set; }
        [DataMember]
        public int TotalWednesday { get; set; }
        [DataMember]
        public int TotalThursday { get; set; }
        [DataMember]
        public int TotalFriday { get; set; }
        [DataMember]
        public int TotalSaturday { get; set; }
        [DataMember]
        public int TotalNoPeriod { get; set; }
        [DataMember]
        public int TotalTeacheredReqd { get; set; }
        [DataMember]
        public int TotalExtraPeriod { get; set; }
        [DataMember]
        public int AvailableTeacher { get; set; }
        [DataMember]
        public int TotalAvailableTeacher { get; set; }
        [DataMember]
        public string Teacherlist { get; set; }
        [DataMember]
        public int SundayStatus { get; set; }
        [DataMember]
        public int MondayStatus { get; set; }
        [DataMember]
        public int TuesdayStatus { get; set; }
        [DataMember]
        public int WednesdayStatus { get; set; }
        [DataMember]
        public int ThursdayStatus { get; set; }
        [DataMember]
        public int FridayStatus { get; set; }
        [DataMember]
        public int SaturdayStatus { get; set; }
    }
    public class TimeTableData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int32 GroupID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int MainSubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string MainSubjectIDs { get; set; }
        [DataMember]
        public int TotalWeeklyPeriod { get; set; }
        [DataMember]
        public int Sunday { get; set; }
        [DataMember]
        public string SundaySubject { get; set; }
        [DataMember]
        public int Monday { get; set; }
        [DataMember]
        public string MondaySubject { get; set; }
        [DataMember]
        public int Tuesday { get; set; }
        [DataMember]
        public string TuesdaySubject { get; set; }
        [DataMember]
        public int Wednesday { get; set; }
        [DataMember]
        public string WednesdaySubject { get; set; }
        [DataMember]
        public int Thursday { get; set; }
        [DataMember]
        public string ThursdaySubject { get; set; }
        [DataMember]
        public int Friday { get; set; }
        [DataMember]
        public string FridaySubject { get; set; }
        [DataMember]
        public int Saturday { get; set; }
        [DataMember]
        public string SaturdaySubject { get; set; }
        [DataMember]
        public int Noperiods { get; set; }
        [DataMember]
        public int Norecess { get; set; }
        [DataMember]
        public int DefaultPeriod { get; set; }
        [DataMember]
        public int TeacherID { get; set; }
        [DataMember]
        public string TimeRange { get; set; }
        [DataMember]
        public int Periodid { get; set; }
        [DataMember]
        public int SlotType { get; set; }
        [DataMember]
        public int AllocatedTeacher { get; set; }
        [DataMember]
        public int AllocatedSubject { get; set; }
        [DataMember]
        public int SlotID { get; set; }
        [DataMember]
        public int Actualalloted { get; set; }
        [DataMember]
        public int MaxPeriodalowed { get; set; }
        [DataMember]
        public int PeriodUpdatestatus { get; set; }
        [DataMember]
        public int DayID { get; set; }
        [DataMember]
        public String PeriodNo { get; set; }
        [DataMember]
        public String TeacherName { get; set; }
        [DataMember]
        public int PeriodCount { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int SubsTeacherID { get; set; }
        [DataMember]
        public String SubsTeacherName { get; set; }
    }
    public class TeacherWisePeriod : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 TeacherID { get; set; }
        [DataMember]
        public string TeacherName { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public int SubSubjectID { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string SubSubject { get; set; }
        [DataMember]
        public int TotalPeriod { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public int ActualPeriodAlloted { get; set; }
        [DataMember]
        public int NoPeriodDistributed { get; set; }
        [DataMember]
        public int DayID { get; set; }
        [DataMember]
        public int AssignStatus { get; set; }
        [DataMember]
        public int PeriodCount { get; set; }
        [DataMember]
        public int PeriodNo { get; set; }
        [DataMember]
        public int ClassTotalPeriod { get; set; }
       
        [DataMember]
        public int P_I_SubjectID { get; set; }
        [DataMember]
        public int P_II_SubjectID { get; set; }
        [DataMember]
        public int P_III_SubjectID { get; set; }
        [DataMember]
        public int P_IV_SubjectID { get; set; }
        [DataMember]
        public int P_V_SubjectID { get; set; }
        [DataMember]
        public int P_VI_SubjectID { get; set; }
        [DataMember]
        public int P_VII_SubjectID { get; set; }
        [DataMember]
        public int P_VIII_SubjectID { get; set; }
        [DataMember]
        public int P_IX_SubjectID { get; set; }
        [DataMember]
        public int P_X_SubjectID { get; set; }

        [DataMember]
        public int P_I_SubSubjectID { get; set; }
        [DataMember]
        public int P_II_SubSubjectID { get; set; }
        [DataMember]
        public int P_III_SubSubjectID { get; set; }
        [DataMember]
        public int P_IV_SubSubjectID { get; set; }
        [DataMember]
        public int P_V_SubSubjectID { get; set; }
        [DataMember]
        public int P_VI_SubSubjectID { get; set; }
        [DataMember]
        public int P_VII_SubSubjectID { get; set; }
        [DataMember]
        public int P_VIII_SubSubjectID { get; set; }
        [DataMember]
        public int P_IX_SubSubjectID { get; set; }
        [DataMember]
        public int P_X_SubSubjectID { get; set; }
        [DataMember]
        public string P_I_SubSubjectName { get; set; }
        [DataMember]
        public string P_II_SubSubjectName { get; set; }
        [DataMember]
        public string P_III_SubSubjectName { get; set; }
        [DataMember]
        public string P_IV_SubSubjectName { get; set; }
        [DataMember]
        public string P_V_SubSubjectName { get; set; }
        [DataMember]
        public string P_VI_SubSubjectName { get; set; }
        [DataMember]
        public string P_VII_SubSubjectName { get; set; }
        [DataMember]
        public string P_VIII_SubSubjectName { get; set; }
        [DataMember]
        public string P_IX_SubSubjectName { get; set; }
        [DataMember]
        public string P_X_SubSubjectName { get; set; }

        [DataMember]
        public int P_I_TeacherID { get; set; }
        [DataMember]
        public int P_II_TeacherID { get; set; }
        [DataMember]
        public int P_III_TeacherID { get; set; }
        [DataMember]
        public int P_IV_TeacherID { get; set; }
        [DataMember]
        public int P_V_TeacherID { get; set; }
        [DataMember]
        public int P_VI_TeacherID { get; set; }
        [DataMember]
        public int P_VII_TeacherID { get; set; }
        [DataMember]
        public int P_VIII_TeacherID { get; set; }
        [DataMember]
        public int P_IX_TeacherID { get; set; }
        [DataMember]
        public int P_X_TeacherID { get; set; }
        [DataMember]
        public int FilterType { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public int RemainingSlots { get; set; }
        

    }
    public class TimetableslotData
    {
        [DataMember]
        public int SlotID { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int GroupdID { get; set; }
        [DataMember]
        public int Session { get; set; }
        [DataMember]
        public int SlotType { get; set; }
    }
}
