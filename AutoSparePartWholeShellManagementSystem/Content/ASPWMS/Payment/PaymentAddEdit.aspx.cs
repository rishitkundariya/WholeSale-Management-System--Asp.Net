using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_Payment_PaymentAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PaymentID"] != null)
            {
                lblPageHeading.Text = "Edit Payment Details";
                FillData(Convert.ToInt32(Request.QueryString["PaymentID"]));

            }
            else
                CommonFillMethod.FillStateDropDownListRetailer(ddlPaymentPerson);

        }
    }
    #region Fill data in edit mode
    public void FillData(SqlInt32 PaymentID)
    {
        PaymentBAL balPayment = new PaymentBAL();
        PaymentENT entPayment = new PaymentENT();
        entPayment = balPayment.SelectByPK(PaymentID);
        if(entPayment!=null)
        {
            txtAmount.Text = entPayment.Payment_Amount.ToString();
            txtDate.Text =Convert.ToString( entPayment.Payment_Date);
            if(!entPayment.Payment_Description.IsNull)
                 txtDescription.Text = entPayment.Payment_Description.ToString();
            if (entPayment.Payment_Type.ToString() == "Credit")
            {
                rbCredit.Checked = true;
                CommonFillMethod.FillStateDropDownListRetailer(ddlPaymentPerson);
            }
            if(entPayment.Payment_Type.ToString() == "Debit")
            {
                rbDebit.Checked = true;
                CommonFillMethod.FillStateDropDownListSupplier(ddlPaymentPerson);
            }
            ddlPaymentPerson.SelectedValue = entPayment.Payment_PersonID.ToString();
        }
    }
    #endregion

    #region Save Button click event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server side validation
        PaymentENT entPayment = new PaymentENT();
        if (txtAmount.Text.Trim() == "")
            lblMessage.Text += "Enter amount";
        if(ddlPaymentPerson.SelectedIndex  < 1)
            lblMessage.Text += "Select Person";
        if (lblMessage.Text.Trim() != "")
        {
            lblMessage.CssClass = "text-danger";
            return;
        }
        else
        {
            entPayment.Payment_Amount = Convert.ToInt32(txtAmount.Text.Trim());
            entPayment.Payment_Date = txtDate.Text.Trim();
            entPayment.Payment_PersonID = Convert.ToInt32(ddlPaymentPerson.SelectedValue);
            if (rbCredit.Checked)
                entPayment.Payment_Type = "Credit";
            if(rbDebit.Checked)
                entPayment.Payment_Type = "Debit";
            entPayment.Payment_Description = txtDescription.Text.Trim();
        }
        #endregion
        PaymentBAL balPayment = new PaymentBAL();
        if(Request.QueryString["PaymentID"] != null)
        {
            entPayment.PaymentID = Convert.ToInt32(Request.QueryString["PaymentID"]);
            if (balPayment.Update(entPayment))
            {
                Response.Redirect("~/Content/ASPWMS/Payment/PaymentList.aspx");
            }
            else
            {
                lblMessage.Text = balPayment.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        else
        {
            if (balPayment.Insert(entPayment))
            {
                lblMessage.Text = "Data enter successfully";
                lblMessage.CssClass = "alert-success";
                clearControl();
            }
            else
            {
                lblMessage.Text = balPayment.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
    }
    #endregion

    #region Clear Control
    private void clearControl()
    {
        txtAmount.Text = null;
        txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        txtDescription.Text = null;
        ddlPaymentPerson.SelectedIndex = 0;
    }
    #endregion

    

    #region Cancle Button click event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Payment/PaymentList.aspx");
    }
    #endregion
    
    #region Radio button checked change event
    protected void rbCredit_CheckedChanged(object sender, EventArgs e)
    {
        if(rbCredit.Checked==true)
        {
            CommonFillMethod.FillStateDropDownListRetailer(ddlPaymentPerson);
        }
        if (rbDebit.Checked == true)
        {
            CommonFillMethod.FillStateDropDownListSupplier(ddlPaymentPerson);
        }
    }
    #endregion
}