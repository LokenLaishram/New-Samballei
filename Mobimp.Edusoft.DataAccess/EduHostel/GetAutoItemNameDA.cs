using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Campusoft.Data.EduHostel;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.DataAccess;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;

namespace Mobimp.Campusoft.DataAccess.EduHostel
{
    public class GetAutoItemNameDA
    {
        public List<ItemData> GetstudentDetailByID(ItemData objstd)
        {
            List<ItemData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_hostel_GetAutostudentDetailByid", arParms);
                    List<ItemData> lstStudentDetails = ORHelper<ItemData>.FromDataReaderToList(sqlReader);
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
        public List<ItemData> GetAutoItemName(ItemData objitemName)
        {
            List<ItemData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ItemName", SqlDbType.VarChar);
                    arParms[0].Value = objitemName.ItemName;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_autocompleteItemName", arParms);
                    List<ItemData> lstEmployeeDetails = ORHelper<ItemData>.FromDataReaderToList(sqlReader);
                    result = lstEmployeeDetails;
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
        public List<ItemData> GetitemDetailByID(ItemData objitem)
        {
            List<ItemData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
                    arParms[0].Value = objitem.ItemID;

                    arParms[1] = new SqlParameter("@ItemName", SqlDbType.VarChar);
                    arParms[1].Value = objitem.ItemName;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_GetItemDetailByid", arParms);
                    List<ItemData> lstItemDetails = ORHelper<ItemData>.FromDataReaderToList(sqlReader);
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
        public int UpdateTakingServiceItem(ItemData objitem)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[19];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objitem.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[1].Value = objitem.StudentID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objitem.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objitem.SectionID;

                    arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[4].Value = objitem.RollNo;

                    arParms[5] = new SqlParameter("@ItemID", SqlDbType.Int);
                    arParms[5].Value = objitem.ItemID;

                    arParms[6] = new SqlParameter("@ItemRate", SqlDbType.Money);
                    arParms[6].Value = objitem.ItemRate;

                    arParms[7] = new SqlParameter("@ItemQty", SqlDbType.Int);
                    arParms[7].Value = objitem.ItemQty;

                    arParms[8] = new SqlParameter("@TotalAmount", SqlDbType.Money);
                    arParms[8].Value = objitem.TotalAmount;

                    arParms[9] = new SqlParameter("@TotalItemQty", SqlDbType.Int);
                    arParms[9].Value = objitem.TotalItemQty;

                    arParms[10] = new SqlParameter("@NetAmount", SqlDbType.Money);
                    arParms[10].Value = objitem.NetAmount;

                    arParms[11] = new SqlParameter("@IsAjusted", SqlDbType.Bit);
                    arParms[11].Value = objitem.IsAjusted;

                    arParms[12] = new SqlParameter("@AjustedAmt", SqlDbType.Money);
                    arParms[12].Value = objitem.AjustedAmt;

                    arParms[13] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[13].Value = objitem.AddedBy;

                    arParms[14] = new SqlParameter("@UserId", SqlDbType.Int);
                    arParms[14].Value = objitem.UserId;

                    arParms[15] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[15].Value = objitem.CompanyID;

                    arParms[16] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[16].Value = objitem.ActionType;

                    arParms[17] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[17].Value = objitem.xmlItemList;

                    arParms[18] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[18].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_UpdateTakingItemService", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[18].Value);
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

        public List<ItemData> SearchTakingItemtDetails(ItemData objitemlist)
        {
            List<ItemData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objitemlist.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objitemlist.AcademicSessionID;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.BigInt);
                    arParms[2].Value = objitemlist.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.BigInt);
                    arParms[3].Value = objitemlist.SectionID;

                    arParms[4] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[4].Value = objitemlist.Datefrom;

                    arParms[5] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[5].Value = objitemlist.Dateto;

                    arParms[6] = new SqlParameter("@RecieptNo", SqlDbType.VarChar);
                    arParms[6].Value = objitemlist.ReceiptNo;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objitemlist.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objitemlist.CurrentIndex;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[9].Value = objitemlist.IsActiveALL;

                    arParms[10] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[10].Value = objitemlist.UserId;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_SearchTotalTakingItemDetails ", arParms);
                    List<ItemData> lstitemDetails = ORHelper<ItemData>.FromDataReaderToList(sqlReader);
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

        public List<ItemData> SearchTakingItemByRecieptNo(ItemData objitemData)
        {
            List<ItemData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@ReceiptNo", SqlDbType.VarChar);
                    arParms[0].Value = objitemData.ReceiptNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_SearchTakingItemByRecieptNo", arParms);
                    List<ItemData> lstItemDetails = ORHelper<ItemData>.FromDataReaderToList(sqlReader);
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

        public int DeleteTakingItemByReceiptNo(ItemData objitemdata)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@ReceiptNo", SqlDbType.VarChar);
                    arParms[0].Value = objitemdata.ReceiptNo;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objitemdata.AcademicSessionID;

                    arParms[2] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[2].Value = objitemdata.StudentID;

                    arParms[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[3].Value = objitemdata.Remarks;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[5].Value = objitemdata.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_DeleteTakingItemByReceiptNo", arParms);
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
