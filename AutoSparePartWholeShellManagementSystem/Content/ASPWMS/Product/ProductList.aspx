<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Content_ASPWMS_Product_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    Product 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Product List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphTital" runat="Server">
    Product List 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">



        <div class="row">
            <div class="col-md-9" style="float: right">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>

        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="btn btn-primary btntras" Style="margin-bottom: 10px; float: right" OnClick="btnAdd_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded ">
                <asp:GridView ID="gvProduct" runat="server" CssClass="table table-bordered table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvProduct_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.">
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
                                <asp:ImageButton ID="btnDelete" runat="server" Text="Delete" CssClass="hrightwidth mr-10 margin-bottom-5 btntras"
                                    CommandName="DeleteItem"
                                    ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                    CommandArgument='<%#Eval("ProductID")%>' />
                                <asp:ImageButton ID="btnEdit" runat="server"
                                    CssClass="margin-bottom-5 btntras hrightwidth"
                                    CommandName="Edit"
                                    ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/edit.png"
                                    CommandArgument='<%#Eval("ProductID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>
    <script>
        $(document).ready(function () {
            $('#<%= gvProduct.ClientID%>').DataTable({
              
            });

        });
    </script>

</asp:Content>

