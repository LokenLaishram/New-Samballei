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
    public class RackSubGroupBO
    {
        public int UpdateRackSubGroupDetails(RackSubGroupData objgrp)
        {
            int result = 0;

            try
            {
                RackSubGroupDA objgrpDA = new RackSubGroupDA();
                result = objgrpDA.UpdateRackSubGroupDetails(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RackSubGroupData> SearchRackSubGroupDetails(RackSubGroupData objgrp)
        {
            List<RackSubGroupData> result = null;
            try
            {
                RackSubGroupDA objgrpDA = new RackSubGroupDA();
                result = objgrpDA.SearchRackSubGroupDetails(objgrp);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RackSubGroupData> GetRackSubGroupDetailsByID(RackSubGroupData objgrp)
        {
            List<RackSubGroupData> result = null;

            try
            {
                RackSubGroupDA objgrpDA = new RackSubGroupDA();
                result = objgrpDA.GetRackSubGroupDetailsByID(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteRackSubGroupDetailsByID(RackSubGroupData objgrp)
        {
            int result = 0;

            try
            {
                RackSubGroupDA objgrpDA = new RackSubGroupDA();
                result = objgrpDA.DeleteRackSubGroupDetailsByID(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(RackSubGroupData objgrp)
        {
            int result = 0;

            try
            {
                RackSubGroupDA objstdloyeeDA = new RackSubGroupDA();
                result = objstdloyeeDA.ActivateRackSubGroup(objgrp);

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
