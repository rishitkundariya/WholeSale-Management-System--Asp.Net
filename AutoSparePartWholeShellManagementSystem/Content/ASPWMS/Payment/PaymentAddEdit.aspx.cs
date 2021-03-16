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