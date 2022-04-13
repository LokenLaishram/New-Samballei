using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Campusoft.DataAccess.EduHostel;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.EduHostel
{
    public class DepositFeeBO
    {
        public int UpdateServiceFeeDepositDetails(DepositFeeData objfee)
        {

            int result = 0;

            try
            {
                DepositFeeDA objfeesDA = new DepositFeeDA();
                result = objfeesDA.UpdateServiceFeeDepositDetails(objfee);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DepositFeeData> SearchDepositFeeDetails(DepositFeeData objservfee)
        {

            List<DepositFeeData> result = null;

            try
            {
                DepositFeeDA objservfeeDA = new DepositFeeDA();
                result = objservfeeDA.SearchDepositFeeDepositDetails(objservfee);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int DeleteDepositFeesByID(DepositFeeData objdepositfee)
        {
            int result = 0;

            try
            {
                DepositFeeDA objfeesloyeeDA = new DepositFeeDA();
                result = objfeesloyeeDA.DeleteDepositFeesByID(objdepositfee);

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
