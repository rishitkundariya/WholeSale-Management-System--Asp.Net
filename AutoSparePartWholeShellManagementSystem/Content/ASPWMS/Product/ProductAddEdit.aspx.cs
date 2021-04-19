using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_Product_ProductAddEdit : System.Web.UI.Page
{
    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
        {
            CommonFillMethod.FillStateDropDownListBrand(ddlBrandName);
            if (Request.QueryString["q"] != null)
            {
                lblPageHeading.Text = "Edit Product Details";
                FillData(Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString()))));
            }
        }
    }
    #endregion

    #region FillData 
    private void FillData(SqlInt32 ProductID)
    {
        ProductBAL balProduct = new ProductBAL();
        ProductENT entProduct = new ProductENT();
        entProduct = balProduct.SelectByPK(ProductID);
        if(entProduct!=null)
        {
            txtProductName.Text = entProduct.Product_Name.ToString();
            txtPrice.Text = entProduct.Product_Price.ToString();
            ddlBrandName.SelectedValue = entProduct.Product_BrandID.ToString();
      
        }
        else
        {
            lblMessage.Text = balProduct.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
    #endregion

    #region Save Button Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ProductBAL balProduct = new ProductBAL();
        ProductENT entProduct = new ProductENT();
        #region Server Side Validation

        if (txtProductName.Text.Trim() == null)
            lblMessage.Text += "Enter Product Name";
        if (txtPrice.Text.Trim() == null)
            lblMessage.Text += "Enter Price";
        if (ddlBrandName.SelectedIndex == 0)
            lblMessage.Text += "Select Brand";

        if (lblMessage.Text.Trim() != null)
        {
            entProduct.Product_Name = txtProductName.Text.Trim();
            entProduct.Product_Price = Convert.ToDecimal(txtPrice.Text.Trim());
            entProduct.Product_BrandID = Convert.ToInt32(ddlBrandName.SelectedValue);

        }
        else
            return;

        
        
        #endregion
        if (Request.QueryString["q"] != null)
        {
            entProduct.ProductID= Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString())));
            if (balProduct.Update(entProduct))
            {
                Response.Redirect("~/Content/ASPWMS/Product/ProductList.aspx");
            }
            else
            {
                lblMessage.Text = balProduct.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        else
        {
            if (balProduct.Insert(entProduct))
            {
                lblMessage.Text = "Data Enter Successfully";
                lblMessage.CssClass = "alert-success";
                ClearControl();
            }
            else
            {
                lblMessage.Text = balProduct.Message;
                lblMessage.CssClass = "text-danger"; 
            }
        }
    }

 
    #endregion

    #region Cancle Button Click
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Product/ProductList.aspx");
    }
    #endregion

    #region ClearControl
    private void ClearControl()
    {
        txtPrice.Text = null;
        txtProductName.Text = null;
        ddlBrandName.SelectedIndex = 0;
    }
    #endregion

}