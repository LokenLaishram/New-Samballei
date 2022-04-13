using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduFees
{
    public class FeeCollectionData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public int IsTop10 { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public int StudentTypeID { get; set; }
        [DataMember]
        public int Class { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public Int64 AdmissionID { get; set; }
        [DataMember]
        public int ClassID { get; set; }
        [DataMember]
        public int PaymentType { get; set; }
        [DataMember]
        public string PaymentTypename { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int FeeTypeID { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string SexName { get; set; }
        [DataMember]
        public string StreamName { get; set; }
        [DataMember]
        public int PayModeID { get; set; }
        [DataMember]
        public string PayMode { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string ChalanNo { get; set; }
        [DataMember]
        public Decimal FeeAmount { get; set; }
        [DataMember]
        public Decimal GeneralFeeamount { get; set; }
        [DataMember]
        public Decimal Totalexemption { get; set; }
        [DataMember]
        public Decimal PaidAmount { get; set; }
        [DataMember]
        public Decimal TotalBill { get; set; }
        [DataMember]
        public Decimal TotalBillAmount { get; set; }
        [DataMember]
        public Decimal FineAmount { get; set; }
        [DataMember]
        public Decimal TotalAmount { get; set; }
        [DataMember]
        public int JanuaryID { get; set; }
        [DataMember]
        public string January { get; set; }
        [DataMember]
        public int FebruaryID { get; set; }
        [DataMember]
        public string February { get; set; }
        [DataMember]
        public int MarchID { get; set; }
        [DataMember]
        public string IsactiveAll { get; set; }
        [DataMember]
        public string March { get; set; }
        [DataMember]
        public int AprilID { get; set; }
        [DataMember]
        public string April { get; set; }
        [DataMember]
        public int MayID { get; set; }
        [DataMember]
        public string May { get; set; }
        [DataMember]
        public int JuneID { get; set; }
        [DataMember]
        public string June { get; set; }
        [DataMember]
        public int JulyID { get; set; }
        [DataMember]
        public string July { get; set; }
        [DataMember]
        public int AugustID { get; set; }
        [DataMember]
        public string August { get; set; }
        [DataMember]
        public int SeptemberID { get; set; }
        [DataMember]
        public string September { get; set; }
        [DataMember]
        public int OctoberID { get; set; }
        [DataMember]
        public string October { get; set; }
        [DataMember]
        public int NovemberID { get; set; }
        [DataMember]
        public string November { get; set; }
        [DataMember]
        public int DecemberID { get; set; }
        [DataMember]
        public string December { get; set; }
        [DataMember]
        public int ActionTypes { get; set; }
        [DataMember]
        public string Sfirstname { get; set; }
        [DataMember]
        public string Smiddlename { get; set; }
        [DataMember]
        public string Slastname { get; set; }
        [DataMember]
        public int SexID { get; set; }
        [DataMember]
        public int StreamID { get; set; }
        [DataMember]
        public DateTime Datefrom { get; set; }
        [DataMember]
        public DateTime Dateto { get; set; }
        [DataMember]
        public decimal TotalFees { get; set; }
        [DataMember]
        public decimal TotalFine { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string AdmissioNo { get; set; }
        [DataMember]
        public Decimal Janfine { get; set; }
        [DataMember]
        public Decimal Febfine { get; set; }
        [DataMember]
        public Decimal Marchfine { get; set; }
        [DataMember]
        public Decimal AprilFine { get; set; }
        [DataMember]
        public Decimal Mayfine { get; set; }
        [DataMember]
        public Decimal Junefine { get; set; }
        [DataMember]
        public Decimal Julyfine { get; set; }
        [DataMember]
        public Decimal Augstfine { get; set; }
        [DataMember]
        public Decimal Septfine { get; set; }
        [DataMember]
        public Decimal Octfine { get; set; }
        [DataMember]
        public Decimal Novfine { get; set; }
        [DataMember]
        public Decimal Decfine { get; set; }
        [DataMember]
        public int StudentCategoryID { get; set; }
        [DataMember]
        public int AdmissionTypeID { get; set; }
        [DataMember]
        public int TariffID { get; set; }
        [DataMember]
        public Decimal ExemptedAmount { get; set; }
        [DataMember]
        public Decimal Discount { get; set; }
        [DataMember]
        public Decimal Due { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public Decimal AmounttobePaid { get; set; }
        [DataMember]
        public Decimal AmountHaveToPaid { get; set; }
        ////SCHOOLFEESCOLLECTION////////////////////////////
        [DataMember]
        public Decimal DuePaidAmount { get; set; }
        [DataMember]
        public Decimal DueAmount { get; set; }
        [DataMember]
        public Decimal TotalFeeAmount { get; set; }
        [DataMember]
        public Decimal MonthlyFeeAmountPaid { get; set; }
        [DataMember]
        public Decimal CollectedDueAmount { get; set; }
        [DataMember]
        public int AdmissionStatus { get; set; }
        [DataMember]
        public int BoardingStatus { get; set; }
        [DataMember]
        public int AdmissionType { get; set; }
        [DataMember]
        public int FeeStatus { get; set; }
        [DataMember]
        public Int64 BillNo { get; set; }
        [DataMember]
        public string xmlmonthlyfeepaidstatuslist { get; set; }
        [DataMember]
        public string xmlmonthlyduefeepaidstatuslist { get; set; }
        [DataMember]
        public Decimal TotalSumFeeAmount { get; set; }
        [DataMember]
        public Decimal TotalSumDueFeeAmount { get; set; }
        [DataMember]
        public Decimal GrandTotalDueFeeAmount { get; set; }
        [DataMember]
        public Decimal GrandTotalFeeAmount { get; set; }
        [DataMember]
        public Decimal TotalexemptAmount { get; set; }
        [DataMember]
        public Decimal TotalFineAmount { get; set; }
        [DataMember]
        public Decimal TotalNetAmount { get; set; }
        [DataMember]
        public Decimal TotalDueDiscountAmount { get; set; }
        [DataMember]
        public Decimal TotalDiscountAmount { get; set; }
        [DataMember]
        public Decimal TotalPayableAmount { get; set; }
        [DataMember]
        public Decimal TotalDuePayableAmount { get; set; }
        [DataMember]
        public Decimal TotalDueAmount { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public Decimal FeeDueAmount { get; set; }
        // TOTAL SUM AMOUNT
        [DataMember]
        public Decimal SumTotalSumFeeAmount { get; set; }
        [DataMember]
        public Decimal SUMGrandTotalFeeAmount { get; set; }
        [DataMember]
        public Decimal SUMTotalexemptAmount { get; set; }
        [DataMember]
        public Decimal SUMTotalFineAmount { get; set; }
        [DataMember]
        public Decimal SUMTotalNetAmount { get; set; }
        [DataMember]
        public Decimal SUMTotalDiscountAmount { get; set; }
        [DataMember]
        public Decimal SUMTotalPayableAmount { get; set; }
        [DataMember]
        public Decimal SUMPaidAmount { get; set; }
        [DataMember]
        public Decimal SUMTotalDueAmount { get; set; }
        /////////////////////////////////////////////
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public int VihicleID { get; set; }
        [DataMember]
        public Decimal TotalCurrentDue { get; set; }
        [DataMember]
        public int Istakingtransports { get; set; }
    }
    public class ExcelFeeStudentList
    {
        [DataMember]
        public Int64 StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public string FeeType { get; set; }
        [DataMember]
        public Decimal TotalFeeAmount { get; set; }
        [DataMember]
        public Decimal TotalexemptAmount { get; set; }
        [DataMember]
        public Decimal TotalFineAmount { get; set; }
        [DataMember]
        public Decimal TotalNetAmount { get; set; }
        [DataMember]
        public Decimal TotalDiscountAmount { get; set; }
        [DataMember]
        public Decimal TotalPayableAmount { get; set; }
        [DataMember]
        public Decimal PaidAmount { get; set; }
        [DataMember]
        public Decimal TotalDueAmount { get; set; }
    }
    }
