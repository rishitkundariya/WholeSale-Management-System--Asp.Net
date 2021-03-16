<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Content_ASPWMS_Product_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    Product
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Product List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">

        <div class="row ">
            <div class="col-md-12 text-center">
                <h2>Product List</h2>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col-md-9" style="float: right">
                <asp:label id="lblMessage" runat="server" text="" cssclass="text-danger"></asp:label>
            </div>
            <div class="col-md-2 margin-10" style="float: right">
                <asp:button id="btnAdd" runat="server" text="Add Product" cssclass="btn btn-primary" style="float: right" onclick="btnAdd_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-11 table-responsive shadow-lg p-3 mb-5 bg-white rounded ">
                <asp:gridview id="gvProduct" runat="server" cssclass="table table-bordered table-hover table-striped thead-dark" autogeneratecolumns="False" onrowcommand="gvProduct_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No">
                         <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
                        <asp:BoundField DataField="BrandName" HeaderText="Brand Name" />
                        <asp:BoundField DataField="Product_Price" HeaderText="Product Price" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn rounded-pill btn-danger btn-sm margin-right-5 margin-bottom-5 " CommandName="DeleteItem" CommandArgument='<%#Eval("ProductID")%>' />
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-dark btn-sm rounded-pill margin-right-5 margin-bottom-5 " CommandName="Edit" CommandArgument='<%#"~/Content/ASPWMS/Product/ProductAddEdit.aspx?ProductID=" + Eval("ProductID").ToString() %>' Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:gridview>

            </div>
        </div>

    </div>
    <script>
        $(document).ready(function () {
            $('#<%= gvProduct.ClientID%>').DataTable();
        });
    </script>

</asp:Content>

