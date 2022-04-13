using Mobimp.Campusoft.DataAccess.HRAndPayroll.Utility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.EduUtility;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility
{
    public class LeaveTypeBO
    {
        public int UpdateLeaveTypeDetails(LeaveTypeData objDataBO)
        {
            int result = 0;
            try
            {
                LeaveTypeDA objLeaveTypeDA = new LeaveTypeDA();
                result = objLeaveTypeDA.UpdateLeaveTypeDetails(objDataBO);
            }
            catch(Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LeaveTypeData> SearchLeaveTypeDetails(LeaveTypeData ObjLeaveType)
        {
            List<LeaveTypeData> result = null;
            try
            {
                LeaveTypeDA ObjLeaveTypeDA = new LeaveTypeDA();
                result = ObjLeaveTypeDA.SearchLeaveTypeDetails(ObjLeaveType);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<LeaveTypeData> GetLeaveTypeDetailsByID(LeaveTypeData ObjLeaveType)
        {
            List<LeaveTypeData> result = null;

            try
            {
                LeaveTypeDA ObjLeaveTypeDA = new LeaveTypeDA();
                result = ObjLeaveTypeDA.GetLeaveTypeDetailsByID(ObjLeaveType);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public int DeleteLeaveTypeDetailsByID(LeaveTypeData ObjLeaveType)
        {
            int result = 0;

            try
            {
                LeaveTypeDA ObjLeaveTypeDA = new LeaveTypeDA();
                result = ObjLeaveTypeDA.DeleteLeaveTypeDetailsByID(ObjLeaveType);

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
