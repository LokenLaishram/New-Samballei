using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class ExamTimeTableDA
    {
        public int UpdateExamscheduler(ExamSchedulerData objexamscheduler)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[15];

                    arParms[0] = new SqlParameter("@ScheduleID", SqlDbType.Int);
                    arParms[0].Value = objexamscheduler.ScheduleID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamscheduler.ClassID;

                    arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[2].Value = objexamscheduler.SubjectID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objexamscheduler.ExamID;

                    arParms[4] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                    arParms[4].Value = objexamscheduler.StartDate;

                    arParms[5] = new SqlParameter("@Starttime", SqlDbType.VarChar);
                    arParms[5].Value = objexamscheduler.Starttime;

                    arParms[6] = new SqlParameter("@Endtime", SqlDbType.VarChar);
                    arParms[6].Value = objexamscheduler.Endtime;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = objexamscheduler.AddedBy;

                    arParms[8] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[8].Value = objexamscheduler.CompanyID;

                    arParms[9] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[9].Value = objexamscheduler.ActionType;

                    arParms[10] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[10].Value = objexamscheduler.AcademicSessionID;

                    arParms[11] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[11].Direction = ParameterDirection.Output;

                    arParms[12] = new SqlParameter("@StartimeAffix", SqlDbType.Int);
                    arParms[12].Value = objexamscheduler.StartimeAffix;

                    arParms[13] = new SqlParameter("@EndtimeAffix", SqlDbType.Int);
                    arParms[13].Value = objexamscheduler.EndtimeAffix;

                    arParms[14] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[14].Value = objexamscheduler.CategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateExamscheduler", arParms);
                    if (result_ > 0 || result_ == -1)
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
        public List<ExamSchedulerData> SearchExamscheduler(ExamSchedulerData objexamscheduler)
        {
            List<ExamSchedulerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamscheduler.ClassID;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = objexamscheduler.SubjectID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objexamscheduler.ExamID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamscheduler.AcademicSessionID;

                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[4].Value = objexamscheduler.IsActive;

                    arParms[5] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    arParms[5].Value = objexamscheduler.CategoryID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SearchExamschedule", arParms);
                    List<ExamSchedulerData> lstExamscheduler = ORHelper<ExamSchedulerData>.FromDataReaderToList(sqlReader);
                    result = lstExamscheduler;
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
        public List<ExamSchedulerData> GetExamschedulerByID(ExamSchedulerData objexamscheduler)
        {
            List<ExamSchedulerData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ScheduleID", SqlDbType.Int);
                    arParms[0].Value = objexamscheduler.ScheduleID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_EditExamScheduler", arParms);
                    List<ExamSchedulerData> lstExamscheduler = ORHelper<ExamSchedulerData>.FromDataReaderToList(sqlReader);
                    result = lstExamscheduler;
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
        public int DeleteExamschedulerByID(ExamSchedulerData objexamscheduler)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ScheduleID", SqlDbType.Int);
                    arParms[0].Value = objexamscheduler.ScheduleID;
                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteExamSchedule", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
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
