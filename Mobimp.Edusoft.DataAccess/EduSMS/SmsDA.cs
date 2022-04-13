using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduSMS;
using System.Data.SqlClient;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using System.Data;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.DataAccess.EduSMS
{
    public class SmsDA
    {
        public List<SmsData> SearchSmsTemplateDetails(SmsData objSms)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@Template", SqlDbType.VarChar);
                    arParms[0].Value = objSms.Template;

                    arParms[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[1].Value = objSms.Descriptions;

                    arParms[2] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[2].Value = objSms.PageSize;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objSms.CurrentIndex;

                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[4].Value = objSms.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SMS_SearchTemplates", arParms);
                    List<SmsData> lstSmsTemplateDetails = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = lstSmsTemplateDetails;
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
        public int UpdateSMSTemplateDetails(SmsData objsms)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@TemplateID", SqlDbType.Int);
                    arParms[0].Value = objsms.TemplateID;

                    arParms[1] = new SqlParameter("@Template", SqlDbType.VarChar);
                    arParms[1].Value = objsms.Template;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = objsms.Descriptions;

                    arParms[3] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[3].Value = objsms.UserId;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objsms.CompanyID;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objsms.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SMS_Add_Templates", arParms);
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
        public List<SmsData> GetSMSTemplateDetailsByID(SmsData objSms)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@TemplateID", SqlDbType.Int);
                    arParms[0].Value = objSms.TemplateID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SMS_Get_TemplateByID", arParms);
                    List<SmsData> lstSmsTemplateDetails = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = lstSmsTemplateDetails;
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
        public int DeleteSMSTemplateDetailsByID(SmsData objSms)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@TemplateID", SqlDbType.Int);
                    arParms[0].Value = objSms.TemplateID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SMS_Delete_TemplateByID", arParms);
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
        public int UpdateSentSMS(SmsData objsms)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[16];

                    arParms[0] = new SqlParameter("@XmlSMSData", SqlDbType.NVarChar);
                    arParms[0].Value = objsms.XmlSendSMS;

                    arParms[1] = new SqlParameter("@TemplateID", SqlDbType.Int);
                    arParms[1].Value = objsms.TemplateID;

                    arParms[2] = new SqlParameter("@Template", SqlDbType.NVarChar);
                    arParms[2].Value = objsms.Template;

                    arParms[3] = new SqlParameter("@Descriptions", SqlDbType.NVarChar);
                    arParms[3].Value = objsms.Descriptions;

                    arParms[4] = new SqlParameter("@SendTo", SqlDbType.Int);
                    arParms[4].Value = objsms.SendTo;

                    arParms[5] = new SqlParameter("@SmsTypeID", SqlDbType.Int);
                    arParms[5].Value = objsms.SmsTypeID;

                    arParms[6] = new SqlParameter("@RecipientCount", SqlDbType.Int);
                    arParms[6].Value = objsms.RecipientCount;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@UserID", SqlDbType.Int);
                    arParms[8].Value = objsms.UserId;

                    arParms[9] = new SqlParameter("@SentBy", SqlDbType.VarChar);
                    arParms[9].Value = objsms.SentBy;

                    arParms[10] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[10].Value = objsms.CompanyID;

                    arParms[11] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[11].Value = objsms.AcademicSessionID;

                    arParms[12] = new SqlParameter("@TotalSmsCost", SqlDbType.Int);
                    arParms[12].Value = objsms.TotalSmsCost;

                    arParms[13] = new SqlParameter("@HeaderStatus", SqlDbType.VarChar);
                    arParms[13].Value = objsms.HeaderStatus;

                    arParms[14] = new SqlParameter("@HeaderStatusID", SqlDbType.Int);
                    arParms[14].Value = objsms.HeaderStatusID;

                    arParms[15] = new SqlParameter("@SmsBalance", SqlDbType.BigInt);
                    arParms[15].Value = objsms.BalanceAfter;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_EduSMS_UpdateDeliveredSMS", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[7].Value);
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
        //
        public List<SmsData> GetSmsSuggestedParameter()
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_EduSMS_GetSmsSuggestedParameter");
                    List<SmsData> smsresult = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = smsresult;
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
        public List<SmsData> Getmobilenumers(SmsData objsms)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objsms.StudentID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objsms.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objsms.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objsms.RollNo;

                    arParms[4] = new SqlParameter("@SendTo", SqlDbType.Int);
                    arParms[4].Value = objsms.SendTo;

                    arParms[5] = new SqlParameter("@EmployeeID", SqlDbType.BigInt);
                    arParms[5].Value = objsms.EmployeeID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objsms.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objsms.CurrentIndex;

                    arParms[8] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[8].Value = objsms.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SMS_GetMobilenumberList", arParms);
                    List<SmsData> smsreult = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = smsreult;
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
        public List<SmsData> SMSBindGridExamMarDA(SmsData objsms)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objsms.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objsms.SectionID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objsms.ExamID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objsms.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SMS_ExamData", arParms);
                    List<SmsData> smsreult = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = smsreult;
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
        public List<SmsData> SMSBindGridSubTypeDA(SmsData objsms)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objsms.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objsms.SectionID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objsms.ExamID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objsms.AcademicSessionID;

                    arParms[4] = new SqlParameter("@SubjectName", SqlDbType.VarChar);
                    arParms[4].Value = objsms.SubjectName;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SMS_ExamDataSubType", arParms);
                    List<SmsData> smsreult = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = smsreult;
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

        //SMS History
        public List<SmsData> GetSmsID(SmsData objSmsData)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@SmsID", SqlDbType.BigInt);
                    arParms[0].Value = objSmsData.SmsID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_EduSMS_AutocompleteSmsID", arParms);
                    List<SmsData> lstSmsDataResult = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = lstSmsDataResult;
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
        public List<SmsData> SearchSmsHistoryList(SmsData objsms)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objsms.AcademicSessionID;

                    arParms[1] = new SqlParameter("@SendToID", SqlDbType.Int);
                    arParms[1].Value = objsms.SendTo;

                    arParms[2] = new SqlParameter("@SmsTypeID", SqlDbType.Int);
                    arParms[2].Value = objsms.SmsTypeID;

                    arParms[3] = new SqlParameter("@StatusID", SqlDbType.Int);
                    arParms[3].Value = objsms.StatusID;

                    arParms[4] = new SqlParameter("@SmsID", SqlDbType.BigInt);
                    arParms[4].Value = objsms.SmsID;

                    arParms[5] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
                    arParms[5].Value = objsms.DateFrom;

                    arParms[6] = new SqlParameter("@DateTo", SqlDbType.DateTime);
                    arParms[6].Value = objsms.DateTo;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objsms.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objsms.CurrentIndex;

                    arParms[9] = new SqlParameter("@UserLoginID", SqlDbType.Int);
                    arParms[9].Value = objsms.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_EduSMS_SearchSmsHistoryList", arParms);
                    List<SmsData> smsreult = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = smsreult;
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
        public List<SmsData> SearchChildDetailBySmsID(SmsData objitemData)
        {
            List<SmsData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objitemData.AcademicSessionID;

                    arParms[1] = new SqlParameter("@SmsID", SqlDbType.BigInt);
                    arParms[1].Value = objitemData.SmsID;

                    arParms[2] = new SqlParameter("@SendToID", SqlDbType.Int);
                    arParms[2].Value = objitemData.SendTo;

                    arParms[3] = new SqlParameter("@SmsTypeID", SqlDbType.Int);
                    arParms[3].Value = objitemData.SmsTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_EduSMS_GetChildGridDataSmsHistory", arParms);
                    List<SmsData> lstChildDetails = ORHelper<SmsData>.FromDataReaderToList(sqlReader);
                    result = lstChildDetails;
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
