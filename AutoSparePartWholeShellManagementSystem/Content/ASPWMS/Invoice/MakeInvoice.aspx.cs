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

public partial class Content_ASPWMS_Invoice_MakeInvoice : System.Web.UI.Page
{
    DataTable Dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CommonFillMethod.FillStateDropDownListProduct(ddlProduct);
            AddColumnInDatatable();
            if (Request.QueryString["InvoiceID"] == null)
            {
                lblPageHeading.Text = "Add Items";
            }
            else
            {
                FillData(Convert.ToInt32(Request.QueryString["InvoiceID"]));
                lblPageHeading.Text = "Edit Items";
            }
        }

    }

    #region FillData 
    private void FillData(SqlInt32 InvoiceID)
    {
        InvoiceItemBAL balInvoiceItem = new InvoiceItemBAL();
        DataTable datable = new DataTable();
        datable = balInvoiceItem.SelectAll(InvoiceID);
        if(datable != null)
        {
            foreach (DataRow row in datable.Rows)
            {
                DataRow dr = Dt.NewRow();
                dr[0] = row[0].ToString();
                dr[1] = row[1].ToString();
                dr[2] = row[2].ToString();
                dr[3] = row[3].ToString();
                dr[4] = (Convert.ToInt32(row[2].ToString())*Convert.ToDecimal(row[3].ToString())).ToString();
                Dt.Rows.Add(dr);
             
            }
            gvInvoiceItem.DataSource = Dt;
            gvInvoiceItem.DataBind();
            GridViewHeaderEnable();
            Session["Data"] = Dt;
            CalculateGrandTotal();
        }
        else
        {
            lblMessage.Text = balInvoiceItem.Message;
            lblMessage.CssClass = "text-danger";
        }
    }
    #endregion

    #region GridViewHeaderEnable
    public void GridViewHeaderEnable()
    {
        gvInvoiceItem.UseAccessibleHeader = true;
        gvInvoiceItem.HeaderRow.TableSection = TableRowSection.TableHeader;
        gvInvoiceItem.FooterRow.TableSection = TableRowSection.TableFooter;

    }
    #endregion

    #region Add Column in DataTable
    private void AddColumnInDatatable()
    {
        Dt.Columns.Add("ProductID");
        Dt.Columns.Add("Product_Name");
        Dt.Columns.Add("Quantity");
        Dt.Columns.Add("Price");
        Dt.Columns.Add("Total");
        Session["Data"] = Dt;

    }
    #endregion

    #region Add Product Button Click Event
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {

        if (ddlProduct.SelectedIndex > 0)
        {
            DataTable Dtdata = (DataTable)Session["Data"];
            DataRow dr = Dtdata.NewRow();
            dr[0] = ddlProduct.SelectedItem.Value.ToString();
            dr[1] = ddlProduct.SelectedItem.Text;
            dr[2] = txtQuantity.Text.Trim();
            dr[3] = lblPrice.Text;
            dr[4] = (Convert.ToDecimal(lblPrice.Text) * Convert.ToInt32(txtQuantity.Text)).ToString();
            Dtdata.Rows.Add(dr);
            gvInvoiceItem.DataSource = Dtdata;
            gvInvoiceItem.DataBind();
            GridViewHeaderEnable();
            Session["Data"] = Dtdata;
            lblPrice.Text = "";
            txtQuantity.Text = null;
            ddlProduct.SelectedIndex = 0;
            ddlProduct.Focus();
            CalculateGrandTotal();
        }


    }
    #endregion

    #region Calculate GrandTotal 
    private void CalculateGrandTotal()
    {
        decimal grandTotal = 0;

        foreach (GridViewRow row in gvInvoiceItem.Rows)
        {
            grandTotal = grandTotal + Convert.ToDecimal(row.Cells[4].Text.ToString());
        }
        gvInvoiceItem.FooterRow.Cells[3].Text = "Grand Total";
        gvInvoiceItem.FooterRow.Cells[4].Text = grandTotal.ToString();
        gvInvoiceItem.UseAccessibleHeader = true;
        gvInvoiceItem.HeaderRow.TableSection = TableRowSection.TableHeader;
        gvInvoiceItem.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    #endregion

    #region Product Drop Down Selected Index Change Event
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProduct.SelectedIndex > 0)
        {
            ProductBAL balProduct = new ProductBAL();
            decimal Price = balProduct.SelectProductPriceByProductID(Convert.ToInt32(ddlProduct.SelectedValue));
            if (Price == -1)
            {
                lblPrice.Text = balProduct.Message;
            }
            else
            {
                lblPrice.Text = Price.ToString();
            }
            txtQuantity.Focus();
        }
        else
        {
            rfvddlProduct.ErrorMessage = "Select Product";
        }
        if (gvInvoiceItem.Rows.Count > 0)
        {
            GridViewHeaderEnable();
        }

    }
    #endregion

    #region Grid View Row Command Event
    protected void gvInvoiceItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int RowIndex = Convert.ToInt32(e.CommandArgument.ToString());

        #region Delete Row
        if (e.CommandName.ToString() == "DeleteItem")
        {

            deleteRow(Convert.ToInt32(RowIndex));


        }
        #endregion

        #region Edit Rows
        if (e.CommandName.ToString() == "EditItem")
        {
            EditRecord(RowIndex, Convert.ToInt32(gvInvoiceItem.Rows[RowIndex].Cells[2].Text.ToString()), Convert.ToDecimal(gvInvoiceItem.Rows[RowIndex].Cells[3].Text.ToString()));
            deleteRow(Convert.ToInt32(RowIndex));
        }
        #endregion

    }
    #endregion

    #region Delete Row
    public void deleteRow(int index)
    {
        DataTable dt = (DataTable)Session["Data"];
        dt.Rows[index].Delete();
        Session["Data"] = dt;
        gvInvoiceItem.DataSource = dt;
        gvInvoiceItem.DataBind();
        GridViewHeaderEnable();
        CalculateGrandTotal();
    }
    #endregion

    #region Edit Rows
    public void EditRecord(int RowIndex, int Quantity, decimal Price)
    {
        GridViewHeaderEnable();
        ddlProduct.SelectedValue = gvInvoiceItem.DataKeys[RowIndex].Values[0].ToString();
        txtQuantity.Text = Quantity.ToString();
        lblPrice.Text = Price.ToString();

    }
    #endregion

    #region Cancle Button Click Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        InvoiceItemBAL balIvoiceItem = new InvoiceItemBAL();
        if (balIvoiceItem.Delete(Convert.ToInt32(Session["InvoiceID"].ToString())))
        {
            string url = "~/Content/ASPWMS/Invoice/InvoiceAddEdit.aspx?InvoiceID=" + Session["InvoiceID"].ToString();
            if (Request.QueryString["InvoiceID"] == null)
            {
                InvoiceBAL balInvoice = new InvoiceBAL();
                if (balInvoice.Delete(Convert.ToInt32(Session["InvoiceID"].ToString())))
                {
                    Response.Redirect("~/Content/ASPWMS/Invoice/InvoiceList.aspx");
                }
            }
            else
            {
                Response.Redirect(url);
            }
            Session.Clear();
           
        }
        else
        {
            lblMessage.Text = balIvoiceItem.Message;
        }
    }
    #endregion

    #region Make Invoice Button Click Event
    protected void btnMakeInvoice_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["InvoiceID"] == null)
        {
            addItems(Convert.ToInt32(Session["InvoiceID"].ToString()));
        }
        else
        {
            InvoiceItemBAL balInvoiceItem = new InvoiceItemBAL();
            if (balInvoiceItem.Delete(Convert.ToInt32(Session["InvoiceID"].ToString())))
            {
                addItems(Convert.ToInt32(Session["InvoiceID"].ToString()));
            }
            else
            {
                lblMessage.Text += balInvoiceItem.Message;
                return;
            }
        }

    }
    #endregion

    #region Add Items
    private void addItems(SqlInt32 InvoiceID)
    {
        #region Add Item Into data Data Table
        Decimal Total = 0;
        Boolean response = true;
        if (gvInvoiceItem.Rows.Count > 0)
        {
            DataTable dtData = (DataTable)Session["Data"];
           
            foreach (DataRow dtRow in dtData.Rows)
            {
                InvoiceItemBAL balIvoiceItem = new InvoiceItemBAL();
                InvoiceItemENT entIvoiceItem = new InvoiceItemENT();
                entIvoiceItem.InvoiceID = InvoiceID;
                entIvoiceItem.ProductID = Convert.ToInt32(dtRow[0].ToString());
                entIvoiceItem.Quantity = Convert.ToInt32(dtRow[2].ToString());
                entIvoiceItem.Price = Convert.ToDecimal(dtRow[3].ToString());
                Total += Convert.ToDecimal(dtRow[4].ToString());
                if (balIvoiceItem.Insert(entIvoiceItem))
                {
                    response = true;
                }
                else
                {
                    lblMessage.Text += balIvoiceItem.Message;
                    response = false;
                }

            }
          
        }
        else
        {
            lblMessage.Text = "Select At leat One Item";
            lblMessage.CssClass = "text-danger";
            return ;
        }

        #endregion

        #region Set Total 
        InvoiceBAL balInvoice = new InvoiceBAL();
        if (balInvoice.setAmount(InvoiceID, Total))
        {
            if (response == true)
            {
                Response.Redirect("~/Content/ASPWMS/Invoice/InvoiceList.aspx");
                Session.Clear();
            }
        }
        else
        {
            lblMessage.Text += balInvoice.Message;
        }
        #endregion
    }
    #endregion
    
}