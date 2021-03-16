using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Supplier_SupplierList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridview();
        }

    }

    #region Fill Gridview
    protected void FillGridview()
    {
        SupplierBAL balsupplier = new SupplierBAL();
        DataTable dt = new DataTable();
        dt = balsupplier.SelectAll();
        if (dt != null)
        {
            gvSupplierList.DataSource = dt;
            gvSupplierList.DataBind();
            gvSupplierList.UseAccessibleHeader = true;
            gvSupplierList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        else
        {
            lblMessage.Text = balsupplier.Message;
            lblMessage.CssClass = "text-danger";
        }
        
    }
    #endregion

    #region Add Supplier Button Click Event
    protected void btnAddSupplier_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Supplier/SupplierAddEdit.aspx");
    }
    #endregion

    protected void gvRetailerList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
            DeleteItem(Convert.ToInt32(e.CommandArgument.ToString()));
        if (e.CommandName == "Edit")
            Response.Redirect(e.CommandArgument.ToString());

    }

    #region Delete Item From Gridview
    protected void DeleteItem(int SupplierID)
    {
        SupplierBAL balsupplier = new SupplierBAL();
        
        if (balsupplier.Delete(SupplierID))
        {
            lblMessage.Text = "Data Deleted Successfully";
            lblMessage.CssClass = "alert-success";
            FillGridview();
        }
        else
        {
            lblMessage.Text = balsupplier.Message;
            lblMessage.CssClass = "text-danger";
        }

    }
    #endregion
}