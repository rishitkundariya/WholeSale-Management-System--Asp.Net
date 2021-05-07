using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.DAL;

public partial class Content_ASPWMS_Borrow_BorrowList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
            FillGridView();
    }

    #region Fill GridView
    private void FillGridView()
    {
        RetailerBAL balRetailer = new RetailerBAL();
        DataTable dt = new DataTable();
        dt = balRetailer.BorrowList();
        if (dt != null)
        {
            gvBorrow.DataSource = dt;
            gvBorrow.DataBind();
            if (dt.Rows.Count > 0)
            {
                gvBorrow.UseAccessibleHeader = true;
                gvBorrow.HeaderRow.TableSection = TableRowSection.TableHeader;
                colorRow();
            }

        }
        else
        {
            lblMessage.Text = balRetailer.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
    #endregion
    #region color Row
    private void colorRow()
    {
        foreach (GridViewRow row in gvBorrow.Rows)
        {
            if (Convert.ToInt32(row.Cells[3].Text.ToString()) <0 )
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


}