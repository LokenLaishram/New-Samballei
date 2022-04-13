using Mobimp.Campusoft.Data.EduUtility;
using Mobimp.Campusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.BussinessProcess.EduUtility
{
    public class ClasswiseSubjectBO
    {
        public int UpdateSubjectDetails(ClasswiseSubjectData objsubject)
        {
            int result = 0;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
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
        public int AddSubSubjectDetails(ClasswiseSubjectData objsubject)
        {
            int result = 0;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.AddSubSubjectDetails(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateSubSubjectDetails(ClasswiseSubjectData objsubject)
        {
            int result = 0;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.UpdateSubSubjectDetails(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateSubjectList(ClasswiseSubjectData objstd)
        {
            int result = 0;

            try
            {
                ClasswiseSubjectDA objstdloyeeDA = new ClasswiseSubjectDA();
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

        public List<ClasswiseSubjectData> SearchClasswiseSubjectDetails(ClasswiseSubjectData objsubject)
        {

            List<ClasswiseSubjectData> result = null;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.SearchClasswiseSubjectDetails(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ClasswiseSubjectData> GetclasswiseSubsubjectlist(ClasswiseSubjectData objsubject)
        {

            List<ClasswiseSubjectData> result = null;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.GetclasswiseSubsubjectlist(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ClasswiseSubjectData> SearchClasswiseSubSubjectDetails(ClasswiseSubjectData objsubject)
        {

            List<ClasswiseSubjectData> result = null;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.SearchClasswiseSubSubjectDetails(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ClasswiseSubjectData> GetClasswiseSubjectList(ClasswiseSubjectData objsubject)
        {

            List<ClasswiseSubjectData> result = null;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
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
        public List<ClasswiseSubjectData> GetClasswiseSubjectDetailsByID(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.GetClasswiseSubjectDetailsByID(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ClasswiseSubjectData> GetsubsubjectbyID(ClasswiseSubjectData objsubject)
        {
            List<ClasswiseSubjectData> result = null;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.GetsubsubjectbyID(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteClasswiseSubjectDetailsByID(ClasswiseSubjectData objsubject)
        {
            int result = 0;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.DeleteClasswiseSubjectDetailsByID(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSubsubjectByID(ClasswiseSubjectData objsubject)
        {
            int result = 0;

            try
            {
                ClasswiseSubjectDA objsubjectDA = new ClasswiseSubjectDA();
                result = objsubjectDA.DeleteSubsubjectByID(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int AcitvateSubject(ClasswiseSubjectData objsub)
        {
            int result = 0;

            try
            {
                ClasswiseSubjectDA objstdloyeeDA = new ClasswiseSubjectDA();
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
