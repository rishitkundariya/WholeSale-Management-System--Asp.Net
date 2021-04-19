using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_Invoice_InvoiceAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        if (!Page.IsPostBack)
        {
            CommonFillMethod.FillStateDropDownListRetailer(ddlShopList);
            CommonFillMethod.FillStateDropDownListCity(ddlCity);
            ddlCity.Enabled = false;
            if (Request.QueryString["q"] == null)
            {
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
            }
            else
            {
                FillDatainEditMode(Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString()))));
                lblMainHeading.Text = "Edit Invoice";
                btnMakeInvoice.Text = "Save Invoice";
            }

        }
       
    }

    #region Fill data
    private void FillDatainEditMode(SqlInt32 InvoiceID)
    {
        InvoiceENT entInvoice = new InvoiceENT();
        InvoiceBAL balInvoice = new InvoiceBAL();
        entInvoice = balInvoice.SelectByPK(InvoiceID);
        if (entInvoice == null)
        {
            lblMessage.Text = balInvoice.Message;
            lblMessage.CssClass = "text-danger";
        }
        else
        {
            ddlShopList.SelectedValue = entInvoice.CoustomerID.ToString();
            txtDate.Text = entInvoice.Date.ToString();
            RetailerBAL balRetailer = new RetailerBAL();
            RetailerENT entRetailer = new RetailerENT();
            entRetailer = balRetailer.SelectByPK(entInvoice.CoustomerID);
            if (entRetailer != null)
            {
                ddlCity.SelectedValue = entRetailer.CityID.ToString();
                lblTransportName.Text = entRetailer.TransportName.ToString();
                lblretailerName.Text = entRetailer.RetailerName.ToString();
            }
            else
            {
                lblMessage.Text += balRetailer.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
    }
    #endregion

    #region Cancle Button Click event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Invoice/InvoiceList.aspx");
    }
    #endregion

    #region Make Invoice Button Click Event
    protected void btnMakeInvoice_Click(object sender, EventArgs e)
    {
        #region Server Side validation
       
        InvoiceENT entInvoice = new InvoiceENT();
        if (ddlShopList.SelectedIndex > 0)
            entInvoice.CoustomerID = Convert.ToInt32(ddlShopList.SelectedValue.ToString());
        else
        {
            lblMessage.Text += "Select Shopname";
            return;
        }
        entInvoice.Date = txtDate.Text.ToString().Trim();
        #endregion

        InvoiceBAL balInvoice = new InvoiceBAL();

        #region Insert Data
        if (Request.QueryString["q"] == null)
        {
            if (balInvoice.Insert(entInvoice))
            {
                Session["InvoiceID"] = entInvoice.InvoiceID;
                Response.Redirect("~/Content/ASPWMS/Invoice/MakeInvoice.aspx");

            }
            else
            {
                lblMessage.Text=balInvoice.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        #endregion

        #region Edit Data
        else
        {
            entInvoice.InvoiceID = Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString())));
            if (balInvoice.Update(entInvoice))
            {
                Session["InvoiceID"] = entInvoice.InvoiceID;
                string url= "~/Content/ASPWMS/Invoice/MakeInvoice.aspx?q="+ HttpUtility.UrlEncode(Cryptography.EncryptQueryString(entInvoice.InvoiceID.ToString())).ToString();
                Response.Redirect(url);

            }
            else
            {
                lblMessage.Text = balInvoice.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        #endregion
    }
    #endregion

    #region Drop Down ShopList Index change event
    protected void ddlShopList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShopList.SelectedIndex > 0)
        {
            RetailerENT entRetailer = new RetailerENT();
            RetailerBAL balRetailer = new RetailerBAL();
            entRetailer = balRetailer.SelectByPK(Convert.ToInt32(ddlShopList.SelectedValue));
            if (entRetailer != null)
            {
                if (entRetailer.RetailerName.ToString() != null)
                {
                    lblretailerName.Text = entRetailer.RetailerName.ToString();
                }
                if (entRetailer.TransportName.ToString() != null)
                    lblTransportName.Text = entRetailer.TransportName.ToString();
                if (entRetailer.CityID.ToString() != null)
                    ddlCity.SelectedValue = entRetailer.CityID.ToString();
            }
           
        }
        else
        {
            lblretailerName.Text = null;
            lblTransportName.Text = null;
            ddlCity.SelectedIndex = 0;
           
        }
      
    }
    #endregion
}