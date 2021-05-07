using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_USER_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["RetailerID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");
        else
            fillData();
    }

    #region Fill Data 
    private void fillData()
    {
        int RetailerID=Convert.ToInt32(Session["RetailerID"].ToString());
        RetailerENT entRetailer = new RetailerENT();
        RetailerBAL balRetailer = new RetailerBAL();
        entRetailer = balRetailer.SelectByPK(RetailerID);
        if(entRetailer == null)
        {
            lblMessage.Text = balRetailer.Message;
        }
        else
        {
            lblRetailerName.Text += entRetailer.RetailerName.ToString();
            lblShopName.Text = entRetailer.ShopName.ToString();
            lblTrasportName.Text = entRetailer.TransportName.ToString();
            lblMobileNO.Text = entRetailer.MobileNumber.ToString();
            lblEmail.Text = entRetailer.Email.ToString();
            lblShopAddress.Text = entRetailer.ShopAddress.ToString();
        }
    }
    #endregion

    #region change Password Panel Show Button Click Event
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        lblRetailerName.Visible = false;
        pnChangePassword.Visible = true;
        pnContent.Visible = false;
        txtOldPassword.Focus();
        
    }
    #endregion

    #region Panel Hide button click event
    protected void btnHide_Click(object sender, EventArgs e)
    {
        pnChangePassword.Visible = false;
        pnContent.Visible = true;
        lblRetailerName.Visible = true;
    }
    #endregion

    #region Change Password Click Event
    protected void btnChgPassword_Click(object sender, EventArgs e)
    {
        
        if(txtNewPassword.Text.Trim() != txtReNewPassword.Text.Trim())
        {
            lblMessage.Text = "Enter Same Password ";
            lblMessage.CssClass = "text-danger";
            clearControl();
            txtOldPassword.Focus();
            return ;
        }
        else
        {
            UserENT entUser = new UserENT();
            UserBAL balUser = new UserBAL();
            String oldPassword=  balUser.fetchPassword(lblMobileNO.Text);
            if(oldPassword != txtOldPassword.Text.Trim())
            {
                lblMessage.Text = "Enter Old password is not correct.";
                lblMessage.CssClass = "text-danger";
                clearControl();
                txtOldPassword.Focus();
                return;
            }
            else
            {
                if (balUser.changePassword(Convert.ToInt32(Session["UserID"].ToString()),txtNewPassword.Text.Trim()))
                {
                    lblMessage.Text = "Change Password Successfully";
                    lblMessage.CssClass = "alert-success";
                    pnChangePassword.Visible = false;
                    pnContent.Visible = true;
                }
            }
        }
    }
    #endregion

    #region Clear Control
    public void clearControl()
    {
        txtNewPassword.Text = null;
        txtOldPassword.Text = null;
        txtReNewPassword.Text = null;
    }
    #endregion
}