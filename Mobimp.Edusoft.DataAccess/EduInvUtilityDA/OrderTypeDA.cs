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
using Mobimp.Edusoft.Data.EduInvUtility;

namespace Mobimp.Edusoft.DataAccess.EduInvUtilityDA
{
    public class OrderTypeDA
    {
        public int SaveOrderType(OrderTypeData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objdata.OrderTypeID;

                    arParms[1] = new SqlParameter("@OrderType", SqlDbType.VarChar);
                    arParms[1].Value = objdata.OrderType;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objdata.AcademicSessionID;

                    arParms[3] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[3].Value = objdata.IsActive;

                    arParms[4] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[4].Value = objdata.EmployeeID;

                    arParms[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[5].Value = objdata.CompanyID;

                    arParms[6] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[6].Value = objdata.ActionType;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_UpdateOrderTypeMST", arParms);
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
        public List<OrderTypeData> Searchordertype(OrderTypeData objOrderType)
        {
            List<OrderTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objOrderType.OrderTypeID;

                    arParms[1] = new SqlParameter("@OrderType", SqlDbType.VarChar);
                    arParms[1].Value = objOrderType.OrderType;

                    arParms[2] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[2].Value = objOrderType.IsActive;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objOrderType.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objOrderType.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_SearchOrderTypeMST", arParms);
                    List<OrderTypeData> lstDetails = ORHelper<OrderTypeData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public List<OrderTypeData> GetordertypebyID(OrderTypeData objOrderType)
        {
            List<OrderTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objOrderType.OrderTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_EditOrderTypeMST", arParms);
                    List<OrderTypeData> lstDetails = ORHelper<OrderTypeData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public int DeleteordertypebyID(OrderTypeData objOrderType)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objOrderType.OrderTypeID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objOrderType.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objOrderType.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_DeleteActivateOrderTypeMST", arParms);
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
        public int ActivateOrderType(OrderTypeData objgrp)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objgrp.OrderTypeID;
                    arParms[1] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[1].Value = objgrp.ActionType;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objgrp.Remark;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_DeleteActivateOrderTypeMST", arParms);
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
        //-----ORDER TEMPLATE------//
        public List<OrderTypeData> SearchOrderTemplate(OrderTypeData objOrderType)
        {
            List<OrderTypeData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objOrderType.OrderTypeID;

                    arParms[1] = new SqlParameter("@OrderTemplateID", SqlDbType.Int);
                    arParms[1].Value = objOrderType.OrderTemplateID;

                    arParms[2] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[2].Value = objOrderType.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_SearchWorkOrderTemplateMST", arParms);
                    List<OrderTypeData> lstDetails = ORHelper<OrderTypeData>.FromDataReaderToList(sqlReader);
                    result = lstDetails;
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
        public int SaveOrderTemplate(OrderTypeData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objdata.OrderTypeID;

                    arParms[1] = new SqlParameter("@OrderTemplateID", SqlDbType.Int);
                    arParms[1].Value = objdata.OrderTemplateID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objdata.AcademicSessionID;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[4].Value = objdata.EmployeeID;

                    arParms[5] = new SqlParameter("@TemplateHeader", SqlDbType.VarChar);
                    arParms[5].Value = objdata.TemplateHeader;

                    arParms[6] = new SqlParameter("@TemplateFooter", SqlDbType.VarChar);
                    arParms[6].Value = objdata.TemplateFooter;

                    arParms[7] = new SqlParameter("@DecodeTemplateHeader", SqlDbType.VarChar);
                    arParms[7].Value = objdata.DecodeTemplateHeader;

                    arParms[8] = new SqlParameter("@DecodeTemplateFooter", SqlDbType.VarChar);
                    arParms[8].Value = objdata.DecodeTemplateFooter;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Inv_util_UpdateWorkOrderTemplateMST", arParms);
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
