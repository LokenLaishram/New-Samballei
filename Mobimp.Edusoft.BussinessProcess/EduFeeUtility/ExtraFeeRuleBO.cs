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
    public class ExtraFeeRuleBO
    {
        public List<ExtraFeeRuleData> GetExtraRule(ExtraFeeRuleData objextra)
        {
            List<ExtraFeeRuleData> result = null;
            try
            {
                ExtraFeeRuleDA objextraDA = new ExtraFeeRuleDA();
                result = objextraDA.GetExtraRule(objextra);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateExtraFeeRule(ExtraFeeRuleData objextra)
        {
            int result = 0;
            try
            {
                ExtraFeeRuleDA objextraDA = new ExtraFeeRuleDA();
                result = objextraDA.UpdateExtraFeeRule(objextra);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteExtraRuleByID(ExtraFeeRuleData objextra)
        {
            int result = 0;
            try
            {
                ExtraFeeRuleDA objfeesDA = new ExtraFeeRuleDA();
                result = objfeesDA.DeleteExtraRuleByID(objextra);

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
