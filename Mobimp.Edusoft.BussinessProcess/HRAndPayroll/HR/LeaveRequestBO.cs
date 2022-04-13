using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.HR;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR
{
    public class LeaveRequestBO
    {
        public List<LeaveRequestData> GetLeaveRequestDetail (LeaveRequestData objData)
        {
            List<LeaveRequestData> result = null;

            try
            {
                LeaveRequestDA objDA = new LeaveRequestDA();
                result = objDA.GetLeaveRequestDetails(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LeaveRequestData> InsertLeaveRequestDetails (LeaveRequestData objData)
        {
            List<LeaveRequestData> result = null;

            try
            {
                LeaveRequestDA objLeaveRequest = new LeaveRequestDA();
                result = objLeaveRequest.InsertLeaveRequestDetails(objData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int UpdateLeaveApproval(LeaveRequestData objData)
        {
            int result = 0;

            try
            {
                LeaveRequestDA objLeaveRequest = new LeaveRequestDA();
                result = objLeaveRequest.UpdateLeaveApproval(objData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LeaveRequestData> GetLeaveRequestList (LeaveRequestData requestData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                LeaveRequestDA RequestList = new LeaveRequestDA();
                result = RequestList.SearchRequestList(requestData);
            }
            catch(Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LeaveRequestData> GetleavedetailbyLRNo(LeaveRequestData requestData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                LeaveRequestDA RequestList = new LeaveRequestDA();
                result = RequestList.GetleavedetailbyLRNo(requestData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteLeaveRequestDetailsByLRNo(LeaveRequestData requestdata)
        {
            int result = 0;

            try
            {
                LeaveRequestDA requestDA = new LeaveRequestDA();
                result = requestDA.DeleteLeaveRequestDetailsByLRNo(requestdata);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LeaveRequestData> GetChildLeaveRequest (LeaveRequestData requestData)
        {
            List<LeaveRequestData> result = null;
            try
            {
                LeaveRequestDA requestDA = new LeaveRequestDA();
                result = requestDA.GetChildLeaveRequest(requestData);
            }
            catch(Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteChildGridRequestList(LeaveRequestData requestdata)
        {
            int result = 0;

            try
            {
                LeaveRequestDA requestDA = new LeaveRequestDA();
                result = requestDA.DeleteChildGridRequestList(requestdata);

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
