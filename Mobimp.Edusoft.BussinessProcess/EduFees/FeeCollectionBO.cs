using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.DataAccess.EduFees;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;

namespace Mobimp.Edusoft.BussinessProcess.EduFees
{
    public class FeeCollectionBO
    {
        //////////////////SCHOOLFEESCOLLECTION///////////////////
        public List<FeeCollectionData> GetClasswiseFeesDetail(FeeCollectionData objstudentData)
        {

            List<FeeCollectionData> result = null;

            try
            {
                FeeCollectionDA objstudentDA = new FeeCollectionDA();
                result = objstudentDA.GetClasswiseFeesDetail(objstudentData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeeCollectionData> GetClasswiseDueFeesDetail(FeeCollectionData objstudentData)
        {

            List<FeeCollectionData> result = null;

            try
            {
                FeeCollectionDA objstudentDA = new FeeCollectionDA();
                result = objstudentDA.GetClasswiseDueFeesDetail(objstudentData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeepaymentData> Payfee_newstudents(FeepaymentData obj)
        {
            List<FeepaymentData> result = null;

            try
            {
                FeeCollectionDA ObjDA = new FeeCollectionDA();
                result = ObjDA.Payfee_newstudents(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<FeepaymentData> Getfeepaymentdetails_newregister_student(FeepaymentData obj)
        {
            List<FeepaymentData> result = null;
            try
            {
                FeeCollectionDA ObjDA = new FeeCollectionDA();
                result = ObjDA.Getfeepaymentdetails_newregister_student(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentFeeDetails(FeeCollectionData objfees)
        {
            int result = 0;

            try
            {
                FeeCollectionDA objfeesDA = new FeeCollectionDA();
                result = objfeesDA.UpdateStudentFeeDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateStudentDueFeeDetails(FeeCollectionData objfees)
        {
            int result = 0;

            try
            {
                FeeCollectionDA objfeesDA = new FeeCollectionDA();
                result = objfeesDA.UpdateStudentDueFeeDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeeCollectionData> SearchSchoolFeeDetailsList(FeeCollectionData objfees)
        {

            List<FeeCollectionData> result = null;

            try
            {
                FeeCollectionDA objfeesloyeeDA = new FeeCollectionDA();
                result = objfeesloyeeDA.SearchSchoolFeeDetailsList(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeeCollectionData> SearchChildDetailByNo(FeeCollectionData objitemData)
        {
            List<FeeCollectionData> result = null;

            try
            {
                FeeCollectionDA objitemDA = new FeeCollectionDA();
                result = objitemDA.SearchChildDetailByNo(objitemData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteSchoolFeesByID(FeeCollectionData objfees)
        {
            int result = 0;
            try
            {
                FeeCollectionDA objfeesloyeeDA = new FeeCollectionDA();
                result = objfeesloyeeDA.DeleteSchoolFeesByID(objfees);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        //////////////////////////tap5//////////////////////////////
        public List<FeeCollectionData> SearchDuecollectionListtap5(FeeCollectionData objfees)
        {

            List<FeeCollectionData> result = null;

            try
            {
                FeeCollectionDA objfeesloyeeDA = new FeeCollectionDA();
                result = objfeesloyeeDA.SearchDuecollectionListtap5(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteSchoolFeesByIDtap5(FeeCollectionData objfees)
        {
            int result = 0;
            try
            {
                FeeCollectionDA objfeesloyeeDA = new FeeCollectionDA();
                result = objfeesloyeeDA.DeleteSchoolFeesByIDtap5(objfees);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<FeeCollectionData> SearchChildDetailByNotap5(FeeCollectionData objitemData)
        {
            List<FeeCollectionData> result = null;

            try
            {
                FeeCollectionDA objitemDA = new FeeCollectionDA();
                result = objitemDA.SearchChildDetailByNotap5(objitemData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<FeeCollectionData> GetStudentFeeListoexcel(FeeCollectionData objstd)
        {

            List<FeeCollectionData> result = null;

            try
            {
                FeeCollectionDA objstdloyeeDA = new FeeCollectionDA();
                result = objstdloyeeDA.GetStudentFeeListoexcel(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeepaymentData> Getfeepaymentdetails(FeepaymentData obj)
        {
            List<FeepaymentData> result = null;
            try
            {
                FeeCollectionDA ObjDA = new FeeCollectionDA();
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
        public int Payfee(FeepaymentData obj)
        {
            int result = 0;

            try
            {
                FeeCollectionDA ObjDA = new FeeCollectionDA();
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
        public List<FeeStatusData> Getfeepamentlist(FeeStatusData obj)
        {
            List<FeeStatusData> result = null;
            try
            {
                FeeCollectionDA ObjDA = new FeeCollectionDA();
                result = ObjDA.Getfeepamentlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<FeeStatusData> Getdefaulterlist(FeeStatusData obj)
        {
            List<FeeStatusData> result = null;
            try
            {
                FeeCollectionDA ObjDA = new FeeCollectionDA();
                result = ObjDA.Getdefaulterlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteBill(FeeStatusData objfees)
        {
            int result = 0;
            try
            {
                FeeCollectionDA objfeesloyeeDA = new FeeCollectionDA();
                result = objfeesloyeeDA.DeleteBill(objfees);
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
