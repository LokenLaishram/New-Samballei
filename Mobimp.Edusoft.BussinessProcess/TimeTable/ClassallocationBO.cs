using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Campusoft.DataAccess.TimeTable;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.BussinessProcess.TimeTable
{
    public class ClassallocationBO
    {
        public int updateclassallocation(ClassallocationData obj)
        {
            int result = 0;

            try
            {
                ClassallocationDA ObjDA = new ClassallocationDA();
                result = ObjDA.updateclassallocation(obj);
           }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int updatesubjectallocation(SubjectAllocationData obj)
        {
            int result = 0;

            try
            {
                ClassallocationDA ObjDA = new ClassallocationDA();
                result = ObjDA.updatesubjectallocation(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int updateclasswiseperiod(ClasswisePeriodPlannerData obj)
        {
            int result = 0;

            try
            {
                ClassallocationDA ObjDA = new ClassallocationDA();
                result = ObjDA.updateclasswiseperiod(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int Updatetimetablerules(TimetableruleData obj)
        {
            int result = 0;

            try
            {
                ClassallocationDA ObjDA = new ClassallocationDA();
                result = ObjDA.Updatetimetablerules(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ClassallocationData> Getallocatedteacherlist(ClassallocationData obj)
        {
            List<ClassallocationData> result = null;
            try
            {
                ClassallocationDA objstdloyeeDA = new ClassallocationDA();
                result = objstdloyeeDA.Getallocatedteacherlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TimetableruleData> GettimetableClasslist(TimetableruleData obj)
        {
            List<TimetableruleData> result = null;
            try
            {
                ClassallocationDA objstdloyeeDA = new ClassallocationDA();
                result = objstdloyeeDA.GettimetableClasslist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TimetableruleData> GetNosubjectbyclassID( int classID, int sessionid)
        {
            List<TimetableruleData> result = null;
            try
            {
                ClassallocationDA objstdloyeeDA = new ClassallocationDA();
                result = objstdloyeeDA.GetNosubjectbyclassID(classID, sessionid);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TimetableruleData> GettimetablebyclassID(TimetableruleData obj)
        {
            List<TimetableruleData> result = null;
            try
            {
                ClassallocationDA objstdloyeeDA = new ClassallocationDA();
                result = objstdloyeeDA.GettimetablebyclassID(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<TimetableslotData> GettimetableSlots(TimetableslotData obj)
        {
            List<TimetableslotData> result = null;
            try
            {
                ClassallocationDA objstdloyeeDA = new ClassallocationDA();
                result = objstdloyeeDA.GettimetableSlots(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<SubjectAllocationData> GetAssignsubjectlist(SubjectAllocationData obj)
        {
            List<SubjectAllocationData> result = null;
            try
            {
                ClassallocationDA objstdloyeeDA = new ClassallocationDA();
                result = objstdloyeeDA.GetAssignsubjectlist(obj);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<ClassallocationData> GetallocatedlistbyID(ClassallocationData obj)
        {
            List<ClassallocationData> result = null;

            try
            {
                ClassallocationDA objDA = new ClassallocationDA();
                result = objDA.GetallocatedlistbyID(obj);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteteacherbyID(ClassallocationData obj)
        {
            int result = 0;

            try
            {
                ClassallocationDA objDA = new ClassallocationDA();
                result = objDA.DeleteteacherbyID(obj);

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
