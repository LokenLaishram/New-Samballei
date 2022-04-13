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
    public class ReturnBookDA
    {
        public List<ReturnBookData> GetAutoStudentDetails(ReturnBookData objdata)
        {
            List<ReturnBookData> result = null;
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
                    List<ReturnBookData> lstStudentDetails = ORHelper<ReturnBookData>.FromDataReaderToList(sqlReader);
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
        public List<ReturnBookData> GetStudentDetailByID(ReturnBookData objdata)
        {
            List<ReturnBookData> result = null;
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
                    List<ReturnBookData> lstStudentDetails = ORHelper<ReturnBookData>.FromDataReaderToList(sqlReader);
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
        public List<ReturnBookData> GetBookDetailByID(ReturnBookData objgrp)
        {
            List<ReturnBookData> result = null;
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
                    List<ReturnBookData> lstbook = ORHelper<ReturnBookData>.FromDataReaderToList(sqlReader);
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
        public List<ReturnBookData> GetAutoBookDetails(ReturnBookData objdata)
        {
            List<ReturnBookData> result = null;
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
                    List<ReturnBookData> lstStudentDetails = ORHelper<ReturnBookData>.FromDataReaderToList(sqlReader);
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

        public List<ReturnBookData> SearchBookReturnDetailsbyID(ReturnBookData objlist)
        {
            List<ReturnBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objlist.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objlist.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.BigInt);
                    arParms[2].Value = objlist.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.BigInt);
                    arParms[3].Value = objlist.SectionID;

                    arParms[4] = new SqlParameter("@IssueDate", SqlDbType.DateTime);
                    arParms[4].Value = objlist.IssueDate;

                    arParms[5] = new SqlParameter("@ReturnDate", SqlDbType.DateTime);
                    arParms[5].Value = objlist.ReturnDate;

                    arParms[6] = new SqlParameter("@IssueNo", SqlDbType.VarChar);
                    arParms[6].Value = objlist.IssueNo;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objlist.IsActive;

                    arParms[8] = new SqlParameter("@TypeID", SqlDbType.Int);
                    arParms[8].Value = objlist.TypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_SearchBookReturnDetailsbyID", arParms);
                    List<ReturnBookData> lstitemDetails = ORHelper<ReturnBookData>.FromDataReaderToList(sqlReader);
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
        public int UpdateBookReturnDetails(ReturnBookData objgrp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

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

                    arParms[5] = new SqlParameter("@ModifiedBy", SqlDbType.VarChar);
                    arParms[5].Value = objgrp.ModifiedBy;

                    arParms[6] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[6].Value = objgrp.UserId;

                    arParms[7] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[7].Value = objgrp.XmlBookReturnlist;

                    arParms[8] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[8].Direction = ParameterDirection.Output;

                    arParms[9] = new SqlParameter("@TypeID", SqlDbType.Int);
                    arParms[9].Value = objgrp.TypeID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_UpdateBookReturnDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[8].Value);
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


        public List<ReturnBookData> SearchBookReturnDetails(ReturnBookData objlist)
        {
            List<ReturnBookData> result = null;
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
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_SearchBookReturnDetails", arParms);
                    List<ReturnBookData> lstitemDetails = ORHelper<ReturnBookData>.FromDataReaderToList(sqlReader);
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
        public List<ReturnBookData> SearchReturnBookByIssueNo(ReturnBookData objData)
        {
            List<ReturnBookData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@IssueNo", SqlDbType.VarChar);
                    arParms[0].Value = objData.IssueNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_BookReturnChildGridByIssueNo", arParms);
                    List<ReturnBookData> lstItemDetails = ORHelper<ReturnBookData>.FromDataReaderToList(sqlReader);
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
        public int DeleteBookIssueNo(ReturnBookData objdata)
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
