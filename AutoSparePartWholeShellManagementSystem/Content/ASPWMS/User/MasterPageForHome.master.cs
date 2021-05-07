using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_ASPWMS_MasterPageForHome : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Content/ASPWMS/Login.aspx");
    }
}
