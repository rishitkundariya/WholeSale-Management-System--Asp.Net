using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWMS.BAL;
using ASPWMS.ENT;

public partial class Content_ASPWMS_ModelPopUpDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            BindGridView1();
        }

    }
    protected void BindGridView1()
    {
        CityBAL balcity = new CityBAL();
        DataTable dt = new DataTable();
        dt = balcity.SelectAll();
        if (dt != null)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    //for pop-up gridview  
    protected void BindGrid2(SqlInt32 CityID)
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


    

    




  

    protected void btnSave_Click(object sender, EventArgs e)
    {
      
        lblMessage.Text = "Onclick call";
    }
}  

   

    
