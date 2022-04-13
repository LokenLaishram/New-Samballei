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
    public class RackGroupBO
    {
        public int UpdateRackGroupDetails(RackGroupData objgrp)
        {
            int result = 0;

            try
            {
                RackGroupDA objgrpDA = new RackGroupDA();
                result = objgrpDA.UpdateRackGroupDetails(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RackGroupData> SearchRackGroupDetails(RackGroupData objgrp)
        {
            List<RackGroupData> result = null;
            try
            {
                RackGroupDA objgrpDA = new RackGroupDA();
                result = objgrpDA.SearchRackGroupDetails(objgrp);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RackGroupData> GetRackGroupDetailsByID(RackGroupData objgrp)
        {
            List<RackGroupData> result = null;

            try
            {
                RackGroupDA objgrpDA = new RackGroupDA();
                result = objgrpDA.GetRackGroupDetailsByID(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteRackGroupDetailsByID(RackGroupData objgrp)
        {
            int result = 0;

            try
            {
                RackGroupDA objgrpDA = new RackGroupDA();
                result = objgrpDA.DeleteRackGroupDetailsByID(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(RackGroupData objgrp)
        {
            int result = 0;

            try
            {
                RackGroupDA objstdloyeeDA = new RackGroupDA();
                result = objstdloyeeDA.ActivateRackGroup(objgrp);

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
