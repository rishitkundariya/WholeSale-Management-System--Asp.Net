<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="InvoiceAddEdit.aspx.cs" Inherits="Content_ASPWMS_Invoice_InvoiceAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js" ></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
   Invioce
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Invoice | Make Edit
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphTital" runat="Server">
   <asp:label runat="server" ID="lblMainHeading" >Make Invoice</asp:label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container-fluid">

        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
        </div>

        <div class="row" style="margin: 10px;">

            <div class="offset-md-2 col-md-3 text-right" style="float: right; vertical-align: middle;">
               <b> <span class="text-danger">*</span>Shop Name:</b>
            </div>

            <div class=" col-md-5" style="margin-bottom: 20px;">
                <asp:DropDownList ID="ddlShopList" runat="server" CssClass="form-control select2me"  OnSelectedIndexChanged="ddlShopList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlShopName" runat="server" ErrorMessage="Select Shop Name " CssClass="text-danger" Display="Dynamic" ControlToValidate="ddlShopList"  ValidationGroup="save" InitialValue="-1" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>

            
          


        </div>

        <div class="row" style="margin: 5px;">
            <div class="col-md-2 text-right" >
               <b><span class="text-danger">*</span>Date:</b>
            </div>

            <div class=" col-md-3 col-from-lable" style="margin-bottom: 20px;">
                <asp:TextBox runat="server" ID="txtDate" TextMode="Date" CssClass="form-control font-weight-bold"></asp:TextBox>
            </div>

            <div class="offset-md-1 col-md-2 text-right">
                <b>Retailer Name &nbsp;:</b>
            </div>

            <div class="col-md-3 col-from-lable">
                <asp:Label ID="lblretailerName" runat="server" Text="" CssClass="form-control font-weight-bold "></asp:Label>
            </div>

        </div>

        <div class="row" style="margin: 5px;">

            <div class="col-md-2 text-right" >
                <b>Transport Name:</b>
            </div>

            <div class=" col-md-3 col-from-lable" style="margin-bottom: 20px;">
                <asp:Label ID="lblTransportName" runat="server" Text=""  CssClass="form-control font-weight-bold"></asp:Label>
            </div>

            <div class="offset-md-1 col-md-2 text-right">
                <b>City Name &nbsp;:</b>
            </div>
            <div class="col-md-3 col-from-lable">
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" ></asp:DropDownList>
            </div>

        </div>

        <hr />

        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="btnCancle" runat="server" Text="Cancle" CssClass="btn btn-danger" OnClick="btnCancle_Click" />
                <asp:Button ID="btnMakeInvoice" runat="server" Text="Make Invoice" CssClass="btn btn-warning" OnClick="btnMakeInvoice_Click" ValidationGroup="save" />  
            </div>
        </div>

      

    </div>
   <script>
        $('#<%=ddlShopList.ClientID%>').chosen();
    </script>
</asp:Content>

