using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Campusoft.DataAccess.EduHostel;

namespace Mobimp.Campusoft.BussinessProcess.EduHostel
{
    public class GetAjustedBO
    {
        public List<AjustedData> GetstudentDetailByID(AjustedData objstd)
        {

            List<AjustedData> result = null;

            try
            {
                AjustedDA objstdloyeeDA = new AjustedDA();
                result = objstdloyeeDA.GetstudentDetailByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AjustedData> SearchAjustedtDetails(AjustedData objajustedlist)
        {

            List<AjustedData> result = null;

            try
            {
                AjustedDA objajustedDA = new AjustedDA();
                result = objajustedDA.SearchAjustedtDetails(objajustedlist);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateAjustedDetails(AjustedData objajutdata)
        {
            int result = 0;

            try
            {
                AjustedDA objajustDA = new AjustedDA();
                result = objajustDA.UpdateAjustedDetails(objajutdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<AjustedData> SearchFeeAjustedCollectoionDetails(AjustedData objfeeajustedlist)
        {
            List<AjustedData> result = null;

            try
            {
                AjustedDA objfeeajustedDA = new AjustedDA();
                result = objfeeajustedDA.SearchFeeAjustedCollectoionDetails(objfeeajustedlist);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteAjustedFeesByID(AjustedData objajustdata)
        {
            int result = 0;

            try
            {
                AjustedDA objajustedfeeDA = new AjustedDA();
                result = objajustedfeeDA.DeleteAjustedFeesByID(objajustdata);

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
