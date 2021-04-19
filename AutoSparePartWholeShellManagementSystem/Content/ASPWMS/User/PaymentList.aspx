<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPageForHome.master" AutoEventWireup="true" CodeFile="PaymentList.aspx.cs" Inherits="Content_ASPWMS_User_PaymentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    Payment
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Payment List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTital" Runat="Server">
    Payment List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphmMainContent" Runat="Server">
    <div class="Container">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <div class="row">
             <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
               <asp:GridView ID="gvPayment" runat="server" CssClass="table table-bordered thead-dark" AutoGenerateColumns="False"  >  
                   <columns>
                       <asp:TemplateField HeaderText="Sr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="Payment_Amount" HeaderText=" Amount" />
                       <asp:BoundField DataField="ShopName" HeaderText="Person Name" />
                       <asp:BoundField DataField="Payment_Date" HeaderText=" Date" />
                       <asp:BoundField DataField="Payment_Description" HeaderText="Description" />
                   </columns>
                </asp:GridView> 
                
            </div>
        </div>
    </div>
      <script>
     $(document).ready( function () {
    $('#<%= gvPayment.ClientID%>').DataTable();
    } );
 </script>
</asp:Content>

