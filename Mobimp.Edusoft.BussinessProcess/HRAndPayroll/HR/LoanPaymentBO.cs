using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.HR;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR
{
    public class LoanPaymentBO
    {
        public List<LoanPaymentData> GetEmployeeName(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
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

        public List<LoanPaymentData> SaveLoanPayment(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;

            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.SaveLoanPayment(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<LoanPaymentData> GetLoanRecordDetails(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;

            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.GetLoanRecordDetails(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }


        public List<LoanPaymentData> SearchChildPaymentRecordDetails(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;

            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.SearchChildPaymentRecordDetails(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<LoanPaymentData> GetLoanDetailsByPaymentNo(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;

            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.GetLoanDetailsByPaymentNo(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteLoanByPaymentNo(LoanPaymentData ObjData)
        {
            int result = 0;
            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.DeleteLoanByPaymentNo(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        //------------------------------------- Start Loan Repayment -------------------------------------

        public List<LoanPaymentData> GetPaymentNo(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;
            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.GetPaymentNo(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<LoanPaymentData> SaveLoanRepayment(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;

            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.SaveLoanRepayment(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<LoanPaymentData> GetLoanRepaymentDetails(LoanPaymentData ObjData)
        {
            List<LoanPaymentData> result = null;

            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.GetLoanRepaymentDetails(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteLoanRepaymentByReturnNo(LoanPaymentData ObjData)
        {
            int result = 0;
            try
            {
                LoanPaymentDA ObjDA = new LoanPaymentDA();
                result = ObjDA.DeleteLoanRepaymentByReturnNo(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        //------------------------------------- End Loan Repayment ----------------------------------------- 
    }
}
