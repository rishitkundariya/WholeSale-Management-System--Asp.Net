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

public partial class Content_ASPWMS_Retailer_RetailerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
            FillGridViewOfRetailer();
    }

    #region Fill gridView Of Retailer
    protected void FillGridViewOfRetailer()
    {
        RetailerBAL balRetailer = new RetailerBAL();
        DataTable dt = new DataTable();
        dt = balRetailer.SelectAll();
        if (dt != null)
        {
            gvRetailerList.DataSource = dt;
            gvRetailerList.DataBind();
            gvRetailerList.UseAccessibleHeader = true;
            gvRetailerList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        else
        {
            lblMessage.Text = balRetailer.Message;
            lblMessage.CssClass = "text-danger";
        }

      
    }
    #endregion

    protected void gvRetailerList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
            DeleteItem(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
        if (e.CommandName == "Edit")
        {
            string url = "~/Content/ASPWMS/Retailer/RetailerAddEdit.aspx?q=" + HttpUtility.UrlEncode(Cryptography.EncryptQueryString(e.CommandArgument.ToString())).ToString();
            Response.Redirect(url);
        }
           
    }

    #region Delete Data
    protected void DeleteItem(int RetailerID)
    {

        RetailerBAL balRetailer = new RetailerBAL();
       
        if (balRetailer.Delete(RetailerID))
        {
            lblMessage.Text = "Data Deleted Successfully";
            lblMessage.CssClass = "alert-success";
            FillGridViewOfRetailer();
        }
        else
        {
            lblMessage.Text = balRetailer.Message;
            lblMessage.CssClass = "text-danger";
        }

    }
    #endregion

    #region Add Button Click Event
    protected void btnAddRetailer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Retailer/RetailerAddEdit.aspx");
    }
    #endregion
}