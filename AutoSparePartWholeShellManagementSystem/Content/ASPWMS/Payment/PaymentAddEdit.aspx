<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentAddEdit.aspx.cs" Inherits="Content_ASPWMS_Payment_PaymentAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
   <asp:Label ID="lblPageHeading" runat="server" Text="Add Payment Details"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Payment Add | Edit
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
        </div>
        <div class="row" style="margin: 20px;">
            <div class="col-md-3 text-right" >
                <b><span class="text-danger">*</span>  Payment Type &nbsp;:</b>
            </div>

            <div class="col-md-4" style="margin-left: 1rem;">
                <asp:RadioButton ID="rbCredit" runat="server" GroupName="PaymentType" Checked="True" Text="Credit" AutoPostBack="True" OnCheckedChanged="rbCredit_CheckedChanged"  />&nbsp;&nbsp;
                <asp:RadioButton ID="rbDebit" runat="server" GroupName="PaymentType" Text="Debit" AutoPostBack="True" OnCheckedChanged="rbCredit_CheckedChanged"  />

            </div>

        </div>

        <div class="row" style="margin: 20px;">
            <div class="col-md-3 text-right" >
                <b><span class="text-danger">*</span> Payment Person &nbsp;:</b>
            </div>

            <div class="col-md-4">
                <asp:DropDownList ID="ddlPaymentPerson" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:RequiredFieldValidator ID="rfvPaymentPerson" runat="server" ErrorMessage="Select anyone" ControlToValidate="ddlPaymentPerson" SetFocusOnError="True" Display="Dynamic" CssClass="text-danger" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row" style="margin: 20px;">
            <div class="col-md-3 text-right" >
                <b><span class="text-danger">*</span> Amount &nbsp;:</b>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"  CssClass="form-control"  placeholder="Enter Amount"></asp:TextBox>

            </div>
            <div class="col-md-4">
                <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ErrorMessage="Enter Amount" ControlToValidate="txtAmount" SetFocusOnError="True" Display="Dynamic" CssClass="text-danger" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row" style="margin: 20px;">
            <div class="col-md-3 text-right" >
                <b><span class="text-danger">*</span> Date &nbsp;:</b>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                 <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Enter Date" ControlToValidate="txtDate" SetFocusOnError="True" Display="Dynamic" CssClass="text-danger" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row" style="margin: 20px;">
            <div class="col-md-3 text-right">
                <b>&nbsp;&nbsp; Discription  &nbsp;:</b>
            </div>

            <div class="col-md-4">
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="2"  CssClass="form-control"  placeholder="Enter Payment Dispcription "></asp:TextBox>
            </div>
            <div class="col-md-4">
            </div>
        </div>

        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-4" style="padding-left: 6rem; margin-bottom: 4rem">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btntras btn btn-primary margin-10" ValidationGroup="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancle" runat="server" Text="Cancel" CssClass="btntras btn btn-danger margin-10" OnClick="btnCancle_Click" />

            </div>


        </div>
    </div>
</asp:Content>

