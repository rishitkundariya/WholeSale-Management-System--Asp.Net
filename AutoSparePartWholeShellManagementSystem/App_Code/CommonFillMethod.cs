using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

/// <summary>
/// Summary description for CommonFillMethod
/// </summary>
public class CommonFillMethod
{
    #region Constructor
    public CommonFillMethod()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion
    
    #region FillDropDownList  Brand
    public static void FillStateDropDownListBrand(DropDownList ddlBrand)
    {
        BrandBAL balState = new BrandBAL();
        ddlBrand.DataSource = balState.SelectForDropDown();
        ddlBrand.DataTextField = "BrandName";
        ddlBrand.DataValueField = "BrandID";
        ddlBrand.DataBind();
        ddlBrand.Items.Insert(0, new ListItem("Select Brand", "-1"));
    }
    #endregion

    #region FillDropDownList  City
    public static void FillStateDropDownListCity(DropDownList ddlCity)
    {
        CityBAL balState = new CityBAL();
        ddlCity.DataSource = balState.SelectForDropDown();
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityID";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
    }
    #endregion

    #region FillDropDownList Retailer
    public static void FillStateDropDownListRetailer(DropDownList ddlRetailer)
    {
        RetailerBAL balRetailer = new RetailerBAL();
        ddlRetailer.DataSource = balRetailer.SelectForDropDown();
        ddlRetailer.DataTextField = "ShopName";
        ddlRetailer.DataValueField = "RetailerID";
        ddlRetailer.DataBind();
        ddlRetailer.Items.Insert(0, new ListItem("Select Retailer", "-1"));
    }
    #endregion

    #region FillDropDownList Supplier
    public static void FillStateDropDownListSupplier(DropDownList ddlSupplier)
    {
        SupplierBAL balSupplier = new SupplierBAL();
        ddlSupplier.DataSource = balSupplier.SelectForDropDown();
        ddlSupplier.DataTextField = "SupplierName";
        ddlSupplier.DataValueField = "SupplierID";
        ddlSupplier.DataBind();
        ddlSupplier.Items.Insert(0, new ListItem("Select Supplier", "-1"));
    }
    #endregion

    #region FillDropDownList Product
    public static void FillStateDropDownListProduct(DropDownList ddlProduct)
    {
        ProductBAL balProduct = new ProductBAL();
        ddlProduct.DataSource = balProduct.SelectForDropDown();
        ddlProduct.DataTextField = "Product_Name";
        ddlProduct.DataValueField = "ProductID";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("Select Product", "-1"));
    }
    #endregion

}