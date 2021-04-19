<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="SupplierList.aspx.cs" Inherits="Content_ASPWMS_Supplier_SupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    Supplier
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Supplier List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphTital" runat="Server">
  Supplier List 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">
      
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 margin-10">
                <asp:Button ID="btnAddSupplier" runat="server" Text="Add Supplier" CssClass="btn btn-primary btntras" style="float:right" OnClick="btnAddSupplier_Click" />
            </div>
        </div>

    <div class="row">

        <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded ">
            <asp:GridView ID="gvSupplierList" runat="server" CssClass="table table-bordered table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvRetailerList_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SupplierID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" />
                    <asp:BoundField DataField="Number" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="BrandName" HeaderText="Brand Name" />
                    <asp:BoundField DataField="CityName" HeaderText="City Name" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server"
                                CssClass="btntras mr-10 margin-bottom-5 hrightwidth"
                                ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                CommandName="DeleteItem" CommandArgument='<%#Eval("SupplierID")%>' />
                            <asp:ImageButton ID="btnEdit" runat="server"
                                CssClass="btntras margin-bottom-5 hrightwidth"
                                CommandName="Edit" ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/Edit.png"
                                CommandArgument='<%#Eval("SupplierID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

        </div>

    </div>
    </div>
     <script>
         $(document).ready(function () {
             $('#<%= gvSupplierList.ClientID%>').DataTable();
         });
     </script>
</asp:Content>

