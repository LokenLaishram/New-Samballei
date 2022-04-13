using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.DataAccess.Common;

namespace Mobimp.Edusoft.BussinessProcess.Common
{
    public class MasterLookupBO
    {

        public List<LookupItem> GetLookupsList(LookupNames lookupName)
        {
            List<LookupItem> listLookUpList = null;
            try
            {

                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> listLookup = objMasterLookup.GetLookupsList(lookupName);
                listLookUpList = listLookup;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return listLookUpList;
        }
        public List<LookupItem> GetAssignClassList(int ID)
        {
            List<LookupItem> classlist = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> ltsclass = objMasterLookup.GetAssignClassList(ID);
                classlist = ltsclass;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return classlist;
        }
        public List<LookupItem> GetMenuSubheaderByHeaderID(int ID)
        {
            List<LookupItem> doctlist = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> Doctorlist = objMasterLookup.GetMenuSubheaderByHeaderID(ID);
                doctlist = Doctorlist;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return doctlist;
        }
        public List<LookupItem> GetStatelistByCountryID(int CountryID)
        {
            List<LookupItem> liststates = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> liststate = objMasterLookup.GetStatelistByCountryID(CountryID);
                liststates = liststate;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return liststates;
        }
        public List<LookupItem> GetSectionByClassID(int ClassID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetSectionByClassID(ClassID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetTeacherByclassIDSubjectID(int ClassID, int SubjectID, int sessionid)
        {
            List<LookupItem> listteacher = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetTeacherByclassIDSubjectID(ClassID, SubjectID, sessionid);
                listteacher = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return listteacher;
        }
        public List<LookupItem> GetDestination(int RouteID, int Ttype)
        {
            List<LookupItem> lsdestination = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetDestination(RouteID, Ttype);
                lsdestination = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lsdestination;
        }
        public List<LookupItem> GetFarebydestinationID(int DestinationID)
        {
            List<LookupItem> lsdestination = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetFarebydestinationID(DestinationID);
                lsdestination = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lsdestination;
        }
        public List<LookupItem> GetMainSubjectByClassID(int ClassID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetMainSubjectByClassID(ClassID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetAltSubjectByClassID(int ClassID, int sessionid)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetAltSubjectByClassID(ClassID, sessionid);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetOptSubjectByClassID(int ClassID, int sessionid)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetOptSubjectByClassID(ClassID, sessionid);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetSectionByClassIDCategoryID(int ClassID, int SessionID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetSectionByClassIDCategoryID(ClassID, SessionID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        //ELearning Assignment
        public List<LookupItem> GetAssignmentClassByTeacherID(int SessionID, Int64 TeacherID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetAssignmentClassByTeacherID(SessionID, TeacherID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetAssignmentSectionByClassIDTeacherID(int ClassID, int SessionID, Int64 TeacherID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetAssignmentSectionByClassIDTeacherID(ClassID, SessionID, TeacherID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetAssignmentSubjectByClassIDTeacherID(int ClassID, int SessionID, Int64 TeacherID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetAssignmentSubjectByClassIDTeacherID(ClassID, SessionID, TeacherID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetAssignmentSubjectByClassIDSectionID(int ClassID, int SessionID, int SectionID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetAssignmentSubjectByClassIDSectionID(ClassID, SessionID, SectionID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetassignedClass(int TeacherID, int SessionID, int SubjectID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetassignedClass(TeacherID, SessionID, SubjectID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetassignedSubjectList(int TeacherID, int SessionID, int ClassID, int SectionID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetassignedSubjectList(TeacherID, SessionID, ClassID, SectionID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetsystemgenratedSubjectwiseteacher(int SubjectID, int SessionID, int GroupID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetsystemgenratedSubjectwiseteacher(SubjectID, SessionID, GroupID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetTimetableGetSubjectList(int DayID, int SessionID, int GroupID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetTimetableGetSubjectList(DayID, SessionID, GroupID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetGridsystemgenratedSubjectwiseteacher(int SubjectID, int SessionID, int GroupID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetGridsystemgenratedSubjectwiseteacher(SubjectID, SessionID, GroupID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetPeriodlistByclassID(int ClassID, int SessionID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetPeriodlistByclassID(ClassID, SessionID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetTeacherByClassID(int ClassID, int SessionID, int SubjectID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetTeacherByClassID(ClassID, SessionID, SubjectID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetExamTypeByClassID(int ClassID, int Session)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetExamTypeByClassID(ClassID, Session);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetExamTypeByClassIDAcademicID(int ClassID, int AcademicSessionID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetExamTypeByClassIDAcademicID(ClassID, AcademicSessionID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetStreamByClassID(int ClassID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetStreamByClassID(ClassID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetStartTranspotmonthByID(int StudentID, int sesssionID, int feetype)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetStartTranspotmonthByID(StudentID, sesssionID, feetype);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetSubjectByClassID(int ClassID)
        {
            List<LookupItem> lssubject = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssubjects = objMasterLookup.GetSubjectByClassID(ClassID);
                lssubject = lssubjects;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubject;
        }
        public List<LookupItem> GetSubjectByClassIDCatgeoryID(int ClassID)
        {
            List<LookupItem> lssubject = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssubjects = objMasterLookup.GetSubjectByClassIDCatgeoryID(ClassID);
                lssubject = lssubjects;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubject;
        }
        public List<LookupItem> GetSubjectByClassIDAcademicID(int ClassID, int AcademicID)
        {
            List<LookupItem> lssubject = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssubjects = objMasterLookup.GetSubjectByClassIDAcademicID(ClassID, AcademicID);
                lssubject = lssubjects;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubject;
        }
        public List<LookupItem> GetDaywiseSubjectByClassID(int ClassID, int sectionID, int GroupID, int sessionid, DateTime Date)
        {
            List<LookupItem> lssubject = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssubjects = objMasterLookup.GetDaywiseSubjectByClassID(ClassID, sectionID, GroupID,sessionid,Date);
                lssubject = lssubjects;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubject;
        }
        public List<LookupItem> GetDaywiseSubstitionTeachers(int PeriodNo, int SubjectID, int GroupID, int sessionid, DateTime Date)
        {
            List<LookupItem> lssubject = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssubjects = objMasterLookup.GetDaywiseSubstitionTeachers( PeriodNo,  SubjectID,  GroupID,  sessionid,  Date);
                lssubject = lssubjects;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubject;
        }
        public List<LookupItem> GetExamlistbysessionID(int ClassID, int sessionID)
        {
            List<LookupItem> lssubject = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssubjects = objMasterLookup.GetExamlistbysessionID(ClassID, sessionID);
                lssubject = lssubjects;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubject;
        }
        public List<LookupItem> GetoptionalByClassID(int ClassID, int StreamID)
        {
            List<LookupItem> lssubject = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssubjects = objMasterLookup.GetoptionalByClassID(ClassID, StreamID);
                lssubject = lssubjects;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubject;
        }
        public List<LookupItem> GetSexBySalutationID(int SalutationID)
        {
            List<LookupItem> listsex = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> listsexs = objMasterLookup.GetSexBySalutationID(SalutationID);
                listsex = listsexs;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return listsex;
        }
        public List<LookupItem> GetDistrictlistByID(int StateID, int CountryID)
        {
            List<LookupItem> listdistrict = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> listdistricts = objMasterLookup.GetDistrictlistByID(StateID, CountryID);
                listdistrict = listdistricts;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return listdistrict;
        }
        //////////////////////////////////////////////////////////////////////
        public List<LookupItem> GetVihicleByRootID(int RootID, int SessionID)
        {
            List<LookupItem> lssubroot = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetVihicleByRootID(RootID, SessionID);
                lssubroot = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubroot;
        }
        public List<LookupItem> GetSubRootByRootID(int RootID, int TransportStdTypeID, int SessionID)
        {
            List<LookupItem> lssubroot = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetSubRootByRootID(RootID, TransportStdTypeID, SessionID);
                lssubroot = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubroot;
        }
        //////////////////////////////////////////////////////////////////////
        public List<LookupItem> GetCtypeByClassID(int ClassID)
        {
            List<LookupItem> lssection = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.GetCtypeByClassID(ClassID);
                lssection = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssection;
        }
        public List<LookupItem> GetSubGroupByGroupID(int GroupID)
        {
            List<LookupItem> lsgrp = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> listgrp = objMasterLookup.GetSubGroupByGroupID(GroupID);
                lsgrp = listgrp;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lsgrp;
        }
        public List<LookupItem> GetInvSubGroupByID(int GroupID)
        {
            List<LookupItem> lsgrp = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> listgrp = objMasterLookup.GetInvSubGroupByID(GroupID);
                lsgrp = listgrp;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lsgrp;
        }
        public List<LookupItem> GetVendorByID(int ID)
        {
            List<LookupItem> VList = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> VendorList = objMasterLookup.GetVendorByID(ID);
                VList = VendorList;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return VList;
        }
        //---------------EMI---------------------//
        public List<LookupItem> GetEMIByAcademicYear(int Pop4_SessionID)
        {
            List<LookupItem> lsEMIlist = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> ltEmiYear = objMasterLookup.GetEMIByAcademicYear(Pop4_SessionID);
                lsEMIlist = ltEmiYear;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lsEMIlist;
        }

        //------------Account ----------------//
        public List<LookupItem> GetFromLederByTransactionTypeID(int ID)
        {
            List<LookupItem> LedgerList = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> list = objMasterLookup.GetFromLederByTransactionTypeID(ID);
                LedgerList = list;

            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }

            return LedgerList;
        }
        public List<LookupItem> GetToLederByTransactionTypeID(int ID)
        {
            List<LookupItem> LedgerList = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> list = objMasterLookup.GetToLederByTransactionTypeID(ID);
                LedgerList = list;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.BO);
                throw new BusinessProcessException("4000001", ex);
            }
            return LedgerList;
        }
        public List<LookupItem> Getsessionmonthlist(int SessionID)
        {
            List<LookupItem> lssubroot = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> lssections = objMasterLookup.Getsessionmonthlist(SessionID);
                lssubroot = lssections;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return lssubroot;
        }
        //---------Transport--------//
        public List<LookupItem> GetVehiclenumberbyTID(Int32 TypeID)
        {
            List<LookupItem> listdistrict = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> listdistricts = objMasterLookup.GetVehiclenumberbyTID(TypeID);
                listdistrict = listdistricts;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return listdistrict;
        }
        public List<LookupItem> GetVehicleTypeByRouteID(int RouteID, int AcademicSessionID)
        {
            List<LookupItem> liststates = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> liststate = objMasterLookup.GetVehicleTypeByRouteID(RouteID, AcademicSessionID);
                liststates = liststate;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return liststates;
        }
        public List<LookupItem> GetVehicleNumberByVehicleTypeID(int VehicleID, int AcademicSessionID, int RouteID)
        {
            List<LookupItem> liststates = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> liststate = objMasterLookup.GetVehicleNumberByVehicleTypeID(VehicleID, AcademicSessionID, RouteID);
                liststates = liststate;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return liststates;
        }
        public List<LookupItem> GetRoutesByAcademicID(int AcademicSessionID)
        {
            List<LookupItem> liststates = null;
            try
            {
                MasterLookupDA objMasterLookup = new MasterLookupDA();
                List<LookupItem> liststate = objMasterLookup.GetRoutesByAcademicID(AcademicSessionID);
                liststates = liststate;
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return liststates;
        }
    }
}
