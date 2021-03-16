<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="Content_ASPWMS_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    <asp:Label ID="lblPageHeading" runat="server" Text="Add City"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
   City Add | Edit
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
               <b><span class="text-danger">*</span>  City Name &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control"  placeholder="Enter City Name"></asp:TextBox>
                  </div>
            <div class="col-md-3">
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Enter City " CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCityName" SetFocusOnError="True" ValidationGroup="Save" ></asp:RequiredFieldValidator>
           
                 </div>
        </div>
         <div class="row" style="margin:20px;">
            <div class="col-md-3" style="float:right">
               <b>&nbsp;&nbsp; Pincode &nbsp;:-</b>
            </div>
            
            <div class="col-md-4">
                <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control"  placeholder="Enter Pincode"></asp:TextBox>
               
            </div>
            <div class="col-md-4">  
                 <asp:RegularExpressionValidator ID="rexPincode" runat="server" ErrorMessage=" Enter  Six Digit Pincode" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtPincode" ValidationGroup="Save" ValidationExpression="\d{6}" SetFocusOnError="True"></asp:RegularExpressionValidator>
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

