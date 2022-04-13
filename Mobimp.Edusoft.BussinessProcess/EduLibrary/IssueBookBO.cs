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
    public class IssueBookBO
    {
        public List<IssueBookData> GetAutoStudentDetails(IssueBookData objdata)
        {
            List<IssueBookData> result = null;

            try
            {
                IssueBookDA objda= new IssueBookDA();
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
        public List<IssueBookData> GetStudentDetailByID(IssueBookData objdata)
        {

            List<IssueBookData> result = null;

            try
            {
                IssueBookDA objda = new IssueBookDA();
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
        public List<IssueBookData> GetBookDetailByID(IssueBookData objData)
        {

            List<IssueBookData> result = null;

            try
            {
                IssueBookDA objDA = new IssueBookDA();
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
        public List<IssueBookData> GetAutoBookDetails(IssueBookData objdata)
        {
            List<IssueBookData> result = null;

            try
            {
                IssueBookDA objda = new IssueBookDA();
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

        public int UpdateBookIssueDetails(IssueBookData objdata)
        {
            int result = 0;

            try
            {
                IssueBookDA objDA = new IssueBookDA();
                result = objDA.UpdateBookIssueDetails(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IssueBookData> SearchBookIssueDetails(IssueBookData objlist)
        {

            List<IssueBookData> result = null;

            try
            {
                IssueBookDA objDA = new IssueBookDA();
                result = objDA.SearchBookIssueDetails(objlist);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IssueBookData> SearchIssueBookByIssueNo(IssueBookData objData)
        {
            List<IssueBookData> result = null;

            try
            {
                IssueBookDA objDA = new IssueBookDA();
                result = objDA.SearchIssueBookByIssueNo(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteBookIssueNo(IssueBookData objdata)
        {
            int result = 0;
            try
            {
                IssueBookDA objDA = new IssueBookDA();
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
