using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduLibrary;

namespace Mobimp.Edusoft.DataAccess.EduLibrary
{
    public class IssueBookDA
    {
        public List<IssueBookData> GetAutoStudentDetails(IssueBookData objdata)
        {
            List<IssueBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentDetail", SqlDbType.VarChar);
                    arParms[0].Value = objdata.StudentDetail;
                    arParms[1] = new SqlParameter("@TypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.TypeID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_autocompleteStudentDetails", arParms);
                    List<IssueBookData> lstStudentDetails = ORHelper<IssueBookData>.FromDataReaderToList(sqlReader);
                    result = lstStudentDetails;
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
        public List<IssueBookData> GetStudentDetailByID(IssueBookData objdata)
        {
            List<IssueBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.BigInt);
                    arParms[0].Value = objdata.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objdata.StudentID;

                    arParms[2] = new SqlParameter("@TypeID", SqlDbType.Int);
                    arParms[2].Value = objdata.TypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_GetBookReturnStudentByid", arParms);
                    List<IssueBookData> lstStudentDetails = ORHelper<IssueBookData>.FromDataReaderToList(sqlReader);
                    result = lstStudentDetails;
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
        public List<IssueBookData> GetBookDetailByID(IssueBookData objgrp)
        {
            List<IssueBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.BigInt);
                    arParms[0].Value = objgrp.AcademicSessionID;

                    arParms[1] = new SqlParameter("@HID", SqlDbType.BigInt);
                    arParms[1].Value = objgrp.HID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_GetBookDetailByHID", arParms);
                    List<IssueBookData> lstbook = ORHelper<IssueBookData>.FromDataReaderToList(sqlReader);
                    result = lstbook;
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
        public List<IssueBookData> GetAutoBookDetails(IssueBookData objdata)
        {
            List<IssueBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@BookDetails", SqlDbType.VarChar);
                    arParms[0].Value = objdata.BookDetails;
                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_lib_autocompleteBookfromHeader", arParms);
                    List<IssueBookData> lstStudentDetails = ORHelper<IssueBookData>.FromDataReaderToList(sqlReader);
                    result = lstStudentDetails;
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

        public int UpdateBookIssueDetails(IssueBookData objgrp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objgrp.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[1].Value = objgrp.StudentID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objgrp.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objgrp.SectionID;

                    arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[4].Value = objgrp.RollNo;

                    arParms[5] = new SqlParameter("@HID", SqlDbType.Int);
                    arParms[5].Value = objgrp.HID;

                    arParms[6] = new SqlParameter("@TotalItemQty", SqlDbType.Int);
                    arParms[6].Value = objgrp.TotalItemQty;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = objgrp.AddedBy;

                    arParms[8] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[8].Value = objgrp.UserId;

                    arParms[9] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[9].Value = objgrp.XmlBookIssuelist;

                    arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[10].Direction = ParameterDirection.Output;

                    arParms[11] = new SqlParameter("@TypeID", SqlDbType.Int);
                    arParms[11].Value = objgrp.TypeID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_UpdateBookIssueDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[10].Value);
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
        public List<IssueBookData> SearchBookIssueDetails(IssueBookData objlist)
        {
            List<IssueBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objlist.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objlist.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.BigInt);
                    arParms[2].Value = objlist.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.BigInt);
                    arParms[3].Value = objlist.SectionID;

                    arParms[4] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[4].Value = objlist.Datefrom;

                    arParms[5] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[5].Value = objlist.Dateto;

                    arParms[6] = new SqlParameter("@IssueNo", SqlDbType.VarChar);
                    arParms[6].Value = objlist.IssueNo;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objlist.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objlist.CurrentIndex;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[9].Value = objlist.IsActive;

                    arParms[10] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[10].Value = objlist.UserId;

                    arParms[11] = new SqlParameter("@TypeID", SqlDbType.Int);
                    arParms[11].Value = objlist.TypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_SearchBookIssueDetails", arParms);
                    List<IssueBookData> lstitemDetails = ORHelper<IssueBookData>.FromDataReaderToList(sqlReader);
                    result = lstitemDetails;
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
        public List<IssueBookData> SearchIssueBookByIssueNo(IssueBookData objData)
        {
            List<IssueBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@IssueNo", SqlDbType.VarChar);
                    arParms[0].Value = objData.IssueNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_SearchChildGridByIssueNo", arParms);
                    List<IssueBookData> lstItemDetails = ORHelper<IssueBookData>.FromDataReaderToList(sqlReader);
                    result = lstItemDetails;
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
        public int DeleteBookIssueNo(IssueBookData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@IssueNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.IssueNo;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.AcademicSessionID;

                    arParms[2] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[2].Value = objdata.StudentID;

                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remarks;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[5].Value = objdata.UserId;

                    arParms[6] = new SqlParameter("@GenerateID", SqlDbType.Int);
                    arParms[6].Value = objdata.GenerateID;

                    arParms[7] = new SqlParameter("@ModifiedBy", SqlDbType.VarChar);
                    arParms[7].Value = objdata.ModifiedBy;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_DeleteBookIssueNo", arParms);
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
    }
}
