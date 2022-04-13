using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduAccount;
using Mobimp.Edusoft.DataAccess.EduAccount;

namespace Mobimp.Edusoft.BussinessProcess.EduAccount
{
    public class StatementBO
    {
        public List<StatementData> SearchAccountTransactionList(StatementData obj)
        {
            List<StatementData> result = null;
            try
            {
                StatementDA objDA = new StatementDA();
                result = objDA.SearchAccountTransactionList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<StatementData> ExpenditureTransactionList(StatementData obj)
        {
            List<StatementData> result = null;
            try
            {
                StatementDA objDA = new StatementDA();
                result = objDA.ExpenditureTransactionList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
    }
}
