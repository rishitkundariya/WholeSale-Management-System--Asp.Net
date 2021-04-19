using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

using System.IO;
using System.Text;

using iTextSharp.text;
using ASPWMS.ENT;

public partial class Content_ASPWMS_Invoice_PrintInvoice : System.Web.UI.Page
{

    DataTable Dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["InvoiceID"] != null)
            {
               
                Dt.Columns.Add("ProductID");
                Dt.Columns.Add("Product_Name");
                Dt.Columns.Add("Quantity");
                Dt.Columns.Add("Price");
                Dt.Columns.Add("Total");
                InvoiceItemBAL balInvoiceItem = new InvoiceItemBAL();
                DataTable datable = new DataTable();
                datable = balInvoiceItem.SelectAll(Convert.ToInt32(Request.QueryString["InvoiceID"].ToString()));
                if (datable != null)
                {
                    foreach (DataRow row in datable.Rows)
                    {
                        DataRow dr = Dt.NewRow();
                        dr[0] = row[0].ToString();
                        dr[1] = row[1].ToString();
                        dr[2] = row[2].ToString();
                        dr[3] = row[3].ToString();
                        dr[4] = (Convert.ToInt32(row[2].ToString()) * Convert.ToDecimal(row[3].ToString())).ToString();
                        Dt.Rows.Add(dr);

                    }
                    gvInvoiceItemList.DataSource = Dt;
                    gvInvoiceItemList.DataBind();
                }
                InvoiceBAL balInvoice = new InvoiceBAL();
                InvoiceENT entInvoice = new InvoiceENT();
                entInvoice = balInvoice.SelectByPK(Convert.ToInt32(Request.QueryString["InvoiceID"]));
                RetailerBAL balretailer = new RetailerBAL();
                RetailerENT entReatiler = new RetailerENT();
                entReatiler = balretailer.SelectByPK(entInvoice.CoustomerID);
                if (entReatiler != null)
                {
                    lblAddress.Text = entReatiler.ShopAddress.ToString();
                    lblDate.Text = entInvoice.Date.ToString();
                    lblInvoiceID.Text = entInvoice.InvoiceID.ToString();
                    lblShopName.Text = entReatiler.ShopName.ToString();
                    lblTransportName.Text = entReatiler.TransportName.ToString();

                }
                decimal grandTotal = 0;

                foreach (GridViewRow row in gvInvoiceItemList.Rows)
                {
                    grandTotal = grandTotal + Convert.ToDecimal(row.Cells[4].Text.ToString());
                }
                lblGrandTotal.Text = ((int)grandTotal).ToString();
            }
        }


    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

   

    protected void gvInvoiceItemList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}