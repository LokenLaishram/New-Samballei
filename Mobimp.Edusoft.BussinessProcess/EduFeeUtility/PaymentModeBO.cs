using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduFeeUtility;
using Mobimp.Edusoft.DataAccess.EduFeeUtility;

namespace Mobimp.Edusoft.BussinessProcess.EduFeeUtility
{
    public class PaymentModeBO
    {
        public int UpdatePaymentModeDetails(PaymentModeData objpayment)
        {
            int result = 0;

            try
            {
                PaymentModeDA objpaymentDA = new PaymentModeDA();
                result = objpaymentDA.UpdatePaymentModeDetails(objpayment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<PaymentModeData> SearchPaymentModeDetails(PaymentModeData objpayment)
        {

            List<PaymentModeData> result = null;

            try
            {
                PaymentModeDA objpaymentDA = new PaymentModeDA();
                result = objpaymentDA.SearchPaymentModeDetails(objpayment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<PaymentModeData> GetPaymentModeDetailsByID(PaymentModeData objpayment)
        {
            List<PaymentModeData> result = null;

            try
            {
                PaymentModeDA objpaymentDA = new PaymentModeDA();
                result = objpaymentDA.GetPaymentModeDetailsByID(objpayment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeletePaymentModeDetailsByID(PaymentModeData objpayment)
        {
            int result = 0;

            try
            {
                PaymentModeDA objpaymentDA = new PaymentModeDA();
                result = objpaymentDA.DeletePaymentModeDetailsByID(objpayment);

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
