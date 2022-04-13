using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
    public class SexBO
    {
        public int UpdateSexDetails(SexData objCast)
        {
            int result = 0;
            try
            {
                SexDA objSexDA = new SexDA();
                result = objSexDA.UpdateSexDetails(objCast);
            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SexData> SearchSexDetails(SexData objCast)
        {

            List<SexData> result = null;

            try
            {
                SexDA objSexDA = new SexDA();
                result = objSexDA.SearchSexDetails(objCast);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SexData> GetSexDetailsByID(SexData objCast)
        {
            List<SexData> result = null;

            try
            {
                SexDA objSexDA = new SexDA();
                result = objSexDA.GetSexDetailsByID(objCast);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSexDetailsByID(SexData objCast)
        {
            int result = 0;
            try
            {
                SexDA objSexDA = new SexDA();
                result = objSexDA.DeleteSexDetailsByID(objCast);

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
