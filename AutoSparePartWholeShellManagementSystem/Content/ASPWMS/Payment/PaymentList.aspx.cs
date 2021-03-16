using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Payment_PaymentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }

    #region Fill Gridview Method
    public void FillGridView()
    {
        PaymentBAL balPayment = new PaymentBAL();
        DataTable dt = new DataTable();
        dt = balPayment.SelectAll();
        if(dt!=null)
        {
            gvPayment.DataSource = dt;
            gvPayment.DataBind();
            gvPayment.UseAccessibleHeader = true;
            gvPayment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        else
        {
            lblMessage.Text = balPayment.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
    #endregion

    #region Add button click event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Payment/PaymentAddEdit.aspx");
    }
    #endregion

    #region Delete Data
    public void DeleteData(SqlInt32 PaymentID)
    {
        PaymentBAL balPayment = new PaymentBAL();
        if (balPayment.Delete(PaymentID))
        {
            lblMessage.Text = "Data Deleted Successfully";
            lblMessage.CssClass = "alert-success";
            FillGridView();
        }
        else
        {
            lblMessage.Text = balPayment.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
    #endregion

    protected void gvPayment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName== "DeleteItem")
        {
            DeleteData(Convert.ToInt32(e.CommandArgument));
        }
        if(e.CommandName== "Edit")
        {
            Response.Redirect(e.CommandArgument.ToString());
        }
    }
}