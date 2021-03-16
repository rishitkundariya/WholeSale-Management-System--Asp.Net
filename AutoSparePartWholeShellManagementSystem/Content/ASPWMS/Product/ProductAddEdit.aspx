<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="ProductAddEdit.aspx.cs" Inherits="Content_ASPWMS_Product_ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    <asp:Label ID="lblPageHeading" runat="server" Text="Add Product"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Product Add | Edit
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
        </div>
        <div class="row" style="margin: 20px;">
            <div class="col-md-3" style="float: right">
                <b><span class="text-danger">*</span>  product Name &nbsp;:-</b>
            </div>

            <div class="col-md-4" >
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Enter Product Name"></asp:TextBox>
            </div>
             <div class="col-md-4">
                <asp:RequiredFieldValidator ID="rfvPRoductName" runat="server" ErrorMessage="Enter product name" ControlToValidate="txtProductName" SetFocusOnError="True" Display="Dynamic" CssClass="text-danger"  ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row" style="margin: 20px;">
            <div class="col-md-3" style="float: right">
                <b><span class="text-danger">*</span> Brand Name &nbsp;:-</b>
            </div>

            <div class="col-md-4">
                <asp:DropDownList ID="ddlBrandName" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:RequiredFieldValidator ID="rfvBrandName" runat="server" ErrorMessage="Select One Brand" ControlToValidate="ddlBrandName" SetFocusOnError="True" Display="Dynamic" CssClass="text-danger" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row" style="margin: 20px;">
            <div class="col-md-3" style="float: right">
                <b><span class="text-danger">*</span> Price &nbsp;:-</b>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtPrice" runat="server"  CssClass="form-control"  placeholder="Enter Price" TextMode="Number"></asp:TextBox>

            </div>
            <div class="col-md-4">
                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Enter Price" ControlToValidate="txtPrice" SetFocusOnError="True" Display="Dynamic" CssClass="text-danger" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>

        
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-4" style="padding-left: 6rem; margin-bottom: 4rem">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary margin-10" ValidationGroup="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancle" runat="server" Text="Cancel" CssClass="btn btn-danger margin-10" OnClick="btnCancle_Click" />

            </div>


        </div>
    </div>
</asp:Content>

