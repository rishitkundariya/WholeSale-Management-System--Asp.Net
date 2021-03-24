<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="SupplierAddEdit.aspx.cs" Inherits="Content_ASPWMS_Supplier_SupplierAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
       <asp:Label ID="lblPageHeading" runat="server" Text="Supplier"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Supplier Add | Edit
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
     <div class="container">
       <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
        </div>
    
       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right" >
               <b><span class="text-danger">*</span> Supplier Name &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control"  placeholder="Enter Supplier Name"></asp:TextBox>
                  </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="rfvSupplierName" runat="server" ErrorMessage="Enter Supplier Name " CssClass="text-danger" Display="Dynamic" ControlToValidate="txtSupplierName" SetFocusOnError="True" ValidationGroup="Save" ></asp:RequiredFieldValidator>
           
                 </div>
        </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right" >
               <b><span class="text-danger">*</span> Mobile Number &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control"  placeholder="Enter Mobile Number"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                 <asp:RegularExpressionValidator ID="revMobileNuber" runat="server" ErrorMessage=" Enter  Ten Digit Number" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtMobileNumber" ValidationGroup="Save" ValidationExpression="\d{10}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ErrorMessage="Enter Mobile Number" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="True" ControlToValidate="txtMobileNumber" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
         </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right">
               <b><span class="text-danger text-right">*</span> Brand Name &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
                <asp:DropDownList ID="ddlBrandName" runat="server" CssClass="form-control"></asp:DropDownList>
               
            </div>
            <div class="col-md-4">  
               <asp:RequiredFieldValidator ID="rfvBrandName" runat="server" ErrorMessage="Select Brand " SetFocusOnError="True" CssClass="text-danger" Display="Dynamic" ControlToValidate="ddlBrandName" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
               
            </div>
         </div>

   
 
       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right" >
               <b> &nbsp;&nbsp;&nbsp;City &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
               
            </div>
            <div class="col-md-4">  
            </div>
         </div>
  

       <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-4" style="padding-left:5.4rem; margin-bottom:4rem">
                <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="btntras btn btn-primary margin-10" ValidationGroup="Save" OnClick="btnSave_Click" />
               <asp:Button ID="btnCancle" runat="server" Text="Cancel"  CssClass="btntras btn btn-danger margin-10" OnClick="btnCancle_Click" />

            </div>
            
             
            
        </div>   
        
    </div>
</asp:Content>

