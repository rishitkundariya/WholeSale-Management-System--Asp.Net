<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="RetailerAddEdit.aspx.cs" Inherits="Content_ASPWMS_Retailer_RetailerAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
     <asp:Label ID="lblPageHeading" runat="server" Text="Retailer"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Retailer
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
               <b><span class="text-danger">*</span> Retailer Name &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtRetailerName" runat="server" CssClass="form-control"  placeholder="Enter Retailer Name"></asp:TextBox>
                  </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="rfvRetailerName" runat="server" ErrorMessage="Enter Retailer Name " CssClass="text-danger" Display="Dynamic" ControlToValidate="txtRetailerName" SetFocusOnError="True" ValidationGroup="Save" ></asp:RequiredFieldValidator>
           
                 </div>
        </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b><span class="text-danger">*</span> Mobile Number &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control"  placeholder="Enter Mobile Number"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                 <asp:RegularExpressionValidator ID="revMobileNuber" runat="server" ErrorMessage=" Enter  Ten Digit Number" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtMobileNumber" ValidationGroup="Save" ValidationExpression="\d{10}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ErrorMessage="Enter Mobile Number" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="True" ControlToValidate="txtMobileNumber" CssClass="text-danger"
></asp:RequiredFieldValidator>
            </div>
         </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b><span class="text-danger">*</span> Shop Name &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtShopName" runat="server" CssClass="form-control"  placeholder="Enter Shop Name"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                <asp:RequiredFieldValidator ID="rfvShopName" runat="server" ErrorMessage="Enter Shop Name"  CssClass="text-danger" Display="Dynamic" ControlToValidate="txtShopName" ValidationGroup="Save"  SetFocusOnError="True"></asp:RequiredFieldValidator>
               
            </div>
         </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b><span class="text-danger">*</span> Shop Address &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtShopAddress" runat="server" CssClass="form-control"  placeholder="Enter Shop Address " TextMode="MultiLine" Rows="3"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                <asp:RequiredFieldValidator ID="rfvShopAddress" runat="server" ErrorMessage="Enter Shop Address"  CssClass="text-danger" Display="Dynamic" ControlToValidate="txtShopAddress" ValidationGroup="Save"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                
            </div>
         </div>
 
       <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b><span class="text-danger">*</span> City &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
               
            </div>
            <div class="col-md-4">  
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Select City " SetFocusOnError="True" CssClass="text-danger" Display="Dynamic" ControlToValidate="ddlCity" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
         </div>
  
       <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b><span class="text-danger">*</span> Transport Name &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtTransport" runat="server" CssClass="form-control"  placeholder="Enter Transport Name"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                <asp:RequiredFieldValidator ID="rfvTransportName" runat="server" ErrorMessage="Enter Transport Name" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtTransport" ValidationGroup="Save"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                
            </div>
         </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b>&nbsp;&nbsp; Email &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"  placeholder="Enter Email"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                 <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage=" Enter Emial in  Proper 
Formate" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="Save"  SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
         </div>

       <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-4" style="padding-left:6rem; margin-bottom:4rem">
                <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="btn btn-primary margin-10" ValidationGroup="Save" OnClick="btnSave_Click" />
               <asp:Button ID="btnCancle" runat="server" Text="Cancel"  CssClass="btn btn-danger margin-10" OnClick="btnCancle_Click" />

            </div>
            
             
            
        </div>   
        
    </div>
</asp:Content>

