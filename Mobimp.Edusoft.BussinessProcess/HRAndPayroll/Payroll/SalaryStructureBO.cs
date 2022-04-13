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
    public class SalaryStructureBO
    {

        public List<SalaryStructureData> GetSalaryStructure(SalaryStructureData objData)
        {
            List<SalaryStructureData> result = null;

            try
            {
                SalaryStructureDA objDA = new SalaryStructureDA();
                result = objDA.GetSalaryStructure(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateSalaryStructure(SalaryStructureData objData)
        {
            int result = 0;

            try
            {
                SalaryStructureDA objDA = new SalaryStructureDA();
                result = objDA.UpdateSalaryStructure(objData);
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
