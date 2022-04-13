using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.DataAccess.EduFees;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduFees
{
    public class FeeBO
    {
        public List<FeeData> GetStudentID(FeeData objemp)
        {

            List<FeeData> result = null;

            try
            {
                FeeDA objEmployeeDA = new FeeDA();
                result = objEmployeeDA.GetStudentID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        ////////////////////////SCHOOLFEESCOLLECTION//////////////////////////////////////
        public List<FeeData> GetAutoStudentDetails(FeeData objitemName)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objitemDA = new FeeDA();
                result = objitemDA.GetAutoStudentDetails(objitemName);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeeData> GetAutoStudentName(FeeData objitemName)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objitemDA = new FeeDA();
                result = objitemDA.GetAutoStudentName(objitemName);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeeData> GetStudentDetailByID(FeeData objFeeData)
        {

            List<FeeData> result = null;

            try
            {
                FeeDA objstudentDA = new FeeDA();
                result = objstudentDA.GetStudentDetailByID(objFeeData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeeData> SearchDueDetailsList(FeeData objDuelist)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objduefeeDA = new FeeDA();
                result = objduefeeDA.SearchDueFeeDetailsList(objDuelist);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        //Student Fee Status
        public List<FeeData> SearchStudentFeeStatusList(FeeData objFee)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objduefeeDA = new FeeDA();
                result = objduefeeDA.SearchStudentFeeStatusList(objFee);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        //Student Fee Status Details
        public List<FeeData> SearchFeeStatusDetails(FeeData objDetails)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objfeeDA = new FeeDA();
                result = objfeeDA.SearchFeeStatusDetails(objDetails);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        // Fee Payment 
        public List<FeeData> SearchFeePaymentDetails(FeeData objDetails)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objfeeDA = new FeeDA();
                result = objfeeDA.SearchFeePaymentDetails(objDetails);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentPaymentDetails(FeeData objfees)
        {
            int result = 0;

            try
            {
                FeeDA objfeesDA = new FeeDA();
                result = objfeesDA.UpdateStudentPaymentDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        //Fee Payment List
        public List<FeeData> SearchFeePaymentlist(FeeData objFee)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objduefeeDA = new FeeDA();
                result = objduefeeDA.SearchFeePaymentlist(objFee);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        //Child Grid
        public List<FeeData> SearchChildDetailByNo(FeeData objitemData)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objitemDA = new FeeDA();
                result = objitemDA.SearchChildDetailByNo(objitemData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteSchoolFeesByID(FeeData objfees)
        {
            int result = 0;
            try
            {
                FeeDA objfeesloyeeDA = new FeeDA();
                result = objfeesloyeeDA.DeleteSchoolFeesByID(objfees);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        // Due list
        public List<FeeData> SearchFeeDuelist(FeeData objFee)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objduefeeDA = new FeeDA();
                result = objduefeeDA.SearchFeeDuelist(objFee);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentDuePaymentDetails(FeeData objfees)
        {
            int result = 0;

            try
            {
                FeeDA objfeesDA = new FeeDA();
                result = objfeesDA.UpdateStudentDuePaymentDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<FeeData> SearchFeeDuePaymentlist(FeeData objFee)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objduefeeDA = new FeeDA();
                result = objduefeeDA.SearchFeeDuePaymentlist(objFee);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        // Yearly Wise Income
        public List<FeeData> SearchYearlyWiseIncome(FeeData objDetails)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objfeeDA = new FeeDA();
                result = objfeeDA.SearchYearlyWiseIncome(objDetails);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        // Monthly Wise Income
        public List<FeeData> SearchMonthlyWiseIncome(FeeData objDetails)
        {
            List<FeeData> result = null;

            try
            {
                FeeDA objfeeDA = new FeeDA();
                result = objfeeDA.SearchMonthlyWiseIncome(objDetails);

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


