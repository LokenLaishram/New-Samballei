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
    public class CountryBO
    {
        public int UpdateCountryDetails(CountryData objcountry)
        {
            int result = 0;

            try
            {
                CountryDA objcountryDA = new CountryDA();
                result = objcountryDA.UpdateCountryDetails(objcountry);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<CountryData> SearchCountryDetails(CountryData objcountry)
        {

            List<CountryData> result = null;

            try
            {
                CountryDA objcountryDA = new CountryDA();
                result = objcountryDA.SearchCountryDetails(objcountry);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<CountryData> GetCountryDetailsByID(CountryData objcountry)
        {
            List<CountryData> result = null;

            try
            {
                CountryDA objcountryDA = new CountryDA();
                result = objcountryDA.GetCountryDetailsByID(objcountry);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteCountryDetailsByID(CountryData objcountry)
        {
            int result = 0;

            try
            {
                CountryDA objcountryDA = new CountryDA();
                result = objcountryDA.DeleteCountryDetailsByID(objcountry);

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
