using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.EduInventory;
using Mobimp.Edusoft.BussinessProcess.EduInventory;
using Mobimp.Edusoft.Common;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;

namespace Mobimp.Edusoft.Web.EduInventory
{
    public partial class WorkOrderPreview : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string WONo = (Request["OrderNo"].ToString());
            GetWorkOrderDetails(WONo);
        }
        protected void GetWorkOrderDetails(string OrderNo)
        {
            WorkOrderData ObjData = new WorkOrderData();
            WorkOrderBO ObjBO = new WorkOrderBO();
            List<WorkOrderData> DataList = new List<WorkOrderData>();
            ObjData.WorkOrderNo = OrderNo;
            DataList = ObjBO.PrintWorkOrderDetailsByOrderNo(ObjData);
            if (DataList.Count > 0)
            {
                lblOrderNo.Text = DataList[0].WorkOrderNo;
                lblOrderDate.Text = DataList[0].OrderDate.ToString("dd/MM/yyyy");
                lblVendorName.Text = DataList[0].VendorName;
                lblSubject.Text = DataList[0].Subject;
                lblTemplateHeader.Text = Server.HtmlDecode(DataList[0].TemplateHeader);
                lblTemplateFooter.Text = Server.HtmlDecode(DataList[0].TemplateFooter);
                StringBuilder strwOrder = new StringBuilder();
                int Slno = 1;
                for (int i = 0; i < DataList.Count; i++)
                {
                    strwOrder.Append("<div class='row'>");
                    strwOrder.Append("<div class='col-sm-1'>" + Slno + "</div>");
                    strwOrder.Append("<div class='col-sm-4'>" + DataList[i].ItemName + "</div>");
                    strwOrder.Append("<div class='col-sm-1'>" + DataList[i].Size + "</div>");
                    strwOrder.Append("<div class='col-sm-2'>" + DataList[i].NoOfPage + "</div>");
                    strwOrder.Append("<div class='col-sm-2'>" + DataList[i].NoOfCopies + "</div>");
                    strwOrder.Append("<div class='col-sm-2'>" + DataList[i].NoOfIssuePaper + "</div>");
                    strwOrder.Append("</div>");
                    Slno = Slno + 1;
                }
                LtrWorkOrderTable.Text = strwOrder.ToString();
            }
        }
    }
}