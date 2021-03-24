using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_Bike_BikeAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Postback Event
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BikeID"] == null)
                lblMainHeading.Text = "Add Bike Details";
            else
            {
                FillData(Convert.ToInt32(Request.QueryString["BikeID"].ToString()));
                lblMainHeading.Text = "Edit Bike Details";
            }

        }
        #endregion
    }

        
    #region fill data in edit mode
    protected void FillData(int BikeID)
    {
        BikeBAL balBike = new BikeBAL();
        BikeENT entBike = new BikeENT();
        entBike = balBike.SelectByPK(BikeID);
        if (entBike == null)
        {
            lblMessage.Text = balBike.Message;
        }
        else
        {
            if (entBike.BikeName.ToString()!=null)
                txtBikeName.Text = entBike.BikeName.ToString();
            if (entBike.BikeModelYear.ToString() != null)
                txtBikeModelYear.Text = entBike.BikeModelYear.ToString();
            if (entBike.BikeModelNumber.ToString() != null)
                txtBikeModelNumber.Text = entBike.BikeModelNumber.ToString();
            if (entBike.CompanyName.ToString() != null)
                txtCompanyName.Text = entBike.CompanyName.ToString();
        }

        
    }
    #endregion


    #region Save Button Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BikeBAL balBike = new BikeBAL();
        BikeENT entBike = new BikeENT();
        if (txtBikeName.Text.Trim() != null)
            entBike.BikeName = txtBikeName.Text.Trim();
        else
            lblMessage.Text += "Enter Bike Name </br>";

        if (txtCompanyName.Text.Trim() != null)
            entBike.CompanyName = txtCompanyName.Text.Trim();
        else
            lblMessage.Text += "Enter Company Name </br>";

        if (txtBikeModelYear.Text.Trim() != null)
            entBike.BikeModelYear = txtBikeModelYear.Text.Trim();

        if (txtBikeModelNumber.Text.Trim() != null)
            entBike.BikeModelNumber = txtBikeModelNumber.Text.Trim();
        else
            lblMessage.Text += "Enter Bike Model Number </br>";

        if (lblMessage.Text != "")
        {
            lblMessage.CssClass = "text-danger";
            return;
        }
        

        #region Save or Update data
        if (Request.QueryString["BikeID"] == null)
        {
            if(balBike.Insert(entBike))
            {
                ClearControl();
                lblMessage.CssClass = "alert-success";
                lblMessage.Text = "Data Enter Successfully";
            }
            else
            {
                lblMessage.Text = balBike.Message;
                lblMessage.CssClass = "Text-danger";
            }
        }
        else
        {
            entBike.BikeID = Convert.ToInt32(Request.QueryString["BikeID"].ToString());
            if (balBike.Update(entBike))
            {
                Response.Redirect("~/Content/ASPWMS/Bike/BikeList.aspx");
            }
            else
            {
                lblMessage.Text = balBike.Message;
                lblMessage.CssClass = "Text-danger";
            }
        }
        #endregion


    }
    #endregion

    #region Clear Control
    public void ClearControl()
    {
        txtBikeName.Text = null;
        txtCompanyName.Text = null;
        txtBikeModelYear.Text = null;
        txtBikeModelNumber.Text = null;
    }
    #endregion

    #region cancle Button click event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/Bike/BikeList.aspx");
    }
    #endregion
}