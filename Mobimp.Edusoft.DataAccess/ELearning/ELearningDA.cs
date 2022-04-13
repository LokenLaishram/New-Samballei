using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.ELearning;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.ELearning
{
    public class ELearningDA
    {
        public int UpdateSubjectTeacherMapping(ELearningData objLearn)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[17];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                arParms[1] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[1].Value = objLearn.DayID;

                arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[2].Value = objLearn.ClassID;

                arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[3].Value = objLearn.SectionID;

                arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[4].Value = objLearn.SubjectID;

                arParms[5] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[5].Value = objLearn.TeacherID;

                arParms[6] = new SqlParameter("@VideoLink", SqlDbType.NVarChar);
                arParms[6].Value = objLearn.VideoLink;

                arParms[7] = new SqlParameter("@StartTime", SqlDbType.VarChar);
                arParms[7].Value = objLearn.TeacherStartTime;

                arParms[8] = new SqlParameter("@EndTime", SqlDbType.VarChar);
                arParms[8].Value = objLearn.TeacherEndTime;

                arParms[9] = new SqlParameter("@UserID", SqlDbType.Int);
                arParms[9].Value = objLearn.UserId;

                arParms[10] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                arParms[10].Value = objLearn.AddedBy;

                arParms[11] = new SqlParameter("@CompanyID", SqlDbType.Int);
                arParms[11].Value = objLearn.CompanyID;

                arParms[12] = new SqlParameter("@IsActive", SqlDbType.Bit);
                arParms[12].Value = objLearn.IsActive;

                arParms[13] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[13].Direction = ParameterDirection.Output;

                arParms[14] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[14].Value = objLearn.AcademicSessionID;

                arParms[15] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[15].Value = objLearn.ActionType;

                arParms[16] = new SqlParameter("@OldTeacherID", SqlDbType.BigInt);
                arParms[16].Value = objLearn.OldTeacherID;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_UpdateSubjectTeacherMapping", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[13].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchSubjectTeacherMapping(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[12];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = objLearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[1].Value = objLearn.DayID;

                arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[2].Value = objLearn.ClassID;

                arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[3].Value = objLearn.SectionID;

                arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[4].Value = objLearn.SubjectID;

                arParms[5] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[5].Value = objLearn.TeacherID;

                arParms[6] = new SqlParameter("@VideoLink", SqlDbType.NVarChar);
                arParms[6].Value = objLearn.VideoLink;

                arParms[7] = new SqlParameter("@StartTime", SqlDbType.VarChar);
                arParms[7].Value = objLearn.TeacherStartTime;

                arParms[8] = new SqlParameter("@EndTime", SqlDbType.VarChar);
                arParms[8].Value = objLearn.TeacherEndTime;

                arParms[9] = new SqlParameter("@PageSize", SqlDbType.Int);
                arParms[9].Value = objLearn.PageSize;

                arParms[10] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                arParms[10].Value = objLearn.CurrentIndex;

                arParms[11] = new SqlParameter("@IsActive", SqlDbType.Bit);
                arParms[11].Value = objLearn.IsActive;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchSubjectTeacherMapping", arParms);
                List<ELearningData> lstClassDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstClassDetails;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetSubjectTeacherMappingByID(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_GetSubjectTeacherMappingByID", arParms);
                List<ELearningData> lstClassDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstClassDetails;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int DeleteSubjectTeacherMappingByID(ELearningData objLearn)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[1].Direction = ParameterDirection.Output;

                arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[2].Value = objLearn.ActionType;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_DeleteSubjectTeacherMappingByID", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[1].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchDailyTeacherLiveClassList(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[9];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = objLearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[1].Value = objLearn.DayID;

                arParms[2] = new SqlParameter("@ClassDate", SqlDbType.DateTime);
                arParms[2].Value = objLearn.ClassDate;

                arParms[3] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[3].Value = objLearn.TeacherID;

                arParms[4] = new SqlParameter("@ActionType", SqlDbType.Int);
                arParms[4].Value = objLearn.ActionType;

                arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                arParms[5].Value = objLearn.PageSize;

                arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                arParms[6].Value = objLearn.CurrentIndex;

                arParms[7] = new SqlParameter("@UserLoginID", SqlDbType.BigInt);
                arParms[7].Value = objLearn.UserId;

                arParms[8] = new SqlParameter("@TeacherName", SqlDbType.VarChar);
                arParms[8].Value = objLearn.TeacherName;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchDailyTeacherLiveClassList", arParms);
                List<ELearningData> lstClassDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstClassDetails;

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int StartDailyTeacherLiveClass(ELearningData objLearn)
        {
            int result = 0;
            try
            {

                SqlParameter[] arParms = new SqlParameter[15];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = objLearn.AcademicSessionID;

                arParms[2] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[2].Value = objLearn.DayID;

                arParms[3] = new SqlParameter("@LiveClassID", SqlDbType.BigInt);
                arParms[3].Value = objLearn.LiveClassID;

                arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[4].Value = objLearn.ClassID;

                arParms[5] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[5].Value = objLearn.SectionID;

                arParms[6] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[6].Value = objLearn.SubjectID;

                arParms[7] = new SqlParameter("@TotalStudent", SqlDbType.Int);
                arParms[7].Value = objLearn.TotalStudent;

                arParms[8] = new SqlParameter("@TotalAttended", SqlDbType.Int);
                arParms[8].Value = objLearn.TotalAttended;

                arParms[9] = new SqlParameter("@VideoLink", SqlDbType.NVarChar);
                arParms[9].Value = objLearn.VideoLink;

                arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[10].Value = ParameterDirection.Output;

                arParms[11] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[11].Value = objLearn.TeacherID;

                arParms[12] = new SqlParameter("@UserLoginID", SqlDbType.BigInt);
                arParms[12].Value = objLearn.UserId;

                arParms[13] = new SqlParameter("@ClassDate", SqlDbType.DateTime);
                arParms[13].Value = objLearn.ClassDate;

                arParms[14] = new SqlParameter("@TeacherName", SqlDbType.VarChar);
                arParms[14].Value = objLearn.TeacherName;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_StartDailyTeacherLiveClass", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[10].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int EndDailyTeacherLiveClass(ELearningData objLearn)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = objLearn.AcademicSessionID;

                arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[2].Value = ParameterDirection.Output;

                arParms[3] = new SqlParameter("@TeacherName", SqlDbType.VarChar);
                arParms[3].Value = objLearn.TeacherName;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_EndDailyTeacherLiveClass", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[2].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchTeacherNamebyUserLoginID(Int64 ID)
        {
            List<ELearningData> Result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@UserLoginID", SqlDbType.BigInt);
                arParms[0].Value = ID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTeacherNamebyUserLoginID", arParms);
                List<ELearningData> lstEmpDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                Result = lstEmpDetails;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return Result;
        }
        public List<ELearningData> GetTotalStudents(ELearningData ObjELearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = ObjELearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[1].Value = ObjELearn.ClassID;

                arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[2].Value = ObjELearn.SectionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchTotalStudents", arParms);
                List<ELearningData> lstELearn = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstELearn;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetTotalStudentsAttended(ELearningData ObjELearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[6];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = ObjELearn.ID;

                arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[1].Value = ObjELearn.TeacherID;

                arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[2].Value = ObjELearn.SubjectID;

                arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[3].Value = ObjELearn.AcademicSessionID;

                arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[4].Value = ObjELearn.ClassID;

                arParms[5] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[5].Value = ObjELearn.SectionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchTotalStudentsAttended", arParms);
                List<ELearningData> lstELearn = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstELearn;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchStudentDetailsbyUserLoginID(Int64 ID, int AcademicSessionID)
        {
            List<ELearningData> Result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@UserLoginID", SqlDbType.BigInt);
                arParms[0].Value = ID;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = AcademicSessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetStudentDetailsByUserLoginID", arParms);
                List<ELearningData> lstEmpDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                Result = lstEmpDetails;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return Result;
        }
        public List<ELearningData> SearchDailyStudentLiveClassList(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[10];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = objLearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[1].Value = objLearn.DayID;

                arParms[2] = new SqlParameter("@ClassDate", SqlDbType.DateTime);
                arParms[2].Value = objLearn.ClassDate;

                arParms[3] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                arParms[3].Value = objLearn.StudentID;

                arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[4].Value = objLearn.ClassID;

                arParms[5] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[5].Value = objLearn.SectionID;

                arParms[6] = new SqlParameter("@RollNo", SqlDbType.Int);
                arParms[6].Value = objLearn.RollNo;

                arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                arParms[7].Value = objLearn.PageSize;

                arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                arParms[8].Value = objLearn.CurrentIndex;

                arParms[9] = new SqlParameter("@UserLoginID", SqlDbType.BigInt);
                arParms[9].Value = objLearn.UserId;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchDailyStudentLiveClassList", arParms);
                List<ELearningData> lstClassDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstClassDetails;

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }

        public int JoinDailyStudentLiveClass(ELearningData objLearn)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[8];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = objLearn.AcademicSessionID;

                arParms[2] = new SqlParameter("@LiveClassID", SqlDbType.BigInt);
                arParms[2].Value = objLearn.LiveClassID;

                arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[3].Value = ParameterDirection.Output;

                arParms[4] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                arParms[4].Value = objLearn.StudentID;

                arParms[5] = new SqlParameter("@StudentJoiningTime", SqlDbType.DateTime);
                arParms[5].Value = objLearn.StudentJoiningTime;

                arParms[6] = new SqlParameter("@StudentLogoutTime", SqlDbType.DateTime);
                arParms[6].Value = objLearn.StudentLogoutTime;

                arParms[7] = new SqlParameter("@TeacherLiveClassID", SqlDbType.BigInt);
                arParms[7].Value = objLearn.TeacherClassID;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_JoinDailyStudentLiveClass", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[3].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateStudentAttendance(ELearningData objstd)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[5];

                arParms[0] = new SqlParameter("@XmlStudentAttendanceList", SqlDbType.Xml);
                arParms[0].Value = objstd.XmlStudentAttendanceList;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = objstd.AcademicSessionID;

                arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                arParms[2].Value = objstd.AddedBy;

                arParms[3] = new SqlParameter("@UserId", SqlDbType.BigInt);
                arParms[3].Value = objstd.UserId;

                arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[4].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_UpdateStudentAttendance", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[4].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetClassLinkByID(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_GetClassLinkByID", arParms);
                List<ELearningData> lstClassDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstClassDetails;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateTeachersClassVideoLink(ELearningData objLearn)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[0].Value = objLearn.ID;

                arParms[1] = new SqlParameter("@VideoLink", SqlDbType.NVarChar);
                arParms[1].Value = objLearn.VideoLink;

                arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                arParms[2].Value = objLearn.AddedBy;

                arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[3].Direction = ParameterDirection.Output;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_UpdateTeachersClassVideoLink", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[3].Value);

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }

        //Assignment
        public List<ELearningData> SearchTotalAssignmentsForRespectiveTeacher(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = objLearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[1].Value = objLearn.TeacherID;

                arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                arParms[2].Value = objLearn.PageSize;

                arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                arParms[3].Value = objLearn.CurrentIndex;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchTotalAssignmentsByTeacherID", arParms);
                List<ELearningData> lstClassDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstClassDetails;

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int AddAssignment(ELearningData objLearn)
        {
            int result = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[11];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = objLearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[1].Value = objLearn.TeacherID;

                arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[2].Value = objLearn.ClassID;

                arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[3].Value = objLearn.SectionID;

                arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[4].Value = objLearn.SubjectID;

                arParms[5] = new SqlParameter("@Title", SqlDbType.VarChar);
                arParms[5].Value = objLearn.Title;

                arParms[6] = new SqlParameter("@AssignmentFile", SqlDbType.Image);
                arParms[6].Value = objLearn.AssignmentFile;

                arParms[7] = new SqlParameter("@LastDate", SqlDbType.DateTime);
                arParms[7].Value = objLearn.LastDate;

                arParms[8] = new SqlParameter("@Remark", SqlDbType.VarChar);
                arParms[8].Value = objLearn.Remark;

                arParms[9] = new SqlParameter("@Output", SqlDbType.SmallInt);
                arParms[9].Direction = ParameterDirection.Output;

                arParms[10] = new SqlParameter("@ID", SqlDbType.BigInt);
                arParms[10].Value = objLearn.ID;

                int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_AddAssignment", arParms);
                if (result_ > 0 || result_ == -1)
                    result = Convert.ToInt32(arParms[9].Value);
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchAssignmentList(ELearningData ObjELearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[10];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = ObjELearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[1].Value = ObjELearn.ClassID;

                arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[2].Value = ObjELearn.SectionID;

                arParms[3] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[3].Value = ObjELearn.SubjectID;

                arParms[4] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[4].Value = ObjELearn.TeacherID;

                arParms[5] = new SqlParameter("@Title", SqlDbType.VarChar);
                arParms[5].Value = ObjELearn.Title;

                arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                arParms[6].Value = ObjELearn.PageSize;

                arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                arParms[7].Value = ObjELearn.CurrentIndex;

                arParms[8] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                arParms[8].Value = ObjELearn.Datefrom;

                arParms[9] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                arParms[9].Value = ObjELearn.Dateto;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchAssignmentList", arParms);
                List<ELearningData> lstELearn = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstELearn;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> GetStudentListByAssignmentID(ELearningData ObjELearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@AssignmentID", SqlDbType.BigInt);
                arParms[0].Value = ObjELearn.ID;

                arParms[1] = new SqlParameter("@AssignmentStatus", SqlDbType.Int);
                arParms[1].Value = ObjELearn.Status;

                arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[2].Value = ObjELearn.AcademicSessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_GetStudentListByAssignmentStatus", arParms);
                List<ELearningData> lstELearn = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstELearn;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ELearningData> SearchAssignmentListByStudentID(ELearningData objLearn)
        {
            List<ELearningData> result = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[9];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = objLearn.AcademicSessionID;

                arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                arParms[1].Value = objLearn.StudentID;

                arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[2].Value = objLearn.ClassID;

                arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[3].Value = objLearn.SectionID;

                arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                arParms[4].Value = objLearn.RollNo;

                arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                arParms[5].Value = objLearn.PageSize;

                arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                arParms[6].Value = objLearn.CurrentIndex;

                arParms[7] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[7].Value = objLearn.SubjectID;

                arParms[8] = new SqlParameter("@StatusID", SqlDbType.Int);
                arParms[8].Value = objLearn.Status;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_ELearning_SearchAssignmentListByStudentID", arParms);
                List<ELearningData> lstAsgmtDetails = ORHelper<ELearningData>.FromDataReaderToList(sqlReader);
                result = lstAsgmtDetails;

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
