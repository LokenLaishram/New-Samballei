using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;

namespace Mobimp.Edusoft.DataAccess.EduUtility
{
    public class ExamTypeDA
    {
        public int UpdateExamtypeDetails(ExamTypeData objexam)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[0].Value = objexam.ExamID;

                    arParms[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[1].Value = objexam.Code;

                    arParms[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[2].Value = objexam.Descriptions;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = objexam.AddedBy;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[4].Value = objexam.UserId;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = objexam.CompanyID;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objexam.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    arParms[7] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[7].Value = objexam.ClassID;

                    arParms[8] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[8].Value = objexam.ID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateExamtypeDetailMST", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> GetExamNameByID(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];


                    arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ExamID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetExamNameByID", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public int DeleteStudentfromexamlist(Examdata objexam)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexam.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexam.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexam.SectionID;

                    arParms[3] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[3].Value = objexam.StudentID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexam.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[5].Value = objexam.SubjectID;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteStudentfromexamlis", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[6].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int SubjectwiseAddStudent(Examdata objexam)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[20];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexam.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexam.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexam.SectionID;

                    arParms[3] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[3].Value = objexam.StudentID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexam.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[5].Value = objexam.SubjectID;

                    arParms[6] = new SqlParameter("@TotalMark", SqlDbType.Float);
                    arParms[6].Value = objexam.TotalMark;

                    arParms[7] = new SqlParameter("@TotalPassMark", SqlDbType.Float);
                    arParms[7].Value = objexam.TotalPassMark;

                    arParms[8] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[8].Value = objexam.AddedBy;

                    arParms[9] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[9].Value = objexam.CompanyID;

                    arParms[10] = new SqlParameter("@FullMark", SqlDbType.Float);
                    arParms[10].Value = objexam.FullMark;

                    arParms[11] = new SqlParameter("@PassMark", SqlDbType.Float);
                    arParms[11].Value = objexam.PassMark;

                    arParms[12] = new SqlParameter("@MarkingType", SqlDbType.Int);
                    arParms[12].Value = objexam.MarkingType;

                    arParms[13] = new SqlParameter("@PWmark", SqlDbType.Float);
                    arParms[13].Value = objexam.PWmark;

                    arParms[14] = new SqlParameter("@PWpassmark", SqlDbType.Float);
                    arParms[14].Value = objexam.PWpassmark;

                    arParms[15] = new SqlParameter("@UTmark", SqlDbType.Float);
                    arParms[15].Value = objexam.UTmark;

                    arParms[16] = new SqlParameter("@UTpassmark", SqlDbType.Float);
                    arParms[16].Value = objexam.UTpassmark;

                    arParms[17] = new SqlParameter("@HAmark", SqlDbType.Float);
                    arParms[17].Value = objexam.HAmark;

                    arParms[18] = new SqlParameter("@HApassmark", SqlDbType.Float);
                    arParms[18].Value = objexam.HApassmark;

                    arParms[19] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[19].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_AddsubjectwiseStudentLsit", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[19].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> GetSubjectWiseStudentList(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.SectionID;

                    arParms[3] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[3].Value = objexamsubject.StudentID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.SubjectID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_exam_GetSubjectWiseStudentList", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public int ProcessVerification(ExamTypeData objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.XmlMarksdetaillist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_ProcessVerification", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ExamTypeData> Getyearwiseexamlist(ExamTypeData objexam)
        {
            List<ExamTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[0].Value = objexam.ExamID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexam.ClassID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objexam.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetYearwiseexamlist", arParms);
                    List<ExamTypeData> lstExamtypeDetail = ORHelper<ExamTypeData>.FromDataReaderToList(sqlReader);
                    result = lstExamtypeDetail;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int DeleteExamByID(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ExamID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteExamNameByID", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> GetExamList(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];


                    arParms[0] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[0].Value = objexamsubject.Code;

                    arParms[1] = new SqlParameter("@ExamName", SqlDbType.VarChar);
                    arParms[1].Value = objexamsubject.ExamName;

                    arParms[2] = new SqlParameter("@IsActive", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.IsActive;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetExamNameList", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public int UpdateExamName(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@Code", SqlDbType.VarChar);
                    arParms[2].Value = objexamMarks.Code;

                    arParms[3] = new SqlParameter("@ExamName", SqlDbType.VarChar);
                    arParms[3].Value = objexamMarks.ExamName;

                    arParms[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[4].Value = objexamMarks.IsActive;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.ActionType;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_UpdateExamNames", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[0].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> SearchexamSubjectDetails(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.AcademicSessionID;

                    arParms[3] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.CurrentIndex;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.PageSize;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhExamMarkList", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public int UpdateExamMarkslist(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.xmlexammarklist;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ClassID;

                    arParms[2] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.ExamID;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexamMarks.AcademicSessionID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_UpdateSubjectMarkDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[3].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateCorrectRanklist(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.XMLranklist;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.ExamID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objexamMarks.AddedBy;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.AcademicSessionID;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objexamMarks.CompanyID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[8].Value = objexamMarks.StudentCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateCorrectRanks", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[7].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int PromoteStudent(PromoteSrudent objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.xmlpromotestudentlist;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ClassID;

                    arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[2].Value = objexamMarks.AddedBy;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objexamMarks.CompanyID;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    arParms[6] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[6].Value = objexamMarks.StudentCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_PromoteStudent", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> GetstudentRankDetails(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.RollNo;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.Status;

                    arParms[6] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[6].Value = objexamsubject.StudentCategoryID;

                    arParms[7] = new SqlParameter("@Ranks", SqlDbType.Int);
                    arParms[7].Value = objexamsubject.Ranks;

                    arParms[8] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[8].Value = objexamsubject.PageSize;

                    arParms[9] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[9].Value = objexamsubject.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetStudentRankDetails", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public List<Examdata> GetPromoteStudent(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.RollNo;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.Status;

                    arParms[6] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[6].Value = objexamsubject.StudentCategoryID;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objexamsubject.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objexamsubject.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetPromoteStudent", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public List<Examdata> GetClassTopper(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.AcademicSessionID;

                    arParms[3] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.StudentCategoryID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetClass_Topper", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public int PublishExamresult(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.StudentCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_PublishExamResultP", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int PublishExamresultF(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.StudentCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_PublishExamResultF", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int ProcessExamresult(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.StudentCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_ProcessExamResult", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int CalculateExamresult(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.StudentCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_CalculateTotalExamResult", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int ProsessResultSummary(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.StudentCategoryID;

                    //arParms[6] = new SqlParameter("@ExamNo", SqlDbType.Int);
                    //arParms[6].Value = objexamMarks.ExamNo;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Summariseexamresult", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[4].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int DeleteWrongrecords(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[4].Value = objexamMarks.RollNo;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    arParms[6] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[6].Value = objexamMarks.StudentCategoryID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_DeleteExamRecordByRollNo", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[5].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateExamMarks(ExamTypeData objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.XmlMarksdetaillist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateExamMarklist", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int UpdateClassExamMarkslist(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[22];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.xmlexammarklist;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.RollNo;

                    arParms[4] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[4].Value = objexamMarks.ExamID;

                    arParms[5] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[5].Value = objexamMarks.StudentID;

                    arParms[6] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[6].Value = objexamMarks.StudentCategoryID;

                    arParms[7] = new SqlParameter("@Attendance", SqlDbType.Int);
                    arParms[7].Value = objexamMarks.Attendance;

                    arParms[8] = new SqlParameter("@TotalWorkingDay", SqlDbType.Int);
                    arParms[8].Value = objexamMarks.TotalWorkingDay;

                    arParms[9] = new SqlParameter("@ResultStatus", SqlDbType.VarChar);
                    arParms[9].Value = objexamMarks.ResultStatus;

                    arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[10].Direction = ParameterDirection.Output;

                    arParms[11] = new SqlParameter("@TotalMarkObtain", SqlDbType.Float);
                    arParms[11].Value = objexamMarks.TotalMarkObtain;

                    arParms[12] = new SqlParameter("@TotalMark", SqlDbType.Float);
                    arParms[12].Value = objexamMarks.TotalMark;

                    arParms[13] = new SqlParameter("@TotalPassMark", SqlDbType.Float);
                    arParms[13].Value = objexamMarks.TotalPassMark;

                    arParms[14] = new SqlParameter("@CountAbsent", SqlDbType.Int);
                    arParms[14].Value = objexamMarks.CountAbsent;

                    arParms[15] = new SqlParameter("@CountFail", SqlDbType.Int);
                    arParms[15].Value = objexamMarks.CountFail;

                    arParms[16] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[16].Value = objexamMarks.AddedBy;

                    arParms[17] = new SqlParameter("@AcademicSessionID", SqlDbType.Bit);
                    arParms[17].Value = objexamMarks.AcademicSessionID;

                    arParms[18] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[18].Value = objexamMarks.CompanyID;

                    arParms[19] = new SqlParameter("@FullMark", SqlDbType.Float);
                    arParms[19].Value = objexamMarks.FullMark;

                    arParms[20] = new SqlParameter("@PassMark", SqlDbType.Float);
                    arParms[20].Value = objexamMarks.PassMark;

                    //arParms[21] = new SqlParameter("@PM", SqlDbType.Float);
                    //arParms[21].Value = objexamMarks.PM;



                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateSubjectExamMarklist", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[10].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }

        public int UpdateSubjectWiseExamMarkslist(ExammarkentryData objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.XMLData;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.CLassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.ExamID;

                    arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[4].Value = objexamMarks.SubjectID;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.EmployeeID;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = objexamMarks.AcademicSessionID;

                    arParms[7] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[7].Value = objexamMarks.CompanyID;

                    arParms[8] = new SqlParameter("@MarkingType", SqlDbType.VarChar);
                    arParms[8].Value = objexamMarks.MarkingType;

                    arParms[9] = new SqlParameter("@PWNoEntryCount", SqlDbType.Int);
                    arParms[9].Value = objexamMarks.PWNoEntryCount;

                    arParms[10] = new SqlParameter("@UTNoEntryCount", SqlDbType.Int);
                    arParms[10].Value = objexamMarks.UTNoEntryCount;

                    arParms[11] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[11].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateSubjectWiseMarklist", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[11].Value);
                    }
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int updateonlineexammanager(OnlineExamresultData objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.XMLData;

                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.EmployeeID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_update_CMS_util_Online_Exam_Publish", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[2].Value);
                    }
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int Publishresult(ExamresultData objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.CLassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ExamID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.AcademicSessionID;

                    arParms[3] = new SqlParameter("@Declaredby", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.EmployeeID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Publish_result", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[4].Value);
                    }
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int Publishoverallresult(ExamresultData objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.CLassID;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Declaredby", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.EmployeeID;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_Publish_ClasswiseOverall_Result", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[3].Value);
                    }
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> GetstudenrmarkDetails(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.RollNo;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.AcademicSessionID;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.StudentCategoryID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetStudentMarks", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ExamsubjectData> GetSubjectWiseMarkDetails(ExamsubjectData objexamsubject)
        {
            List<ExamsubjectData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.CLassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.SectionID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.AcademicSessionID;

                    arParms[4] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.SubjectID;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Class_sectionwise_exam_markentry_status_list", arParms);
                    List<ExamsubjectData> lstSubjectDetails = ORHelper<ExamsubjectData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public List<ExamresultData> GetExamresultlist(ExamresultData objexamsubject)
        {
            List<ExamresultData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.CLassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.AcademicSessionID;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.EmployeeID;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Yearwise_ExamList", arParms);
                    List<ExamresultData> lstSubjectDetails = ORHelper<ExamresultData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public List<OnlineExamresultData> GetonlineexamResults(OnlineExamresultData objexamsubject)
        {
            List<OnlineExamresultData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Online_Results", arParms);
                    List<OnlineExamresultData> lstSubjectDetails = ORHelper<OnlineExamresultData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public List<OnlineExamresultData> GetgetexamresultbyStudentID(OnlineExamresultData objexamsubject)
        {
            List<OnlineExamresultData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@SessionID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objexamsubject.StudentID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Get_Online_Results_byStudentID", arParms);
                    List<OnlineExamresultData> lstSubjectDetails = ORHelper<OnlineExamresultData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public List<ExammarkentryData> Getsubjectwisestudentlist(ExammarkentryData objexamsubject)
        {
            List<ExammarkentryData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ExamID;

                    arParms[1] = new SqlParameter("@SubjectID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.SubjectID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.CLassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.SectionID;

                    arParms[4] = new SqlParameter("@Roll", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.Roll;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.AcademicSessionID;

                    arParms[6] = new SqlParameter("@Addedby", SqlDbType.Int);
                    arParms[6].Value = objexamsubject.EmployeeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_exam_GetSubjectWiseStudentList", arParms);
                    List<ExammarkentryData> lstSubjectDetails = ORHelper<ExammarkentryData>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }

        public List<ExamTypeData> SearchExamtypeDetail(ExamTypeData objexam)
        {
            List<ExamTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[0].Value = objexam.ExamID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexam.ClassID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_SeacrhExamMarkList", arParms);
                    List<ExamTypeData> lstExamtypeDetail = ORHelper<ExamTypeData>.FromDataReaderToList(sqlReader);
                    result = lstExamtypeDetail;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<ExamTypeData> GetExamtypeDetailByID(ExamTypeData objexam)
        {
            List<ExamTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objexam.ID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_EditExamtypeDetailMST", arParms);
                    List<ExamTypeData> lstExamtypeDetail = ORHelper<ExamTypeData>.FromDataReaderToList(sqlReader);
                    result = lstExamtypeDetail;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int DeleteExamtypeDetailByID(ExamTypeData objexam)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objexam.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_DeleteExamtypeDetailMST", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[1].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        //manual attendence
        public List<AttendanceData> GetstudAttendanceDetails(AttendanceData objattendance)
        {
            List<AttendanceData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objattendance.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objattendance.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objattendance.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objattendance.RollNo;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objattendance.AcademicSessionID;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objattendance.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objattendance.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetstudAttendanceDetails", arParms);
                    List<AttendanceData> listattandance = ORHelper<AttendanceData>.FromDataReaderToList(sqlReader);
                    result = listattandance;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public int Updatestudattendlist(AttendanceData objatt)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objatt.XMLData;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objatt.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objatt.SectionID;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objatt.ExamID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objatt.AddedBy;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objatt.AcademicSessionID;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objatt.CompanyID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateCorrectAttendence", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[7].Value);
                    }
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> GetStudentRankResult(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.ExamID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.RollNo;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objexamsubject.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.Status;

                    arParms[6] = new SqlParameter("@TopStudent", SqlDbType.Int);
                    arParms[6].Value = objexamsubject.TopStudent;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objexamsubject.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objexamsubject.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_GetStudentRankResult", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        /////////////////////////////////////////////////////////////////////////  
        public int UpdateStudentRankResult(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.XMLranklist;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objexamMarks.SectionID;

                    arParms[4] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[4].Value = objexamMarks.AddedBy;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objexamMarks.AcademicSessionID;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objexamMarks.CompanyID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[8].Value = objexamMarks.StudentCategoryID;

                    arParms[9] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[9].Value = objexamMarks.ExamID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_UpdateStudentRankResult", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[7].Value);
                }
            }

            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////
        public List<Examdata> GetCTPCertifcateDetails(Examdata objexamsubject)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamsubject.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = objexamsubject.SectionID;

                    arParms[2] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[2].Value = objexamsubject.RollNo;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamsubject.AcademicSessionID;

                    arParms[4] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[4].Value = objexamsubject.StudentID;

                    arParms[5] = new SqlParameter("@CertificateType", SqlDbType.Int);
                    arParms[5].Value = objexamsubject.CertificateType;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objexamsubject.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objexamsubject.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Util_GetCTPCertifcateDetails", arParms);
                    List<Examdata> lstSubjectDetails = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstSubjectDetails;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;

        }
        public int CreateCTPCertificate(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objexamMarks.xmlCTPCertificatelist;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.ClassID;

                    arParms[2] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[2].Value = objexamMarks.AddedBy;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.AcademicSessionID;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[4].Value = objexamMarks.CompanyID;

                    arParms[5] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[5].Direction = ParameterDirection.Output;

                    arParms[6] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[6].Value = objexamMarks.SectionID;

                    arParms[7] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[7].Value = objexamMarks.RollNo;

                    arParms[8] = new SqlParameter("@CertificateType", SqlDbType.Int);
                    arParms[8].Value = objexamMarks.CertificateType;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_CreateCTPCertificate", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[5].Value);
                    }
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                // PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public List<Examdata> SubCount(Examdata objsubcount)
        {
            List<Examdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objsubcount.ClassID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objsubcount.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_exam_GetSubCount", arParms);
                    List<Examdata> lstExamtypeDetail = ORHelper<Examdata>.FromDataReaderToList(sqlReader);
                    result = lstExamtypeDetail;
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }

        public int OverallProcessExamresult(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new SqlParameter("@ExamID", SqlDbType.Int);
                    arParms[3].Value = objexamMarks.ExamID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "CMS_Exam_OverallProcess", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[2].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
        public int PublishOverallResultP(Examdata objexamMarks)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];


                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = objexamMarks.ClassID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objexamMarks.AcademicSessionID;

                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Exam_PublishOverallResultP", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[2].Value);
                }
            }
            catch (Exception ex) //Exception of the business layer(itself)//unhandle
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.DataAccessExceptionPolicy, ex, "330001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new DataAccessException("5000001", ex);
            }
            return result;
        }
    }
}
