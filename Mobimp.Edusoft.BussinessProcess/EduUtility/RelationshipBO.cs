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
    public class RelationshipDataBO
    {
        public int UpdateRelationshipDetails(RelationshipData objrelation)
        {
            int result = 0;

            try
            {
                RelationshipDA objrelationDA = new RelationshipDA();
                result = objrelationDA.UpdateRelationshipDetails(objrelation);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<RelationshipData> SearchRelationshipDetails(RelationshipData objrelation)
        {

            List<RelationshipData> result = null;

            try
            {
                RelationshipDA objrelationDA = new RelationshipDA();
                result = objrelationDA.SearchRelationshipDetails(objrelation);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<RelationshipData> GetRelationshipDetailsByID(RelationshipData objrelation)
        {
            List<RelationshipData> result = null;

            try
            {
                RelationshipDA objrelationDA = new RelationshipDA();
                result = objrelationDA.GetRelationshipDetailsByID(objrelation);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteRelationshipDetailsByID(RelationshipData objrelation)
        {
            int result = 0;

            try
            {
                RelationshipDA objrelationDA = new RelationshipDA();
                result = objrelationDA.DeleteRelationshipDetailsByID(objrelation);

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
