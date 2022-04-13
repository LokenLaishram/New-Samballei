using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
    public class SubjectBO
    {
        public int UpdateSubjectDetails(SubjectData objsubject)
        {
            int result = 0;

            try
            {
                SubjectDA objsubjectDA = new SubjectDA();
                result = objsubjectDA.UpdateSubjectDetails(objsubject);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateSubjectList(SubjectData objstd)
        {
            int result = 0;

            try
            {
                SubjectDA objstdloyeeDA = new SubjectDA();
                result = objstdloyeeDA.UpdateSubjectList(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<SubjectData> SearchSubjectDetails(SubjectData objsubject)
        {

            List<SubjectData> result = null;

            try
            {
                SubjectDA objsubjectDA = new SubjectDA();
                result = objsubjectDA.SearchSubjectDetails(objsubject);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SubjectData> GetClasswiseSubjectList(SubjectData objsubject)
        {

            List<SubjectData> result = null;

            try
            {
                SubjectDA objsubjectDA = new SubjectDA();
                result = objsubjectDA.GetClasswiseSubjectList(objsubject);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }


        public List<SubjectData> GetSubjectDetailsByID(SubjectData objsubject)
        {
            List<SubjectData> result = null;

            try
            {
                SubjectDA objsubjectDA = new SubjectDA();
                result = objsubjectDA.GetSubjectDetailsByID(objsubject);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSubjectDetailsByID(SubjectData objsubject)
        {
            int result = 0;

            try
            {
                SubjectDA objsubjectDA = new SubjectDA();
                result = objsubjectDA.DeleteSubjectDetailsByID(objsubject);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int AcitvateSubject(SubjectData objsub)
        {
            int result = 0;

            try
            {
                SubjectDA objstdloyeeDA = new SubjectDA();
                result = objstdloyeeDA.Activatesub(objsub);

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
