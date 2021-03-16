using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Invoice_InvoiceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }

    #region Fill Gried View
    private void FillGridView()
    {
        InvoiceBAL balInvoice = new InvoiceBAL();
        DataTable dt = new DataTable();
        dt = balInvoice.SelectAll();
        if (dt == null)
        {
            lblMessage.Text = balInvoice.Message;
            lblMessage.CssClass = "alert-danger";
        }
        else
        {
            gvInvoice.DataSource = dt;
            gvInvoice.DataBind();
            gvInvoice.UseAccessibleHeader = true;
            gvInvoice.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Invoice/InvoiceAddEdit.aspx");
    }

    #region Row Commad Event
    protected void gvInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
        {
            deleteData(Convert.ToInt32(e.CommandArgument.ToString()));
        }
        if (e.CommandName == "EditItem")
        {
            Response.Redirect(e.CommandArgument.ToString());
        }

    }
    #endregion

    #region Delete Data
    private void deleteData(SqlInt32 InvoiceID)
    {
        InvoiceItemBAL balInvoiceItem = new InvoiceItemBAL();
        if (balInvoiceItem.Delete(InvoiceID))
        {
            InvoiceBAL balInvoice = new InvoiceBAL();
            if (balInvoice.Delete(InvoiceID))
            {
                lblMessage.Text = "Data deleted successfully";
                lblMessage.CssClass = "alert-success";
                FillGridView();
            }
            else
            {
                lblMessage.Text += balInvoice.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        else
        {
            lblMessage.Text += balInvoiceItem.Message;
            lblMessage.CssClass = "text-danger";
        }

       
    }
    #endregion
}