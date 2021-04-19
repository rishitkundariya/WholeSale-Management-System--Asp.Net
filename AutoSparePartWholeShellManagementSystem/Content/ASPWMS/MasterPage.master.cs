using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       


    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["q"] == null)
        {
            if(Session["InvoiceID"] != null)
            {
                int InvoiceID =Convert.ToInt32(Session["InvoiceID"].ToString());
                InvoiceItemBAL balInvoiceItem = new InvoiceItemBAL();
                if (balInvoiceItem.Delete(InvoiceID))
                {
                    InvoiceBAL balInvoice = new InvoiceBAL();
                    if (balInvoice.Delete(InvoiceID))
                    {
                        Session.Clear();
                        Response.Redirect("~/Content/ASPWMS/Login.aspx");
                    }
                   
                }
                
            }
        }
       
        Session.Clear();
        Response.Redirect("~/Content/ASPWMS/Login.aspx");
    }
}
