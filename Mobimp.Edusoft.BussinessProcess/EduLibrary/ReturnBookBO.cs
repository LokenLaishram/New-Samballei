using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduLibrary;
using Mobimp.Edusoft.DataAccess.EduLibrary;

namespace Mobimp.Edusoft.BussinessProcess.EduLibrary
{
    public class ReturnBookBO
    {
        public List<ReturnBookData> GetAutoStudentDetails(ReturnBookData objdata)
        {
            List<ReturnBookData> result = null;

            try
            {
                ReturnBookDA objda= new ReturnBookDA();
                result = objda.GetAutoStudentDetails(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ReturnBookData> GetStudentDetailByID(ReturnBookData objdata)
        {

            List<ReturnBookData> result = null;

            try
            {
                ReturnBookDA objda = new ReturnBookDA();
                result = objda.GetStudentDetailByID(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ReturnBookData> GetBookDetailByID(ReturnBookData objData)
        {

            List<ReturnBookData> result = null;

            try
            {
                ReturnBookDA objDA = new ReturnBookDA();
                result = objDA.GetBookDetailByID(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ReturnBookData> GetAutoBookDetails(ReturnBookData objdata)
        {
            List<ReturnBookData> result = null;

            try
            {
                ReturnBookDA objda = new ReturnBookDA();
                result = objda.GetAutoBookDetails(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<ReturnBookData> SearchBookReturnDetailsbyID(ReturnBookData objlist)
        {

            List<ReturnBookData> result = null;

            try
            {
                ReturnBookDA objDA = new ReturnBookDA();
                result = objDA.SearchBookReturnDetailsbyID(objlist);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateBookReturnDetails(ReturnBookData objdata)
        {
            int result = 0;

            try
            {
                ReturnBookDA objDA = new ReturnBookDA();
                result = objDA.UpdateBookReturnDetails(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<ReturnBookData> SearchBookReturnDetails(ReturnBookData objlist)
        {

            List<ReturnBookData> result = null;

            try
            {
                ReturnBookDA objDA = new ReturnBookDA();
                result = objDA.SearchBookReturnDetails(objlist);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ReturnBookData> SearchReturnBookByIssueNo(ReturnBookData objData)
        {
            List<ReturnBookData> result = null;

            try
            {
                ReturnBookDA objDA = new ReturnBookDA();
                result = objDA.SearchReturnBookByIssueNo(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteBookIssueNo(ReturnBookData objdata)
        {
            int result = 0;
            try
            {
                ReturnBookDA objDA = new ReturnBookDA();
                result = objDA.DeleteBookIssueNo(objdata);
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
