using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{

    public class DistrictBO
    {
        public int UpdateDistrictDetails(DistrictData objDistrict)
        {
            int result = 0;

            try
            {
                DistrictDA objDistrictDA = new DistrictDA();
                result = objDistrictDA.UpdateDistrictDetails(objDistrict);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DistrictData> SearchDistrictDetails(DistrictData objDistrict)
        {

            List<DistrictData> result = null;

            try
            {
                DistrictDA objDistrictDA = new DistrictDA();
                result = objDistrictDA.SearchDistrictDetails(objDistrict);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DistrictData> GetDistrictDetailsByID(DistrictData objDistrict)
        {
            List<DistrictData> result = null;

            try
            {
                DistrictDA objDistrictDA = new DistrictDA();
                result = objDistrictDA.GetDistrictDetailsByID(objDistrict);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteDistrictDetailsByID(DistrictData objDistrict)
        {
            int result = 0;

            try
            {
                DistrictDA objDistrictDA = new DistrictDA();
                result = objDistrictDA.DeleteDistrictDetailsByID(objDistrict);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<LookupItem> GetStatelistByCountryID(int CountryID)
        {
            List<LookupItem> liststates = null;
            try
            {
                DistrictDA objDistrictDA = new DistrictDA();
                List<LookupItem> liststate = objDistrictDA.GetStatelistByCountryID(CountryID);
                liststates = liststate;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return liststates;
        }

     


    }

}
