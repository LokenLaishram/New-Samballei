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
    public class DepartmentBO
    {
        public int UpdateDepartmentDetails(DepartmentData objDepartment)
        {
            int result = 0;

            try
            {
                DepartmentDA objDepartmentDA = new DepartmentDA();
                result = objDepartmentDA.UpdateDepartmentDetails(objDepartment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DepartmentData> SearchDepartmentDetails(DepartmentData objDepartment)
        {

            List<DepartmentData> result = null;

            try
            {
                DepartmentDA objDepartmentDA = new DepartmentDA();
                result = objDepartmentDA.SearchDepartmentDetails(objDepartment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DepartmentData> GetDepartmentDetailsByID(DepartmentData objDepartment)
        {
            List<DepartmentData> result = null;

            try
            {
                DepartmentDA objDepartmentDA = new DepartmentDA();
                result = objDepartmentDA.GetDepartmentDetailsByID(objDepartment);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteDepartmentDetailsByID(DepartmentData objDepartment)
        {
            int result = 0;

            try
            {
                DepartmentDA objDepartmentDA = new DepartmentDA();
                result = objDepartmentDA.DeleteDepartmentDetailsByID(objDepartment);

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
