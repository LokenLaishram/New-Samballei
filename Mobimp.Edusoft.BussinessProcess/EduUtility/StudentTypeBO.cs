using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduFeeUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.EduUtility
{
    public class StudentTypeBO
    {
        public int UpdateStudentType(StudentTypeData objstudent)
        {
            int result = 0;

            try
            {
                StudentTypeDA objstudentDA = new StudentTypeDA();
                result = objstudentDA.UpdateStudentType(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentTypeData> SearchStudentTypeList(StudentTypeData objstudent)
        {

            List<StudentTypeData> result = null;

            try
            {
                StudentTypeDA objstudentDA = new StudentTypeDA();
                result = objstudentDA.SearchStudentTypeList(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentTypeData> GetStudenttypeByID(StudentTypeData objstd)
        {
            List<StudentTypeData> result = null;

            try
            {
                StudentTypeDA objStudentDA = new StudentTypeDA();
                result = objStudentDA.GetStudenttypeByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteStudentDetailsByID(StudentTypeData objstudent)
        {
            int result = 0;

            try
            {
                StudentTypeDA objstudentDA = new StudentTypeDA();
                result = objstudentDA.DeleteStudentDetailsByID(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        ////////////////////////////////////////////////////////////
        public int UpdateTranportStudentType(StudentTypeData objstudent)
        {
            int result = 0;

            try
            {
                StudentTypeDA objstudentDA = new StudentTypeDA();
                result = objstudentDA.UpdateTranportStudentType(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentTypeData> GetTransportStudenttypeByID(StudentTypeData objstd)
        {
            List<StudentTypeData> result = null;

            try
            {
                StudentTypeDA objStudentDA = new StudentTypeDA();
                result = objStudentDA.GetTransportStudenttypeByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteTransportStudentDetailsByID(StudentTypeData objstudent)
        {
            int result = 0;

            try
            {
                StudentTypeDA objstudentDA = new StudentTypeDA();
                result = objstudentDA.DeleteTransportStudentDetailsByID(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateBoardingStudentType(StudentTypeData objstudent)
        {
            int result = 0;

            try
            {
                StudentTypeDA objstudentDA = new StudentTypeDA();
                result = objstudentDA.UpdateBoardingStudentType(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentTypeData> SearchTransportStudentTypeList(StudentTypeData objstudent)
        {

            List<StudentTypeData> result = null;

            try
            {
                StudentTypeDA objcountryDA = new StudentTypeDA();
                result = objcountryDA.SearchTransportStudentTypeList(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentTypeData> GetBoardingStudenttypeByID(StudentTypeData objstd)
        {
            List<StudentTypeData> result = null;

            try
            {
                StudentTypeDA objStudentDA = new StudentTypeDA();
                result = objStudentDA.GetBoardingStudenttypeByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteBoardingStudentDetailsByID(StudentTypeData objstudent)
        {
            int result = 0;

            try
            {
                StudentTypeDA objstudentDA = new StudentTypeDA();
                result = objstudentDA.DeleteBoardingStudentDetailsByID(objstudent);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StudentTypeData> SearchBoardingStudentTypeList(StudentTypeData objstudent)
        {

            List<StudentTypeData> result = null;

            try
            {
                StudentTypeDA objcountryDA = new StudentTypeDA();
                result = objcountryDA.SearchBoardingStudentTypeList(objstudent);

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
