using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Data.EduTransport;
using Mobimp.Edusoft.DataAccess.EduTransport;

namespace Mobimp.Edusoft.BussinessProcess.EduTransport
{
    public class VehicleBO
    {
        public int UpdateVehicleDetails(VehicleData objfees)
        {
            int result = 0;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.UpdateVehicleDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<VehicleData> GetVehicledetails(VehicleData objfees)
        {

            List<VehicleData> result = null;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.GetVehicledetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<VehicleData> GetVehicleDetailsByID(VehicleData objfees)
        {
            List<VehicleData> result = null;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.GetVehicleDetailsByID(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteVehicleDetailsByID(VehicleData objfees)
        {
            int result = 0;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.DeleteVehicleDetailsByID(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpLoadDriverPhoto(VehicleData objstd)
        {
            int result = 0;

            try
            {
                VehicleDA objstdloyeeDA = new VehicleDA();
                result = objstdloyeeDA.UpLoadDriverPhoto(objstd);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<VehicleData> GetRouteDetails(VehicleData objfees)
        {

            List<VehicleData> result = null;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.GetRouteDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int UpdateRouteDetails(VehicleData objfees)
        {
            int result = 0;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.UpdateRouteDetails(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<VehicleData> GetTransportRouteDetailsByID(VehicleData objfees)
        {
            List<VehicleData> result = null;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.GetTransportRouteDetailsByID(objfees);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteTransportRouteDetailsByID(VehicleData objfees)
        {
            int result = 0;

            try
            {
                VehicleDA objfeesDA = new VehicleDA();
                result = objfeesDA.DeleteTransportRouteDetailsByID(objfees);

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
