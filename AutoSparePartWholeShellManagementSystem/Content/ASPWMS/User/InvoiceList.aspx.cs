using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_User_InvoiceList : System.Web.UI.Page
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


    #region Fill Gried View
    private void FillGridView()
    {
        InvoiceBAL balInvoice = new InvoiceBAL();
        DataTable dt = new DataTable();
        dt = balInvoice.SelectAllByUserID(Convert.ToInt32(Session["RetailerID"].ToString()));
        if (dt == null)
        {
            lblMessage.Text = balInvoice.Message;
            lblMessage.CssClass = "alert-danger";
        }
        else
        {
            gvInvoice.DataSource = dt;
            gvInvoice.DataBind();
            if(dt.Rows.Count > 0)
            {
                gvInvoice.UseAccessibleHeader = true;
                gvInvoice.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
         
        }
    }
    #endregion

    #region Row Commad Event
    protected void gvInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "PrintInvoice")
        {
            Response.Redirect(e.CommandArgument.ToString());
        }

    }
    #endregion
}