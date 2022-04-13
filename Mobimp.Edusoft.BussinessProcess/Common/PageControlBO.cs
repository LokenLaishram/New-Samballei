using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediqura.DAL.CommonDA;
using Mobimp.Campusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mediqura.BOL.CommonBO
{
    public class PageControlBO
    {
        public List<PageControlsData> GetControlList(PageControlsData objcontrols)
        {
            List<PageControlsData> controlist = null;
            try
            {
                PageControlDA objcontrolDA = new PageControlDA();
                List<PageControlsData> controls = objcontrolDA.GetControlList(objcontrols);
                controlist = controls;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return controlist;
        }
        public List<PageControlsData> GetControlEnabledetails(PageControlsData objcontrols)
        {
            List<PageControlsData> controlist = null;
            try
            {
                PageControlDA objcontrolDA = new PageControlDA();
                List<PageControlsData> controls = objcontrolDA.GetControlEnabledetails(objcontrols);
                controlist = controls;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return controlist;
        }
        public List<PageControlsData> GetPageurls(PageControlsData objcontrols)
        {
            List<PageControlsData> controlist = null;
            try
            {
                PageControlDA objcontrolDA = new PageControlDA();
                List<PageControlsData> controls = objcontrolDA.GetPageurls(objcontrols);
                controlist = controls;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return controlist;
        }
        public int Updatepagecontrols(PageControlsData objcontrols)
        {
            int result = 0;
            try
            {
                PageControlDA objcontrolDA = new PageControlDA();
                result = objcontrolDA.Updatepagecontrols(objcontrols);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
    }
}
