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
    public class SchoolDetailBO
    {
        public int UpdateSchoolDetails(SchoolDetailData objSchool)
        {
            int result = 0;

            try
            {
                SchoolDetailDA objSchoolDetailDA = new SchoolDetailDA();
                result = objSchoolDetailDA.UpdateSchoolDetails(objSchool);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SchoolDetailData> SearchSchoolDetails(SchoolDetailData objSchool)
        {

            List<SchoolDetailData> result = null;

            try
            {
                SchoolDetailDA objSchoolDetailDA = new SchoolDetailDA();
                result = objSchoolDetailDA.SearchSchoolDetails(objSchool);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SchoolDetailData> GetSchoolDetailsByID(SchoolDetailData objSchool)
        {
            List<SchoolDetailData> result = null;

            try
            {
                SchoolDetailDA objSchoolDetailDA = new SchoolDetailDA();
                result = objSchoolDetailDA.GetSchoolDetailsByID(objSchool);

            }
            catch (Exception ex)
            {
              PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSchoolDetailsByID(SchoolDetailData objSchool)
        {
            int result = 0;

            try
            {
                SchoolDetailDA objSchoolDetailDA = new SchoolDetailDA();
                result = objSchoolDetailDA.DeleteSchoolDetailsByID(objSchool);

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
