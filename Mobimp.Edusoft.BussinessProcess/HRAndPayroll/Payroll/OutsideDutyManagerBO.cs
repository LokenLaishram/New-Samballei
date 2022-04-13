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
    public class OutsideDutyManagerBO
    {
        public List<OutsideDutyManagerData> GetEmployeeName(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                OutsideDutyManagerDA ObjDA = new OutsideDutyManagerDA();
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

        public List<OutsideDutyManagerData> GetEmployeeNameByID(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                OutsideDutyManagerDA ObjDA = new OutsideDutyManagerDA();
                result = ObjDA.GetEmployeeNameByID(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateOutsideDutyDetails(OutsideDutyManagerData ObjData)
        {
            int result = 0;

            try
            {
                OutsideDutyManagerDA ObjDA = new OutsideDutyManagerDA();
                result = ObjDA.UpdateOutsideDutyDetails(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<OutsideDutyManagerData> GetOutsideDutyDetails(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                OutsideDutyManagerDA ObjDA = new OutsideDutyManagerDA();
                result = ObjDA.GetOutsideDutyDetails(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public List<OutsideDutyManagerData> GetOutsideDutyByID(OutsideDutyManagerData ObjData)
        {
            List<OutsideDutyManagerData> result = null;
            try
            {
                OutsideDutyManagerDA ObjDA = new OutsideDutyManagerDA();
                result = ObjDA.GetOutsideDutyByID(ObjData);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int DeleteOutsideDutyByID(OutsideDutyManagerData ObjData)
        {
            int result = 0;

            try
            {
                OutsideDutyManagerDA ObjDA = new OutsideDutyManagerDA();
                result = ObjDA.DeleteOutsideDutyByID(ObjData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateOutsideDutyListDetails(OutsideDutyManagerData ObjData)
        {
            int result = 0;

            try
            {
                OutsideDutyManagerDA ObjDA = new OutsideDutyManagerDA();
                result = ObjDA.UpdateOutsideDutyListDetails(ObjData);

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
