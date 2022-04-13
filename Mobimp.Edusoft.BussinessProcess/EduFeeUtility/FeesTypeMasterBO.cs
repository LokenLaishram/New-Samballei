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
    public class FeesTypeMasterBO
    {
        public int UpdateFeeTypes(FeesTypeMasterData objfees)
        {
            int result = 0;

            try
            {
                FeesTypeMasterDA objfeesDA = new FeesTypeMasterDA();
                result = objfeesDA.UpdateFeeTypes(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<FeesTypeMasterData> SearchFeesTypesMaster(FeesTypeMasterData objfees)
        {
            List<FeesTypeMasterData> result = null;

            try
            {
                FeesTypeMasterDA objfeesDA = new FeesTypeMasterDA();
                result = objfeesDA.SearchFeesTypesMaster(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<FeesTypeMasterData> GetFeesDetailsByID(FeesTypeMasterData objfees)
        {
            List<FeesTypeMasterData> result = null;

            try
            {
                FeesTypeMasterDA objfeesDA = new FeesTypeMasterDA();
                result = objfeesDA.GetFeesDetailsByID(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteFeesDetailsByID(FeesTypeMasterData objfees)
        {
            int result = 0;

            try
            {
                FeesTypeMasterDA objfeesDA = new FeesTypeMasterDA();
                result = objfeesDA.DeleteFeesDetailsByID(objfees);

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
