using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduInvUtility;
using Mobimp.Edusoft.DataAccess.EduInvUtilityDA;

namespace Mobimp.Edusoft.BussinessProcess.EduInvUtility
{
   public class SubgroupBO
    {
        public int SaveGroup(SubgroupData objclass)
        {
            int result = 0;

            try
            {
                SubgroupDA objclassDA = new SubgroupDA();
                result = objclassDA.SaveSubGroup(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SubgroupData> SearchSubGroup(SubgroupData objclass)
        {
            List<SubgroupData> result = null;
            try
            {
                SubgroupDA objclassDA = new SubgroupDA();
                result = objclassDA.SearchSubGroup(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<SubgroupData> GetSubGroupbyID(SubgroupData objclass)
        {
            List<SubgroupData> result = null;

            try
            {
                SubgroupDA objclassDA = new SubgroupDA();
                result = objclassDA.GetSubGroupbyID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSubGroupbyID(SubgroupData objclass)
        {
            int result = 0;

            try
            {
                SubgroupDA objclassDA = new SubgroupDA();
                result = objclassDA.DeleteSubGroupbyID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Activate(SubgroupData objgrp)
        {
            int result = 0;

            try
            {
                SubgroupDA objstdloyeeDA = new SubgroupDA();
                result = objstdloyeeDA.ActivateSubGroup(objgrp);
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
