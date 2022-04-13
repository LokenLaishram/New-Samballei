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
    public class SubRouteBO
    {
        public int UpdateSubRouteDetails(SubRouteData objSubRoute)
        {
            int result = 0;

            try
            {
                SubRouteDA objSubRouteDA = new SubRouteDA();
                result = objSubRouteDA.UpdateSubRouteDetails(objSubRoute);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SubRouteData> SearchSubRouteDetails(SubRouteData objSubRoute)
        {
            List<SubRouteData> result = null;
            try
            {
                SubRouteDA objSubRouteDA = new SubRouteDA();
                result = objSubRouteDA.SearchSubRouteDetails(objSubRoute);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SubRouteData> GetSubRouteDetailsByID(SubRouteData objSubRoute)
        {
            List<SubRouteData> result = null;

            try
            {
                SubRouteDA objSubRouteDA = new SubRouteDA();
                result = objSubRouteDA.GetSubRouteDetailsByID(objSubRoute);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

       

        public int DeleteSubRouteDetailsByID(SubRouteData objSubRoute)
        {
            int result = 0;

            try
            {
                SubRouteDA objSubRouteDA = new SubRouteDA();
                result = objSubRouteDA.DeleteSubRouteDetailsByID(objSubRoute);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(SubRouteData objSubRoute)
        {
            int result = 0;

            try
            {
                SubRouteDA objstdloyeeDA = new SubRouteDA();
                result = objstdloyeeDA.ActivateRoute(objSubRoute);

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
