using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.DataAccess.EduFees;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduFees
{
    public class MonthlyFeeStatementBO
    {
        public int GenerateDailyFeeStatement(MonthlyFeeStatementData objfees)
        {
            int result = 0;

            try
            {
                MonthlyFeeStatementDA objfeesDA = new MonthlyFeeStatementDA();
                result = objfeesDA.GenerateDailyFeeStatement(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int GenerateMonthlyFeeStatement(MonthlyFeeStatementData objfees)
        {
            int result = 0;

            try
            {
                MonthlyFeeStatementDA objfeesDA = new MonthlyFeeStatementDA();
                result = objfeesDA.GenerateMonthlyFeeStatement(objfees);

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
