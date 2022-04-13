using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Campusoft.DataAccess.TimeTable;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.BussinessProcess.TimeTable
{
    public class PeriodplannerBO
    {
        public List<PeriodPlannerData> Getclasswisesubjectlist(PeriodPlannerData obj)
        {
            List<PeriodPlannerData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Getclasswisesubjectlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ClasswisePeriodPlannerData> Getclasswiseperiodplannerlist(ClasswisePeriodPlannerData obj)
        {
            List<ClasswisePeriodPlannerData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Getclasswiseperiodplannerlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ClasswisePeriodPlannerData> Getsubjectwiseplannerlist(ClasswisePeriodPlannerData obj)
        {
            List<ClasswisePeriodPlannerData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Getsubjectwiseplannerlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ClasswiseResourcePlannerData> Getsubjectwiseresourceplanning(ClasswiseResourcePlannerData obj)
        {
            List<ClasswiseResourcePlannerData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Getsubjectwiseresourceplanning(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetSubjectwiseteacherlsit(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetSubjectwiseteacherlsit(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetSubjectwiseactiveteachers(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetSubjectwiseactiveteachers(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetSubjectwiseDayteacherlsit(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetSubjectwiseDayteacherlsit(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> Getassignsubjectistt(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Getassignsubjectistt(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetTeacherPeriodlist(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetTeacherPeriodlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetTeacher_subjectwise_periodanalysis(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetTeacher_subjectwise_periodanalysis(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int Updateperiod_distribution(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Updateperiod_distribution(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int Addsubjectwiseteachers(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Addsubjectwiseteachers(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateassignSubjectlist(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.UpdateassignSubjectlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateTeachererAssignClass(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.UpdateTeachererAssignClass(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int GenerateTimetable(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GenerateTimetable(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int Teacherautodistributeclasses(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Teacherautodistributeclasses(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateteacherStatus(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.UpdateteacherStatus(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateAllotedsubjectTeacher(TimeTableData obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.UpdateAllotedsubjectTeacher(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateDailyAllotedsubjectTeacher(TimeTableData obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.UpdateDailyAllotedsubjectTeacher(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateDailySubstituteTeacher(TimeTableData obj)
        {
            int result = 0;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.UpdateDailySubstituteTeacher(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ClasswisePeriodPlannerData> Getclasswise_sectionwise_subjectlist(ClasswisePeriodPlannerData obj)
        {
            List<ClasswisePeriodPlannerData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Getclasswise_sectionwise_subjectlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TimeTableData> GetTimeTable(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetTimeTable(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TimeTableData> GetDailyTimeTable(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetDailyTimeTable(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TimeTableData> GetTeacherwiseClass(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetTeacherwiseClass(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TimeTableData> GetTeacherwiseassignsubjectlist(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.GetTeacherwiseassignsubjectlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<PeriodPlannerData> Get_subjectassign_teacherlist(PeriodPlannerData obj)
        {
            List<PeriodPlannerData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Get_subjectassign_teacherlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TimeTableData> Get_classwise_sectionwsie_allocated_teacherlist(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.Get_classwise_sectionwsie_allocated_teacherlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<PeriodPlannerData> UpdateassignSubject(PeriodPlannerData obj)
        {
            List<PeriodPlannerData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.UpdateassignSubject(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TimeTableData> update_classwise_sectionwise_timetable_subjects(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                PeriodplannerDA objDA = new PeriodplannerDA();
                result = objDA.update_classwise_sectionwise_timetable_subjects(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
    }
}
