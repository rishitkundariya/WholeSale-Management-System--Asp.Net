﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="MakeInvoice.aspx.cs" Inherits="Content_ASPWMS_Invoice_MakeInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    <asp:Label ID="lblPageHeading" runat="server" Text=" Add Item In  Invoice"> </asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Add | Edit Item In  Invoice
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">
        <div class="row" style="margin-bottom: 25px">
            <div class=" col-md-2">
                <b>Product Name</b>
            </div>

            <div class="col-md-4">
                <asp:DropDownList ID="ddlProduct" runat="server"
                    CssClass="form-control"
                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddlProduct"
                    runat="server"
                    ErrorMessage="Select Product"
                    ValidationGroup="Save"
                    CssClass="text-danger"
                    Display="Dynamic"
                    ControlToValidate="ddlProduct"
                    InitialValue="-1"></asp:RequiredFieldValidator>
            </div>

            <div class=" col-md-1">
                <b><span class="text-danger">*</span>Quntatity</b>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control text-center" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtprice" runat="server"
                    ErrorMessage="Enter Quantity"
                    Display="Dynamic"
                    CssClass="text-danger"
                    ControlToValidate="txtQuantity"
                    ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class=" col-md-1 text-center">
                <b>Price :- </b>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblPrice" runat="server" Text="" CssClass="form-control text-center col-from-label"></asp:Label>

            </div>
        </div>

        <div class="row">
            <div class="col-md-12 text-center col-from-label">
                <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="btn btn-warning" ValidationGroup="Save" OnClick="btnAddProduct_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-9 text-center" style="float: right">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <hr />

        <div class="row table-responsive">
            <asp:GridView ID="gvInvoiceItem"
                runat="server" AutoGenerateColumns="false"
                CssClass="table table-bordered table-hover table-striped thead-dark"
                ShowFooter="True" OnRowCommand="gvInvoiceItem_RowCommand"
                DataKeyNames="ProductID">
                <Columns>
                    <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="ProductID" HeaderText="ID" />--%>
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server"
                                Text="Delete"
                                CssClass="btn rounded-pill btn-danger btn-sm  margin-right-5 margin-bottom-5"
                                CommandName="DeleteItem" CommandArgument='<%# Container.DataItemIndex %>' />

                            <asp:Button ID="btnEdit" runat="server"
                                CssClass="btn btn-dark btn-sm rounded-pill margin-right-5 margin-bottom-5" Text="Edit"
                                CommandName="EditItem" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="btnCancle" runat="server" Text="Cancle" CssClass="btn btn-danger" OnClick="btnCancle_Click" />
                <asp:Button ID="btnMakeInvoice" runat="server" Text="Make Invoice" CssClass="btn btn-warning" OnClick="btnMakeInvoice_Click" />
            </div>
        </div>

    </div>

    <script>
        $('#<%=ddlProduct.ClientID%>').chosen();

        $(document).ready(function () {
            $('#<%= gvInvoiceItem.ClientID%>').DataTable();
        });

        </script>
</asp:Content>

