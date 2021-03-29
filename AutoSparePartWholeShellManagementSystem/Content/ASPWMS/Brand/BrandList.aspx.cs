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

public partial class Content_ASPWMS_Brand_BrandList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            FillGridView();
    }

    #region Fill Grid View
    protected  void FillGridView()
    {
        BrandBAL balBrand = new BrandBAL();
        DataTable dtBrand = new DataTable();
        dtBrand = balBrand.SelectAll();
        if (dtBrand == null)
        {
            lblMessage.Text = balBrand.Message;
            lblMessage.CssClass = "Text-danger";
        }
        else
        {
            gvBrandList.DataSource = dtBrand;
            gvBrandList.DataBind();
            gvBrandList.UseAccessibleHeader = true;
            gvBrandList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }
    #endregion

    #region Add Button Click Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Brand/BrandAddEdit.aspx");
    }
    #endregion

    #region Row Command
    protected void gvBrandList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
        {
            DeleteItem(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
        }
        if (e.CommandName == "Edit")
        {
            String url = "~/Content/ASPWMS/Brand/BrandAddEdit.aspx?q=" + HttpUtility.UrlEncode(Cryptography.EncryptQueryString(e.CommandArgument.ToString())).ToString(); ;
            Response.Redirect(url);
        }
    }
    #endregion

    #region Delete Item 
    protected void DeleteItem(int BrandID)
    {
        BrandBAL balBrand = new BrandBAL();
        if(balBrand.Delete(BrandID))
        {
            lblMessage.Text = "Data Deleted Successfully";
            lblMessage.CssClass = "alert-success";
            FillGridView();
        }
        else
        {
            lblMessage.Text =balBrand.Message;
            lblMessage.CssClass = "text-danger";
        }

    }
    #endregion


}