using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RetailerID"] != null)
        {
            Response.Redirect("~/Content/ASPWMS/User/Home.aspx");
           
        }
        if (Session["UserID"]!=null && Session["UserID"].ToString() == "1")
        {
            Response.Redirect("~/Content/ASPWMS/Home.aspx");
        }
        
    }

    protected void btnForgetPassword_Click(object sender, EventArgs e)
    {
        pnLogin.Visible = false;
        pnForgetPassword.Visible = true;
    }

    #region Submit Button Click from forget password 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtUsernameforget.Text.Trim() == "")
            lblMessageForget.Text += "Enter UserName <br/>";
        if (lblMessageForget.Text != "")
        {
            txtUsernameforget.Text = null;
            return;
        }
        else
        {
            UserBAL balUser = new UserBAL();
            String Password = balUser.fetchPassword(txtUsernameforget.Text.Trim());
            if (Password == null || Password=="admin")
            {
               
                lblMessageForget.Text += "Enter Valid UserName <br/>";
                txtUsernameforget.Text = null;
                return ;
            }
            else
            {
                UserENT entUser = new UserENT();
                entUser = balUser.selectUser(txtUsernameforget.Text.Trim(), Password);
                if (entUser != null)
                {
                    Email.sendEmailOfForgetPassword(entUser);
                    lblMessageForget.Text = "Password send into your Email ";
                    lblMessageForget.CssClass = "alert-success";
                    txtUsernameforget.Text = null;

                }
                else
                {
                    lblMessageForget.Text = balUser.Message;
                    txtUsernameforget.Text = null;
                }
            }
        }

    }
    #endregion

    #region Back to login from forget password
    protected void btnLoginFromForget_Click(object sender, EventArgs e)
    {
        pnLogin.Visible = true;
        pnForgetPassword.Visible = false;
      
    }
    #endregion

    #region Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Check 
        if (txtUserName.Text.Trim() == "")
            lblMessage.Text += "Enter UserName <br/>";
        if (txtPassword.Text.Trim() == "")
            lblMessage.Text += "Enter Password <br/>";
        if (lblMessage.Text != "")
        {
            txtPassword.Text = null;
            txtUserName.Text = null;
            return;
        }
        #endregion

        else
        {
            UserENT entUser = new UserENT();
            UserBAL balUser = new UserBAL();
            entUser = balUser.selectUser(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if(entUser == null)
            {
                txtPassword.Text = null;
                txtUserName.Text = null;
                lblMessage.Text = "Enter valid Username or Password";
                return;
            }
            else
            {
                Session["UserID"] = entUser.UserID.ToString();
                if (entUser.UserID == 1)
                {
                    Response.Redirect("~/Content/ASPWMS/Home.aspx");
                }
                else
                {
                    Session["RetailerID"] = entUser.RetailerID;
                    Response.Redirect("~/Content/ASPWMS/User/Home.aspx");
                }

            }
        }
    }
    #endregion
}