using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.EduFees;

namespace Mobimp.Edusoft.DataAccess.EduStudent
{
    public class AddstudentDA
    {
        public int UpdateStudentDetails(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[97];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[1].Value = objstd.StudentTypeID;

                    arParms[2] = new SqlParameter("@SalutationID", SqlDbType.Int);
                    arParms[2].Value = objstd.SalutationID;

                    arParms[3] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Sfirstname;

                    arParms[4] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[4].Value = objstd.Smiddlename;

                    arParms[5] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[5].Value = objstd.Slastname;

                    arParms[6] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[6].Value = objstd.SexID;

                    arParms[7] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[7].Value = objstd.ReligionID;

                    arParms[8] = new SqlParameter("@DOB", SqlDbType.DateTime);
                    arParms[8].Value = objstd.DOB;

                    arParms[9] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[9].Value = objstd.CastID;

                    arParms[10] = new SqlParameter("@GsalutationID", SqlDbType.Int);
                    arParms[10].Value = objstd.GsalutationID;

                    arParms[11] = new SqlParameter("@Gfirstname", SqlDbType.VarChar);
                    arParms[11].Value = objstd.Gfirstname;

                    arParms[12] = new SqlParameter("@Gmiddlename", SqlDbType.VarChar);
                    arParms[12].Value = objstd.Gmiddlename;

                    arParms[13] = new SqlParameter("@StudentPhoto", SqlDbType.VarChar);
                    arParms[13].Value = objstd.StudentPhoto;

                    arParms[14] = new SqlParameter("@Glastname", SqlDbType.VarChar);
                    arParms[14].Value = objstd.Glastname;

                    arParms[15] = new SqlParameter("@GreligionID", SqlDbType.Int);
                    arParms[15].Value = objstd.GreligionID;

                    arParms[16] = new SqlParameter("@GCastID", SqlDbType.Int);
                    arParms[16].Value = objstd.GCastID;

                    arParms[17] = new SqlParameter("@GsexID", SqlDbType.Int);
                    arParms[17].Value = objstd.GsexID;

                    arParms[18] = new SqlParameter("@Age", SqlDbType.Int);
                    arParms[18].Value = objstd.Age;

                    arParms[19] = new SqlParameter("@GphoneNo", SqlDbType.VarChar);
                    arParms[19].Value = objstd.GphoneNo;

                    arParms[20] = new SqlParameter("@GmobileNo", SqlDbType.VarChar);
                    arParms[20].Value = objstd.GmobileNo;

                    arParms[21] = new SqlParameter("@Goccupation", SqlDbType.VarChar);
                    arParms[21].Value = objstd.Goccupation;

                    arParms[22] = new SqlParameter("@GrelationshipID", SqlDbType.Int);
                    arParms[22].Value = objstd.GrelationshipID;

                    arParms[25] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[25].Value = objstd.ClassID;

                    arParms[26] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[26].Value = objstd.SectionID;

                    arParms[27] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[27].Value = objstd.StreamID;

                    arParms[28] = new SqlParameter("@cAddress", SqlDbType.VarChar);
                    arParms[28].Value = objstd.cAddress;

                    arParms[29] = new SqlParameter("@cPhoneNo", SqlDbType.VarChar);
                    arParms[29].Value = objstd.cPhoneNo;

                    arParms[30] = new SqlParameter("@cMobileNo", SqlDbType.VarChar);
                    arParms[30].Value = objstd.cMobileNo;

                    arParms[31] = new SqlParameter("@cCountryID", SqlDbType.Int);
                    arParms[31].Value = objstd.cCountryID;

                    arParms[32] = new SqlParameter("@cStateID", SqlDbType.Int);
                    arParms[32].Value = objstd.cStateID;

                    arParms[33] = new SqlParameter("@cDistrictID", SqlDbType.Int);
                    arParms[33].Value = objstd.cDistrictID;

                    arParms[34] = new SqlParameter("@cPIN", SqlDbType.Int);
                    arParms[34].Value = objstd.cPIN;

                    arParms[35] = new SqlParameter("@cLandMark", SqlDbType.VarChar);
                    arParms[35].Value = objstd.cLandMark;

                    arParms[36] = new SqlParameter("@pAddress", SqlDbType.VarChar);
                    arParms[36].Value = objstd.pAddress;

                    arParms[37] = new SqlParameter("@pPhoneNo", SqlDbType.VarChar);
                    arParms[37].Value = objstd.pPhoneNo;

                    arParms[38] = new SqlParameter("@pMobileNo", SqlDbType.VarChar);
                    arParms[38].Value = objstd.pMobileNo;

                    arParms[39] = new SqlParameter("@pCountryID", SqlDbType.Int);
                    arParms[39].Value = objstd.pCountryID;

                    arParms[40] = new SqlParameter("@pStateID", SqlDbType.Int);
                    arParms[40].Value = objstd.pStateID;

                    arParms[41] = new SqlParameter("@pDistrictID", SqlDbType.Int);
                    arParms[41].Value = objstd.pDistrictID;

                    arParms[42] = new SqlParameter("@pPIN", SqlDbType.Int);
                    arParms[42].Value = objstd.pPIN;

                    arParms[43] = new SqlParameter("@pLandMark", SqlDbType.VarChar);
                    arParms[43].Value = objstd.pLandMark;

                    arParms[44] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[44].Value = objstd.UserId;

                    arParms[45] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[45].Value = objstd.CompanyID;

                    arParms[46] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[46].Value = objstd.AcademicSessionID;

                    arParms[47] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[47].Value = objstd.AddedBy;

                    arParms[48] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[48].Value = objstd.ActionType;

                    arParms[49] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[49].Value = objstd.IsActive;

                    arParms[50] = new SqlParameter("@IsNew", SqlDbType.Int);
                    arParms[50].Value = objstd.IsNew;

                    arParms[51] = new SqlParameter("@OptSubjectID", SqlDbType.Int);
                    arParms[51].Value = objstd.OptSubjectID;

                    arParms[52] = new SqlParameter("@Output", SqlDbType.BigInt);
                    arParms[52].Direction = ParameterDirection.Output;

                    arParms[53] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[53].Value = objstd.XmlSubjectlist;

                    arParms[54] = new SqlParameter("@NationalityID", SqlDbType.Int);
                    arParms[54].Value = objstd.NationalityID;

                    arParms[55] = new SqlParameter("@Msalutation", SqlDbType.Int);
                    arParms[55].Value = objstd.Msalutation;

                    arParms[56] = new SqlParameter("@Mothername", SqlDbType.VarChar);
                    arParms[56].Value = objstd.Mothername;

                    arParms[57] = new SqlParameter("@MotherOccupation", SqlDbType.VarChar);
                    arParms[57].Value = objstd.MotherOccupation;

                    arParms[58] = new SqlParameter("@Istakingtransport", SqlDbType.Bit);
                    arParms[58].Value = objstd.Istakingtransport;

                    arParms[59] = new SqlParameter("@TransportTypeID", SqlDbType.Int);
                    arParms[59].Value = objstd.TransportTypeID;

                    arParms[60] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                    arParms[60].Value = objstd.VehicleNo;

                    arParms[61] = new SqlParameter("@BloogroupID", SqlDbType.Int);
                    arParms[61].Value = objstd.BloogroupID;

                    arParms[62] = new SqlParameter("@HouseID", SqlDbType.Int);
                    arParms[62].Value = objstd.HouseID;

                    arParms[63] = new SqlParameter("@IDmarks", SqlDbType.VarChar);
                    arParms[63].Value = objstd.IDmarks;

                    arParms[64] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime);
                    arParms[64].Value = objstd.AdmissionDate;

                    arParms[65] = new SqlParameter("@StudentImage", SqlDbType.Image);
                    arParms[65].Value = objstd.StudentImage;

                    arParms[66] = new SqlParameter("@Allerrgic", SqlDbType.VarChar);
                    arParms[66].Value = objstd.Allerrgic;

