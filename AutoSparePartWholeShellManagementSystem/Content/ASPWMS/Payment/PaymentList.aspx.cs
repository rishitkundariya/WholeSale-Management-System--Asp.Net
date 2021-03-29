using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Payment_PaymentList : System.Web.UI.Page
{
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion

    #region Fill Gridview Method
    public void FillGridView()
    {
        PaymentBAL balPayment = new PaymentBAL();
        DataTable dt = new DataTable();
        dt = balPayment.SelectAll();
        if (dt != null)
        {
            gvPayment.DataSource = dt;
            gvPayment.DataBind();
            gvPayment.UseAccessibleHeader = true;
            gvPayment.HeaderRow.TableSection = TableRowSection.TableHeader;
            colorGridviewRow();
        }
        else
        {
            lblMessage.Text = balPayment.Message;
            lblMessage.CssClass = "text-danger";
        }


    }




    #endregion

    #region  color Gridview Row
    private void colorGridviewRow()
    {
        foreach (GridViewRow row in gvPayment.Rows)
        {
            if (String.Equals(row.Cells[2].Text.ToString(), "Debit"))
            {
                row.ForeColor = Color.FromName("#D2042D");
            }
            else
            {
                row.ForeColor = Color.FromName("#228b22 ");
            }
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

    #region Gridview row command Event
    protected void gvPayment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
        {
            DeleteData(Convert.ToInt32(e.CommandArgument));
        }
        if (e.CommandName == "Edit")
        {
            Response.Redirect(e.CommandArgument.ToString());
        }
    }
    #endregion
}