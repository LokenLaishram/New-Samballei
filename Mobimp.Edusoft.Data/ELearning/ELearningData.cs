using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.ELearning
{
    public class ELearningData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public Int64 LiveClassID { get; set; }
        [DataMember]
        public int DayID { get; set; }
        [DataMember]
        public string DayName { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public Int64 TeacherID { get; set; }
        [DataMember]
        public Int64 OldTeacherID { get; set; }
        [DataMember]
        public string TeacherName { get; set; }
        [DataMember]
        public string VideoLink { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public string TeacherStartTime { get; set; }
        [DataMember]
        public string TeacherEndTime { get; set; }
        [DataMember]
        public DateTime ClassDate { get; set; }
        [DataMember]
        public int TotalStudent { get; set; }
        [DataMember]
        public int TotalAttended { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public int ClassStatus { get; set; } //0-Pending   //1-Ongoing    //2-Completed
        [DataMember]
        public int IsPresent { get; set; }
        [DataMember]
        public DateTime StudentJoiningTime { get; set; }
        [DataMember]
        public DateTime StudentLogoutTime { get; set; }
        [DataMember]
        public Int64 TeacherClassID { get; set; }
        [DataMember]
        public string Attendance { get; set; }
        [DataMember]
        public int AttendanceID { get; set; }
        [DataMember]
        public string XmlStudentAttendanceList { get; set; }

        //Assignment Related
        [DataMember]
        public string ClassDetail { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public byte[] AssignmentFile { get; set; }
        [DataMember]
        public byte[] AssignmentFileTeacher { get; set; }
        [DataMember]
        public DateTime LastDate { get; set; }
        [DataMember]
        public int TotalAssignment { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public int SubmissionStatusID { get; set; }
        [DataMember]
        public int TotalSubmitted { get; set; }
        [DataMember]
        public int TotalPending { get; set; }
        [DataMember]
        public string SubmissionStatus { get; set; }
        [DataMember]
        public Int64 AssignmentID { get; set; }
    }
    public class ELearningDataToExcel
    {
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string StartTime { get; set; }
        [DataMember]
        public string EndTime { get; set; }
        [DataMember]
        public string Teacher { get; set; }
        [DataMember]
        public string VideoLink { get; set; }
    }
    public class ELearningTeacherClassExcel
    {
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Section { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string StartTime { get; set; }
        [DataMember]
        public string EndTime { get; set; }
        [DataMember]
        public string Teacher { get; set; }
        [DataMember]
        public string VideoLink { get; set; }
        [DataMember]
        public string ClassStatus { get; set; }
        [DataMember]
        public string IsEnded { get; set; }
        [DataMember]
        public int TotalStudents { get; set; }
        [DataMember]
        public int TotalStudentsAttended { get; set; }
    }
}
