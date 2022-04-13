using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

using Mobimp.Campusoft.Data.EduHostel;
using Mobimp.Campusoft.DataAccess.EduHostel;
using Mobimp.Edusoft.Data.EduStudent;

namespace Mobimp.Campusoft.BussinessProcess.EduHostel
{
    public class HostelRegistrationBO
    {
        //public List<StudentData> GetHostelstudentDetailByID(StudentData objstd)
        //{

        //    List<StudentData> result = null;

        //    try
        //    {
        //        HostelRegistrationDA objstdloyeeDA = new HostelRegistrationDA();
        //        result = objstdloyeeDA.GetHostelstudentDetailByID(objstd);

        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
        //        LogManager.UpdateCmsErrorDetails(ex);
        //        throw new BusinessProcessException("4000001", ex);
        //    }
        //    return result;

        //}
        public List<HostelRegistrationData> GetHostelstudentDetailByID(HostelRegistrationData objstd)
        {

            List<HostelRegistrationData> result = null;

            try
            {
                HostelRegistrationDA objstdloyeeDA = new HostelRegistrationDA();
                result = objstdloyeeDA.GetHostelstudentDetailByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HostelRegistrationData> GetStudentID(HostelRegistrationData objemp)
        {

            List<HostelRegistrationData> result = null;

            try
            {
                HostelRegistrationDA objEmployeeDA = new HostelRegistrationDA();
                result = objEmployeeDA.GetStudentID(objemp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HostelRegistrationData> GetstudentDetailByID(HostelRegistrationData objstd)
        {

            List<HostelRegistrationData> result = null;

            try
            {
                HostelRegistrationDA objstdloyeeDA = new HostelRegistrationDA();
                result = objstdloyeeDA.GetstudentDetailByID(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int UpdateHostelRegistration(HostelRegistrationData objreg)
        {
            int result = 0;

            try
            {
                HostelRegistrationDA objregDA = new HostelRegistrationDA();
                result = objregDA.UpdateHostelRegistration(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HostelRegistrationData> SearchHostelRegistration(HostelRegistrationData objreg)
        {

            List<HostelRegistrationData> result = null;

            try
            {
                HostelRegistrationDA objregDA = new HostelRegistrationDA();
                result = objregDA.SearchHostelRegistration(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HostelRegistrationData> GetHostelRegistrationByID(HostelRegistrationData objreg)
        {
            List<HostelRegistrationData> result = null;

            try
            {
                HostelRegistrationDA objregDA = new HostelRegistrationDA();
                result = objregDA.GetHostelRegistrationByID(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteHostelRegistrationByID(HostelRegistrationData objreg)
        {
            int result = 0;

            try
            {
                HostelRegistrationDA objregDA = new HostelRegistrationDA();
                result = objregDA.DeleteHostelRegistrationByID(objreg);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HostelRegistrationData> SearchHostelStudentDetails(HostelRegistrationData objreg)
        {

            List<HostelRegistrationData> result = null;

            try
            {
                HostelRegistrationDA objregDA = new HostelRegistrationDA();
                result = objregDA.SearchHostelStudentDetails(objreg);

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
