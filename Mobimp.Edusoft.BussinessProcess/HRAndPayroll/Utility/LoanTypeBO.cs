using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.Utility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility
{
    public class LoanTypeBO
    {
        public int UpdateLoanTypeDetails(LoanTypeData ObjLoanType)
        {
            int result = 0;

            try
            {
                LoanTypeDA ObjLoanTypeDA = new LoanTypeDA();
                result = ObjLoanTypeDA.UpdateLoanTypeDetails(ObjLoanType);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LoanTypeData> SearchLoanTypeDetails(LoanTypeData ObjLoanType)
        {
            List<LoanTypeData> result = null;
            try
            {
                LoanTypeDA ObjLoanTypeDA = new LoanTypeDA();
                result = ObjLoanTypeDA.SearchLoanTypeDetails(ObjLoanType);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LoanTypeData> GetLoanTypeDetailsByID(LoanTypeData ObjLoanType)
        {
            List<LoanTypeData> result = null;

            try
            {
                LoanTypeDA ObjLoanTypeDA = new LoanTypeDA();
                result = ObjLoanTypeDA.GetLoanTypeDetailsByID(ObjLoanType);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteLoanTypeDetailsByID(LoanTypeData ObjLoanType)
        {
            int result = 0;

            try
            {
                LoanTypeDA ObjLoanTypeDA = new LoanTypeDA();
                result = ObjLoanTypeDA.DeleteLoanTypeDetailsByID(ObjLoanType);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(LoanTypeData ObjLoanType)
        {
            int result = 0;

            try
            {
                LoanTypeDA objstdloyeeDA = new LoanTypeDA();
                result = objstdloyeeDA.ActivateLoanType(ObjLoanType);

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
