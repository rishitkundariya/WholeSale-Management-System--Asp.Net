using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;

public partial class Content_ASPWMS_Bike_BikeList : System.Web.UI.Page
{
    #region Page load 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            FillGridView();
    }
    #endregion

    #region  Fill Grid View Of Bike
    protected void FillGridView()
    {
        BikeBAL balBike = new BikeBAL();
        DataTable dtBike = new DataTable();
        dtBike=balBike.SelectAll();
        if (dtBike == null)
        {
            lblMessage.Text = balBike.Message;
           
        }
        else
        {
            gvBikeList.DataSource = dtBike;
            gvBikeList.DataBind();
            gvBikeList.UseAccessibleHeader = true;
            gvBikeList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        
    }
    #endregion

    #region Button add Event
    protected void btnAdd_Bike(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Bike/BikeAddEdit.aspx");
    }
    #endregion

    #region DeleteItem method
    protected void DeleteItem(int BikeID)
    {

        BikeBAL balBike = new BikeBAL();
        if (balBike.Delete(BikeID))
        {
            FillGridView();
            lblMessage.Text = "Data Deleted Successfully";
            lblMessage.CssClass = "alert-success";
            
        }
        else
        {
            lblMessage.Text =balBike.Message;
        }

    }
    #endregion

    #region RowCommand
    protected void gvBikeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
        {
            DeleteItem(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
        }
        if(e.CommandName == "Edit")
        {
           
            String url = "~/Content/ASPWMS/Bike/BikeAddEdit.aspx?q=" + HttpUtility.UrlEncode(Cryptography.EncryptQueryString(e.CommandArgument.ToString())).ToString();
            Response.Redirect(url);
        }
    }
    #endregion
}