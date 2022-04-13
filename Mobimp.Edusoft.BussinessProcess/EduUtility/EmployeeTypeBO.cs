using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
    public class EmployeeTypeBO
    {
        public int UpdateEmployeeTypeDetails(EmployeeTypeData objemptype)
        {
            int result = 0;

            try
            {
                EmployeeTypeDA objEmployeeTypeDA = new EmployeeTypeDA();
                result = objEmployeeTypeDA.UpdateEmployeeTypeDetails(objemptype);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeTypeData> SearchEmployeeTypeDetails(EmployeeTypeData objemptype)
        {

            List<EmployeeTypeData> result = null;

            try
            {
                EmployeeTypeDA objEmployeeTypeDA = new EmployeeTypeDA();
                result = objEmployeeTypeDA.SearchEmployeeTypeDetails(objemptype);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeTypeData> GetEmployeeTypeDetailsByID(EmployeeTypeData objemptype)
        {
            List<EmployeeTypeData> result = null;

            try
            {
                EmployeeTypeDA objEmployeeTypeDA = new EmployeeTypeDA();
                result = objEmployeeTypeDA.GetEmployeeTypeDetailsByID(objemptype);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteEmployeeTypeDetailsByID(EmployeeTypeData objemptype)
        {
            int result = 0;

            try
            {
                EmployeeTypeDA objEmployeeTypeDA = new EmployeeTypeDA();
                result = objEmployeeTypeDA.DeleteEmployeeTypeDetailsByID(objemptype);

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
