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
    public class StockEntryWithoutPODA
    {
        public List<StockEntryWithoutPOData> GetItemNameAuto(StockEntryWithoutPOData objdata)
        {
            List<StockEntryWithoutPOData> result = null;
            
            return result;
        }
        public List<StockEntryWithoutPOData> GetItemNameWithPrice(StockEntryWithoutPOData objdata)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[0].Value = objdata.ItemID;
                    arParms[1] = new SqlParameter("@YearID", SqlDbType.Int);
                    arParms[1].Value = objdata.YearID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_GetItemDetailWithPrice", arParms);
                    List<StockEntryWithoutPOData> lstDetails = ORHelper<StockEntryWithoutPOData>.FromDataReaderToList(sqlReader);
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
        public List<StockEntryWithoutPOData> SaveStockWithoutPO(StockEntryWithoutPOData objdata)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objdata.XMLData;

                    arParms[1] = new SqlParameter("@StkReceivedDate", SqlDbType.DateTime);
                    arParms[1].Value = objdata.StkReceivedDate;

                    arParms[2] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[2].Value = objdata.EmployeeID;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objdata.AcademicSessionID;

                    arParms[4] = new SqlParameter("@CompanyID", SqlDbType.VarChar);
                    arParms[4].Value = objdata.CompanyID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_SaveStockWithoutPO", arParms);
                    List<StockEntryWithoutPOData> lstDetails = ORHelper<StockEntryWithoutPOData>.FromDataReaderToList(sqlReader);
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
        //----TAB2----//
        public List<StockEntryWithoutPOData> GetGRNWithoutPOList(StockEntryWithoutPOData objig)
        {
            List<StockEntryWithoutPOData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[0].Value = objig.VendorID;

                    arParms[1] = new SqlParameter("@SubGroupID", SqlDbType.Int);
                    arParms[1].Value = objig.SubGroupID;

                    arParms[2] = new SqlParameter("@ReceiptNo", SqlDbType.VarChar);
                    arParms[2].Value = objig.ReceiptNo;

                    arParms[3] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[3].Value = objig.ItemID;

                    arParms[4] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[4].Value = objig.Datefrom;

                    arParms[5] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[5].Value = objig.Dateto;

                    arParms[6] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[6].Value = objig.IsActive;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objig.CurrentIndex;

                    arParms[8] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[8].Value = objig.PageSize;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_SearchStockEntryWithoutPO", arParms);
                    List<StockEntryWithoutPOData> lstDetails = ORHelper<StockEntryWithoutPOData>.FromDataReaderToList(sqlReader);
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
        public int DeleteGRNoteByStockNo(StockEntryWithoutPOData objdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@ReceiptNo", SqlDbType.VarChar);
                    arParms[0].Value = objdata.ReceiptNo;
                    arParms[1] = new SqlParameter("@EmployeeID", SqlDbType.Int);
                    arParms[1].Value = objdata.EmployeeID;
                    arParms[2] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[2].Direction = ParameterDirection.Output;
                    arParms[3] = new SqlParameter("@Remark", SqlDbType.VarChar);
                    arParms[3].Value = objdata.Remark;
                    arParms[4] = new SqlParameter("@StockID", SqlDbType.Int);
                    arParms[4].Value = objdata.StockID;
                    arParms[5] = new SqlParameter("@StockNo", SqlDbType.VarChar);
                    arParms[5].Value = objdata.StockNo;
                    arParms[6] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[6].Value = objdata.ItemID;
                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_delete_grnotebystock", arParms);
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
