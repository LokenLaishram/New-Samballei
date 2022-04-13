using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.DataAccess.EduInventory;

namespace Mobimp.Edusoft.BussinessProcess.EduInventory
{
    public class IndentGenerationBO
    {
        public List<IndentGenerationData> GetAutoAllVendorNameByVendorType(IndentGenerationData objstd)
        {

            List<IndentGenerationData> result = null;

            try
            {
                IndentGenerationDA objDA = new IndentGenerationDA();
                result = objDA.GetAutoAllVendorNameByVendorType(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<IndentGenerationData> SaveIndentGeneration(IndentGenerationData objtran)
        {
            List<IndentGenerationData> result = null;
            try
            {
                IndentGenerationDA objDA = new IndentGenerationDA();
                result = objDA.SaveIndentGeneration(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentGenerationData> GetVendorDetailsByID(IndentGenerationData objtran)
        {
            List<IndentGenerationData> result = null;
            try
            {
                IndentGenerationDA objDA = new IndentGenerationDA();
                result = objDA.GetVendorDetailsByID(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentGenerationData> GetAutoItembySubGroupid(IndentGenerationData objtran)
        {
            List<IndentGenerationData> result = null;
            try
            {
                IndentGenerationDA objDA = new IndentGenerationDA();
                result = objDA.GetAutoItembySubGroupid(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentGenerationData> GetItemDetailsByID(IndentGenerationData objtran)
        {
            List<IndentGenerationData> result = null;
            try
            {
                IndentGenerationDA objDA = new IndentGenerationDA();
                result = objDA.GetItemDetailsByID(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentGenerationData> GetItemDetailsBySubGroup(IndentGenerationData objtran)
        {
            List<IndentGenerationData> result = null;
            try
            {
                IndentGenerationDA objDA = new IndentGenerationDA();
                result = objDA.GetItemDetailsBySubGroup(objtran);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        //---Tab2---//
        public List<IndentGenerationData> SearchIndentDetailsList(IndentGenerationData obj)
        {
            List<IndentGenerationData> result = null;
            try
            {
                IndentGenerationDA objUserAdminDA = new IndentGenerationDA();
                result = objUserAdminDA.SearchIndentDetailsList(obj);
            }
            catch (Exception ex) //Exception of the layer(itself)/unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<IndentGenerationData> SearchChildIndentDetails(IndentGenerationData objdata)
        {
            List<IndentGenerationData> result = null;
            try
            {
                IndentGenerationDA Objda = new IndentGenerationDA();
                result = Objda.SearchChildIndentDetails(objdata);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteIndentGenbyIndentNo(IndentGenerationData obj)
        {
            int result = 0;

            try
            {
                IndentGenerationDA objDA = new IndentGenerationDA();
                result = objDA.DeleteIndentGenbyIndentNo(obj);

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
