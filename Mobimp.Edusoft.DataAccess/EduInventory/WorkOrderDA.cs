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
using Mobimp.Edusoft.Data.EduInventory;

namespace Mobimp.Edusoft.DataAccess.EduInventory
{
    public class WorkOrderDA
    {
        public List<WorkOrderData> GetItemName(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[0].Value = objdata.ItemID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_GetItemDetails", arParms);
                    List<WorkOrderData> lstDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
        public List<WorkOrderData> SaveWorkOrderGeneration(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[19];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.OrderTypeID;

                    arParms[2] = new SqlParameter("@WorkOrderNo", SqlDbType.VarChar);
                    arParms[2].Value = objdata.WorkOrderNo;

                    arParms[3] = new SqlParameter("@OrderTemplateID", SqlDbType.Int);
                    arParms[3].Value = objdata.OrderTemplateID;

                    arParms[4] = new SqlParameter("@AddressTitle", SqlDbType.VarChar);
                    arParms[4].Value = objdata.AddressTitle;

                    arParms[5] = new SqlParameter("@Subject", SqlDbType.VarChar);
                    arParms[5].Value = objdata.Subject;

                    arParms[6] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[6].Value = objdata.VendorID;

                    arParms[7] = new SqlParameter("@TemplateHeader", SqlDbType.VarChar);
                    arParms[7].Value = objdata.TemplateHeader;

                    arParms[8] = new SqlParameter("@TemplateFooter", SqlDbType.VarChar);
                    arParms[8].Value = objdata.TemplateFooter;

                    arParms[9] = new SqlParameter("@TotalCopies", SqlDbType.Int);
                    arParms[9].Value = objdata.TotalCopies;

                    arParms[10] = new SqlParameter("@PrintModeID", SqlDbType.Int);
                    arParms[10].Value = objdata.PrintModeID;

                    arParms[11] = new SqlParameter("@OrderDate", SqlDbType.DateTime);
                    arParms[11].Value = objdata.OrderDate;

                    arParms[12] = new SqlParameter("@DeliverDate", SqlDbType.DateTime);
                    arParms[12].Value = objdata.DeliverDate;

                    arParms[13] = new SqlParameter("@OrderDescription", SqlDbType.VarChar);
                    arParms[13].Value = objdata.OrderDescription;

                    arParms[14] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[14].Value = objdata.EmployeeID;

                    arParms[15] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[15].Value = objdata.AcademicSessionID; 

                    arParms[16] = new SqlParameter("@SysGenWorkOrderNo", SqlDbType.VarChar);
                    arParms[16].Value = objdata.SysGenWorkOrderNo;

                    arParms[17] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[17].Value = objdata.ActionType; ;

                    arParms[18] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[18].Direction = ParameterDirection.Output;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_workorder_UpdateWorkOrder", arParms);
                    List<WorkOrderData> lstDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
        public List<WorkOrderData> SearchWorkOrderList(WorkOrderData objig)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objig.OrderTypeID;

                    arParms[1] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[1].Value = objig.VendorID;

                    arParms[2] = new SqlParameter("@WorkOrderNo", SqlDbType.VarChar);
                    arParms[2].Value = objig.WorkOrderNo; 
                    
                    arParms[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[3].Value = objig.Datefrom;

                    arParms[4] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[4].Value = objig.Dateto;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objig.IsActive;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objig.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objig.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_workorder_SearchWorkOrderList", arParms);
                    List<WorkOrderData> lstDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
        public List<WorkOrderData> SearchOrderTemplate(WorkOrderData objOrderType)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[0].Value = objOrderType.OrderTypeID;

                    arParms[1] = new SqlParameter("@OrderTemplateID", SqlDbType.Int);
                    arParms[1].Value = objOrderType.OrderTemplateID;

                    arParms[2] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[2].Value = objOrderType.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_util_SearchWorkOrderTemplateMST", arParms);
                    List<WorkOrderData> lstDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
        public List<WorkOrderData> GetWorkOrderDetailsByWONo(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@SysGenWorkOrderNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.SysGenWorkOrderNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_workorder_Getworkorderdetailbywono", arParms);
                    List<WorkOrderData> lstDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
        public List<WorkOrderData> PrintWorkOrderDetailsByOrderNo(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@WorkOrderNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.WorkOrderNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_workorder_printworkorderdetails", arParms);
                    List<WorkOrderData> lstDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
        public int DeleteWorkOrdeByWONo(WorkOrderData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@SysGenWorkOrderNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.SysGenWorkOrderNo;
                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_DeleteWorkOrderbywono", arParms);
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

        public List<WorkOrderData> GetAutoItemDetails(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ItemDetails", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ItemDetails;
                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_autocompleteItemDetail", arParms);
                    List<WorkOrderData> lstStudentDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
        public List<WorkOrderData> GetItemDetailByID(WorkOrderData objgrp)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objgrp.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[1].Value = objgrp.ItemID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_GetItemDetailByID", arParms);
                    List<WorkOrderData> lstbook = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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

        public List<WorkOrderData> GetAutoVendorDetails(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@VendorDetail", SqlDbType.VarChar);
                    arParms[0].Value = objdata.VendorDetail;
                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objdata.AcademicSessionID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_autocompleteVendorDetail", arParms);
                    List<WorkOrderData> lstStudentDetails = ORHelper<WorkOrderData>.FromDataReaderToList(sqlReader);
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
