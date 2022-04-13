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
   public class VendorBO
    {
        public int SaveVendor(VendorData objvendor)
        {
            int result = 0;

            try
            {
                VendorDA objVendorDA = new VendorDA();
                result = objVendorDA.SaveVendor(objvendor);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<VendorData> SearchVendor(VendorData objvendor)
        {
            List<VendorData> result = null;
            try
            {
                VendorDA objVendorDA = new VendorDA();
                result = objVendorDA.SearchVendor(objvendor);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<VendorData> GetVendorbyID(VendorData objvendor)
        {
            List<VendorData> result = null;

            try
            {
                VendorDA objVendorDA = new VendorDA();
                result = objVendorDA.GetVendorbyID(objvendor);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteVendorID(VendorData objvendor)
        {
            int result = 0;

            try
            {
                VendorDA objVendorDA = new VendorDA();
                result = objVendorDA.DeleteVendorID(objvendor);

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
