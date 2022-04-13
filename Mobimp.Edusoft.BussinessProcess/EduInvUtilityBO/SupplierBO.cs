using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduInvUtility;
using Mobimp.Edusoft.DataAccess.EduInvUtilityDA;

namespace Mobimp.Edusoft.BussinessProcess.EduInvUtility
{
    public class SupplierBO
    {
        public int SaveSupplier(SupplierData objsub)
        {
            int result = 0;

            try
            {
                SupplierDA objsubDA = new SupplierDA();
                result = objsubDA.Savesupplier(objsub);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeletesupplierbyID(SupplierData objsup)
        {
            int result = 0;

            try
            {
                SupplierDA objsupDA = new SupplierDA();
                result = objsupDA.DeletesupplierbyID(objsup);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SupplierData> Searchsupplier(SupplierData objclass)
        {
            List<SupplierData> result = null;
            try
            {
                SupplierDA objclassDA = new SupplierDA();
                result = objclassDA.Searchsupplier(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SupplierData> GetsupplierbyID(SupplierData objclass)
        {
            List<SupplierData> result = null;

            try
            {
                SupplierDA objclassDA = new SupplierDA();
                result = objclassDA.GetsupplierbyID(objclass);

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
