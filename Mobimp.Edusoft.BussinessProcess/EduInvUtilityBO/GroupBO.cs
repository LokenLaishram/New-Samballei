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
    public class GroupBO
    {
        public int SaveGroup(GroupData objGroup)
        {
            int result = 0;

            try
            {
                GroupDA objGroupDA = new GroupDA();
                result = objGroupDA.SaveGroup(objGroup);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<GroupData> SearchGroup(GroupData objGroup)
        {
            List<GroupData> result = null;
            try
            {
                GroupDA objGroupDA = new GroupDA();
                result = objGroupDA.SearchGroup(objGroup);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<GroupData> GetGroupbyID(GroupData objGroup)
        {
            List<GroupData> result = null;

            try
            {
                GroupDA objGroupDA = new GroupDA();
                result = objGroupDA.GetGroupbyID(objGroup);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteGroupbyID(GroupData objGroup)
        {
            int result = 0;

            try
            {
                GroupDA objGroupDA = new GroupDA();
                result = objGroupDA.DeleteGroupbyID(objGroup);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Activate(GroupData objgrp)
        {
            int result = 0;

            try
            {
                GroupDA objstdloyeeDA = new GroupDA();
                result = objstdloyeeDA.ActivateGroup(objgrp);
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
