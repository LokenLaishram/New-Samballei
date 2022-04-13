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
    public class MonthlyPaymentBO
    {
        public List<MonthlyPaymentData> GetMonthlyPayment(MonthlyPaymentData objpayment)
        {
            List<MonthlyPaymentData> result = null;
            try
            {
                MonthlyPaymentDA objpaymentDA = new MonthlyPaymentDA();
                result = objpaymentDA.GetMonthlyPayment(objpayment);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateMonthlyPayment(MonthlyPaymentData objpayment)
        {
            int result = 0;
            try
            {
                MonthlyPaymentDA objpaymentDA = new MonthlyPaymentDA();
                result = objpaymentDA.UpdateMonthlyPayment(objpayment);
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
