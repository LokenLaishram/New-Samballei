using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.HRAndPayroll.Payroll;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.Payroll;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Payroll
{
    public class SalaryGeneratorBO
    {
        public List<SalaryGeneratorData> GetEmployeeName(SalaryGeneratorData ObjData)
        {
            List<SalaryGeneratorData> result = null;
            try
            {
                SalaryGeneratorDA ObjDA = new SalaryGeneratorDA();
                result = ObjDA.GetEmployeeName(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<SalaryGeneratorData> GetSalaryGenerator(SalaryGeneratorData objData)
        {
            List<SalaryGeneratorData> result = null;

            try
            {
                SalaryGeneratorDA objDA = new SalaryGeneratorDA();
                result = objDA.GetSalaryGenerator(objData);

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
