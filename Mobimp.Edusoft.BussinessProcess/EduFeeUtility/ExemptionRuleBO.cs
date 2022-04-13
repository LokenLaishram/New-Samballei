using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduFeeUtility;
using Mobimp.Edusoft.DataAccess.EduFeeUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Campusoft.BussinessProcess.EduFeeUtility
{
    public class ExemptionRuleBO
    {
        public List<ExemptionRuleData> GetExemptionRule(ExemptionRuleData objpayment)
        {
            List<ExemptionRuleData> result = null;
            try
            {
                ExemptionRuleDA objpaymentDA = new ExemptionRuleDA();
                result = objpaymentDA.GetExemptionRule(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateExemptionRule(ExemptionRuleData objpayment)
        {
            int result = 0;
            try
            {
                ExemptionRuleDA objpaymentDA = new ExemptionRuleDA();
                result = objpaymentDA.UpdateExemptionRule(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<TransportExemptionRuleData> GetTransportExemptionRule(TransportExemptionRuleData objpayment)
        {
            List<TransportExemptionRuleData> result = null;
            try
            {
                ExemptionRuleDA objpaymentDA = new ExemptionRuleDA();
                result = objpaymentDA.GetTransportExemptionRule(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateTransportExemptionRule(TransportExemptionRuleData objpayment)
        {
            int result = 0;
            try
            {
                ExemptionRuleDA objpaymentDA = new ExemptionRuleDA();
                result = objpaymentDA.UpdateTransportExemptionRule(objpayment);
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
