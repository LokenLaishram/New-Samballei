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
    public class EMIPaymentBO
    {
        public List<EMIPaymentData> GetEMIPayment(EMIPaymentData objpayment)
        {
            List<EMIPaymentData> result = null;
            try
            {
                EMIPaymentDA objpaymentDA = new EMIPaymentDA();
                result = objpaymentDA.GetEMIPayment(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateEMIPayment(EMIPaymentData objpayment)
        {
            int result = 0;
            try
            {
                EMIPaymentDA objpaymentDA = new EMIPaymentDA();
                result = objpaymentDA.UpdateEMIPayment(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<EMIPaymentData> GetEMINo(EMIPaymentData objpayment)
        {
            List<EMIPaymentData> result = null;
            try
            {
                EMIPaymentDA objpaymentDA = new EMIPaymentDA();
                result = objpaymentDA.GetEMINo(objpayment);
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
