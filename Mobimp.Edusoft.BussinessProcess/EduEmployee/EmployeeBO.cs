using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.DataAccess.EduEmployee;

namespace Mobimp.Edusoft.BussinessProcess.EduEmployee
{
    public class EmployeeBO
    {
        public int UpdateEmployeeDetails(EmployeeData objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.UpdateEmployeeDetails(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateEmployeeAttenedance(EmployeeAttendanceData objstd)
        {
            int result = 0;

            try
            {
                EmployeeDA objstdloyeeDA = new EmployeeDA();
                result = objstdloyeeDA.UpdateEmployeeAttenedance(objstd);

            }
            catch (Exception ex)
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateEmployeeLeaveDetails(EmployeeLeaveData objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.UpdateEmployeeLeaveDetails(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpLoadEmployeePhoto(EmployeeData objstd)
        {
            int result = 0;

            try
            {
                EmployeeDA objstdloyeeDA = new EmployeeDA();
                result = objstdloyeeDA.UpLoadEmployeePhoto(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateEmployeeSalaryDetails(EmployeeSalary objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.UpdateEmployeeSalaryDetails(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeData> SearchEmployeeTypeDetails(EmployeeData objemp)
        {

            List<EmployeeData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.SearchEmployeeDetails(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeData> SearchEmployeePhoto(EmployeeData objemp)
        {

            List<EmployeeData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.SearchEmployeePhoto(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeLeaveData> SearchEmployeeLeaveDetails(EmployeeLeaveData objemp)
        {

            List<EmployeeLeaveData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.SearchEmployeeLeaveDetails(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeSalary> GetSalaryDetails(EmployeeSalary objemp)
        {

            List<EmployeeSalary> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetSalaryDetails(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<Logintrackdata> TrackLogin(Logintrackdata objemp)
        {

            List<Logintrackdata> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.TrackLogin(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeAttendanceData> GetEmployeeRegister(EmployeeAttendanceData objemp)
        {

            List<EmployeeAttendanceData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmployeeRegister(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeSalary> GenerateEmployeesalary(EmployeeSalary objemp)
        {

            List<EmployeeSalary> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GenerateEmployeesalary(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeAttendanceData> GetEmpattendance(EmployeeAttendanceData objemp)
        {

            List<EmployeeAttendanceData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmpattendance(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeData> GetEmpnames(EmployeeData objemp)
        {

            List<EmployeeData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmpnames(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeData> GetEmpNo(EmployeeData objemp)
        {

            List<EmployeeData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmpNo(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeData> GetEmployeeDetailsByID(EmployeeData objemp)
        {
            List<EmployeeData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmployeeDetailsByID(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<userdetails> GetEmployeeDetailsLoginDetails(userdetails objemp)
        {
            List<userdetails> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmployeeDetailsLoginDetails(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeLeaveData> GetEmployeeLeaveDetailsByID(EmployeeLeaveData objemp)
        {
            List<EmployeeLeaveData> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmployeeLeaveDetailsByID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeSalary> GetEmployeeSalaryDetailsByID(EmployeeSalary objemp)
        {
            List<EmployeeSalary> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmployeeSalaryDetailsByID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeSalary> GetEmployeeSalaryDetails(EmployeeSalary objemp)
        {
            List<EmployeeSalary> result = null;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.GetEmployeeSalaryDetails(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteEmployeeDetailsByID(EmployeeData objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.DeleteEmployeeDetailsByID(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteEmployeeLeaveDetailsByID(EmployeeLeaveData objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.DeleteEmployeeLeaveDetailsByID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateLogin(EmployeeAttendanceData objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.UpdateLogin(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateEmployeeSalary(EmployeeSalary objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.UpdateEmployeeSalary(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateLogout(EmployeeAttendanceData objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.UpdateLogout(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeletSalaryDetailsByID(EmployeeSalary objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.DeletSalaryDetailsByID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateLeaveStatus(EmployeeLeaveData objemp)
        {
            int result = 0;

            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                result = objEmployeeDA.UpdateLeaveStatus(objemp);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        /////////Employee list exporting/////////////////////
        public List<EmployeeData> GetEmployeeListoexcel(EmployeeData objemp)
        {

            List<EmployeeData> result = null;

            try
            {
                EmployeeDA objempDA = new EmployeeDA();
                result = objempDA.GetEmployeeListoexcel(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<EmployeeData> GetEmployeePasswordList(EmployeeData objemp)
        {

            List<EmployeeData> result = null;

            try
            {
                EmployeeDA objempDA = new EmployeeDA();
                result = objempDA.GetEmployeePasswordList(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateEmployeePassword(EmployeeData objemp)
        {

            int result = 0;

            try
            {
                EmployeeDA objempDA = new EmployeeDA();
                result = objempDA.UpdateEmployeePassword(objemp);

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
