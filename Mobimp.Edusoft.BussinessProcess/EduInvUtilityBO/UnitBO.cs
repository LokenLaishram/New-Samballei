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
    public class UnitBO
    {
        public int UpdateUnitDetails(UnitData objclass)
        {
            int result = 0;

            try
            {
                UnitDA objclassDA = new UnitDA();
                result = objclassDA.UpdateUnitDetails(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<UnitData> SearchUnitDetails(UnitData objclass)
        {
            List<UnitData> result = null;
            try
            {
                UnitDA objclassDA = new UnitDA();
                result = objclassDA.SearchUnitDetails(objclass);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<UnitData> GetUnitDetailsByID(UnitData objclass)
        {
            List<UnitData> result = null;

            try
            {
                UnitDA objclassDA = new UnitDA();
                result = objclassDA.GetUnitDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteUnitDetailsByID(UnitData objclass)
        {
            int result = 0;

            try
            {
                UnitDA objclassDA = new UnitDA();
                result = objclassDA.DeleteUnitDetailsByID(objclass);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Activate(UnitData objgrp)
        {
            int result = 0;

            try
            {
                UnitDA objstdloyeeDA = new UnitDA();
                result = objstdloyeeDA.Activate(objgrp);
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
