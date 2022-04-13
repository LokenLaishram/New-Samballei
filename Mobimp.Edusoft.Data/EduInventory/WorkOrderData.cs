using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduInventory
{
    public class WorkOrderData : BaseData
    {
        [DataMember]
        public Int64 ID { get; set; }
        [DataMember]
        public string WorkOrderNo { get; set; }
        [DataMember]
        public string SysGenWorkOrderNo { get; set; }
        [DataMember]
        public string AddressTitle { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember] 
        public int OrderTypeID { get; set; }
        [DataMember]
        public string OrderTypeName { get; set; }       
        [DataMember]
        public int VendorTypeID { get; set; }
        [DataMember]
        public string VendorTypeName { get; set; }
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public string VendorAddress { get; set; }         
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public int SubGroupID { get; set; }
        [DataMember]
        public string SubGroupName { get; set; }
        [DataMember]
        public Int64 ItemID { get; set; }
        [DataMember]
        public string ItemCode { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int UnitID { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public string Size { get; set; }
        [DataMember]
        public int NoOfPage { get; set; }
        [DataMember]
        public int NoOfCopies { get; set; }
        [DataMember]
        public string ReceivedNo { get; set; }
        [DataMember]
        public int PreTotalReceived { get; set; }
        [DataMember]
        public int NowReceived { get; set; }
        [DataMember]
        public int TotalNowReceived { get; set; }
        [DataMember]
        public int TotalReceived { get; set; }
        [DataMember]
        public int DueReceived { get; set; }
        [DataMember]
        public int IsFullReceived { get; set; }
        [DataMember]
        public int ReceivedByID { get; set; }
        [DataMember]
        public string ReceivedBy { get; set; }
        [DataMember]
        public DateTime ReceivedDate { get; set; }       
        [DataMember]
        public string NoOfIssuePaper { get; set; }  
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public int PrintModeID { get; set; }
        [DataMember]
        public string PrintingMode { get; set; }
        [DataMember]
        public DateTime DeliverDate { get; set; }
        [DataMember]
        public string OrderDescription { get; set; }
        [DataMember]
        public int TotalCopies { get; set; }
        [DataMember]
        public int OrderTemplateID { get; set; }
        [DataMember]
        public string OrderTemplateName { get; set; }
        [DataMember]
        public string TemplateHeader { get; set; }
        [DataMember]
        public string DecodeTemplateHeader { get; set; }
        [DataMember]
        public string TemplateFooter { get; set; }
        [DataMember]
        public string DecodeTemplateFooter { get; set; }
        [DataMember]
        public string ItemDetails { get; set; }
        [DataMember]
        public string VendorDetail { get; set; }
        
    }
}
