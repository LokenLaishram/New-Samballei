using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobimp.Campusoft.DataAccess.HRAndPayroll.Utility;
using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility
{
    public class HolidayListBO
    {
        public List<HolidayListData> GetHolidayDetails(HolidayListData objData)
        {
            List<HolidayListData> result = null;

            try
            {
                HolidayListDA objDA = new HolidayListDA();
                result = objDA.GetHolidayDetails(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }

        public int UpdateHolidayDetails(HolidayListData objData)
        {
            int result = 0;

            try
            {
                HolidayListDA objfeesDA = new HolidayListDA();
                result = objfeesDA.UpdateHolidayDetails(objData);
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
