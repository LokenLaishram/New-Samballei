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
    public class SectionBO
    {
        public int UpdateSectionDetails(SectionData objsection)
        {
            int result = 0;

            try
            {
                SectionDA objsectionDA = new SectionDA();
                result = objsectionDA.UpdateSectionDetails(objsection);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SectionData> SearchSectionDetails(SectionData objsection)
        {

            List<SectionData> result = null;

            try
            {
                SectionDA objsectionDA = new SectionDA();
                result = objsectionDA.SearchSectionDetails(objsection);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SectionData> GetSectionDetailsByID(SectionData objsection)
        {
            List<SectionData> result = null;

            try
            {
                SectionDA objsectionDA = new SectionDA();
                result = objsectionDA.GetSectionDetailsByID(objsection);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSectionDetailsByID(SectionData objsection)
        {
            int result = 0;

            try
            {
                SectionDA objsectionDA = new SectionDA();
                result = objsectionDA.DeleteSectionDetailsByID(objsection);

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
