using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ASPWMS.BAL;

public partial class Content_ASPWMS_City_City : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
         FillGridView(); 
            
    }

    #region fillgridview
    protected void FillGridView()
    {

        CityBAL balcity = new CityBAL();
        DataTable dt = new DataTable();
        dt = balcity.SelectAll();
        if (dt!=null)
        {
            gvCity.DataSource = dt;
            gvCity.DataBind();
            gvCity.UseAccessibleHeader = true;
            gvCity.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        else
        {
            lblMessage.Text = balcity.Message;
        }
        
    }
    #endregion 

    #region add button click event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/City/CityAddEdit.aspx");
    }
    #endregion


    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
        {
            DeleteItem(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
        }
        if(e.CommandName== "EditItem")
        {
            Response.Redirect(e.CommandArgument.ToString().Trim());
        }
    }

    #region delete item
    protected void DeleteItem(int CityID)
    {

        CityBAL balcity = new CityBAL();
        if (balcity.Delete(CityID))
        {
            lblMessage.Text = "Data Deleted Successfully";
            lblMessage.CssClass = "alert-success";
            FillGridView();


        }
        else
        {
            lblMessage.Text = balcity.Message;
            lblMessage.CssClass = "text-danger";
        }

    }
    #endregion
}