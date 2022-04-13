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
   public class SalutationBO
   {
       public int UpdateSalutationDetails(SalutationData objSalutation)
       {
           int result = 0;

           try
           {
               SalutationDA objSalutationDA = new SalutationDA();
               result = objSalutationDA.UpdateSalutaionDetails(objSalutation);

           }
           catch (Exception ex)
           {
             PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
               LogManager.UpdateCmsErrorDetails(ex);
               throw new BusinessProcessException("4000001", ex);
           }
           return result;

       }
       public List<SalutationData> SearchSalutationDetails(SalutationData objSalutation)
       {

           List<SalutationData> result = null;

           try
           {
               SalutationDA objSalutationDA = new SalutationDA();
               result = objSalutationDA.SearchSalutaionDetails(objSalutation);

           }
           catch (Exception ex)
           {
             PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
               LogManager.UpdateCmsErrorDetails(ex);
               throw new BusinessProcessException("4000001", ex);
           }
           return result;

       }
       public List<SalutationData> GetSalutationDetailsByID(SalutationData objSalutation)
       {
           List<SalutationData> result = null;

           try
           {
               SalutationDA objSalutationDA = new SalutationDA();
               result = objSalutationDA.GetSalutaionDetailsByID(objSalutation);

           }
           catch (Exception ex)
           {
             PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
               LogManager.UpdateCmsErrorDetails(ex);
               throw new BusinessProcessException("4000001", ex);
           }
           return result;

       }
       public int DeleteSalutationDetailsByID(SalutationData objSalutation)
       {
           int result = 0;

           try
           {
               SalutationDA objSalutationDA = new SalutationDA();
               result = objSalutationDA.DeleteSalutaionDetailsByID(objSalutation);

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
