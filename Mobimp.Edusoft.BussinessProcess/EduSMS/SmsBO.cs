using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduSMS;
using Mobimp.Edusoft.DataAccess.EduSMS;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.SMS
{
   public class SmsBO
   {
        public List<SmsData> SearchSmsTemplateDetails(SmsData objSms)
        {
            List<SmsData> result = null;
            try
            {
                SmsDA objSmsDA = new SmsDA();
                result = objSmsDA.SearchSmsTemplateDetails(objSms);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateSMSTemplateDetails(SmsData objSms)
        {
            int result = 0;
            try
            {
                SmsDA objSMSExamDataDA = new SmsDA();
                result = objSMSExamDataDA.UpdateSMSTemplateDetails(objSms);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SmsData> GetSMSTemplateDetailsByID(SmsData objSms)
        {
            List<SmsData> result = null;

            try
            {
                SmsDA objSmsDA = new SmsDA();
                result = objSmsDA.GetSMSTemplateDetailsByID(objSms);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSMSTemplateDetailsByID(SmsData objSms)
        {
            int result = 0;

            try
            {
                SmsDA objSmsDA = new SmsDA();
                result = objSmsDA.DeleteSMSTemplateDetailsByID(objSms);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        //
        public List<SmsData> Getmobilenumers(SmsData objSms)
        {
            List<SmsData> result = null;
            try
            {
                SmsDA objSmsDA = new SmsDA();
                result = objSmsDA.Getmobilenumers(objSms);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SmsData> SMSBindGridExamMarkBO(SmsData objsmsExam)
        {
            List<SmsData> result = null;
            try
            {
                SmsDA objSMSExamDataDA = new SmsDA();
                result = objSMSExamDataDA.SMSBindGridExamMarDA(objsmsExam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SmsData> SMSBindGridSubTypeBO(SmsData objsmsExam)
        {
            List<SmsData> result = null;
            try
            {
                SmsDA objSMSExamDataDA = new SmsDA();
                result = objSMSExamDataDA.SMSBindGridSubTypeDA(objsmsExam);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        //UpdateHeaderDeliveredSMS
        public int UpdateSentSMS(SmsData objSms)
        {
            int result = 0;
            try
            {
                SmsDA objSmsDA = new SmsDA();
                result = objSmsDA.UpdateSentSMS(objSms);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        //Get SMS History
        public List<SmsData> GetSmsID(SmsData objSmsData)
        {

            List<SmsData> result = null;

            try
            {
                SmsDA objSmsDA = new SmsDA();
                result = objSmsDA.GetSmsID(objSmsData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SmsData> SearchSmsHistoryList(SmsData objSms)
        {

            List<SmsData> result = null;

            try
            {
                SmsDA objSmsDA = new SmsDA();
                result = objSmsDA.SearchSmsHistoryList(objSms);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SmsData> SearchChildDetailBySmsID(SmsData objitemData)
        {
            List<SmsData> result = null;

            try
            {
                SmsDA objitemDA = new SmsDA();
                result = objitemDA.SearchChildDetailBySmsID(objitemData);

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
