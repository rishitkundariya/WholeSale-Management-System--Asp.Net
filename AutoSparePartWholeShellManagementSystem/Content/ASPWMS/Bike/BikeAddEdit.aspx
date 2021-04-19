<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="BikeAddEdit.aspx.cs" Inherits="Content_ASPWMS_Bike_BikeAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .btn-primary {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
   Bike
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Bike Add | Edit
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphTital" Runat="Server">
     <asp:Label ID="lblMainHeading" runat="server" Text="Add Bike"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
    <div class="container ">

       <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
        </div>
    
       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right" >
               <b><span class="text-danger">*</span> Bike Name &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtBikeName" runat="server" CssClass="form-control"  placeholder="Enter Bike Name"></asp:TextBox>
                  </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="rfvBikeName" runat="server" ErrorMessage="Enter Bike Name " CssClass="text-danger" Display="Dynamic" ControlToValidate="txtBikeName" SetFocusOnError="True" ValidationGroup="Save" ></asp:RequiredFieldValidator>
           
                 </div>
        </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right" >
               <b><span class="text-danger">*</span> Company Name &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"  placeholder="Enter Company Name"></asp:TextBox>
                  </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ErrorMessage="Enter company Name " CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCompanyName" SetFocusOnError="True" ValidationGroup="Save" ></asp:RequiredFieldValidator>
           
                 </div>
        </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right" >
               <b><span class="text-danger">*</span>  Model Number &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtBikeModelNumber" runat="server" CssClass="form-control"  placeholder="Enter Bike Model Number"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                 <asp:RegularExpressionValidator ID="revMobileNuber" runat="server" ErrorMessage=" Enter Bike Model Number in 4 Digit" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtBikeModelNumber" ValidationGroup="Save" ValidationExpression="\d{4}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ErrorMessage="Enter Bike Model Number" Display="Dynamic" ValidationGroup="Save" SetFocusOnError="True" ControlToValidate="txtBikeModelNumber" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
         </div>

       <div class="row" style="margin:20px;">
            <div class="col-md-3 text-right" >
               <b>  &nbsp;&nbsp; Bike Model year &nbsp;:</b>
            </div>
            
            <div class="col-md-4">
              <asp:TextBox ID="txtBikeModelYear" runat="server" CssClass="form-control"  placeholder="Enter Bike Model year"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
               
               
            </div>
         </div>

       <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-6" style="padding-left:5rem; margin-bottom:4rem">
                <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="btn btn-info margin-10" ValidationGroup="Save" OnClick="btnSave_Click" />
               <asp:Button ID="btnCancle" runat="server" Text="Cancel"  CssClass="btn btn-danger margin-10" OnClick="btnCancle_Click" />

            </div>
            
             
            
        </div>
        
    </div>
</asp:Content>

