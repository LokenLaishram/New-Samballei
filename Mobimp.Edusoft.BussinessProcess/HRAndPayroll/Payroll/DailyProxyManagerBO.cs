using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.Data.HRAndPayroll.Payroll;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.Payroll;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Payroll
{
    public class DailyProxyManagerBO
    {
        public List<DailyProxyManagerData> GetEmployeeName(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                DailyProxyManagerDA ObjDA = new DailyProxyManagerDA();
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

        public List<DailyProxyManagerData> GetEmployeeDetailsByID(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                DailyProxyManagerDA ObjDA = new DailyProxyManagerDA();
                result = ObjDA.GetEmployeeDetailsByID(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateDailyProxyDetails(DailyProxyManagerData ObjData)
        {
            int result = 0;

            try
            {
                DailyProxyManagerDA ObjDA = new DailyProxyManagerDA();
                result = ObjDA.UpdateDailyProxyDetails(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<DailyProxyManagerData> GetDailyProxyDetails(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                DailyProxyManagerDA ObjDA = new DailyProxyManagerDA();
                result = ObjDA.GetDailyProxyDetails(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }


        public List<DailyProxyManagerData> GetDailyProxyByID(DailyProxyManagerData ObjData)
        {
            List<DailyProxyManagerData> result = null;
            try
            {
                DailyProxyManagerDA ObjDA = new DailyProxyManagerDA();
                result = ObjDA.GetDailyProxyByID(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteDailyProxyByID(DailyProxyManagerData ObjData)
        {
            int result = 0;

            try
            {
                DailyProxyManagerDA ObjDA = new DailyProxyManagerDA();
                result = ObjDA.DeleteDailyProxyByID(ObjData);

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
