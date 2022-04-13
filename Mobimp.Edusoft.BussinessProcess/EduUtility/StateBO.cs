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
    public class StateBO
    {
        public int UpdateStateDetails(StateData objstate)
        {
            int result = 0;

            try
            {
                StateDA objstateDA = new StateDA();
                result = objstateDA.UpdateStateDetails(objstate);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StateData> SearchStateDetails(StateData objstate)
        {

            List<StateData> result = null;

            try
            {
                StateDA objstateDA = new StateDA();
                result = objstateDA.SearchStateDetails(objstate);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<StateData> GetStateDetailsByID(StateData objstate)
        {
            List<StateData> result = null;

            try
            {
                StateDA objstateDA = new StateDA();
                result = objstateDA.GetStateDetailsByID(objstate);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteStateDetailsByID(StateData objstate)
        {
            int result = 0;

            try
            {
                StateDA objstateDA = new StateDA();
                result = objstateDA.DeleteStateDetailsByID(objstate);

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
