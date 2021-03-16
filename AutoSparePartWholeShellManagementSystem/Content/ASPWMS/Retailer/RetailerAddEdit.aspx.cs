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

public partial class Content_ASPWMS_Retailer_RetailerAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDown();
            if (Request.QueryString["RetailerID"] != null)
            {
                FillData(Convert.ToInt32(Request.QueryString["RetailerID"].ToString()));
                lblPageHeading.Text = "Edit Retailer";
            }
            else
                lblPageHeading.Text = "Add Retailer";

            
        }

    }

    #region Fill Data 
    protected void FillData(int RetailerID)
    {

        RetailerBAL balRetailer = new RetailerBAL();
        RetailerENT entRetailer = new RetailerENT();
        entRetailer = balRetailer.SelectByPK(RetailerID);
        if (entRetailer!=null)
        {
            txtRetailerName.Text = entRetailer.RetailerName.ToString();
            txtShopName.Text = entRetailer.ShopName.ToString();
            txtShopAddress.Text = entRetailer.ShopAddress.ToString();
            txtMobileNumber.Text = entRetailer.MobileNumber.ToString();
            txtTransport.Text = entRetailer.TransportName.ToString();
            ddlCity.SelectedValue = entRetailer.CityID.ToString();
            if(entRetailer.Email!=null)
                txtEmail.Text = entRetailer.Email.ToString();

        }
        else
        {
            lblMessage.Text = balRetailer.Message;
            lblMessage.CssClass = "text-danger";
        }

    }
    #endregion

    #region Fill Drop Down Of City
    protected void FillDropDown()
    {

        CommonFillMethod.FillStateDropDownListCity(ddlCity);
        
    }
    #endregion

    #region save Button click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {

        RetailerENT entRetailer = new RetailerENT();
        RetailerBAL balRetailer = new RetailerBAL();
        #region Serever Side Value Check And Assign
        if (txtRetailerName.Text.Trim() == null)
            lblMessage.Text += "Enter Retailer Name";
        if (txtShopAddress.Text.Trim() == null)
            lblMessage.Text += "Enter Shop Address";
        if (txtShopName.Text.Trim() == null)
            lblMessage.Text += "Enter Shop Name";
        if (txtMobileNumber.Text.Trim() == null)
            lblMessage.Text += "Enter Mobile Number ";
        if (txtTransport.Text.Trim() == null)
            lblMessage.Text += "EnterTransport Name";
        if (ddlCity.SelectedIndex == 0)
            lblMessage.Text += "Select City ";
        lblMessage.CssClass = "text-danger";
        if (lblMessage.Text == "")
        {
            entRetailer.RetailerName = txtRetailerName.Text.Trim();
            entRetailer.ShopName = txtShopName.Text.Trim();
            entRetailer.ShopAddress = txtShopAddress.Text.Trim();
            entRetailer.MobileNumber = txtMobileNumber.Text.Trim();
            entRetailer.TransportName = txtTransport.Text.Trim();
            entRetailer.CityID = Convert.ToInt32(ddlCity.SelectedValue);
            if (Request.QueryString["RetailerID"] != null)
                entRetailer.RetailerID = Convert.ToInt32(Request.QueryString["RetailerID"]);
            if (txtEmail.Text.Trim() != "")
            {
                entRetailer.Email = txtEmail.Text.Trim();
            }
            else
                entRetailer.Email = null;
        }
        else
            return;

        #endregion
      
        if (Request.QueryString["RetailerID"] == null)
        {
            if (balRetailer.Insert(entRetailer))
            {
                lblMessage.Text = "Data Entered Successfully";
                lblMessage.CssClass = "alert-success";
                ClearControl();

            }
            else
            {
                lblMessage.Text = balRetailer.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        else
        {
            if (balRetailer.Update(entRetailer))
            {
                Response.Redirect("~/Content/ASPWMS/Retailer/RetailerList.aspx");
            }
            else
            {
                lblMessage.Text = balRetailer.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

    }
    #endregion

    #region  cancel button click Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Retailer/RetailerList.aspx");
    }
    #endregion

    #region Clear Control
    public void ClearControl()
    {
        txtEmail.Text = null;
        txtMobileNumber.Text = null;
        txtRetailerName.Text = null;
        txtShopAddress.Text = null;
        txtShopName.Text = null;
        txtTransport.Text = null;
        ddlCity.SelectedIndex = 0;
    }
    #endregion
}