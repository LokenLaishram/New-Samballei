using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Campusoft.Data.EduTransport;
using Mobimp.Campusoft.DataAccess.EduTransport;
using Mobimp.Edusoft.Data.EduStudent;

namespace Mobimp.Campusoft.BussinessProcess.EduTransport
{
    public class TransportRegistrationBO
    {
        public List<StudentData> GetTransportstudentDetailByID(StudentData objstd)
        {

            List<StudentData> result = null;

            try
            {
                TransportRegistrationDA objstdloyeeDA = new TransportRegistrationDA();
                result = objstdloyeeDA.GetTransportstudentDetailByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateTransportRegistration(TransportData objreg)
        {
            int result = 0;
            try
            {
                TransportRegistrationDA objregDA = new TransportRegistrationDA();
                result = objregDA.UpdateTransportRegistration(objreg);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TransportData> SearchTransportRegistration(TransportData objreg)
        {

            List<TransportData> result = null;

            try
            {
                TransportRegistrationDA objregDA = new TransportRegistrationDA();
                result = objregDA.SearchTransportRegistration(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TransportData> SearchMonthlyTransportFee(TransportData objreg)
        {

            List<TransportData> result = null;

            try
            {
                TransportRegistrationDA objregDA = new TransportRegistrationDA();
                result = objregDA.SearchMonthlyTransportFee(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TransportData> GetTransportRegistrationByID(TransportData objreg)
        {
            List<TransportData> result = null;

            try
            {
                TransportRegistrationDA objregDA = new TransportRegistrationDA();
                result = objregDA.GetTransportRegistrationByID(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteTransportRegistrationByID(TransportData objreg)
        {
            int result = 0;

            try
            {
                TransportRegistrationDA objregDA = new TransportRegistrationDA();
                result = objregDA.DeleteTransportRegistrationByID(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int SaveActivationDate(TransportData objstd)
        {
            int result = 0;

            try
            {
                TransportRegistrationDA objstdloyeeDA = new TransportRegistrationDA();
                result = objstdloyeeDA.SaveActivationDate(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateMonthlyTransportFee(TransportData ObjData)
        {
            int result = 0;

            try
            {
                TransportRegistrationDA objstdloyeeDA = new TransportRegistrationDA();
                result = objstdloyeeDA.UpdateMonthlyTransportFee(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TransportData> SearchTransportMonthlyFeeSetting(TransportData objdata)
        {

            List<TransportData> result = null;

            try
            {
                TransportRegistrationDA objdataDA = new TransportRegistrationDA();
                result = objdataDA.SearchTransportMonthlyFeeSetting(objdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateTransportMonthlyFeeSetting(TransportData ObjData)
        {
            int result = 0;

            try
            {
                TransportRegistrationDA objstdloyeeDA = new TransportRegistrationDA();
                result = objstdloyeeDA.UpdateTransportMonthlyFeeSetting(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<TransportData> SearchTransportStudentDetails(TransportData objstd)
        {

            List<TransportData> result = null;

            try
            {
                TransportRegistrationDA objtranDA = new TransportRegistrationDA();
                result = objtranDA.SearchTransportStudentDetails(objstd);

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
