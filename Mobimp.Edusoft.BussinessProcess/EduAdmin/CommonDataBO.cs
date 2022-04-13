using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.DataAccess.EduAdmin;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduAdmin
{
    public class CommonDataBO
    {
        public bool SaveLogo(CommonData lstCommonData)
        {
            bool result = false;
            try
            {
                CommonDataDA objCommonDataDA = new CommonDataDA();
                result = objCommonDataDA.SaveLogo(lstCommonData);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<CommonData> GetLogo(CommonData objCommonData)
        {

            List<CommonData> result = null;

            try
            {
                CommonDataDA objCommonDataDA = new CommonDataDA();
                result = objCommonDataDA.GetLogo(objCommonData);
            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public bool DeleteLogo(CommonData lstCommonData)
        {
            bool result = false;
            try
            {
                CommonDataDA objCommonDataDA = new CommonDataDA();
                result = objCommonDataDA.DeleteLogo(lstCommonData);
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
