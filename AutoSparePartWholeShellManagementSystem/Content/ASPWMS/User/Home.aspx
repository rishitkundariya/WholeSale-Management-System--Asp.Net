<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/User/MasterPageForHome.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Content_ASPWMS_USER_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Home
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTital" runat="Server">
    
    <asp:Label ID="lblRetailerName" runat="server" Text="Welcome " EnableViewState="false"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">
        <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
        <asp:Panel ID="pnContent" runat="server">

        <div class="row">
            <div class="col-md-2">
                ShopName :
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblShopName" runat="server" Text="gfrg"></asp:Label>
            </div>
            <div class="col-md-2">
                Shop Address :
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblShopAddress" runat="server" Text="gfrg"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                Mobile No :
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblMobileNO" runat="server" Text="gfrg"></asp:Label>
            </div>
            <div class="col-md-2">
                Email :
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblEmail" runat="server" Text="gfrg"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="offset-3 col-md-3">
                Transport Name :
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblTrasportName" runat="server" Text="gfrg"></asp:Label>
            </div>

        </div>

        <br />

        <div class="row">
            <div class="col-md-12" style="text-align: center">
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn btn-danger" OnClick="btnChangePassword_Click" />
            </div>
        </div>
             <br />
             <br />
             <br />
             <p><b>If any Information which display above is wrong than contact us immediate.</b></p>
          </asp:Panel>

        

        <asp:Panel ID="pnChangePassword" runat="server" Visible="false">
            <div class="row margin-10">
                <div class="col-md-4">
                    Old Password :
                </div>
                  <div class="col-md-4">
                      <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" palceholder="Enter Old Password" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvOldPassword" 
                          runat="server" ErrorMessage="Enter Old Password"  
                          SetFocusOnError="True" 
                          ControlToValidate="txtOldPassword"
                          Display="Dynamic" CssClass="text-danger" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row margin-10">
                <div class="col-md-4">
                    New Password :
                </div>
                  <div class="col-md-4">
                      <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" palceholder="Enter New Password" EnableViewState="false"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvtxtNewPassword" 
                          runat="server" ErrorMessage="Enter New Password"  
                          SetFocusOnError="True" 
                          ControlToValidate="txtNewPassword"
                          Display="Dynamic" CssClass="text-danger" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row margin-10">
                <div class="col-md-4">
                    Retype New Password :
                </div>
                  <div class="col-md-4">
                      <asp:TextBox ID="txtReNewPassword" runat="server" CssClass="form-control" palceholder="Enter Again New Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtReNewPassword" 
                          runat="server" ErrorMessage="Enter Again New Password"  
                          SetFocusOnError="True" 
                          ControlToValidate="txtReNewPassword"
                          Display="Dynamic" CssClass="text-danger" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row margin-10">
                <div class="col-md-12 text-center">
                     <asp:Button ID="btnChgPassword" runat="server" Text="Change Password" CssClass="btn btn-primary margin-10" ValidationGroup="ChangePassword" OnClick="btnChgPassword_Click" />
                    <asp:Button ID="btnHide" runat="server" Text="Cancel" CssClass="btn btn-danger margin-10" OnClick="btnHide_Click"/>
                </div>
                
            </div>
        </asp:Panel>
        <br />
        

    </div>
</asp:Content>