                    arParms[67] = new SqlParameter("@Isessioninitialheight", SqlDbType.BigInt);
                    arParms[67].Value = objstd.Isessioninitialheight;

                    arParms[68] = new SqlParameter("@Isessioninendingheight", SqlDbType.BigInt);
                    arParms[68].Value = objstd.Isessioninendingheight;

                    arParms[69] = new SqlParameter("@Isessioninitialweight", SqlDbType.BigInt);
                    arParms[69].Value = objstd.Isessioninitialweight;

                    arParms[70] = new SqlParameter("@Isessionendingweight", SqlDbType.BigInt);
                    arParms[70].Value = objstd.Isessionendingweight;

                    arParms[71] = new SqlParameter("@IIsessioninitialheight", SqlDbType.BigInt);
                    arParms[71].Value = objstd.IIsessioninitialheight;

                    arParms[72] = new SqlParameter("@IIsessioninitialweight", SqlDbType.BigInt);
                    arParms[72].Value = objstd.IIsessioninitialweight;

                    arParms[73] = new SqlParameter("@IIsessioninendingheight", SqlDbType.BigInt);
                    arParms[73].Value = objstd.IIsessioninendingheight;

                    arParms[74] = new SqlParameter("@IIsessionendingweight", SqlDbType.BigInt);
                    arParms[74].Value = objstd.IIsessionendingweight;

                    arParms[75] = new SqlParameter("@Rootno", SqlDbType.BigInt);
                    arParms[75].Value = objstd.Rootno;

                    arParms[76] = new SqlParameter("@OwnerNo", SqlDbType.BigInt);
                    arParms[76].Value = objstd.OwnerNo;

                    arParms[77] = new SqlParameter("@Income", SqlDbType.Money);
                    arParms[77].Value = objstd.Income;

                    arParms[78] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[78].Value = objstd.StudentCategory;

                    arParms[79] = new SqlParameter("@LastSchoolName", SqlDbType.VarChar);
                    arParms[79].Value = objstd.LastSchoolName;

                    arParms[80] = new SqlParameter("@LastClass", SqlDbType.VarChar);
                    arParms[80].Value = objstd.LastClass;

                    arParms[81] = new SqlParameter("@LastSection", SqlDbType.VarChar);
                    arParms[81].Value = objstd.LastSection;

                    arParms[82] = new SqlParameter("@LastRollno", SqlDbType.Int);
                    arParms[82].Value = objstd.LastRollno;

                    arParms[83] = new SqlParameter("@LastMark", SqlDbType.VarChar);
                    arParms[83].Value = objstd.LastMark;

                    arParms[84] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[84].Value = objstd.RollNo;

                    arParms[85] = new SqlParameter("@Aadhar", SqlDbType.VarChar);
                    arParms[85].Value = objstd.Aadhar;

                    arParms[86] = new SqlParameter("@IFSC", SqlDbType.VarChar);
                    arParms[86].Value = objstd.IFSC;

                    arParms[87] = new SqlParameter("@AC", SqlDbType.VarChar);
                    arParms[87].Value = objstd.AC;

                    arParms[88] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[88].Value = objstd.BankName;

                    arParms[89] = new SqlParameter("@EmaildID", SqlDbType.VarChar);
                    arParms[89].Value = objstd.EmaildID;

                    arParms[90] = new SqlParameter("@LastAttendance", SqlDbType.VarChar);
                    arParms[90].Value = objstd.LastAttendance;

                    arParms[91] = new SqlParameter("@RegdNo", SqlDbType.VarChar);
                    arParms[91].Value = objstd.RegdNo;

                    arParms[92] = new SqlParameter("@MotherTongue", SqlDbType.VarChar);
                    arParms[92].Value = objstd.MotherTongue;

                    arParms[93] = new SqlParameter("@BirthRegNo", SqlDbType.VarChar);
                    arParms[93].Value = objstd.BirthRegNo;

                    arParms[94] = new SqlParameter("@BelongToBPLoptionID", SqlDbType.Int);
                    arParms[94].Value = objstd.BelogToBPLoptionID;

                    arParms[95] = new SqlParameter("@EnrollmentNo", SqlDbType.VarChar);
                    arParms[95].Value = objstd.EnrollmentNo;

