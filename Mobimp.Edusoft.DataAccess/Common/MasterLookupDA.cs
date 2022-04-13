using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Edusoft.DataAccess.Common
{
    public class MasterLookupDA : DataAccessObjectBase
    {
        public List<LookupItem> GetLookupsList(LookupNames lookupName)
        {
            List<LookupItem> lstObject = null;
            try
            {
                SqlParameterHelper paraColl = new SqlParameterHelper();
                paraColl.Add(LookupConstants.Parameters.LookupsName, SqlDbType.VarChar, lookupName.ToString());
                SqlDataReader dataReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetMasterLookup", paraColl.ToArray());
                lstObject = ORHelper<LookupItem>.FromDataReaderToList(dataReader);
                dataReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lstObject;
        }
        public List<LookupItem> GetStatelistByCountryID(int CountryID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@CountryID", SqlDbType.Int);
                arParms[0].Value = CountryID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetStateByCountryID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetAssignClassList(int ID)
        {
            List<LookupItem> Classlist = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[0].Value = ID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetAssignClassList", arParms);
                Classlist = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return Classlist;
        }
        public List<LookupItem> GetMenuSubheaderByHeaderID(int ID)
        {
            List<LookupItem> Doclist = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[0].Value = ID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetMenuSubeheaderByID", arParms);
                Doclist = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.DA);
                throw new BusinessProcessException("5000001", ex);
            }
            return Doclist;
        }
        public List<LookupItem> GetSectionByClassID(int ClassID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetSectionByClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetTeacherByclassIDSubjectID(int ClassID, int subjectID, int sessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@subjectID", SqlDbType.Int);
                arParms[1].Value = subjectID;

                arParms[2] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[2].Value = sessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTeacherby_classID_SubjectID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetDestination(int RouteID, int Ttype)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@RouteID", SqlDbType.Int);
                arParms[0].Value = RouteID;

                arParms[1] = new SqlParameter("@TransporttypeID", SqlDbType.Int);
                arParms[1].Value = Ttype;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetDestinationByRouteID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetFarebydestinationID(int DestinationID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@DestinationID", SqlDbType.Int);
                arParms[0].Value = DestinationID;


                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetFareBydestinationID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetMainSubjectByClassID(int ClassID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetMainSubjectIDByClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetAltSubjectByClassID(int ClassID, int sessionid)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = sessionid;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetAltSubjectIDByClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetOptSubjectByClassID(int ClassID, int sessionid)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = sessionid;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetOptSubjectIDByClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetSectionByClassIDCategoryID(int ClassID, int SessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetSectionByClassIDCategoryID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetassignedClass(int TeacherID, int SessionID, int SubjectID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[0].Value = TeacherID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[2].Value = SubjectID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTeahersAssignedClasslist", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetassignedSubjectList(int TeacherID, int SessionID, int ClassID, int SectionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@TeacherID", SqlDbType.Int);
                arParms[0].Value = TeacherID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[2].Value = ClassID;

                arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[3].Value = SectionID;

                SqlDataReader sqlReader = null;

                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTeahersAssignedSubjectlist", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }

        //ELearning Assignment
        public List<LookupItem> GetAssignmentClassByTeacherID(int SessionID, Int64 TeacherID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[0].Value = SessionID;

                arParms[1] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[1].Value = TeacherID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetAssignmentClassByTeacherID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetAssignmentSectionByClassIDTeacherID(int ClassID, int SessionID, Int64 TeacherID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[2].Value = TeacherID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetAssignmentSectionByClassIDTeacherID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetAssignmentSubjectByClassIDTeacherID(int ClassID, int AcademicID, Int64 TeacherID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = AcademicID;

                arParms[2] = new SqlParameter("@TeacherID", SqlDbType.BigInt);
                arParms[2].Value = TeacherID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetAssignmentSubjectByClassIDTeacherID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetAssignmentSubjectByClassIDSectionID(int ClassID, int AcademicID, int SectionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = AcademicID;

                arParms[2] = new SqlParameter("@SectionID", SqlDbType.BigInt);
                arParms[2].Value = SectionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetAssignmentSubjectByClassIDSectionID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetsystemgenratedSubjectwiseteacher(int SubjectID, int SessionID, int GroupID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[0].Value = SubjectID;

                arParms[1] = new SqlParameter("@Session", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[2].Value = GroupID;

                SqlDataReader sqlReader = null;

                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Time_Table_Generate_System_Teacher", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetGridsystemgenratedSubjectwiseteacher(int SubjectID, int SessionID, int GroupID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[0].Value = SubjectID;

                arParms[1] = new SqlParameter("@Session", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[2].Value = GroupID;

                SqlDataReader sqlReader = null;

                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Time_Table_Grid_Generate_System_Teacher", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetTimetableGetSubjectList(int DayID, int SessionID, int GroupID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@DayID", SqlDbType.Int);
                arParms[0].Value = DayID;

                arParms[1] = new SqlParameter("@Session", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[2].Value = GroupID;

                SqlDataReader sqlReader = null;

                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Time_Table_GetSubjectList", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetPeriodlistByclassID(int ClassID, int SessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetpPeriodbyClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetTeacherByClassID(int ClassID, int SessionID, int SubjectID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[2].Value = SubjectID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTeacherbyClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetExamTypeByClassID(int ClassID, int session)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = session;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetExamTypeByClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetExamTypeByClassIDAcademicID(int ClassID, int AcademicSessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = AcademicSessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetExamTypeByClassIDAcademicID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetStreamByClassID(int ClassID)
        {
            List<LookupItem> lststream = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetStreamByClassID", arParms);
                lststream = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststream;
        }

        public List<LookupItem> GetStartTranspotmonthByID(int StudentID, int sesssionID, int feetype)
        {
            List<LookupItem> lststream = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];
                arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                arParms[0].Value = StudentID;
                arParms[1] = new SqlParameter("@sesssionID", SqlDbType.Int);
                arParms[1].Value = sesssionID;
                arParms[2] = new SqlParameter("@FeeTypes", SqlDbType.Int);
                arParms[2].Value = feetype;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetStartTranspotMonthByID", arParms);
                lststream = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststream;
        }

        public List<LookupItem> GetSubjectByClassID(int ClassID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetMainSubjectIDByClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }

        public List<LookupItem> GetSubjectByClassIDCatgeoryID(int ClassID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetSubjectByClassIDCatgeroyID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetSubjectByClassIDAcademicID(int ClassID, int AcademicID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[1].Value = AcademicID;
                
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetSubjectByClassIDAcademicID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetDaywiseSubjectByClassID(int ClassID, int sectionID, int GroupID, int sessionid, DateTime Date)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[5];

                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;

                arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                arParms[1].Value = sectionID;

                arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[2].Value = GroupID;

                arParms[3] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[3].Value = sessionid;

                arParms[4] = new SqlParameter("@Date", SqlDbType.DateTime);
                arParms[4].Value = Date;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetDay_WisesubjectID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetDaywiseSubstitionTeachers(int PeriodNo, int SubjectID, int GroupID, int sessionid, DateTime Date)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[5];

                arParms[0] = new SqlParameter("@PeriodNo", SqlDbType.Int);
                arParms[0].Value = PeriodNo;

                arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                arParms[1].Value = SubjectID;

                arParms[2] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[2].Value = GroupID;

                arParms[3] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[3].Value = sessionid;

                arParms[4] = new SqlParameter("@Date", SqlDbType.DateTime);
                arParms[4].Value = Date;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetDay_Substituitionlist", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetExamlistbysessionID(int ClassID, int sessionID)
        {
            List<LookupItem> examlist = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@AcademicsessionID", SqlDbType.Int);
                arParms[0].Value = sessionID;

                arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[1].Value = ClassID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Examlist_byClassID_bysessionID", arParms);
                examlist = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return examlist;
        }

        public List<LookupItem> GetoptionalByClassID(int ClassID, int StreamID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                arParms[1] = new SqlParameter("@StreamID", SqlDbType.Int);
                arParms[1].Value = StreamID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetOptionalSubjectByStreamID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }

        public List<LookupItem> GetSexBySalutationID(int SalutationID)
        {
            List<LookupItem> lstsex = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@SalutationID", SqlDbType.Int);
                arParms[0].Value = SalutationID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetSexBysalutationID", arParms);
                lstsex = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lstsex;
        }
        public List<LookupItem> GetDistrictlistByID(int StateID, int CountryID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];
                arParms[0] = new SqlParameter("@CountryID", SqlDbType.Int);
                arParms[0].Value = CountryID;

                arParms[1] = new SqlParameter("@StateID", SqlDbType.Int);
                arParms[1].Value = StateID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetDistrictByID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        //////////////////////////////////////////////
        public List<LookupItem> GetVihicleByRootID(int RootID, int SessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@RootID", SqlDbType.Int);
                arParms[0].Value = RootID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;


                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetVihicleDetailsByRootID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetSubRootByRootID(int RootID, int TransportStdTypeID, int SessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@RootID", SqlDbType.Int);
                arParms[0].Value = RootID;

                arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[1].Value = SessionID;

                arParms[2] = new SqlParameter("@TransportStdTypeID", SqlDbType.Int);
                arParms[2].Value = TransportStdTypeID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetSubRootByRootID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetCtypeByClassID(int ClassID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                arParms[0].Value = ClassID;
                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetCtypeByClassID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetSubGroupByGroupID(int GroupID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[0].Value = GroupID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_lib_GetSubGroupByGroupID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetInvSubGroupByID(int GroupID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@GroupID", SqlDbType.Int);
                arParms[0].Value = GroupID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_GetSubGroupByID", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetVendorByID(int ID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[0].Value = ID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_GetVendorbyVendorTypeid", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        //---------------EMI-------------//
        public List<LookupItem> GetEMIByAcademicYear(int SessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[0].Value = SessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetEMIByAcademicYear", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }

        //------------Account ----------------//
        public List<LookupItem> GetFromLederByTransactionTypeID(int ID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Transactiontypeid", SqlDbType.Int);
                arParms[0].Value = ID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_account_getledgerbytransactionid", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> GetToLederByTransactionTypeID(int ID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Transactiontypeid", SqlDbType.Int);
                arParms[0].Value = ID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_account_gettoledgerbytransactionid", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        public List<LookupItem> Getsessionmonthlist(int SessionID)
        {
            List<LookupItem> lststates = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                arParms[0].Value = SessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_SessionMonths", arParms);
                lststates = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return lststates;
        }
        //------------Transport-----------//
        public List<LookupItem> GetVehiclenumberbyTID(Int32 TypeID)
        {
            List<LookupItem> listvehicle = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@TypeID", SqlDbType.Int);
                arParms[0].Value = TypeID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetVehiclebumberBytypeID", arParms);
                listvehicle = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return listvehicle;
        }
        public List<LookupItem> GetVehicleTypeByRouteID(Int32 RouteID, int AcademicSessionID)
        {
            List<LookupItem> listvehicle = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = AcademicSessionID;

                arParms[1] = new SqlParameter("@RouteID", SqlDbType.Int);
                arParms[1].Value = RouteID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTransportTypeByRouteID", arParms);
                listvehicle = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return listvehicle;
        }
        public List<LookupItem> GetVehicleNumberByVehicleTypeID(Int32 VehicleID, int AcademicSessionID, int RouteID)
        {
            List<LookupItem> listvehicle = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[3];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = AcademicSessionID;

                arParms[1] = new SqlParameter("@VehicleID", SqlDbType.Int);
                arParms[1].Value = VehicleID;

                arParms[2] = new SqlParameter("@RouteID", SqlDbType.Int);
                arParms[2].Value = RouteID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetVehicleNumberByVehicleTypeID", arParms);
                listvehicle = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return listvehicle;
        }
        public List<LookupItem> GetRoutesByAcademicID(int AcademicSessionID)
        {
            List<LookupItem> listvehicle = null;
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                arParms[0].Value = AcademicSessionID;

                SqlDataReader sqlReader = null;
                sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetRoutesByAcademicSessionID", arParms);
                listvehicle = ORHelper<LookupItem>.FromDataReaderToList(sqlReader);
                sqlReader.Close();
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("5000001", ex);
            }
            return listvehicle;
        }
    }
}
