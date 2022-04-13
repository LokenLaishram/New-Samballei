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
    public class StockEntryWithOrderDA
    {
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
        public List<WorkOrderData> GetItemDetailsByWorkOrder(WorkOrderData objig)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@SysGenWorkOrderNo", SqlDbType.VarChar);
                    arParms[0].Value = objig.SysGenWorkOrderNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_GetItemDetailsByWorkOrder", arParms);
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
        public List<WorkOrderData> UpdateStockReceived(WorkOrderData objdata)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@ReceivedDate", SqlDbType.DateTime);
                    arParms[1].Value = objdata.ReceivedDate;

                    arParms[2] = new SqlParameter("@SysGenWorkOrderNo", SqlDbType.VarChar);
                    arParms[2].Value = objdata.SysGenWorkOrderNo;

                    arParms[3] = new SqlParameter("@WorkOrderNo", SqlDbType.VarChar);
                    arParms[3].Value = objdata.WorkOrderNo;

                    arParms[4] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
                    arParms[4].Value = objdata.OrderTypeID;

                    arParms[5] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[5].Value = objdata.VendorTypeID;

                    arParms[6] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[6].Value = objdata.VendorID;

                    arParms[7] = new SqlParameter("@TotalCopies", SqlDbType.Int);
                    arParms[7].Value = objdata.TotalCopies;

                    arParms[8] = new SqlParameter("@TotalReceived", SqlDbType.Int);
                    arParms[8].Value = objdata.TotalReceived;

                    arParms[9] = new SqlParameter("@TotalNowReceived", SqlDbType.Int);
                    arParms[9].Value = objdata.TotalNowReceived;

                    arParms[10] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[10].Value = objdata.Remark;

                    arParms[11] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[11].Value = objdata.EmployeeID;

                    arParms[12] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[12].Value = objdata.AcademicSessionID;

                    arParms[13] = new SqlParameter("@CompanyID", SqlDbType.VarChar);
                    arParms[13].Value = objdata.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_savestockreceivedwithwo", arParms);
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
        //--TAB-2--//
        public List<WorkOrderData> SearchStockReceivedList(WorkOrderData objig)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

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

                    arParms[8] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[8].Value = objig.VendorTypeID;

                    arParms[9] = new SqlParameter("@ReceivedByID", SqlDbType.Int);
                    arParms[9].Value = objig.ReceivedByID;

                    arParms[10] = new SqlParameter("@ReceivedNo", SqlDbType.VarChar);
                    arParms[10].Value = objig.ReceivedNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_searchstockentryWithwolist", arParms);
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
        public int DeleteStockReceivedNo(WorkOrderData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ReceivedNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ReceivedNo;
                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_DeleteStockReceivedByRno", arParms);
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
        public List<WorkOrderData> GetItemDetailsByRecNo(WorkOrderData objig)
        {
            List<WorkOrderData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ReceivedNo", SqlDbType.VarChar);
                    arParms[0].Value = objig.ReceivedNo;
                    arParms[1] = new SqlParameter("@SysGenWorkOrderNo", SqlDbType.VarChar);
                    arParms[1].Value = objig.SysGenWorkOrderNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_Getstockentrybyreceivedno", arParms);
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

        public List<StockEntryWithoutPOData> GetAutoVendorName(StockEntryWithoutPOData objdata)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@VendorDetails", SqlDbType.VarChar);
                    arParms[0].Value = objdata.VendorDetails;
                    arParms[1] = new SqlParameter("@VendorTypeID", SqlDbType.Int);
                    arParms[1].Value = objdata.VendorTypeID;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_inv_autocompleteVendorDetailByVendorTypeid", arParms);
                    List<StockEntryWithoutPOData> lstStudentDetails = ORHelper<StockEntryWithoutPOData>.FromDataReaderToList(sqlReader);
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
