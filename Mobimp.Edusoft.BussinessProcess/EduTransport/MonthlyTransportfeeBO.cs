using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Data.EduTransport;
using Mobimp.Edusoft.DataAccess.EduTransport;

namespace Mobimp.Edusoft.BussinessProcess.EduTransport
{
    public class MonthlyTransportfeeBO
    {
        public int UpdateTransportFeesDetails(TransportData objfees)
        {
            int result = 0;

            try
            {
                TransportfeeDA objfeesDA = new TransportfeeDA();
                result = objfeesDA.UpdateTransportFeesDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TransportFeeData> GetTransportFeesDetailsByID(TransportFeeData objfees)
        {
            List<TransportFeeData> result = null;

            try
            {
                TransportfeeDA objfeesDA = new TransportfeeDA();
                result = objfeesDA.GetTransportFeesDetailsByID(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        //public int DeleteTransFeesDetailsByID(TransportFeeData objfees)
        //{
        //    int result = 0;

        //    try
        //    {
        //        TransportfeeDA objfeesDA = new TransportfeeDA();
        //        result = objfeesDA.DeleteTransFeesDetailsByID(objfees);

        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
        //        LogManager.UpdateCmsErrorDetails(ex);
        //        throw new BusinessProcessException("4000001", ex);
        //    }
        //    return result;

        //}
        //public List<TransportFeeData> GetTransportfeedetails(TransportFeeData objfees)
        //{

        //    List<TransportFeeData> result = null;

        //    try
        //    {
        //        TransportfeeDA objfeesDA = new TransportfeeDA();
        //        result = objfeesDA.GetTransportfeedetails(objfees);

        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
        //        LogManager.UpdateCmsErrorDetails(ex);
        //        throw new BusinessProcessException("4000001", ex);
        //    }
        //    return result;

        //}
    }
}
