using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.DataAccess.TimeTable
{
    public class PeriodplannerDA
    {
        public List<PeriodPlannerData> Getclasswisesubjectlist(PeriodPlannerData obj)
        {
            List<PeriodPlannerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = obj.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = obj.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Class_Section_subject_Listwith_allocated_teacher", arParms);
                    List<PeriodPlannerData> teacherlist = ORHelper<PeriodPlannerData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ClasswisePeriodPlannerData> Getclasswiseperiodplannerlist(ClasswisePeriodPlannerData obj)
        {
            List<ClasswisePeriodPlannerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = obj.SubjectID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[4].Value = obj.EmployeeID;

                    arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[5].Value = obj.TeacherID;

                    arParms[6] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[6].Value = obj.GroupID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table_Class_sectionwise_period_Planner_List", arParms);
                    List<ClasswisePeriodPlannerData> teacherlist = ORHelper<ClasswisePeriodPlannerData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ClasswisePeriodPlannerData> Getsubjectwiseplannerlist(ClasswisePeriodPlannerData obj)
        {
            List<ClasswisePeriodPlannerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = obj.SubjectID;

                    arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[2].Value = obj.GroupID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table_subjectwise_period_Planner_List", arParms);
                    List<ClasswisePeriodPlannerData> teacherlist = ORHelper<ClasswisePeriodPlannerData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ClasswiseResourcePlannerData> Getsubjectwiseresourceplanning(ClasswiseResourcePlannerData obj)
        {
            List<ClasswiseResourcePlannerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[1].Value = obj.GroupID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[3].Value = obj.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table_subject_wise_resource_planning", arParms);
                    List<ClasswiseResourcePlannerData> planninglist = ORHelper<ClasswiseResourcePlannerData>.FromDataReaderToList(sqlReader);
                    result = planninglist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetTeacherPeriodlist(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[1].Value = obj.GroupID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[3].Value = obj.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table_TeacherWiseSubject_PeriodDistribution", arParms);
                    List<TeacherWisePeriod> planninglist = ORHelper<TeacherWisePeriod>.FromDataReaderToList(sqlReader);
                    result = planninglist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetSubjectwiseteacherlsit(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[1].Value = obj.GroupID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[3].Value = obj.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_GET_subjectwise_teachers", arParms);
                    List<TeacherWisePeriod> planninglist = ORHelper<TeacherWisePeriod>.FromDataReaderToList(sqlReader);
                    result = planninglist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetSubjectwiseactiveteachers(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[1].Value = obj.GroupID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[3].Value = obj.IsActive;

                    arParms[4] = new SqlParameter("@DayID", SqlDbType.Int);
                    arParms[4].Value = obj.DayID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_GET_subjectwise_Active_teachers", arParms);
                    List<TeacherWisePeriod> planninglist = ORHelper<TeacherWisePeriod>.FromDataReaderToList(sqlReader);
                    result = planninglist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetSubjectwiseDayteacherlsit(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[1].Value = obj.GroupID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[3].Value = obj.IsActive;

                    arParms[4] = new SqlParameter("@DayID", SqlDbType.Int);
                    arParms[4].Value = obj.DayID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Get_Daywise_TeacherList", arParms);
                    List<TeacherWisePeriod> planninglist = ORHelper<TeacherWisePeriod>.FromDataReaderToList(sqlReader);
                    result = planninglist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> Getassignsubjectistt(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[1].Value = obj.GroupID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@DayID", SqlDbType.Int);
                    arParms[3].Value = obj.DayID;

                    arParms[4] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[4].Value = obj.TeacherID;

                    arParms[5] = new SqlParameter("@FilterType", SqlDbType.Int);
                    arParms[5].Value = obj.FilterType;

                    arParms[6] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[6].Value = obj.CategoryID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Get_Daywise_Period_Arrangerlist", arParms);
                    List<TeacherWisePeriod> planninglist = ORHelper<TeacherWisePeriod>.FromDataReaderToList(sqlReader);
                    result = planninglist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TeacherWisePeriod> GetTeacher_subjectwise_periodanalysis(TeacherWisePeriod obj)
        {
            List<TeacherWisePeriod> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[1].Value = obj.GroupID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = obj.SubjectID;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = obj.ClassID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = obj.SectionID;

                    arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[5].Value = obj.TeacherID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Time_Table_Analyse_Teachers_subjectwise_period", arParms);
                    List<TeacherWisePeriod> planninglist = ORHelper<TeacherWisePeriod>.FromDataReaderToList(sqlReader);
                    result = planninglist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int Updateperiod_distribution(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = obj.AcademicSessionID;

                arParms[1] = new SqlParameter("@XMLData", SqlDbType.Xml);
                arParms[1].Value = obj.XMLData;

                arParms[2] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[2].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_Subjectwise_Teacher_Period_Distribution", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[2].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int Addsubjectwiseteachers(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[5];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = obj.AcademicSessionID;

                arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[1].Value = obj.SubjectID;

                arParms[2] = new SqlParameter("@SubjectName", SqlDbType.VarChar);
                arParms[2].Value = obj.SubjectName;

                arParms[3] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[3].Value = obj.GroupID;

                arParms[4] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[4].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_add_subjectwise_teachers", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[4].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateassignSubjectlist(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[7];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = obj.AcademicSessionID;

                arParms[1] = new SqlParameter("@XMLData", SqlDbType.Xml);
                arParms[1].Value = obj.XMLData;

                arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[2].Value = obj.GroupID;

                arParms[3] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[3].Direction = ParameterDirection.Output;

                arParms[4] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[4].Value = obj.DayID;

                arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[5].Value = obj.TeacherID;

                arParms[6] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[6].Value = obj.SubjectID;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_teacherwise_assignsubjectlist", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[3].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateTeachererAssignClass(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[10];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = obj.AcademicSessionID;

                arParms[1] = new SqlParameter("@SubSubjectID", SqlDbType.Int);
                arParms[1].Value = obj.SubSubjectID;

                arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[2].Value = obj.GroupID;

                arParms[3] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[3].Direction = ParameterDirection.Output;

                arParms[4] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[4].Value = obj.DayID;

                arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[5].Value = obj.TeacherID;

                arParms[6] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[6].Value = obj.SubjectID;

                arParms[7] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[7].Value = obj.ClassID;

                arParms[8] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[8].Value = obj.SectionID;

                arParms[9] = new SqlParameter("@PeriodNo", SqlDbType.Int);
                arParms[9].Value = obj.PeriodNo;


                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_Teacher_class_allocation", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[3].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int GenerateTimetable(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[5];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = obj.AcademicSessionID;

                arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[1].Value = obj.GroupID;

                arParms[2] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[2].Direction = ParameterDirection.Output;

                arParms[3] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[3].Value = obj.DayID;

                arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[4].Value = obj.SubjectID;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Generate_teacherwise_timetable", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[2].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int Teacherautodistributeclasses(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[7];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = obj.AcademicSessionID;

                arParms[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[1].Value = obj.GroupID;

                arParms[2] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[2].Direction = ParameterDirection.Output;

                arParms[3] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[3].Value = obj.DayID;

                arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[4].Value = obj.SubjectID;

                arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[5].Value = obj.TeacherID;

                arParms[6] = new SqlParameter("@PeriodCount", SqlDbType.Int);
                arParms[6].Value = obj.PeriodCount;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_teacherwise_autodistribute_classes", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[2].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateteacherStatus(TeacherWisePeriod obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[6];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = obj.AcademicSessionID;

                arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[1].Value = obj.SubjectID;

                arParms[2] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[2].Value = obj.TeacherID;

                arParms[3] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[3].Value = obj.GroupID;

                arParms[4] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[4].Direction = ParameterDirection.Output;

                arParms[5] = new SqlParameter("@Status", SqlDbType.Bit);
                arParms[5].Value = obj.IsActive;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_TeacherStatus", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[4].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateAllotedsubjectTeacher(TimeTableData obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[12];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = obj.ID;

                arParms[1] = new SqlParameter("@AllocatedSubject", SqlDbType.Int);
                arParms[1].Value = obj.AllocatedSubject;

                arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[2].Value = obj.ClassID;

                arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[3].Value = obj.SectionID;

                arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[4].Value = obj.SubjectID;

                arParms[5] = new SqlParameter("@PeriodNo", SqlDbType.VarChar);
                arParms[5].Value = obj.PeriodNo;

                arParms[6] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[6].Value = obj.DayID;

                arParms[7] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[7].Value = obj.TeacherID;

                arParms[8] = new SqlParameter("@AllocatedTeacher", SqlDbType.Int);
                arParms[8].Value = obj.AllocatedTeacher;

                arParms[9] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[9].Value = obj.AcademicSessionID;

                arParms[10] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[10].Value = obj.GroupID;

                arParms[11] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[11].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Manage_Recources", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[11].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateDailyAllotedsubjectTeacher(TimeTableData obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[9];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = obj.ID;

                arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[1].Value = obj.ClassID;

                arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[2].Value = obj.SectionID;

                arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[3].Value = obj.SubjectID;

                arParms[4] = new SqlParameter("@PeriodNo", SqlDbType.VarChar);
                arParms[4].Value = obj.PeriodNo;

                arParms[5] = new SqlParameter("@Date", SqlDbType.DateTime);
                arParms[5].Value = obj.Date;

                arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[6].Value = obj.AcademicSessionID;

                arParms[7] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[7].Value = obj.GroupID;

                arParms[8] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[8].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Daily_Timetable_Manage_Recources", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[8].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateDailySubstituteTeacher(TimeTableData obj)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[10];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = obj.ID;

                arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[1].Value = obj.ClassID;

                arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[2].Value = obj.SectionID;

                arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[3].Value = obj.SubjectID;

                arParms[4] = new SqlParameter("@PeriodNo", SqlDbType.VarChar);
                arParms[4].Value = obj.PeriodNo;

                arParms[5] = new SqlParameter("@Date", SqlDbType.DateTime);
                arParms[5].Value = obj.Date;

                arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[6].Value = obj.AcademicSessionID;

                arParms[7] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[7].Value = obj.GroupID;

                arParms[8] = new SqlParameter("@Output", SqlDbType.Int);
                arParms[8].Direction = ParameterDirection.Output;

                arParms[9] = new SqlParameter("@SubsTeacherID", SqlDbType.Int);
                arParms[9].Value = obj.SubsTeacherID;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Daily_Timetable_Manage_Recources_Substitutions", arParms);
                if (result_ > 0 || result_ == -1)
                {
                    result = Convert.ToInt32(arParms[8].Value);
                }

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ClasswisePeriodPlannerData> Getclasswise_sectionwise_subjectlist(ClasswisePeriodPlannerData obj)
        {
            List<ClasswisePeriodPlannerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = obj.SubjectID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[4].Value = obj.EmployeeID;

                    arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[5].Value = obj.TeacherID;

                    arParms[6] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[6].Value = obj.Status;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table_Class_sectionwise_Subject_List", arParms);
                    List<ClasswisePeriodPlannerData> teacherlist = ORHelper<ClasswisePeriodPlannerData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TimeTableData> GetTimeTable(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = obj.SubjectID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[4].Value = obj.EmployeeID;

                    arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[5].Value = obj.TeacherID;

                    arParms[6] = new SqlParameter("@Periodid", SqlDbType.Int);
                    arParms[6].Value = obj.Periodid;

                    arParms[7] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[7].Value = obj.GroupID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table", arParms);
                    List<TimeTableData> teacherlist = ORHelper<TimeTableData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TimeTableData> GetDailyTimeTable(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = obj.SubjectID;

                    arParms[4] = new SqlParameter("@Date", SqlDbType.DateTime);
                    arParms[4].Value = obj.Date;

                    arParms[5] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[5].Value = obj.TeacherID;

                    arParms[6] = new SqlParameter("@Periodid", SqlDbType.Int);
                    arParms[6].Value = obj.Periodid;

                    arParms[7] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[7].Value = obj.GroupID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Daily_Time_Table", arParms);
                    List<TimeTableData> teacherlist = ORHelper<TimeTableData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TimeTableData> GetTeacherwiseClass(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[1].Value = obj.TeacherID;

                    arParms[2] = new SqlParameter("@DayID", SqlDbType.Int);
                    arParms[2].Value = obj.DayID;

                    arParms[3] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[3].Value = obj.GroupID;

                    arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[4].Value = obj.SubjectID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table_ManagedResources", arParms);
                    List<TimeTableData> classlist = ORHelper<TimeTableData>.FromDataReaderToList(sqlReader);
                    result = classlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TimeTableData> GetTeacherwiseassignsubjectlist(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@TeacherID", SqlDbType.Int);
                    arParms[1].Value = obj.TeacherID;

                    arParms[2] = new SqlParameter("@DayID", SqlDbType.Int);
                    arParms[2].Value = obj.DayID;

                    arParms[3] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[3].Value = obj.GroupID;



                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Time_Table_Teacherwise_assignsubjectlit", arParms);
                    List<TimeTableData> classlist = ORHelper<TimeTableData>.FromDataReaderToList(sqlReader);
                    result = classlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<PeriodPlannerData> Get_subjectassign_teacherlist(PeriodPlannerData obj)
        {
            List<PeriodPlannerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = obj.SubjectID;

                    arParms[4] = new SqlParameter("@DayID", SqlDbType.Int);
                    arParms[4].Value = obj.DayID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_sectionwise_subject_teacher_allocation", arParms);
                    List<PeriodPlannerData> teacherlist = ORHelper<PeriodPlannerData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TimeTableData> Get_classwise_sectionwsie_allocated_teacherlist(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@Periodid", SqlDbType.Int);
                    arParms[3].Value = obj.Periodid;

                    arParms[4] = new SqlParameter("@SlotID", SqlDbType.Int);
                    arParms[4].Value = obj.SlotID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Classwise_Subjectwise_allocated_Teacher", arParms);
                    List<TimeTableData> teacherlist = ORHelper<TimeTableData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<PeriodPlannerData> UpdateassignSubject(PeriodPlannerData obj)
        {
            List<PeriodPlannerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                    arParms[0].Value = obj.TeacherID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = obj.SubjectID;

                    arParms[4] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[4].Value = obj.AcademicSessionID;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = obj.CompanyID;

                    arParms[6] = new SqlParameter("@DayID", SqlDbType.Int);
                    arParms[6].Value = obj.DayID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_assign_subjects", arParms);
                    List<PeriodPlannerData> teacherlist = ORHelper<PeriodPlannerData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<TimeTableData> update_classwise_sectionwise_timetable_subjects(TimeTableData obj)
        {
            List<TimeTableData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                    arParms[0].Value = obj.TeacherID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = obj.SectionID;

                    arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[3].Value = obj.SubjectID;

                    arParms[4] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[4].Value = obj.AcademicSessionID;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = obj.CompanyID;

                    arParms[6] = new SqlParameter("@Periodid", SqlDbType.Int);
                    arParms[6].Value = obj.Periodid;

                    arParms[7] = new SqlParameter("@SlotID", SqlDbType.Int);
                    arParms[7].Value = obj.SlotID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_update_classwise_sectionwise_timetable_subjects", arParms);
                    List<TimeTableData> teacherlist = ORHelper<TimeTableData>.FromDataReaderToList(sqlReader);
                    result = teacherlist;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
    }
}
