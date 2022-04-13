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
    public class StockStatusDA
    {       
        public List<StockStatusData> GetStockStatus(StockStatusData objdata)
        {
            List<StockStatusData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[0].Value = objdata.VendorID;

                    arParms[1] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[1].Value = objdata.ItemID;

                    arParms[2] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[2].Value = objdata.Datefrom;

                    arParms[3] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Dateto;

                    arParms[4] = new SqlParameter("@StockStatusID", SqlDbType.Int);
                    arParms[4].Value = objdata.StockStatusID;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int); 
                    arParms[5].Value = objdata.CurrentIndex;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objdata.PageSize;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_getstockstatus", arParms);
                    List<StockStatusData> lstDetails = ORHelper<StockStatusData>.FromDataReaderToList(sqlReader);
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
        public List<StockStatusData> GetStockStatusByItemGroup(StockStatusData objdata)
        {
            List<StockStatusData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[0].Value = objdata.VendorID;

                    arParms[1] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[1].Value = objdata.ItemID;

                    arParms[2] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[2].Value = objdata.Datefrom;

                    arParms[3] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Dateto;

                    arParms[4] = new SqlParameter("@StockStatusID", SqlDbType.Int);
                    arParms[4].Value = objdata.StockStatusID;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objdata.CurrentIndex;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objdata.PageSize;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_getstockstatusbyitemgrouping", arParms);
                    List<StockStatusData> lstDetails = ORHelper<StockStatusData>.FromDataReaderToList(sqlReader);
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
        //--TAB 2-----//
        public List<StockStatusData> GetItemwiseStockStatus(StockStatusData objdata)
        {
            List<StockStatusData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@VendorID", SqlDbType.Int);
                    arParms[0].Value = objdata.VendorID;

                    arParms[1] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[1].Value = objdata.ItemID;

                    arParms[2] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[2].Value = objdata.Datefrom;

                    arParms[3] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[3].Value = objdata.Dateto;

                    arParms[4] = new SqlParameter("@StockStatusID", SqlDbType.Int);
                    arParms[4].Value = objdata.StockStatusID;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int); 
                    arParms[5].Value = objdata.CurrentIndex;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objdata.PageSize;

                    arParms[7] = new SqlParameter("@SubGroupID", SqlDbType.Int);
                    arParms[7].Value = objdata.SubGroupID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_inv_stock_getitemwisestockstatus", arParms);
                    List<StockStatusData> lstDetails = ORHelper<StockStatusData>.FromDataReaderToList(sqlReader);
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
    }
}
