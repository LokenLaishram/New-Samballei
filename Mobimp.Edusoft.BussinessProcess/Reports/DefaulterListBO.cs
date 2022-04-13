using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Reports;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.DataAccess.Reports;

namespace Mobimp.Edusoft.BussinessProcess.Reports
{
    public class DefaulterListBO
    {

        public List<DefaulterListData> CreateDefaulterlist(DefaulterListData objfees)
        {

            List<DefaulterListData> result = null;

            try
            {
                DefaulterListDA objdefaulteeDA = new DefaulterListDA();
                result = objdefaulteeDA.CreateDefaulterlist(objfees);

            }
            catch (Exception ex)
            {
               PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DefaulterListData> Getdefaulterlist(DefaulterListData objfees)
        {

            List<DefaulterListData> result = null;

            try
            {
                DefaulterListDA objdefaulteeDA = new DefaulterListDA();
                result = objdefaulteeDA.Getdefaulterlist(objfees);

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
