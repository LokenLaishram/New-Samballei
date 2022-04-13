using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.HR;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR
{
    public class ManualAttendanceBO
    {
        public List<ManualAttendanceData> GetAttendanceDetails(ManualAttendanceData objData)
        {
            List<ManualAttendanceData> result = null;

            try
            {
                ManualAttendanceDA objDA = new ManualAttendanceDA();
                result = objDA.GetAttendanceDetails(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateAttendanceDetails(ManualAttendanceData objData)
        {
            int result = 0;

            try
            {
                ManualAttendanceDA objDA = new ManualAttendanceDA();
                result = objDA.UpdateAttendanceDetails(objData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }


        //-------------------------------------END MANUAL ATTENDANCE----------------------------------

        //-------------------------------------START ATTENDANCE DASHBOARD---------------------------------

        public List<ManualAttendanceData> GetAttendanceDashboard(ManualAttendanceData objData)
        {
            List<ManualAttendanceData> result = null;

            try
            {
                ManualAttendanceDA objDA = new ManualAttendanceDA();
                result = objDA.GetAttendanceDashboard(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        //-------------------------------------END ATTENDANCE DASHBOARD---------------------------------


        //-------------------------------------START ADMIN ATTENDANCE DASHBOARD---------------------------------

        public List<ManualAttendanceData> GetEmployeeName(ManualAttendanceData ObjData)
        {
            List<ManualAttendanceData> result = null;
            try
            {
                ManualAttendanceDA ObjDA = new ManualAttendanceDA();
                result = ObjDA.GetEmployeeName(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<ManualAttendanceData> GetPreviewAttendanceDashboard(ManualAttendanceData objData)
        {
            List<ManualAttendanceData> result = null;

            try
            {
                ManualAttendanceDA objDA = new ManualAttendanceDA();
                result = objDA.GetPreviewAttendanceDashboard(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateAttendance(ManualAttendanceData objData)
        {
            int result = 0;

            try
            {
                ManualAttendanceDA objDA = new ManualAttendanceDA();
                result = objDA.UpdateAttendance(objData);
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
