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
    public class ClassBO
    {
        public int UpdateClassDetails(ClassData objclass)
        {
            int result = 0;

            try
            {
                ClassDA objclassDA = new ClassDA();
                result = objclassDA.UpdateClassDetails(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ClassData> SearchClassDetails(ClassData objclass)
        {
            List<ClassData> result = null;
            try
            {
                ClassDA objclassDA = new ClassDA();
                result = objclassDA.SearchClassDetails(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ClassData> GetClassDetailsByID(ClassData objclass)
        {
            List<ClassData> result = null;

            try
            {
                ClassDA objclassDA = new ClassDA();
                result = objclassDA.GetClassDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteClassDetailsByID(ClassData objclass)
        {
            int result = 0;

            try
            {
                ClassDA objclassDA = new ClassDA();
                result = objclassDA.DeleteClassDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(ClassData objclass)
        {
            int result = 0;

            try
            {
                ClassDA objstdloyeeDA = new ClassDA();
                result = objstdloyeeDA.ActivateClass(objclass);

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
