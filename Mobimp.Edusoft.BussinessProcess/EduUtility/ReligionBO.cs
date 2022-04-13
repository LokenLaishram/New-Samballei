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
    public class ReligionBO
    {
        public int UpdateReligionDetails(ReligionData objreligion)
        {
            int result = 0;

            try
            {
                ReligionDA objReligionDA = new ReligionDA();
                result = objReligionDA.UpdateReligionDetails(objreligion);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ReligionData> SearchReligionDetails(ReligionData objreligion)
        {

            List<ReligionData> result = null;

            try
            {
                ReligionDA objReligionDA = new ReligionDA();
                result = objReligionDA.SearchReligionDetails(objreligion);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ReligionData> GetReligionDetailsByID(ReligionData objreligion)
        {
            List<ReligionData> result = null;

            try
            {
                ReligionDA objReligionDA = new ReligionDA();
                result = objReligionDA.GetReligionDetailsByID(objreligion);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteReligionDetailsByID(ReligionData objreligion)
        {
            int result = 0;

            try
            {
                ReligionDA objReligionDA = new ReligionDA();
                result = objReligionDA.DeleteReligionDetailsByID(objreligion);

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
