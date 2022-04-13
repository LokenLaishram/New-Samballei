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
    public class PaymentTypeBO
    {
        public int UpdatePaymentTypeDetails(PaymentTypeData objpayment)
        {
            int result = 0;

            try
            {
                PaymentTypeDA objpaymentDA = new PaymentTypeDA();
                result = objpaymentDA.UpdatePaymentTypeDetails(objpayment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<PaymentTypeData> SearchPaymentTypeDetails(PaymentTypeData objpayment)
        {

            List<PaymentTypeData> result = null;

            try
            {
                PaymentTypeDA objpaymentDA = new PaymentTypeDA();
                result = objpaymentDA.SearchPaymentTypeDetails(objpayment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<PaymentTypeData> GetPaymentTypeDetailsByID(PaymentTypeData objpayment)
        {
            List<PaymentTypeData> result = null;

            try
            {
                PaymentTypeDA objpaymentDA = new PaymentTypeDA();
                result = objpaymentDA.GetPaymentTypeDetailsByID(objpayment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeletePaymentTypeDetailsByID(PaymentTypeData objpayment)
        {
            int result = 0;

            try
            {
                PaymentTypeDA objpaymentDA = new PaymentTypeDA();
                result = objpaymentDA.DeletePaymentTypeDetailsByID(objpayment);

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
