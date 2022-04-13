using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.BussinessProcess.EduUtility
{
    public class VehicleTypeBO
    {
        public int UpdateVehicleTypeDetails(VehicleTypeData objVehicleType)
        {
            int result = 0;

            try
            {
                VehicleTypeDA objVehicleTypeDA = new VehicleTypeDA();
                result = objVehicleTypeDA.UpdateVehicleTypeDetails(objVehicleType);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<VehicleTypeData> SearchVehicleTypeDetails(VehicleTypeData objVehicleType)
        {
            List<VehicleTypeData> result = null;
            try
            {
                VehicleTypeDA objVehicleTypeDA = new VehicleTypeDA();
                result = objVehicleTypeDA.SearchVehicleTypeDetails(objVehicleType);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<VehicleTypeData> GetVehicleTypeDetailsByID(VehicleTypeData objVehicleType)
        {
            List<VehicleTypeData> result = null;

            try
            {
                VehicleTypeDA objVehicleTypeDA = new VehicleTypeDA();
                result = objVehicleTypeDA.GetVehicleTypeDetailsByID(objVehicleType);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

       

        public int DeleteVehicleTypeDetailsByID(VehicleTypeData objVehicleType)
        {
            int result = 0;

            try
            {
                VehicleTypeDA objVehicleTypeDA = new VehicleTypeDA();
                result = objVehicleTypeDA.DeleteVehicleTypeDetailsByID(objVehicleType);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(VehicleTypeData objVehicleType)
        {
            int result = 0;

            try
            {
                VehicleTypeDA objstdloyeeDA = new VehicleTypeDA();
                result = objstdloyeeDA.ActivateRoute(objVehicleType);

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
