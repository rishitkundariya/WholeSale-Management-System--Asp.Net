using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Product_ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
            FillGridView();
    }

    #region Fill Grid View
    private void FillGridView()
    {
        ProductBAL balProduct = new ProductBAL();
        DataTable dt = new DataTable();
        dt = balProduct.SelectAll();
        if (dt != null)
        {
            gvProduct.DataSource = dt;
            gvProduct.DataBind();
        }
        else
        {
            lblMessage.Text = balProduct.Message;
            lblMessage.CssClass = "text-danger";
        }
        gvProduct.UseAccessibleHeader = true;
        gvProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    #endregion

    #region Add button click Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Product/ProductAddEdit.aspx");
    }
    #endregion

    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName== "DeleteItem")
        {
            DeleteRecord(Convert.ToInt32(e.CommandArgument));
        }
        if (e.CommandName == "Edit")
        {
            string url = "~/Content/ASPWMS/Product/ProductAddEdit.aspx?q=" + HttpUtility.UrlEncode(Cryptography.EncryptQueryString(e.CommandArgument.ToString())).ToString();
            Response.Redirect(url);
        }
    }

    #region Delete Record
    private void DeleteRecord(SqlInt32 ProductID)
    {
        ProductBAL balProduct = new ProductBAL();
        if (balProduct.Delete(ProductID))
        {
            lblMessage.Text = "Delete Data Successfully";
            lblMessage.CssClass = "alert-success";
            FillGridView();
        }
        else
        {
            lblMessage.Text = balProduct.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
    #endregion
}