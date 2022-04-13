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
    public class WingBO
    {
        public int UpdateWingDetails(CampusData objclass)
        {
            int result = 0;

            try
            {
                WingDA objclassDA = new WingDA();
                result = objclassDA.UpdateWingDetails(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<CampusData> SearchWingDetails(CampusData objclass)
        {
            List<CampusData> result = null;
            try
            {
                WingDA objclassDA = new WingDA();
                result = objclassDA.SearchWingDetails(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<CampusData> GetWingDetailsByID(CampusData objclass)
        {
            List<CampusData> result = null;

            try
            {
                WingDA objclassDA = new WingDA();
                result = objclassDA.GetWingDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

       


        public int DeleteWingDetailsByID(CampusData objclass)
        {
            int result = 0;

            try
            {
                WingDA objclassDA = new WingDA();
                result = objclassDA.DeleteWingDetailsByID(objclass);

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
                WingDA objstdloyeeDA = new WingDA();
                result = objstdloyeeDA.ActivateWing(objclass);

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
