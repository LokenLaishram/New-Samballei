using Mobimp.Campusoft.Data.EduExam;
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

namespace Mobimp.Campusoft.DataAccess.EduExam
{
    public class ExamDivisionRuleDA
    {
        //For Div
        public int AddNewRowRecord(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objdata.ID;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.BigInt);
                    arParms[4].Value = objdata.EmployeeID;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_AddNewResultDivisionRuleRow", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
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
        public int AddNewRowRecordForRemark(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objdata.ID;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.BigInt);
                    arParms[4].Value = objdata.EmployeeID;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_AddNewResultRemarkRuleRow", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
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
        public int AddNewRowRecordForGrade(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objdata.ID;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.BigInt);
                    arParms[4].Value = objdata.EmployeeID;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_AddNewResultGradeRuleRow", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
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
        public int AddNewRowRecordForFailPass(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objdata.ID;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.BigInt);
                    arParms[4].Value = objdata.EmployeeID;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objdata.IsActive;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_AddNewResultFailPassRuleRow", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
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
        public List<ExamDivisionRuleData> GetExamDivisionRuleList(ExamDivisionRuleData objdata)
        {
            List<ExamDivisionRuleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];


                    arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[0].Value = objdata.SessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objdata.ClassID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objdata.ExamID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objdata.IsActive;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_GetResultDivisionRuleList", arParms);
                    List<ExamDivisionRuleData> lstSubjectGrade = ORHelper<ExamDivisionRuleData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectGrade;
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
        public List<ExamDivisionRuleData> GetExamFailPassRuleList(ExamDivisionRuleData objdata)
        {
            List<ExamDivisionRuleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];


                    arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[0].Value = objdata.SessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objdata.ClassID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objdata.ExamID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objdata.IsActive;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_GetResultFailPassRuleList", arParms);
                    List<ExamDivisionRuleData> lstSubjectGrade = ORHelper<ExamDivisionRuleData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectGrade;
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
        public List<ExamDivisionRuleData> GetExamRemarkRuleList(ExamDivisionRuleData objdata)
        {
            List<ExamDivisionRuleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];


                    arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[0].Value = objdata.SessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objdata.ClassID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objdata.ExamID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objdata.IsActive;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_GetResultRemarkRuleList", arParms);
                    List<ExamDivisionRuleData> lstSubjectGrade = ORHelper<ExamDivisionRuleData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectGrade;
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
        public List<ExamDivisionRuleData> GetExamGradeRuleList(ExamDivisionRuleData objdata)
        {
            List<ExamDivisionRuleData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];


                    arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[0].Value = objdata.SessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objdata.ClassID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objdata.ExamID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objdata.IsActive;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Util_GetResultGradeRuleList", arParms);
                    List<ExamDivisionRuleData> lstSubjectGrade = ORHelper<ExamDivisionRuleData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectGrade;
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
        public int UpdateExamDivisionRule(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.xmlDivisionRulelist;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@IsCommon", SqlDbType.Int);
                    arParms[4].Value = objdata.IsCommon;
                   

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateExamDivisionRuleMst", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
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
        public int UpdateExamRule(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.xmlExamRulelist;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;                    

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateExamRuleMst", arParms);
                    if (result_ > 0 || result_ == -1)
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

        public int UpdateExamFailPassRule(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.xmlFailPassRulelist;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@IsCommon", SqlDbType.Int);
                    arParms[4].Value = objdata.IsCommon;


                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateExamFailPassRuleMst", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
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
        public int UpdateExamRemarkRule(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.xmlRemarkRulelist;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@IsCommon", SqlDbType.Int);
                    arParms[4].Value = objdata.IsCommon;


                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateExamRemarkRuleMst", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
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
        public int UpdateExamGradeRule(ExamDivisionRuleData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.xmlGradeRulelist;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.SessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objdata.ClassID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objdata.ExamID;

                    arParms[4] = new SqlParameter("@IsMarkOrPC", SqlDbType.Int);
                    arParms[4].Value = objdata.IsMarkOrPC;


                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateExamGradeRuleMst", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
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
        public int DeleteExamDivisionRuleByID(ExamDivisionRuleData objDate)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objDate.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteSubjectGradeByID", arParms);
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
