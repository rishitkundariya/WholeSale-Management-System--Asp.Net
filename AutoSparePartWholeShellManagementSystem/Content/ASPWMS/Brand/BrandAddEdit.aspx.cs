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

public partial class Content_ASPWMS_Brand_BrandAddEdit : System.Web.UI.Page
{
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
        {
            if(Request.QueryString["q"]!=null)
            {
                FillData(Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString()))));
                lblPageHeading.Text = "Edit Brand";
            }
            else
                lblPageHeading.Text = "Add Brand";
        }
    }
    #endregion
    
    #region Fill Data in edit Mode
    protected void FillData(int BrandID)
    {
        BrandBAL balBrand = new BrandBAL();
        BrandENT entBrand = new BrandENT();
        entBrand = balBrand.SelectByPK(BrandID);
        if (entBrand != null)
        {
            if (entBrand.BrandName.ToString() != null)
                txtBrandName.Text = entBrand.BrandName.ToString();
            if (entBrand.BrandSortName.ToString() != null)
                txtBrandSortName.Text = entBrand.BrandSortName.ToString();
        }
        else
        {
            lblMessage.Text = balBrand.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
    #endregion

    #region SAVE BUTTON CLICK EVENT
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        BrandENT entBrand = new BrandENT();
        if (txtBrandName.Text.Trim() == null)
            lblMessage.Text += "Enter Brand name </br>";
        if (txtBrandSortName.Text.Trim() == null)
            lblMessage.Text += "Enter Brand Sortname </br>";
        if (lblMessage.Text != "")
        {
            lblMessage.CssClass = "text-danger";
            return;
        }
        else
        {
           
            entBrand.BrandName = txtBrandName.Text.Trim();
            entBrand.BrandSortName = txtBrandSortName.Text.Trim();
        }
        #endregion

        BrandBAL balBrand = new BrandBAL();
        if (Request.QueryString["q"] == null)
        {
            if (balBrand.Insert(entBrand))
            {
                lblMessage.Text = "Data Enter Successfully";
                lblMessage.CssClass = "alert-success";
                ClearControl();
            }
            else
            {
                lblMessage.Text = balBrand.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        else
        {
            entBrand.BrandID =Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString())));
            if (balBrand.Update(entBrand))
            {
                Response.Redirect("~/Content/ASPWMS/Brand/BrandList.aspx");
            }
            else
            {
                lblMessage.Text = balBrand.Message;
                lblMessage.CssClass = "text-danger";
            }
        }

    }
    #endregion

    #region Cancle Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Brand/BrandList.aspx");
    }
    #endregion

    #region Clear Control
    public void ClearControl()
    {
        txtBrandName.Text = null;
        txtBrandSortName.Text = null;
    }
    #endregion
}