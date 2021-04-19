using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_User_PaymentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
        {
            FillDataInCard();
        }
    }

    private void FillDataInCard()
    {
        PaymentBAL balPayment = new PaymentBAL();
        DataTable dt = new DataTable();
        dt = balPayment.SelectByUserID(Convert.ToInt32(Session["RetailerID"].ToString()));
        if (dt != null)
        {
            gvPayment.DataSource = dt;
            gvPayment.DataBind();
            if (dt.Rows.Count > 0 )
            {
                gvPayment.UseAccessibleHeader = true;
                gvPayment.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
           
        }
        else
        {
            lblMessage.Text = balPayment.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
}