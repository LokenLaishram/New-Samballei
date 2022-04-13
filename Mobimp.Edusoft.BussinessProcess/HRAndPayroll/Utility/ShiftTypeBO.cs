using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.Utility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility
{
    public class ShiftTypeBO
    {
        public int UpdateShiftType(ShiftData ObjShift)
        {
            int result = 0;

            try
            {
                ShiftTypeDA ObjShiftDA = new ShiftTypeDA();
                result = ObjShiftDA.UpdateShiftType(ObjShift);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ShiftData> Searchshifts(ShiftData ObjShift)
        {
            List<ShiftData> result = null;
            try
            {
                ShiftTypeDA ObjShiftDA = new ShiftTypeDA();
                result = ObjShiftDA.Searchshifts(ObjShift);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<ShiftData> GetShiftByID(ShiftData ObjShift)
        {
            List<ShiftData> result = null;

            try
            {
                ShiftTypeDA ObjShiftDA = new ShiftTypeDA();
                result = ObjShiftDA.GetShiftByID(ObjShift);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteShiftByID(ShiftData ObjShift)
        {
            int result = 0;

            try
            {
                ShiftTypeDA ObjShiftDA = new ShiftTypeDA();
                result = ObjShiftDA.DeleteShiftByID(ObjShift);
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
