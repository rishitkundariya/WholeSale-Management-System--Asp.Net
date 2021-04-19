using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_Supplier_SupplierAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        #region postback event
        if (!Page.IsPostBack)
        {
            FillDropDown();
            if (Request.QueryString["q"] != null)
            {
                lblPageHeading.Text = "Edit Supplier";
                FillData(Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString()))));
            }
            else
                lblPageHeading.Text = "Add Supplier";

         
           
        }
        #endregion
    }

    #region Fill datt In edit mode
    protected void FillData(int SupplierID)
    {
        SupplierBAL balSupplier = new SupplierBAL();
        SupplierENT entSupplier = new SupplierENT();
        entSupplier = balSupplier.SelectByPK(SupplierID);
        txtMobileNumber.Text = entSupplier.Number.ToString();
        txtSupplierName.Text = entSupplier.SupplierName.ToString();
        ddlBrandName.SelectedValue = entSupplier.BrandID.ToString();
        if(entSupplier.CityID.ToString()!=null)
           ddlCity.SelectedValue = entSupplier.CityID.ToString();

    }
    #endregion

    #region Fill Drop Down
    protected void FillDropDown()
    {
        CommonFillMethod.FillStateDropDownListBrand(ddlBrandName);
        CommonFillMethod.FillStateDropDownListCity(ddlCity);
    }
    #endregion

   
    #region Save Button Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SupplierENT entSupplier = new SupplierENT();

        #region server side value Check and Assign
        if (txtSupplierName.Text.Trim() == "")
            lblMessage.Text += "Enter Supplier Name";
        if (txtMobileNumber.Text.Trim() == "")
            lblMessage.Text += "Enter Mobile Number";
        if (ddlBrandName.SelectedIndex == 0)
            lblMessage.Text += "Select Brand ";
        if (lblMessage.Text == "")
        {
            entSupplier.SupplierName = txtSupplierName.Text.Trim();
            entSupplier.Number = txtMobileNumber.Text.Trim();
            entSupplier.BrandID =Convert.ToInt32(ddlBrandName.SelectedValue);
            if (ddlCity.SelectedIndex > 0)
                entSupplier.CityID = Convert.ToInt32(ddlCity.SelectedValue);
        }
        else
        {
            lblMessage.CssClass = "text-danger";
            return;
            
        }

        #endregion

        #region Insert or update

        SupplierBAL balSupplier = new SupplierBAL();
        if (Request.QueryString["q"] == null)
        {
            if (balSupplier.Insert(entSupplier))
            {
                lblMessage.Text = "Data Inserted Successfully";
                lblMessage.CssClass = "alert-success";
                ClearControl();
            }
            else
            {
                lblMessage.Text = balSupplier.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        else  
        {
            entSupplier.SupplierID = Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString())));
            if (balSupplier.Update(entSupplier))
            {
                Response.Redirect("~/Content/ASPWMS/Supplier/SupplierList.aspx");
            }
            else
            {
                lblMessage.Text = balSupplier.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        #endregion

    }
    #endregion

    #region Clear Control
    public void ClearControl()
    {
        txtMobileNumber.Text = null;
        txtSupplierName.Text = null;
        ddlBrandName.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0;
    }
    #endregion

    #region cancle Button Click Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Supplier/SupplierList.aspx");
    }
    #endregion
}