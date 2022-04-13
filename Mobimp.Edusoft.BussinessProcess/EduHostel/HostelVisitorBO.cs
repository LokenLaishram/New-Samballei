using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Campusoft.DataAccess.EduHostel;

namespace Mobimp.Campusoft.BussinessProcess.EduHostel
{
    public class HostelVisitorBO
    {
        public int UpdateHostelVisitor(HostelVisitorData objreg)
        {
            int result = 0;

            try
            {
                HostelVisitorDA objregDA = new HostelVisitorDA();
                result = objregDA.UpdateHostelVisitor(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HostelVisitorData> SearchHostelVisitor(HostelVisitorData objreg)
        {

            List<HostelVisitorData> result = null;

            try
            {
                HostelVisitorDA objregDA = new HostelVisitorDA();
                result = objregDA.SearchHostelVisitor(objreg);

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
