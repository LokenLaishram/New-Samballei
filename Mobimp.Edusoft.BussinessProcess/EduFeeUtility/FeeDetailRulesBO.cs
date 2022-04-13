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
    public class FeeDetailRulesBO
    {
        public List<FeeDetailRulesData> SearchFeesDetails(FeeDetailRulesData objfees)
        {
            List<FeeDetailRulesData> result = null;

            try
            {
                FeeDetailRulesDA objfeesDA = new FeeDetailRulesDA();
                result = objfeesDA.SearchFeesDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int SaveFeeDetails(FeeDetailRulesData objfees)
        {
            int result = 0;

            try
            {
                FeeDetailRulesDA objfeesDA = new FeeDetailRulesDA();
                result = objfeesDA.SaveFeeDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateFeeDetails(FeeDetailRulesData objfees)
        {
            int result = 0;

            try
            {
                FeeDetailRulesDA objfeesDA = new FeeDetailRulesDA();
                result = objfeesDA.UpdateFeeDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteFeeDetailsByID(FeeDetailRulesData objfees)
        {
            int result = 0;
            try
            {
                FeeDetailRulesDA objfeesDA = new FeeDetailRulesDA();
                result = objfeesDA.DeleteFeeDetailsByID(objfees);

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
