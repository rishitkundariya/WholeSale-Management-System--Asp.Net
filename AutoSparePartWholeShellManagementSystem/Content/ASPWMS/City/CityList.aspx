<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="Content_ASPWMS_City_City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    City
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    City List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphTital" runat="Server">
    City List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">

        <div class="row">
            <div class="col-md-12" style="float: right">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 margin-10" style="float: right">
                <asp:Button ID="btnAdd" runat="server" Text="Add City" CssClass="btn btn-primary btntras" OnClick="btnAdd_Click" Style="float: right" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
                <asp:GridView ID="gvCity" runat="server" CssClass="table table-bordered  table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvCity_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CityID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="CityName" HeaderText="City Name" />
                        <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server"
                                    ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                    CssClass="mr-10 margin-bottom-5 btntras hrightwidth"
                                    CommandName="DeleteItem" CommandArgument='<%#Eval("CityID")%>' />
                                <asp:ImageButton ID="btnEdit" runat="server" CssClass="margin-bottom-5 btntras hrightwidth"
                                    ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/edit.png"
                                    CommandName="EditItem" CommandArgument='<%#Eval("CityID")%>' />

                               
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>
     <script>
         $(document).ready(function () {
             $('#<%= gvCity.ClientID%>').DataTable();
         });
     </script>
</asp:Content>

