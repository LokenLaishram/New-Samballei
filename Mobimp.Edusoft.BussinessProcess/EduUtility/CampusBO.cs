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
    public class CampusBO
    {
        public int UpdateCampusDetails(CampusData objclass)
        {
            int result = 0;

            try
            {
                CampusDA objclassDA = new CampusDA();
                result = objclassDA.UpdateCampusDetails(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<CampusData> SearchCampusDetails(CampusData objclass)
        {
            List<CampusData> result = null;
            try
            {
                CampusDA objclassDA = new CampusDA();
                result = objclassDA.SearchCampusDetails(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<CampusData> GetCampusDetailsByID(CampusData objclass)
        {
            List<CampusData> result = null;

            try
            {
                CampusDA objclassDA = new CampusDA();
                result = objclassDA.GetCampusDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

       


        public int DeleteCampusDetailsByID(CampusData objclass)
        {
            int result = 0;

            try
            {
                CampusDA objclassDA = new CampusDA();
                result = objclassDA.DeleteCampusDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(CampusData objclass)
        {
            int result = 0;

            try
            {
                CampusDA objstdloyeeDA = new CampusDA();
                result = objstdloyeeDA.ActivateCampus(objclass);

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
