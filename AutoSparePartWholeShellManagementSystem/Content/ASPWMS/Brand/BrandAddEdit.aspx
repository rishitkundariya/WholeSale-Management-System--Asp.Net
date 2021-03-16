<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="BrandAddEdit.aspx.cs" Inherits="Content_ASPWMS_Brand_BrandAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    <asp:Label ID="lblPageHeading" runat="server" Text="Brand Add"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Brand Add | Edit
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
        </div>
        <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b><span class="text-danger">*</span>  Brand Name &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtBrandName" runat="server" CssClass="form-control"  placeholder="Enter Brand Name"></asp:TextBox>
                  </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="rfvBrandName" runat="server" ErrorMessage="Enter Brand " CssClass="text-danger" Display="Dynamic" ControlToValidate="txtBrandName" SetFocusOnError="True" ValidationGroup="Save" ></asp:RequiredFieldValidator>
           
                 </div>
        </div>
         <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b><span class="text-danger">*</span> Brand SortName &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtBrandSortName" runat="server" CssClass="form-control"  placeholder="Enter Brand SortName"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                 <asp:RequiredFieldValidator ID="rfvBrandSortName" runat="server" ErrorMessage="Enter Brand Sort Name " CssClass="text-danger" Display="Dynamic" ControlToValidate="txtBrandSortName" SetFocusOnError="True" ValidationGroup="Save" ></asp:RequiredFieldValidator>
            </div>
         </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-4" style="padding-left:6rem; margin-bottom:4rem">
                <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="btn btn-primary margin-10" ValidationGroup="Save" OnClick="btnSave_Click"  />
               <asp:Button ID="btnCancle" runat="server" Text="Cancel"  CssClass="btn btn-danger margin-10" OnClick="btnCancle_Click"  />

            </div>
            
             <div class>

             </div>
            
        </div>
    </div>
</asp:Content>

