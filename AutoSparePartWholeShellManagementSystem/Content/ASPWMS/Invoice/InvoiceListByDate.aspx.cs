using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Invoice_InvoiceListByDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }

    #region Fill Gridview
    private void FillGridView()
    {
        InvoiceBAL balInvoice = new InvoiceBAL();
        DataTable dt = new DataTable();
        dt = balInvoice.SelectGroupBy();
        if (dt == null)
        {
            lblMessage.Text = balInvoice.Message;
            lblMessage.CssClass = "alert-danger";
        }
        else
        {
            gvInvoiceList.DataSource = dt;
            gvInvoiceList.DataBind();
        }

    }
    #endregion


    #region Row data bound Event
    protected void gvInvoiceList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Date = gvInvoiceList.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView gvInvoice = (GridView)e.Row.FindControl("gvInvoice");
            DataTable dt = new DataTable();
            InvoiceBAL balInvoice = new InvoiceBAL();
            dt = balInvoice.SelectAllByDate(Date);
            if (dt == null)
            {
                lblMessage.Text = balInvoice.Message;
            }
            else
            {
                gvInvoice.DataSource = dt;
                gvInvoice.DataBind(); 
            }
        }
        
    }
    #endregion
}