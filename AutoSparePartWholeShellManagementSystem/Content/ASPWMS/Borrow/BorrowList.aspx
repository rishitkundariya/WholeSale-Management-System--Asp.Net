<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="BorrowList.aspx.cs" Inherits="Content_ASPWMS_Borrow_BorrowList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    Borrow
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Borrow List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTital" Runat="Server">
    Borrow List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphmMainContent" Runat="Server">
     <div class="Container">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <div class="row">
             <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
               <asp:GridView ID="gvBorrow" runat="server" CssClass="table table-bordered thead-dark" AutoGenerateColumns="False"  >  
                   <columns>
                       <asp:TemplateField HeaderText="Sr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="RetailerName" HeaderText="Name" />
                       <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No" />
                       <asp:BoundField DataField="Borrow" HeaderText="Amount" />
                   </columns>
                </asp:GridView> 
                
            </div>
        </div>
    </div>
      <script>
     $(document).ready( function () {
    $('#<%= gvBorrow.ClientID%>').DataTable();
    } );
 </script>
</asp:Content>

