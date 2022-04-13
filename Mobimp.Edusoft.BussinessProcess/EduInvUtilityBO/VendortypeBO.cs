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
   public class VendortypeBO
    {
        public int SaveVendortype(VendortypeData objGroup)
        {
            int result = 0;

            try
            {
                VendortypeDA objVendortypeDA = new VendortypeDA();
                result = objVendortypeDA.SaveVendortype(objGroup);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<VendortypeData> SearchVendortype(VendortypeData objGroup)
        {
            List<VendortypeData> result = null;
            try
            {
                VendortypeDA objVendortypeDA = new VendortypeDA();
                result = objVendortypeDA.SearchVendortype(objGroup);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<VendortypeData> GetVendortypebyID(VendortypeData objGroup)
        {
            List<VendortypeData> result = null;

            try
            {
                VendortypeDA objVendortypeDA = new VendortypeDA();
                result = objVendortypeDA.GetVendortypebyID(objGroup);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteVendortypeID(VendortypeData objGroup)
        {
            int result = 0;

            try
            {
                VendortypeDA objVendortypeDA = new VendortypeDA();
                result = objVendortypeDA.DeleteVendortypeID(objGroup);

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
