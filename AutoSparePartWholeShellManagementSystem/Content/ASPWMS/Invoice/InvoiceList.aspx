<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="InvoiceList.aspx.cs" Inherits="Content_ASPWMS_Invoice_InvoiceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    Invoice
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Invoice List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">
        <div class="row ">
            <div class="col-md-12 text-center">
                <h2>Invoice List</h2>
                <hr />
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row">

            <div class="col-md-12 margin-bottom-5 text-right mb-3">
                <asp:Button ID="btnAdd" runat="server" Text="Add Invoice" CssClass="btn btn-primary " Style="float: right" OnClick="btnAdd_Click" />
            </div>
        </div>

        <div class="row">

            <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
                <asp:GridView ID="gvInvoice" runat="server" CssClass="table table-bordered  table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvInvoice_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="InvoiceID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="ShopName" HeaderText="Shop Name" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnPrint" runat="server"
                                   ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/print.png"
                                    CssClass="mr-10 margin-bottom-5 hrightwidth btntras text-center"
                                    CommandName="PrintInvoice" CommandArgument='<%#"~/Content/ASPWMS/Invoice/PrintInvoice.aspx?InvoiceID=" + Eval("InvoiceID").ToString() %>' />
                              
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server"
                                   ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                    CssClass="mr-10 margin-bottom-5 hrightwidth btntras"
                                    CommandName="DeleteItem" CommandArgument='<%#Eval("InvoiceID")%>' />
                                <asp:ImageButton ID="btnEdit" runat="server"
                                    ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/Edit.png"
                                    CssClass="mr-10 margin-bottom-5 hrightwidth btntras" 
                                    CommandName="EditItem" CommandArgument='<%#"~/Content/ASPWMS/Invoice/InvoiceAddEdit.aspx?InvoiceID=" + Eval("InvoiceID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>

     <script>
     $(document).ready( function () {
    $('#<%= gvInvoice.ClientID%>').DataTable();
    } );
 </script>

</asp:Content>

