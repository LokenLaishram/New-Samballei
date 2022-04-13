using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
    public class CastBO
    {
        public int UpdateCastDetails(CastData objCast)
        {
            int result = 0;
            try
            {
                CastDA objCastDA = new CastDA();
                result = objCastDA.UpdateCastDetails(objCast);
            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<CastData> SearchCastDetails(CastData objCast)
        {

            List<CastData> result = null;

            try
            {
                CastDA objCastDA = new CastDA();
                result = objCastDA.SearchCastDetails(objCast);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<CastData> GetCastDetailsByID(CastData objCast)
        {
            List<CastData> result = null;

            try
            {
                CastDA objCastDA = new CastDA();
                result = objCastDA.GetCastDetailsByID(objCast);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteCastDetailsByID(CastData objCast)
        {
            int result = 0;
            try
            {
                CastDA objCastDA = new CastDA();
                result = objCastDA.DeleteCastDetailsByID(objCast);

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
