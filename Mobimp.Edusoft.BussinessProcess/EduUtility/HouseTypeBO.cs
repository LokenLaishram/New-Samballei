using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduFeeUtility;
using Mobimp.Campusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.BussinessProcess.EduUtility
{
    public class HouseTypeBO
    {
        public int UpdateHouseType(HouseTypeData objhousetype)
        {
            int result = 0;

            try
            {
                HouseTypeDA objhousetypeDA = new HouseTypeDA();
                result = objhousetypeDA.UpdateHouseType(objhousetype);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HouseTypeData> SearchHouseTypeList(HouseTypeData objhousetype)
        {

            List<HouseTypeData> result = null;

            try
            {
                HouseTypeDA objhousetypeDA = new HouseTypeDA();
                result = objhousetypeDA.SearchHouseTypeList(objhousetype);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<HouseTypeData> GetHouseTypeByID(HouseTypeData objhousetype)
        {
            List<HouseTypeData> result = null;

            try
            {
                HouseTypeDA objhousetypeDA = new HouseTypeDA();
                result = objhousetypeDA.GetHouseTypeByID(objhousetype);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteHouseTypeDetailsByID(HouseTypeData objhousetype)
        {
            int result = 0;

            try
            {
                HouseTypeDA objhousetypeDA = new HouseTypeDA();
                result = objhousetypeDA.DeleteHouseTypeDetailsByID(objhousetype);

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
