using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.EduEmployee;
using Mobimp.Edusoft.BussinessProcess.EduEmployee;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.UserControls;

namespace Mobimp.Edusoft.Web
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindprofile();

            }
        }
        private void bindprofile()
        {
            try
            {
                EmployeeData objemp = new EmployeeData();
                EmployeeBO objempBO = new EmployeeBO();
                objemp.EmployeeID = LoginToken.EmployeeID;
                objemp.ActionType = EnumActionType.Select;
                List<EmployeeData> GetResult = objempBO.GetEmployeeDetailsByID(objemp);
                if (GetResult.Count > 0)
                {
                    txtsalutation.Text = GetResult[0].Salutation.ToString();
                    txtEmpno.Text = "Emp No: " + GetResult[0].EmployeeNo.ToString();
                    txtemployeename.Text = GetResult[0].EmpName;
                    txtreligion.Text = GetResult[0].Religion.ToString();
                    txtsex.Text = GetResult[0].SexName.ToString();
                    txtmarital.Text = GetResult[0].MaritalStatus.ToString();
                    txtCast.Text = GetResult[0].CastName.ToString();
                    txtdepartment.Text = GetResult[0].Department.ToString();
                    txtdesignation.Text = GetResult[0].Designation.ToString();
                    txtcurrcountry.Text = GetResult[0].CurrCountry.ToString();
                    txtcurrstate.Text = GetResult[0].CurrState.ToString();
                    txtcurrdistrict.Text = GetResult[0].CurrDistrict.ToString();
                    txtpermtcountry.Text = GetResult[0].PerCountry.ToString();
                    txtpermstate.Text = GetResult[0].PerState.ToString();
                    txtpermdistrict.Text = GetResult[0].PerDistrict.ToString();
                    txtdatebirth.Text = GetResult[0].DOB.ToString("dd/MM/yyyy");
                    txtphone.Text = GetResult[0].PhoneNo;
                    txtmobile.Text = GetResult[0].MobileNo;
                    txtemailID.Text = GetResult[0].EmaildID;
                    txtcurraddress.Text = GetResult[0].CurrentAddress;
                    txtcurrpin.Text = GetResult[0].CurrentPIN.ToString();
                    txtcurrlandmarks.Text = GetResult[0].CurrentLandMark;
                    txtpermaddress.Text = GetResult[0].PermAddress;
                    txtperlandmark.Text = GetResult[0].PermLandMark;
                    txtperpin.Text = GetResult[0].PermPIN.ToString();
                    txtemployeetype.Text = GetResult[0].EmployeeType.ToString();
                    imglogo.Src = GetResult[0].EmployeePhotoLocation;
                    txtqualification.Text = GetResult[0].Qualification;
                    bindgrid();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                Response.Redirect("Login.aspx", false);
            }
        }
        private void bindgrid()
        {
            List<AssignSubjectData> lstsubject = getAssignSubjectdetails(0);
            if (lstsubject.Count > 0)
            {
                GvAssign.DataSource = lstsubject;
                GvAssign.DataBind();

            }
            else
            {
                GvAssign.DataSource = null;
                GvAssign.DataBind();
            }
        }
        public List<AssignSubjectData> getAssignSubjectdetails(int curIndex)
        {

            AssignSubjectData objassignsubj = new AssignSubjectData();
            AssignSubjectBO objassignsubjBO = new AssignSubjectBO();
            objassignsubj.EmployeeID = LoginToken.EmployeeID;
            objassignsubj.IsActiveALL = "1";
            objassignsubj.ActionType = EnumActionType.Select;
            objassignsubj.PageSize = GvAssign.PageSize;
            objassignsubj.CurrentIndex = curIndex;
            return objassignsubjBO.SearchAssignDetails(objassignsubj);

        }
        protected void GvAssign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAssign.DataSource = getAssignSubjectdetails(e.NewPageIndex);
            GvAssign.DataBind();
        }
    }

}