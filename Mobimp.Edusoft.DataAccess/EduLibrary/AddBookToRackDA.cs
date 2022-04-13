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
    public class AddBookToRackDA
    {
        public int UpdateAddBookToRack(AddBookToRackData objgrp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[0].Value = objgrp.GroupID;

                    arParms[1] = new SqlParameter("@SubGroupID", SqlDbType.Int);
                    arParms[1].Value = objgrp.SubGroupID;

                    arParms[2] = new SqlParameter("@Books", SqlDbType.VarChar);
                    arParms[2].Value = objgrp.Books;

                    arParms[3] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[3].Value = objgrp.Description;

                    arParms[4] = new SqlParameter("@Qty", SqlDbType.Int);
                    arParms[4].Value = objgrp.Qty;

                    arParms[5] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[5].Value = objgrp.ActionType;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    arParms[7] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[7].Value = objgrp.AddedBy;

                    arParms[8] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[8].Value = objgrp.UserId;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[9].Value = objgrp.IsActive;

                    arParms[10] = new SqlParameter("@RackID", SqlDbType.Int);
                    arParms[10].Value = objgrp.RackID;

                    arParms[11] = new SqlParameter("@BooksID", SqlDbType.Int);
                    arParms[11].Value = objgrp.BooksID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_UpdateAddBookToRack", arParms);
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
        public List<AddBookToRackData> SearchAddBookToRack(AddBookToRackData objgrp)
        {
            List<AddBookToRackData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[0].Value = objgrp.GroupID;

                    arParms[1] = new SqlParameter("@SubGroupID", SqlDbType.Int);
                    arParms[1].Value = objgrp.SubGroupID;

                    arParms[2] = new SqlParameter("@Books", SqlDbType.VarChar);
                    arParms[2].Value = objgrp.Books;

                    arParms[3] = new SqlParameter("@Description", SqlDbType.VarChar);
                    arParms[3].Value = objgrp.Description;

                    arParms[4] = new SqlParameter("@Qty", SqlDbType.Int);
                    arParms[4].Value = objgrp.Qty;

                    arParms[5] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[5].Value = objgrp.PageSize;

                    arParms[6] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[6].Value = objgrp.CurrentIndex;

                    arParms[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[7].Value = objgrp.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_SearchAddBookToRack", arParms);
                    List<AddBookToRackData> lstClassDetails = ORHelper<AddBookToRackData>.FromDataReaderToList(sqlReader);
                    result = lstClassDetails;
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
        public List<AddBookToRackData> GetAddBookToRackByID(AddBookToRackData objgrp)
        {
            List<AddBookToRackData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@RackID", SqlDbType.Int);
                    arParms[0].Value = objgrp.RackID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_EditAddBookToRack", arParms);
                    List<AddBookToRackData> lstClassDetails = ORHelper<AddBookToRackData>.FromDataReaderToList(sqlReader);
                    result = lstClassDetails;
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
        public int ActivateAddBookToRack(AddBookToRackData objgrp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@RackID", SqlDbType.Int);
                    arParms[0].Value = objgrp.RackID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_ActivateAddBookToRackbyID", arParms);
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
        public int DeleteAddBookToRackByID(AddBookToRackData objgrp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@RackID", SqlDbType.Int);
                    arParms[0].Value = objgrp.RackID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objgrp.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objgrp.Remarks;
                    arParms[4] = new SqlParameter("@GroupID", SqlDbType.Int);
                    arParms[4].Value = objgrp.GroupID;
                    arParms[5] = new SqlParameter("@SubGroupID", SqlDbType.Int);
                    arParms[5].Value = objgrp.SubGroupID;
                    arParms[6] = new SqlParameter("@BooksID", SqlDbType.Int);
                    arParms[6].Value = objgrp.BooksID;
                    arParms[7] = new SqlParameter("@Qty", SqlDbType.Int);
                    arParms[7].Value = objgrp.Qty;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_DeleteAddBookToRackByID", arParms);
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
        public List<AddBookToRackData> GetBookDetailByID(AddBookToRackData objitem)
        {
            List<AddBookToRackData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.BigInt);
                    arParms[0].Value = objitem.AcademicSessionID;

                    arParms[1] = new SqlParameter("@BooksID", SqlDbType.BigInt);
                    arParms[1].Value = objitem.BooksID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_lib_GetBookDetailByID", arParms);
                    List<AddBookToRackData> lstbook = ORHelper<AddBookToRackData>.FromDataReaderToList(sqlReader);
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
        public List<AddBookToRackData> GetAutoBookDetails(AddBookToRackData objitemName)
        {
            List<AddBookToRackData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@BookDetails", SqlDbType.VarChar);
                    arParms[0].Value = objitemName.BookDetails;
                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objitemName.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_lib_autocompleteBookDetails", arParms);
                    List<AddBookToRackData> lstStudentDetails = ORHelper<AddBookToRackData>.FromDataReaderToList(sqlReader);
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
    }
}
