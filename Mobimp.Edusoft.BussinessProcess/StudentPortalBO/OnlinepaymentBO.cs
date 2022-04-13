using Mobimp.Campusoft.Data.StudentPortal;
using Mobimp.Campusoft.DataAccess.StudentPortalDA;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.BussinessProcess.StudentPortalBO
{
    public class OnlinepaymentBO
    {
        public List<PaymentData> Getfeepaymentdetails(PaymentData obj)
        {
            List<PaymentData> result = null;
            try
            {
                OnlinepaymentDA ObjDA = new OnlinepaymentDA();
                result = ObjDA.Getfeepaymentdetails(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Payfee(PaymentData obj)
        {
            int result = 0;

            try
            {
                OnlinepaymentDA ObjDA = new OnlinepaymentDA();
                result = ObjDA.Payfee(obj);
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
