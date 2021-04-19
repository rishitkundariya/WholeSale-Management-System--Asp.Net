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

public partial class Content_ASPWMS_City_CityAddEdit : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/Content/ASPWMS/Login.aspx");

        #region Postback Event
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["q"] == null)
                lblPageHeading.Text = "Add City";
            else
            {
                FillData(Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString()))));
                lblPageHeading.Text = "Edit City";
            }
               
        }
        #endregion
    }

    #region save button click event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region  and variable declaration with serverside validation
        CityENT entCity = new CityENT();

        if (txtCityName.Text.Trim() == null)
            lblMessage.Text += "Enter City name";
        if (lblMessage.Text != "")
        {
            return;
        }
        else
        {
            entCity.CityName = txtCityName.Text.Trim();
            if(txtPincode.Text.Trim() != "")
             entCity.Pincode = txtPincode.Text.Trim();
        }

        #endregion

        CityBAL balCity = new CityBAL();
        
        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                lblMessage.Text = "Enter City Successfully";
                lblMessage.CssClass = "alert-success";
                ClearControl();
            }
            else
            {
                lblMessage.Text = balCity.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Cryptography.DecryptQueryString(HttpUtility.UrlDecode(Request.QueryString["q"].ToString())));
            if (balCity.Update(entCity))
            {
                Response.Redirect("~/Content/ASPWMS/City/CityList.aspx");
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
        }


    }
    #endregion

    #region Cancel button click event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/ASPWMS/City/CityList.aspx");
    }
    #endregion

    #region fill data in edit mode

    protected void FillData(int CityID)
    {
        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();
        entCity = balCity.SelectByPK(CityID);
        if (entCity != null)
        {
            if (entCity.CityName.Value != null)
                txtCityName.Text = entCity.CityName.ToString();
            if (entCity.Pincode.Value != null)
                txtPincode.Text = entCity.Pincode.ToString();
        }
       

    }
    #endregion

    #region ClearControl
    public void ClearControl()
    {
        txtCityName.Text = "";
        txtPincode.Text = "";
    }
    #endregion
}