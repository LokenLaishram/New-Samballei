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
    public class ClassallocationDA
    {
        public int updateclassallocation(ClassallocationData obj)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = obj.XMLData;

                    arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                    arParms[1].Value = obj.TeacherID;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[2].Value = obj.EmployeeID;

                    arParms[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[3].Value = obj.CompanyID;

                    arParms[4] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[4].Value = obj.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Maxperiod", SqlDbType.Int);
                    arParms[5].Value = obj.Maxperiodallowed;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    arParms[7] = new SqlParameter("@CountClass", SqlDbType.Int);
                    arParms[7].Value = obj.CountClass;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_Classallocation", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[6].Value);
                    }
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
        public int updatesubjectallocation(SubjectAllocationData obj)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = obj.XMLData;

                    arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                    arParms[1].Value = obj.TeacherID;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[2].Value = obj.EmployeeID;

                    arParms[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[3].Value = obj.CompanyID;

                    arParms[4] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[4].Value = obj.AcademicSessionID;

                    arParms[5] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[5].Value = obj.ID;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_subject_allocation", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[6].Value);
                    }
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
        public int updateclasswiseperiod(ClasswisePeriodPlannerData obj)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = obj.XMLData;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[2].Value = obj.Status;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = obj.ClassID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = obj.SectionID;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = obj.AcademicSessionID;

                    arParms[6] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[6].Value = obj.GroupID;

                    arParms[7] = new SqlParameter("@Updatetype", SqlDbType.Int);
                    arParms[7].Value = obj.Updatetype;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_ClasswisePeriod", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[1].Value);
                    }
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
        public int Updatetimetablerules(TimetableruleData obj)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[25];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = obj.ID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@Startfrom", SqlDbType.VarChar);
                    arParms[2].Value = obj.Startfrom;

                    arParms[3] = new SqlParameter("@Startto", SqlDbType.VarChar);
                    arParms[3].Value = obj.Startto;

                    arParms[4] = new SqlParameter("@Noperiods", SqlDbType.Int);
                    arParms[4].Value = obj.Noperiods;

                    arParms[5] = new SqlParameter("@PeriodDuration", SqlDbType.VarChar);
                    arParms[5].Value = obj.PeriodDuration;

                    arParms[6] = new SqlParameter("@Norecess", SqlDbType.Int);
                    arParms[6].Value = obj.Norecess;

                    arParms[7] = new SqlParameter("@RecessDuration", SqlDbType.VarChar);
                    arParms[7].Value = obj.RecessDuration;

                    arParms[8] = new SqlParameter("@RecessPeriod", SqlDbType.VarChar);
                    arParms[8].Value = obj.Recessperiod;

                    arParms[9] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[9].Value = obj.AcademicSessionID;

                    arParms[10] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[10].Value = obj.CompanyID;

                    arParms[11] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[11].Value = obj.IsActive;

                    arParms[12] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[12].Value = obj.EmployeeID;

                    arParms[13] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[13].Direction = ParameterDirection.Output;

                    arParms[14] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[14].Value = obj.GroupID;

                    arParms[15] = new SqlParameter("@Actiontype", SqlDbType.Int);
                    arParms[15].Value = obj.ActionType;

                    arParms[16] = new SqlParameter("@Sunday", SqlDbType.Int);
                    arParms[16].Value = obj.Sunday;

                    arParms[17] = new SqlParameter("@Monday", SqlDbType.Int);
                    arParms[17].Value = obj.Monday;

                    arParms[18] = new SqlParameter("@Tuesday", SqlDbType.Int);
                    arParms[18].Value = obj.Tuesday;

                    arParms[19] = new SqlParameter("@Wednesday", SqlDbType.Int);
                    arParms[19].Value = obj.Wednesday;

                    arParms[20] = new SqlParameter("@Thursday", SqlDbType.Int);
                    arParms[20].Value = obj.Thursday;

                    arParms[21] = new SqlParameter("@Friday", SqlDbType.Int);
                    arParms[21].Value = obj.Friday;

                    arParms[22] = new SqlParameter("@Saturday", SqlDbType.Int);
                    arParms[22].Value = obj.Saturday;

                    arParms[23] = new SqlParameter("@TotalWeeklyperiod", SqlDbType.Int);
                    arParms[23].Value = obj.TotalWeeklyperiod;

                    arParms[24] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[24].Value = obj.XMLData;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Timetable_Update_Timetable_rules", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[13].Value);
                    }
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
        public List<ClassallocationData> Getallocatedteacherlist(ClassallocationData obj)
        {
            List<ClassallocationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                    arParms[1].Value = obj.TeacherID;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = obj.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = obj.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Getclassallocatedlist", arParms);
                    List<ClassallocationData> teacherlist = ORHelper<ClassallocationData>.FromDataReaderToList(sqlReader);
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
        public List<TimetableruleData> GettimetableClasslist(TimetableruleData obj)
        {
            List<TimetableruleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = obj.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = obj.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Gettimetableclasslist", arParms);
                    List<TimetableruleData> classlist = ORHelper<TimetableruleData>.FromDataReaderToList(sqlReader);
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
        public List<TimetableruleData> GetNosubjectbyclassID(int classID,int sessionID)
        {
            List<TimetableruleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = sessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = classID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_nosubject_byclassID", arParms);
                    List<TimetableruleData> classlist = ORHelper<TimetableruleData>.FromDataReaderToList(sqlReader);
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
        public List<TimetableruleData> GettimetablebyclassID(TimetableruleData obj)
        {
            List<TimetableruleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[2].Value = obj.GroupID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GettimetablerulebyClassID", arParms);
                    List<TimetableruleData> classlist = ORHelper<TimetableruleData>.FromDataReaderToList(sqlReader);
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
        public List<TimetableslotData> GettimetableSlots(TimetableslotData obj)
        {
            List<TimetableslotData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.Session;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = obj.ClassID;

                    arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[2].Value = obj.GroupdID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GettimetableslotsbyClassID", arParms);
                    List<TimetableslotData> classlist = ORHelper<TimetableslotData>.FromDataReaderToList(sqlReader);
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
        public List<SubjectAllocationData> GetAssignsubjectlist(SubjectAllocationData obj)
        {
            List<SubjectAllocationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = obj.AcademicSessionID;

                    arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                    arParms[1].Value = obj.TeacherID;

                    arParms[2] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[2].Value = obj.ID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_allocated_subject_list", arParms);
                    List<SubjectAllocationData> subjectlist = ORHelper<SubjectAllocationData>.FromDataReaderToList(sqlReader);
                    result = subjectlist;
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
        public List<ClassallocationData> GetallocatedlistbyID(ClassallocationData obj)
        {
            List<ClassallocationData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = obj.ID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = obj.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_allocatedList", arParms);
                    List<ClassallocationData> classlist = ORHelper<ClassallocationData>.FromDataReaderToList(sqlReader);
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
        public int DeleteteacherbyID(ClassallocationData obj)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = obj.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_delete_allocatedclassbyID", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[1].Value);
                    }
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
