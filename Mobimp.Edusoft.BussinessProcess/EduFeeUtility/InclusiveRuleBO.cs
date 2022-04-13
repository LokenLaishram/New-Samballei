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
    public class InclusiveRuleBO
    {
        public List<InclusiveRuleData> GetInclusiveOneTime(InclusiveRuleData objpayment)
        {
            List<InclusiveRuleData> result = null;
            try
            {
                InclusiveRuleDA objpaymentDA = new InclusiveRuleDA();
                result = objpaymentDA.GetInclusiveOneTime(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<InclusiveRuleData> GetInclusiveOtherFeeTypes(InclusiveRuleData objpayment)
        {
            List<InclusiveRuleData> result = null;
            try
            {
                InclusiveRuleDA objpaymentDA = new InclusiveRuleDA();
                result = objpaymentDA.GetInclusiveOtherFeeTypes(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<InclusiveRuleData> GetInclusiveMonths(InclusiveRuleData objpayment)
        {
            List<InclusiveRuleData> result = null;
            try
            {
                InclusiveRuleDA objpaymentDA = new InclusiveRuleDA();
                result = objpaymentDA.GetInclusiveMonths(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }


        public int UpdateInclusiveOtherFee(InclusiveRuleData objpayment)
        {
            int result = 0;

            try
            {
                InclusiveRuleDA objpaymentDA = new InclusiveRuleDA();
                result = objpaymentDA.UpdateInclusiveOtherFee(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateInclusiveMonths(InclusiveRuleData objpayment)
        {
            int result = 0;

            try
            {
                InclusiveRuleDA objpaymentDA = new InclusiveRuleDA();
                result = objpaymentDA.UpdateInclusiveMonths(objpayment);
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
