using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDataInCard();
        }
    }

    #region Fill Data 
    private void FillDataInCard()
    {
        ProductBAL balProduct = new ProductBAL();
        lblProductCount.Text = balProduct.ProductCount().ToString();
        RetailerBAL balRetailer = new RetailerBAL();
        lblRetailerCount.Text = balRetailer.ReatailerCount().ToString();
        InvoiceBAL balInvoice = new InvoiceBAL();
        lblInvoiceCount.Text = balInvoice.InvoiceCount().ToString();
        PaymentBAL balPayment = new PaymentBAL();
        lblNetTotal.Text= balPayment.NetBalance().ToString();
        
        
    }
    #endregion
}
