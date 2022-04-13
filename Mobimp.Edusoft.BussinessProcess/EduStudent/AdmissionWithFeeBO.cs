using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.DataAccess.EduStudent;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduStudent
{
    public class AdmissionWithFeeBO
    {
        public List<AdmissionWithFeeData> GetAvailableStudentID(AdmissionWithFeeData objstudentData)
        {

            List<AdmissionWithFeeData> result = null;

            try
            {
                AdmissionWithFeeDA objstudentDA = new AdmissionWithFeeDA();
                result = objstudentDA.GetAvailableStudentID(objstudentData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentDetails(AdmissionWithFeeData objstd)
        {
            int result = 0;

            try
            {
                AdmissionWithFeeDA objstdloyeeDA = new AdmissionWithFeeDA();
                result = objstdloyeeDA.UpdateStudentDetails(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

     //////// Fees Part
        public List<AdmFeeData> getfeedetailsBystudenttypeID(AdmFeeData objfees)
        {
            List<AdmFeeData> result = null;
            try
            {
                AdmissionWithFeeDA objfeesloyeeDA = new AdmissionWithFeeDA();
                result = objfeesloyeeDA.getfeedetailsBystudenttypeID(objfees);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateAdmissionFeeDetails(AdmFeeData objfees)
        {
            int result = 0;

            try
            {
                AdmissionWithFeeDA objfeesDA = new AdmissionWithFeeDA();
                result = objfeesDA.UpdateAdmissionFeeDetails(objfees);

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