                    arParms[96] = new SqlParameter("@GurdianName", SqlDbType.VarChar);
                    arParms[96].Value = objstd.GurdianName;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentRegistrationDetails", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[52].Value);
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
        public List<StudentDetailData> GetnewregistrationbyID(StudentDetailData obj)
        {
            List<StudentDetailData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[3];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = obj.ClassID;

                    arParms[1] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[1].Value = obj.StudentID;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = obj.AcademicSessionID;

                    SqlDataReader sqlReader = null;

                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_Get_new_registration_studentby_id", arParms);
                    List<StudentDetailData> resultlist = ORHelper<StudentDetailData>.FromDataReaderToList(sqlReader);
                    result = resultlist;
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
        public int DeleteRegistrationDetailsByID(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objstd.AcademicSessionID;

                    arParms[3] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[3].Value = objstd.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_DeleteOnlineRegistrationByID", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[1].Value);
                    }
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
        public List<StudentData> GetOnlineregistrationlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    arParms[2] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[2].Value = objstd.SexID;

                    arParms[3] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[3].Value = objstd.PageSize;

                    arParms[4] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[4].Value = objstd.CurrentIndex;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[5].Value = objstd.IsActiveALL;

                    arParms[6] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[6].Value = objstd.ClassID;

                    arParms[7] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[7].Value = objstd.Datefrom;

                    arParms[8] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[8].Value = objstd.Dateto;

                    arParms[9] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[9].Value = objstd.CastID;

                    arParms[10] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[10].Value = objstd.UserId;

                    arParms[11] = new SqlParameter("@AdmissionStatus", SqlDbType.Int);
                    arParms[11].Value = objstd.IsAdmissionDone;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_Getonlineregistration_List", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public int UpdateonlineregistartionDetails(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[43];

                    arParms[0] = new SqlParameter("@SalutationID", SqlDbType.Int);
                    arParms[0].Value = objstd.SalutationID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.Sfirstname;

                    arParms[2] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[2].Value = objstd.SexID;

                    arParms[3] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[3].Value = objstd.ReligionID;

                    arParms[4] = new SqlParameter("@DOB", SqlDbType.DateTime);
                    arParms[4].Value = objstd.DOB;

                    arParms[5] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[5].Value = objstd.CastID;

                    arParms[6] = new SqlParameter("@Gfirstname", SqlDbType.VarChar);
                    arParms[6].Value = objstd.Gfirstname;

                    arParms[7] = new SqlParameter("@GmobileNo", SqlDbType.VarChar);
                    arParms[7].Value = objstd.GmobileNo;

                    arParms[8] = new SqlParameter("@Goccupation", SqlDbType.VarChar);
                    arParms[8].Value = objstd.Goccupation;

                    arParms[9] = new SqlParameter("@GrelationshipID", SqlDbType.Int);
                    arParms[9].Value = objstd.GrelationshipID;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objstd.ClassID;

                    arParms[11] = new SqlParameter("@cAddress", SqlDbType.VarChar);
                    arParms[11].Value = objstd.cAddress;

                    arParms[12] = new SqlParameter("@cCountryID", SqlDbType.Int);
                    arParms[12].Value = objstd.cCountryID;

                    arParms[13] = new SqlParameter("@cStateID", SqlDbType.Int);
                    arParms[13].Value = objstd.cStateID;

                    arParms[14] = new SqlParameter("@cDistrictID", SqlDbType.Int);
                    arParms[14].Value = objstd.cDistrictID;

                    arParms[15] = new SqlParameter("@cPIN", SqlDbType.Int);
                    arParms[15].Value = objstd.cPIN;

                    arParms[16] = new SqlParameter("@cLandMark", SqlDbType.VarChar);
                    arParms[16].Value = objstd.cLandMark;

                    arParms[17] = new SqlParameter("@Mothername", SqlDbType.VarChar);
                    arParms[17].Value = objstd.Mothername;

                    arParms[18] = new SqlParameter("@MotherOccupation", SqlDbType.VarChar);
                    arParms[18].Value = objstd.MotherOccupation;

                    arParms[19] = new SqlParameter("@BloogroupID", SqlDbType.Int);
                    arParms[19].Value = objstd.BloogroupID;

                    arParms[20] = new SqlParameter("@IDmarks", SqlDbType.VarChar);
                    arParms[20].Value = objstd.IDmarks;

                    arParms[21] = new SqlParameter("@StudentImage", SqlDbType.Image);
                    arParms[21].Value = objstd.StudentImage;

                    arParms[22] = new SqlParameter("@Allerrgic", SqlDbType.VarChar);
                    arParms[22].Value = objstd.Allerrgic;

                    arParms[23] = new SqlParameter("@Isessioninitialheight", SqlDbType.BigInt);
                    arParms[23].Value = objstd.Isessioninitialheight;

                    arParms[24] = new SqlParameter("@Isessioninitialweight", SqlDbType.BigInt);
                    arParms[24].Value = objstd.Isessioninitialweight;

                    arParms[25] = new SqlParameter("@Income", SqlDbType.Money);
                    arParms[25].Value = objstd.Income;

                    arParms[26] = new SqlParameter("@LastSchoolName", SqlDbType.VarChar);
                    arParms[26].Value = objstd.LastSchoolName;

                    arParms[27] = new SqlParameter("@LastClass", SqlDbType.VarChar);
                    arParms[27].Value = objstd.LastClass;

                    arParms[28] = new SqlParameter("@LastSection", SqlDbType.VarChar);
                    arParms[28].Value = objstd.LastSection;

                    arParms[29] = new SqlParameter("@LastRollno", SqlDbType.Int);
                    arParms[29].Value = objstd.LastRollno;

                    arParms[30] = new SqlParameter("@LastMark", SqlDbType.VarChar);
                    arParms[30].Value = objstd.LastMark;

                    arParms[31] = new SqlParameter("@EmaildID", SqlDbType.VarChar);
                    arParms[31].Value = objstd.EmaildID;

                    arParms[32] = new SqlParameter("@LastAttendance", SqlDbType.VarChar);
                    arParms[32].Value = objstd.LastAttendance;

                    arParms[33] = new SqlParameter("@MotherTongue", SqlDbType.VarChar);
                    arParms[33].Value = objstd.MotherTongue;

                    arParms[34] = new SqlParameter("@BelongToBPLoptionID", SqlDbType.Int);
                    arParms[34].Value = objstd.BelogToBPLoptionID;

                    arParms[35] = new SqlParameter("@GurdianName", SqlDbType.VarChar);
                    arParms[35].Value = objstd.GurdianName;

                    arParms[36] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[36].Value = objstd.UserId;

                    arParms[37] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[37].Value = objstd.CompanyID;

                    arParms[38] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[38].Value = objstd.AcademicSessionID;

                    arParms[39] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[39].Value = objstd.AddedBy;

                    arParms[40] = new SqlParameter("@Output", SqlDbType.BigInt);
                    arParms[40].Direction = ParameterDirection.Output;

                    arParms[41] = new SqlParameter("@Actiontype", SqlDbType.Int);
                    arParms[41].Value = objstd.ActionType;

                    arParms[42] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[42].Value = objstd.StudentID;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_Update_Online_Registration_Details", arParms);
                    if (result_ > 0 || result_ == -1)
                    {
                        result = Convert.ToInt32(arParms[40].Value);
                    }
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
        public List<StudentData> GetregistrationdetailbyID(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[12];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_Get_registrationdetailsbyID", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetStudentPasswordlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objstd.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objstd.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objstd.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objstd.RollNo;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objstd.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objstd.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetStudentPasswordList", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public int AcitvateStudent(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlStudentlist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_AvivateStudentbyID", arParms);
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
        public int UpdateStudentTransportlist(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlStudentlist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentTransportlist", arParms);
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
        public int UpdateStudentAttenedance(StudentAttendance objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlStudenAttendancelist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objstd.AcademicSessionID;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objstd.ClassID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = objstd.SectionID;

                    arParms[5] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[5].Value = objstd.StudentCategoryID;

                    arParms[6] = new SqlParameter("@AttendanceDate", SqlDbType.DateTime);
                    arParms[6].Value = objstd.AttendanceDate;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentAttendance", arParms);
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
        public int UpdateRegdDetails(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlStudentlist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objstd.AcademicSessionID;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objstd.ClassID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = objstd.SectionID;

                    arParms[5] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[5].Value = objstd.StudentCategory;


                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentRegd", arParms);
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
        public int Updateexpenditure(Expenditure objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@StudentCategrory", SqlDbType.Int);
                    arParms[1].Value = objstd.StudentCategrory;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objstd.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objstd.SectionID;

                    arParms[4] = new SqlParameter("@ExpenditureAmount", SqlDbType.Decimal);
                    arParms[4].Value = objstd.ExpenditureAmount;

                    arParms[5] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[5].Value = objstd.AcademicSessionID;

                    arParms[6] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[6].Value = objstd.AddedBy;

                    arParms[7] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[7].Value = objstd.CompanyID;

                    arParms[8] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[8].Direction = ParameterDirection.Output;

                    arParms[9] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[9].Value = objstd.Remarks;

                    arParms[10] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[10].Value = objstd.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_UpdateExpenditure", arParms);
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

        public List<Expenditure> SearchExpendtiureDetails(Expenditure objstd)
        {
            List<Expenditure> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@StudentCategrory", SqlDbType.Int);
                    arParms[1].Value = objstd.StudentCategrory;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objstd.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objstd.SectionID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[5].Value = objstd.IsActive;

                    arParms[6] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[6].Value = objstd.Datefrom;

                    arParms[7] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[7].Value = objstd.Dateto;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_SearchExpenditureRecord", arParms);
                    List<Expenditure> lstStudentDetails = ORHelper<Expenditure>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetStudentNames(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@StudentName", SqlDbType.VarChar);
                    arParms[0].Value = objstd.StudentName;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Emp_autocompleteStudentNames", arParms);
                    List<StudentData> lstEmployeeDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetHostelStudentNames(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];
                    arParms[0] = new SqlParameter("@StudentName", SqlDbType.VarChar);
                    arParms[0].Value = objstd.StudentName;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_autocompleteHostelStudentNames", arParms);
                    List<StudentData> lstEmployeeDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetstudentDetailByID(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetstudentDetailByid", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetStudentDetailByName(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentName", SqlDbType.VarChar);
                    arParms[0].Value = objstd.StudentName;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;


                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetStudentDetailByName", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetBroaderstudentDetailByID(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetBroaderstudentDetailByid", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetHostelStudentByID(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetHostelStudentByID", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetHostelStudentByName(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentName", SqlDbType.VarChar);
                    arParms[0].Value = objstd.StudentName;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Hostel_GetHostelStudentByName", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentAttendance> Getclasswisesattendancetudentlist(StudentAttendance objstd)
        {
            List<StudentAttendance> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objstd.SexID;

                    arParms[6] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[6].Value = objstd.ClassID;

                    arParms[7] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[7].Value = objstd.SectionID;

                    arParms[8] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[8].Value = objstd.RollNo;

                    arParms[9] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[9].Value = objstd.StreamID;

                    arParms[10] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[10].Value = objstd.StudentCategoryID;

                    arParms[11] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[11].Value = objstd.PageSize;

                    arParms[12] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[12].Value = objstd.CurrentIndex;

                    arParms[13] = new SqlParameter("@AttendanceDate", SqlDbType.DateTime);
                    arParms[13].Value = objstd.AttendanceDate;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetStudentListforattendance", arParms);
                    List<StudentAttendance> lstStudentDetails = ORHelper<StudentAttendance>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetStudentListRegd(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];
                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objstd.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objstd.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objstd.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objstd.RollNo;

                    arParms[4] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[4].Value = objstd.StudentCategory;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetStudentList_Regd", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> Getclasswisetransportstudentlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[16];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objstd.SexID;

                    arParms[6] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[6].Value = objstd.ClassID;

                    arParms[7] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[7].Value = objstd.SectionID;

                    arParms[8] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[8].Value = objstd.RollNo;

                    arParms[9] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[9].Value = objstd.StreamID;

                    arParms[10] = new SqlParameter("@Istakingtransport", SqlDbType.Bit);
                    arParms[10].Value = objstd.Istakingtransport;

                    arParms[11] = new SqlParameter("@TransportTypeID", SqlDbType.Int);
                    arParms[11].Value = objstd.TransportTypeID;

                    arParms[12] = new SqlParameter("@Rootno", SqlDbType.Int);
                    arParms[12].Value = objstd.Rootno;

                    arParms[13] = new SqlParameter("@StartmonthID", SqlDbType.Int);
                    arParms[13].Value = objstd.MonthID;

                    arParms[14] = new SqlParameter("@EndMonthID", SqlDbType.Int);
                    arParms[14].Value = objstd.EndMonthID;

                    arParms[15] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[15].Value = objstd.IsActive;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetTransportStudentList", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<GetTodaysDateDetails> GetdateDetails(GetTodaysDateDetails objstd)
        {
            List<GetTodaysDateDetails> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[0];

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetTodaysDatedetails", arParms);
                    List<GetTodaysDateDetails> lstStudentDetails = ORHelper<GetTodaysDateDetails>.FromDataReaderToList(sqlReader);
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
        public int DeleteExpenditureByID(Expenditure objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objstd.AcademicSessionID;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = objstd.AddedBy;

                    arParms[4] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[4].Value = objstd.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_DeleteExpenditureDetailsByID", arParms);
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
        public List<StudentAttendance> Getclasswisesattendancelist(StudentAttendance objstd)
        {
            List<StudentAttendance> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[15];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objstd.SexID;

                    arParms[6] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[6].Value = objstd.ClassID;

                    arParms[7] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[7].Value = objstd.SectionID;

                    arParms[8] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[8].Value = objstd.Datefrom;

                    arParms[9] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[9].Value = objstd.Dateto;

                    arParms[10] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[10].Value = objstd.RollNo;

                    arParms[11] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[11].Value = objstd.StreamID;

                    arParms[12] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[12].Value = objstd.StudentCategoryID;

                    arParms[13] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[13].Value = objstd.PageSize;

                    arParms[14] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[14].Value = objstd.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_Getattendancelist", arParms);
                    List<StudentAttendance> lstStudentDetails = ORHelper<StudentAttendance>.FromDataReaderToList(sqlReader);
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
        public int UpdateStudentRollnos(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlStudentlist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentRollNos", arParms);
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
        public int UpdateStudentpassword(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlStudentlist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentPassword", arParms);
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
        public int UpdateSubjects(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlSubjectlist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateSubjectstoprofile", arParms);
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
        public int UpLoadStudentPhoto(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objstd.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objstd.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objstd.RollNo;

                    arParms[4] = new SqlParameter("@StudentPhoto", SqlDbType.VarChar);
                    arParms[4].Value = objstd.StudentPhoto;

                    arParms[5] = new SqlParameter("@StudentImage", SqlDbType.Image);
                    arParms[5].Value = objstd.StudentImage;

                    arParms[6] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[6].Direction = ParameterDirection.Output;

                    arParms[7] = new SqlParameter("@AcademicSessionID", SqlDbType.SmallInt);
                    arParms[7].Value = objstd.AcademicSessionID;

                    arParms[8] = new SqlParameter("@IsPhotoUploaded", SqlDbType.Int);
                    arParms[8].Value = objstd.IsPhotoUploaded;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentPhotos", arParms);
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
        public int UpdateAdmissionDetails(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[99];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[1].Value = objstd.StudentTypeID;

                    arParms[2] = new SqlParameter("@SalutationID", SqlDbType.Int);
                    arParms[2].Value = objstd.SalutationID;

                    arParms[3] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Sfirstname;

                    arParms[4] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[4].Value = objstd.Smiddlename;

                    arParms[5] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[5].Value = objstd.Slastname;

                    arParms[6] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[6].Value = objstd.SexID;

                    arParms[7] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[7].Value = objstd.ReligionID;

                    arParms[8] = new SqlParameter("@DOB", SqlDbType.DateTime);
                    arParms[8].Value = objstd.DOB;

                    arParms[9] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[9].Value = objstd.CastID;

                    arParms[10] = new SqlParameter("@GsalutationID", SqlDbType.Int);
                    arParms[10].Value = objstd.GsalutationID;

                    arParms[11] = new SqlParameter("@Gfirstname", SqlDbType.VarChar);
                    arParms[11].Value = objstd.Gfirstname;

                    arParms[12] = new SqlParameter("@Gmiddlename", SqlDbType.VarChar);
                    arParms[12].Value = objstd.Gmiddlename;

                    arParms[13] = new SqlParameter("@StudentPhoto", SqlDbType.VarChar);
                    arParms[13].Value = objstd.StudentPhoto;

                    arParms[14] = new SqlParameter("@Glastname", SqlDbType.VarChar);
                    arParms[14].Value = objstd.Glastname;

                    arParms[15] = new SqlParameter("@GreligionID", SqlDbType.Int);
                    arParms[15].Value = objstd.GreligionID;

                    arParms[16] = new SqlParameter("@GCastID", SqlDbType.Int);
                    arParms[16].Value = objstd.GCastID;

                    arParms[17] = new SqlParameter("@GsexID", SqlDbType.Int);
                    arParms[17].Value = objstd.GsexID;

                    arParms[18] = new SqlParameter("@Age", SqlDbType.Int);
                    arParms[18].Value = objstd.Age;

                    arParms[19] = new SqlParameter("@GphoneNo", SqlDbType.VarChar);
                    arParms[19].Value = objstd.GphoneNo;

                    arParms[20] = new SqlParameter("@GmobileNo", SqlDbType.VarChar);
                    arParms[20].Value = objstd.GmobileNo;

                    arParms[21] = new SqlParameter("@Goccupation", SqlDbType.VarChar);
                    arParms[21].Value = objstd.Goccupation;

                    arParms[22] = new SqlParameter("@GrelationshipID", SqlDbType.Int);
                    arParms[22].Value = objstd.GrelationshipID;

                    arParms[25] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[25].Value = objstd.ClassID;

                    arParms[26] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[26].Value = objstd.SectionID;

                    arParms[27] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[27].Value = objstd.StreamID;

                    arParms[28] = new SqlParameter("@cAddress", SqlDbType.VarChar);
                    arParms[28].Value = objstd.cAddress;

                    arParms[29] = new SqlParameter("@cPhoneNo", SqlDbType.VarChar);
                    arParms[29].Value = objstd.cPhoneNo;

                    arParms[30] = new SqlParameter("@cMobileNo", SqlDbType.VarChar);
                    arParms[30].Value = objstd.cMobileNo;

                    arParms[31] = new SqlParameter("@cCountryID", SqlDbType.Int);
                    arParms[31].Value = objstd.cCountryID;

                    arParms[32] = new SqlParameter("@cStateID", SqlDbType.Int);
                    arParms[32].Value = objstd.cStateID;

                    arParms[33] = new SqlParameter("@cDistrictID", SqlDbType.Int);
                    arParms[33].Value = objstd.cDistrictID;

                    arParms[34] = new SqlParameter("@cPIN", SqlDbType.Int);
                    arParms[34].Value = objstd.cPIN;

                    arParms[35] = new SqlParameter("@cLandMark", SqlDbType.VarChar);
                    arParms[35].Value = objstd.cLandMark;

                    arParms[36] = new SqlParameter("@pAddress", SqlDbType.VarChar);
                    arParms[36].Value = objstd.pAddress;

                    arParms[37] = new SqlParameter("@pPhoneNo", SqlDbType.VarChar);
                    arParms[37].Value = objstd.pPhoneNo;

                    arParms[38] = new SqlParameter("@pMobileNo", SqlDbType.VarChar);
                    arParms[38].Value = objstd.pMobileNo;

                    arParms[39] = new SqlParameter("@pCountryID", SqlDbType.Int);
                    arParms[39].Value = objstd.pCountryID;

                    arParms[40] = new SqlParameter("@pStateID", SqlDbType.Int);
                    arParms[40].Value = objstd.pStateID;

                    arParms[41] = new SqlParameter("@pDistrictID", SqlDbType.Int);
                    arParms[41].Value = objstd.pDistrictID;

                    arParms[42] = new SqlParameter("@pPIN", SqlDbType.Int);
                    arParms[42].Value = objstd.pPIN;

                    arParms[43] = new SqlParameter("@pLandMark", SqlDbType.VarChar);
                    arParms[43].Value = objstd.pLandMark;

                    arParms[44] = new SqlParameter("@UserloginID", SqlDbType.Int);
                    arParms[44].Value = objstd.UserId;

                    arParms[45] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[45].Value = objstd.CompanyID;

                    arParms[46] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[46].Value = objstd.AcademicSessionID;

                    arParms[47] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[47].Value = objstd.AddedBy;

                    arParms[48] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[48].Value = objstd.ActionType;

                    arParms[49] = new SqlParameter("@IsActive", SqlDbType.Bit);
                    arParms[49].Value = objstd.IsActive;

                    arParms[50] = new SqlParameter("@IsNew", SqlDbType.Int);
                    arParms[50].Value = objstd.IsNew;

                    arParms[51] = new SqlParameter("@OptSubjectID", SqlDbType.Int);
                    arParms[51].Value = objstd.OptSubjectID;

                    arParms[52] = new SqlParameter("@AdmissionID", SqlDbType.BigInt);
                    arParms[52].Value = objstd.AdmissionID;

                    arParms[53] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[53].Direction = ParameterDirection.Output;

                    arParms[54] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[54].Value = objstd.XmlSubjectlist;

                    arParms[55] = new SqlParameter("@NationalityID", SqlDbType.Int);
                    arParms[55].Value = objstd.NationalityID;

                    arParms[56] = new SqlParameter("@Msalutation", SqlDbType.Int);
                    arParms[56].Value = objstd.Msalutation;

                    arParms[57] = new SqlParameter("@Mothername", SqlDbType.VarChar);
                    arParms[57].Value = objstd.Mothername;

                    arParms[58] = new SqlParameter("@MotherOccupation", SqlDbType.VarChar);
                    arParms[58].Value = objstd.MotherOccupation;

                    arParms[59] = new SqlParameter("@Istakingtransport", SqlDbType.Bit);
                    arParms[59].Value = objstd.Istakingtransport;

                    arParms[60] = new SqlParameter("@TransportTypeID", SqlDbType.Int);
                    arParms[60].Value = objstd.TransportTypeID;

                    arParms[61] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                    arParms[61].Value = objstd.VehicleNo;

                    arParms[62] = new SqlParameter("@BloogroupID", SqlDbType.Int);
                    arParms[62].Value = objstd.BloogroupID;

                    arParms[63] = new SqlParameter("@HouseID", SqlDbType.Int);
                    arParms[63].Value = objstd.HouseID;

                    arParms[64] = new SqlParameter("@IDmarks", SqlDbType.VarChar);
                    arParms[64].Value = objstd.IDmarks;

                    arParms[65] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime);
                    arParms[65].Value = objstd.AdmissionDate;

                    arParms[66] = new SqlParameter("@StudentImage", SqlDbType.Image);
                    arParms[66].Value = objstd.StudentImage;

                    arParms[67] = new SqlParameter("@Allerrgic", SqlDbType.VarChar);
                    arParms[67].Value = objstd.Allerrgic;

                    arParms[68] = new SqlParameter("@Isessioninitialheight", SqlDbType.BigInt);
                    arParms[68].Value = objstd.Isessioninitialheight;

                    arParms[69] = new SqlParameter("@Isessioninendingheight", SqlDbType.BigInt);
                    arParms[69].Value = objstd.Isessioninendingheight;

                    arParms[70] = new SqlParameter("@Isessioninitialweight", SqlDbType.BigInt);
                    arParms[70].Value = objstd.Isessioninitialweight;

                    arParms[71] = new SqlParameter("@Isessionendingweight", SqlDbType.BigInt);
                    arParms[71].Value = objstd.Isessionendingweight;

                    arParms[72] = new SqlParameter("@IIsessioninitialheight", SqlDbType.BigInt);
                    arParms[72].Value = objstd.IIsessioninitialheight;

                    arParms[73] = new SqlParameter("@IIsessioninitialweight", SqlDbType.BigInt);
                    arParms[73].Value = objstd.IIsessioninitialweight;

                    arParms[74] = new SqlParameter("@IIsessioninendingheight", SqlDbType.BigInt);
                    arParms[74].Value = objstd.IIsessioninendingheight;

                    arParms[75] = new SqlParameter("@IIsessionendingweight", SqlDbType.BigInt);
                    arParms[75].Value = objstd.IIsessionendingweight;

                    arParms[76] = new SqlParameter("@Rootno", SqlDbType.BigInt);
                    arParms[76].Value = objstd.Rootno;

                    arParms[77] = new SqlParameter("@OwnerNo", SqlDbType.BigInt);
                    arParms[77].Value = objstd.OwnerNo;

                    arParms[78] = new SqlParameter("@Income", SqlDbType.Money);
                    arParms[78].Value = objstd.Income;

                    arParms[79] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[79].Value = objstd.StudentCategory;

                    arParms[80] = new SqlParameter("@LastSchoolName", SqlDbType.VarChar);
                    arParms[80].Value = objstd.LastSchoolName;

                    arParms[81] = new SqlParameter("@LastClass", SqlDbType.VarChar);
                    arParms[81].Value = objstd.LastClass;

                    arParms[82] = new SqlParameter("@LastSection", SqlDbType.VarChar);
                    arParms[82].Value = objstd.LastSection;

                    arParms[83] = new SqlParameter("@LastRollno", SqlDbType.Int);
                    arParms[83].Value = objstd.LastRollno;

                    arParms[84] = new SqlParameter("@LastMark", SqlDbType.VarChar);
                    arParms[84].Value = objstd.LastMark;

                    arParms[85] = new SqlParameter("@Istransfer", SqlDbType.Bit);
                    arParms[85].Value = objstd.Istransfer;

                    arParms[86] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[86].Value = objstd.RollNo;

                    arParms[87] = new SqlParameter("@Aadhar", SqlDbType.VarChar);
                    arParms[87].Value = objstd.Aadhar;

                    arParms[88] = new SqlParameter("@IFSC", SqlDbType.VarChar);
                    arParms[88].Value = objstd.IFSC;

                    arParms[89] = new SqlParameter("@AC", SqlDbType.VarChar);
                    arParms[89].Value = objstd.AC;

                    arParms[90] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[90].Value = objstd.BankName;

                    arParms[91] = new SqlParameter("@EmaildID", SqlDbType.VarChar);
                    arParms[91].Value = objstd.EmaildID;

                    arParms[92] = new SqlParameter("@LastAttendance", SqlDbType.VarChar);
                    arParms[92].Value = objstd.LastAttendance;

                    arParms[93] = new SqlParameter("@RegdNo", SqlDbType.VarChar);
                    arParms[93].Value = objstd.RegdNo;

                    arParms[94] = new SqlParameter("@MotherTongue", SqlDbType.VarChar);
                    arParms[94].Value = objstd.MotherTongue;

                    arParms[95] = new SqlParameter("@BirthRegNo", SqlDbType.VarChar);
                    arParms[95].Value = objstd.BirthRegNo;

                    arParms[96] = new SqlParameter("@BelongToBPLoptionID", SqlDbType.Int);
                    arParms[96].Value = objstd.BelogToBPLoptionID;

                    arParms[97] = new SqlParameter("@EnrollmentNo", SqlDbType.VarChar);
                    arParms[97].Value = objstd.EnrollmentNo;

                    arParms[98] = new SqlParameter("@GurdianName", SqlDbType.VarChar);
                    arParms[98].Value = objstd.GurdianName;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentAdmissionDetail", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[53].Value);
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
        public List<StudentData> SearchStudentDetails(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[21];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objstd.SexID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objstd.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objstd.CurrentIndex;

                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objstd.ActionType;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[9].Value = objstd.IsActiveALL;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objstd.ClassID;

                    arParms[11] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[11].Value = objstd.SectionID;

                    arParms[12] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[12].Value = objstd.StreamID;

                    arParms[13] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[13].Value = objstd.Datefrom;

                    arParms[14] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[14].Value = objstd.Dateto;

                    arParms[15] = new SqlParameter("@IsNew", SqlDbType.Int);
                    arParms[15].Value = objstd.IsNewall;

                    arParms[16] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[16].Value = objstd.CastID;

                    arParms[17] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[17].Value = objstd.StudentCategory;

                    arParms[18] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[18].Value = objstd.UserId;

                    arParms[19] = new SqlParameter("@HouseID", SqlDbType.Int);
                    arParms[19].Value = objstd.HouseID;

                    arParms[20] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[20].Value = objstd.StudentTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchStudentDetails", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetStudentList(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[23];
                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objstd.SexID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objstd.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objstd.CurrentIndex;

                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objstd.ActionType;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[9].Value = objstd.IsActiveALL;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objstd.ClassID;

                    arParms[11] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[11].Value = objstd.SectionID;

                    arParms[12] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[12].Value = objstd.StreamID;

                    arParms[13] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[13].Value = objstd.Datefrom;

                    arParms[14] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[14].Value = objstd.Dateto;

                    arParms[15] = new SqlParameter("@IsNew", SqlDbType.Int);
                    arParms[15].Value = objstd.IsNewall;

                    arParms[16] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[16].Value = objstd.CastID;

                    arParms[17] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[17].Value = objstd.StudentCategory;

                    arParms[18] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[18].Value = objstd.UserId;

                    arParms[19] = new SqlParameter("@HouseID", SqlDbType.Int);
                    arParms[19].Value = objstd.HouseID;

                    arParms[20] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[20].Value = objstd.StudentTypeID;

                    arParms[21] = new SqlParameter("@AdmissionStatus", SqlDbType.Int);
                    arParms[21].Value = objstd.IsAdmissionDone;

                    arParms[22] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[22].Value = objstd.RollNo;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetstudentProfilelist", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetStudentListoexcel(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[21];
                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[1].Value = objstd.Sfirstname;

                    arParms[2] = new SqlParameter("@Smiddlename", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Smiddlename;

                    arParms[3] = new SqlParameter("@Slastname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Slastname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[5].Value = objstd.SexID;

                    arParms[6] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[6].Value = objstd.PageSize;

                    arParms[7] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[7].Value = objstd.CurrentIndex;

                    arParms[8] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[8].Value = objstd.ActionType;

                    arParms[9] = new SqlParameter("@IsActive", SqlDbType.VarChar);
                    arParms[9].Value = objstd.IsActiveALL;

                    arParms[10] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[10].Value = objstd.ClassID;

                    arParms[11] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[11].Value = objstd.SectionID;

                    arParms[12] = new SqlParameter("@StreamID", SqlDbType.Int);
                    arParms[12].Value = objstd.StreamID;

                    arParms[13] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
                    arParms[13].Value = objstd.Datefrom;

                    arParms[14] = new SqlParameter("@Dateto", SqlDbType.DateTime);
                    arParms[14].Value = objstd.Dateto;

                    arParms[15] = new SqlParameter("@IsNew", SqlDbType.Int);
                    arParms[15].Value = objstd.IsNewall;

                    arParms[16] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[16].Value = objstd.CastID;

                    arParms[17] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[17].Value = objstd.StudentCategory;

                    arParms[18] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[18].Value = objstd.UserId;

                    arParms[19] = new SqlParameter("@HouseID", SqlDbType.Int);
                    arParms[19].Value = objstd.HouseID;

                    arParms[20] = new SqlParameter("@StudentTypeID", SqlDbType.Int);
                    arParms[20].Value = objstd.StudentTypeID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetstudentListtoexcel", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> Getclasswisestudentlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objstd.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objstd.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objstd.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objstd.RollNo;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objstd.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objstd.CurrentIndex;

                    arParms[6] = new SqlParameter("@Status", SqlDbType.Int);
                    arParms[6].Value = objstd.IsAdmissionDone;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetStudentList", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<AutoRollData> Getautogenartedrollnumberst(AutoRollData objstd)
        {
            List<AutoRollData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objstd.AcademicSessionID;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objstd.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objstd.SectionID;

                    arParms[3] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[3].Value = objstd.RollNo;

                    arParms[4] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[4].Value = objstd.PageSize;

                    arParms[5] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[5].Value = objstd.CurrentIndex;

                    arParms[6] = new SqlParameter("@AllotedStatus", SqlDbType.Int);
                    arParms[6].Value = objstd.AllotedStatus;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetAutogenaredrollnumbers", arParms);
                    List<AutoRollData> lstStudentDetails = ORHelper<AutoRollData>.FromDataReaderToList(sqlReader);
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

        public List<StudentData> Getclass910tudentlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[14];

                    arParms[0] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[0].Value = objstd.AcademicSessionID;

                    arParms[1] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[1].Value = objstd.StudentID;

                    arParms[2] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Sfirstname;

                    arParms[3] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[3].Value = objstd.SexID;

                    arParms[4] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[4].Value = objstd.ClassID;

                    arParms[5] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[5].Value = objstd.SectionID;

                    arParms[6] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[6].Value = objstd.RollNo;

                    arParms[7] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[7].Value = objstd.StudentCategory;

                    arParms[8] = new SqlParameter("@AltSubjectID", SqlDbType.Int);
                    arParms[8].Value = objstd.AltSubjectID;

                    arParms[9] = new SqlParameter("@OptSubjectID", SqlDbType.Int);
                    arParms[9].Value = objstd.OptSubjectID;

                    arParms[10] = new SqlParameter("@MainSubjectID", SqlDbType.Int);
                    arParms[10].Value = objstd.MainSubjectID;

                    arParms[11] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[11].Value = objstd.PageSize;

                    arParms[12] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[12].Value = objstd.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetClassIX_X_StudentList", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetclassstudentPhotolist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    arParms[2] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[2].Value = objstd.SexID;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objstd.ClassID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = objstd.SectionID;

                    arParms[5] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[5].Value = objstd.RollNo;

                    arParms[6] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[6].Value = objstd.StudentCategory;

                    arParms[7] = new SqlParameter("@status", SqlDbType.Bit);
                    arParms[7].Value = objstd.IsActive;

                    arParms[8] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[8].Value = objstd.PageSize;

                    arParms[9] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[9].Value = objstd.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetStudentPhotoList", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetCsubjectlist(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AdmissionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AdmissionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_std_CsubjectList", arParms);
                    List<StudentData> csubjectlist = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
                    result = csubjectlist;
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
        public List<StudentData> SearchStudentDetailsByID(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchStudentDetailsByID", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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

        public List<StudentData> GetStudentID(StudentData objempt)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.AdmissionNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_autocompleteStdID", arParms);
                    List<StudentData> lstEmployeeDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentData> GetHostelStudentID(StudentData objempt)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar);
                    arParms[0].Value = objempt.AdmissionNo;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_autocompleteHostelStdID", arParms);
                    List<StudentData> lstEmployeeDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public List<StudentDetailData> GetStudentdetailbyRoll(StudentDetailData obj)
        {
            List<StudentDetailData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = obj.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = obj.SectionID;

                    arParms[2] = new SqlParameter("@Roll", SqlDbType.VarChar);
                    arParms[2].Value = obj.Roll;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = obj.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetstudentDetailbyroll", arParms);
                    List<StudentDetailData> resultlist = ORHelper<StudentDetailData>.FromDataReaderToList(sqlReader);
                    result = resultlist;
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
        public List<StudentDetailData> GetcurrentStudentdetailbyRoll(StudentDetailData obj)
        {
            List<StudentDetailData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[0].Value = obj.ClassID;

                    arParms[1] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[1].Value = obj.SectionID;

                    arParms[2] = new SqlParameter("@Roll", SqlDbType.VarChar);
                    arParms[2].Value = obj.Roll;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = obj.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetCurrentstudentDetailbyroll", arParms);
                    List<StudentDetailData> resultlist = ORHelper<StudentDetailData>.FromDataReaderToList(sqlReader);
                    result = resultlist;
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
        public List<StudentDetailData> GetcurrentStudentdetailbyStudentID(StudentDetailData obj)
        {
            List<StudentDetailData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];
    
                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = obj.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = obj.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetCurrentstudentDetaiBystudentID", arParms);
                    List<StudentDetailData> resultlist = ORHelper<StudentDetailData>.FromDataReaderToList(sqlReader);
                    result = resultlist;
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
        public int DeleteStudentDetailsByID(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[7];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.Int);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AdmissionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AdmissionID;

                    arParms[2] = new SqlParameter("@ActionType", SqlDbType.Int);
                    arParms[2].Value = objstd.ActionType;

                    arParms[3] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    arParms[5].Value = objstd.Remarks;

                    arParms[6] = new SqlParameter("@UserId", SqlDbType.BigInt);
                    arParms[6].Value = objstd.UserId;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_DeleteStudentDetails", arParms);
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
        public int CreatePTcertficate(ProvisionalTransfer objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[13];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objstd.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objstd.SectionID;

                    arParms[3] = new SqlParameter("@CertificateType", SqlDbType.Int);
                    arParms[3].Value = objstd.CertificateType;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[5].Value = objstd.AddedBy;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objstd.CompanyID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@HSCRollno", SqlDbType.Int);
                    arParms[8].Value = objstd.HSCRollno;

                    arParms[9] = new SqlParameter("@SecuredMark", SqlDbType.Int);
                    arParms[9].Value = objstd.SecuredMark;

                    arParms[10] = new SqlParameter("@CapturedMark", SqlDbType.Int);
                    arParms[10].Value = objstd.CapturedMark;

                    arParms[11] = new SqlParameter("@Result", SqlDbType.VarChar);
                    arParms[11].Value = objstd.Result;

                    arParms[12] = new SqlParameter("@Division", SqlDbType.VarChar);
                    arParms[12].Value = objstd.Division;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_CreatePTCertificate", arParms);
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
        public List<ProvisionalTransfer> SearchPTcertificate(ProvisionalTransfer objstd)
        {
            List<ProvisionalTransfer> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[1].Value = objstd.ClassID;

                    arParms[2] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[2].Value = objstd.SectionID;

                    arParms[3] = new SqlParameter("@CertificateType", SqlDbType.Int);
                    arParms[3].Value = objstd.CertificateType;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchPTCertificate", arParms);
                    List<ProvisionalTransfer> lstStudentDetails = ORHelper<ProvisionalTransfer>.FromDataReaderToList(sqlReader);
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
        public int DeletePTCertificateByID(ProvisionalTransfer objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@ID", SqlDbType.Int);
                    arParms[0].Value = objstd.ID;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[2].Value = objstd.AcademicSessionID;

                    arParms[3] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[3].Value = objstd.AddedBy;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_DeletePTCertificatesByID", arParms);
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

        public List<StudentData> SearchStudentProfile(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchStudentProfile", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        ////////////////////////Certificate////////////////////////////////////////////
        public int Createcertficate(Characterdata objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[1].Value = objstd.xmlcertificatestudentlist;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objstd.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objstd.SectionID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[5].Value = objstd.AddedBy;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objstd.CompanyID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@Ctype", SqlDbType.Int);
                    arParms[8].Value = objstd.Ctype;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_CreateCertificate", arParms);
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
        public int Updatecertficate(Characterdata objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.VarChar);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[1].Value = objstd.xmlcertificatestudentlist;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objstd.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objstd.SectionID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@AddedBy", SqlDbType.VarChar);
                    arParms[5].Value = objstd.AddedBy;

                    arParms[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
                    arParms[6].Value = objstd.CompanyID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    arParms[8] = new SqlParameter("@Ctype", SqlDbType.Int);
                    arParms[8].Value = objstd.Ctype;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateCertificate", arParms);
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
        public List<Characterdata> GetStudentCharacterdata(Characterdata objstd)
        {
            List<Characterdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[1];

                    arParms[0] = new SqlParameter("@Characters", SqlDbType.VarChar);
                    arParms[0].Value = objstd.Characters;
                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_GetCharacterdata", arParms);
                    List<Characterdata> lstStudentDetails = ORHelper<Characterdata>.FromDataReaderToList(sqlReader);
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
        public List<Characterdata> Searchcertificate(Characterdata objstd)
        {
            List<Characterdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@Ctype", SqlDbType.Int);
                    arParms[1].Value = objstd.Ctype;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objstd.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objstd.SectionID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[5].Value = objstd.StudentID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchCertificate", arParms);
                    List<Characterdata> lstStudentDetails = ORHelper<Characterdata>.FromDataReaderToList(sqlReader);
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
        public List<Characterdata> SearchCreatecertificate(Characterdata objstd)
        {
            List<Characterdata> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[6];

                    arParms[0] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[0].Value = objstd.RollNo;

                    arParms[1] = new SqlParameter("@Ctype", SqlDbType.Int);
                    arParms[1].Value = objstd.Ctype;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objstd.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objstd.SectionID;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[5].Value = objstd.StudentID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_SearchCreatemakerficate", arParms);
                    List<Characterdata> lstStudentDetails = ORHelper<Characterdata>.FromDataReaderToList(sqlReader);
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


        ///////////////////////////////////////STUDENT EDITOR////////////////////////
        public List<StudentData> GetclasswisestudentIDDetails(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[9];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    arParms[2] = new SqlParameter("@SexID", SqlDbType.Int);
                    arParms[2].Value = objstd.SexID;

                    arParms[3] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[3].Value = objstd.ClassID;

                    arParms[4] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[4].Value = objstd.SectionID;

                    arParms[5] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[5].Value = objstd.RollNo;

                    arParms[6] = new SqlParameter("@StudentCategory", SqlDbType.Int);
                    arParms[6].Value = objstd.StudentCategory;

                    arParms[7] = new SqlParameter("@PageSize", SqlDbType.Int);
                    arParms[7].Value = objstd.PageSize;

                    arParms[8] = new SqlParameter("@CurrentIndex", SqlDbType.Int);
                    arParms[8].Value = objstd.CurrentIndex;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_GetStudentdetails", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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

        public int UpdateStudentIDDetails(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@XMLData", SqlDbType.Xml);
                    arParms[0].Value = objstd.XmlStudentlist;

                    arParms[1] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[1].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentIDDetails", arParms);
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
        public List<StudentData> ActivatedStudentDetails(StudentData objstd)
        {
            List<StudentData> result = null;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[2];

                    arParms[0] = new SqlParameter("@StudentID", SqlDbType.BigInt);
                    arParms[0].Value = objstd.StudentID;

                    arParms[1] = new SqlParameter("@academicSessionID", SqlDbType.Int);
                    arParms[1].Value = objstd.AcademicSessionID;

                    SqlDataReader sqlReader = null;
                    sqlReader = SqlHelper.ExecuteReader(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_ActivatedStudentDetails", arParms);
                    List<StudentData> lstStudentDetails = ORHelper<StudentData>.FromDataReaderToList(sqlReader);
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
        public int UpdateStudentProfileTab1(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[17];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@IsNewall", SqlDbType.Int);
                    arParms[1].Value = objstd.IsNewall;

                    arParms[2] = new SqlParameter("@DOB", SqlDbType.DateTime);
                    arParms[2].Value = objstd.DOB;

                    arParms[3] = new SqlParameter("@Sfirstname", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Sfirstname;

                    arParms[4] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[4].Value = objstd.AcademicSessionID;

                    arParms[5] = new SqlParameter("@BirthRegNo", SqlDbType.VarChar);
                    arParms[5].Value = objstd.BirthRegNo;

                    arParms[6] = new SqlParameter("@StudenttypeID", SqlDbType.Int);
                    arParms[6].Value = objstd.StudentTypeID;

                    arParms[7] = new SqlParameter("@CastID", SqlDbType.Int);
                    arParms[7].Value = objstd.CastID;

                    arParms[8] = new SqlParameter("@sexID", SqlDbType.Int);
                    arParms[8].Value = objstd.SexID;

                    arParms[9] = new SqlParameter("@ReligionID", SqlDbType.Int);
                    arParms[9].Value = objstd.ReligionID;

                    arParms[10] = new SqlParameter("@MotherTongue", SqlDbType.VarChar);
                    arParms[10].Value = objstd.MotherTongue;

                    arParms[11] = new SqlParameter("@BelongToBPL", SqlDbType.Int);
                    arParms[11].Value = objstd.BelogToBPLoptionID;

                    arParms[12] = new SqlParameter("@StudentCategoryID", SqlDbType.Int);
                    arParms[12].Value = objstd.StudentCategory;

                    arParms[13] = new SqlParameter("@IDmarks", SqlDbType.VarChar);
                    arParms[13].Value = objstd.IDmarks;

                    arParms[14] = new SqlParameter("@HouseID", SqlDbType.Int);
                    arParms[14].Value = objstd.HouseID;

                    arParms[15] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[15].Value = objstd.tab;

                    arParms[16] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[16].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[16].Value);
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
        public int UpdateStudentProfileTab2(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@ClassID", SqlDbType.Int);
                    arParms[2].Value = objstd.ClassID;

                    arParms[3] = new SqlParameter("@SectionID", SqlDbType.Int);
                    arParms[3].Value = objstd.SectionID;

                    arParms[4] = new SqlParameter("@RollNo", SqlDbType.Int);
                    arParms[4].Value = objstd.RollNo;

                    arParms[5] = new SqlParameter("@RegNo", SqlDbType.VarChar);
                    arParms[5].Value = objstd.RegdNo;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = objstd.AcademicSessionID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
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

        public int UpdateStudentProfileTab3(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@BloogroupID", SqlDbType.Int);
                    arParms[2].Value = objstd.BloodGroupID;

                    arParms[3] = new SqlParameter("@Allerrgic", SqlDbType.VarChar);
                    arParms[3].Value = objstd.Allerrgic;

                    arParms[4] = new SqlParameter("@IstWeight", SqlDbType.BigInt);
                    arParms[4].Value = objstd.IIsessioninitialweight;

                    arParms[5] = new SqlParameter("@IstHeight", SqlDbType.BigInt);
                    arParms[5].Value = objstd.IIsessioninitialheight;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = objstd.AcademicSessionID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
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

        public int UpdateStudentProfileTab4(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[11];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@GfirstName", SqlDbType.VarChar);
                    arParms[2].Value = objstd.FatherName;

                    arParms[3] = new SqlParameter("@MotherName", SqlDbType.VarChar);
                    arParms[3].Value = objstd.MotherName;

                    arParms[4] = new SqlParameter("@Grelationship", SqlDbType.Int);
                    arParms[4].Value = objstd.GrelationshipID;

                    arParms[5] = new SqlParameter("@Goccupation", SqlDbType.VarChar);
                    arParms[5].Value = objstd.Goccupation;

                    arParms[6] = new SqlParameter("@Moccupation", SqlDbType.VarChar);
                    arParms[6].Value = objstd.MotherOccupation;

                    arParms[7] = new SqlParameter("@Income", SqlDbType.Money);
                    arParms[7].Value = objstd.Income;

                    arParms[8] = new SqlParameter("@GmobileNo", SqlDbType.VarChar);
                    arParms[8].Value = objstd.GmobileNo;

                    arParms[9] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[9].Value = objstd.AcademicSessionID;

                    arParms[10] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[10].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
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

        public int UpdateStudentProfileTab5(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[10];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@LastSchoolName", SqlDbType.VarChar);
                    arParms[2].Value = objstd.LastSchoolName;

                    arParms[3] = new SqlParameter("@LastClass", SqlDbType.VarChar);
                    arParms[3].Value = objstd.LastClass;

                    arParms[4] = new SqlParameter("@LastSection", SqlDbType.VarChar);
                    arParms[4].Value = objstd.LastSection;

                    arParms[5] = new SqlParameter("@LastRollno", SqlDbType.Int);
                    arParms[5].Value = objstd.LastRollno;

                    arParms[6] = new SqlParameter("@LastMark", SqlDbType.VarChar);
                    arParms[6].Value = objstd.LastMark;

                    arParms[7] = new SqlParameter("@LastAttendance", SqlDbType.Money);
                    arParms[7].Value = objstd.LastAttendance;

                    arParms[8] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[8].Value = objstd.AcademicSessionID;

                    arParms[9] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[9].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
                    if (result_ > 0 || result_ == -1)
                        result = Convert.ToInt32(arParms[9].Value);
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

        public int UpdateStudentProfileTab6(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[8];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@BankName", SqlDbType.VarChar);
                    arParms[2].Value = objstd.BankName;

                    arParms[3] = new SqlParameter("@IFSC", SqlDbType.VarChar);
                    arParms[3].Value = objstd.IFSC;

                    arParms[4] = new SqlParameter("@AC", SqlDbType.VarChar);
                    arParms[4].Value = objstd.AC;

                    arParms[5] = new SqlParameter("@Aadhar", SqlDbType.VarChar);
                    arParms[5].Value = objstd.Aadhar;

                    arParms[6] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[6].Value = objstd.AcademicSessionID;

                    arParms[7] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[7].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
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

        public int UpdateStudentProfileTab7(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@Address", SqlDbType.VarChar);
                    arParms[2].Value = objstd.Address;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objstd.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
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

        public int UpdateStudentProfileTab8(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@pAddress", SqlDbType.VarChar);
                    arParms[2].Value = objstd.pAddress
;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objstd.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
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

        public int UpdateStudentProfileTab9(StudentData objstd)
        {
            int result = 0;
            try
            {
                {
                    SqlParameter[] arParms = new SqlParameter[5];

                    arParms[0] = new SqlParameter("@AdmissionNo", SqlDbType.BigInt);
                    arParms[0].Value = objstd.AdmissionNo;

                    arParms[1] = new SqlParameter("@tab", SqlDbType.Int);
                    arParms[1].Value = objstd.tab;

                    arParms[2] = new SqlParameter("@SubjectList", SqlDbType.VarChar);
                    arParms[2].Value = objstd.SubjectName;

                    arParms[3] = new SqlParameter("@AcademicSessionID", SqlDbType.Int);
                    arParms[3].Value = objstd.AcademicSessionID;

                    arParms[4] = new SqlParameter("@Output", SqlDbType.SmallInt);
                    arParms[4].Direction = ParameterDirection.Output;

                    int result_ = SqlHelper.ExecuteNonQuery(GlobalConstant.ConnectionString, CommandType.StoredProcedure, "usp_CMS_Std_UpdateStudentProfile", arParms);
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
