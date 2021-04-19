<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="RetailerList.aspx.cs" Inherits="Content_ASPWMS_Retailer_RetailerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
   <i class="fas ion-ios-people  align-middle"  aria-hidden="true"  ></i> Retailer
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Retailer List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphTital" Runat="Server">
    Retailer List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
     <div class="container">
        
        <div class="row">
            <div class="col-md-12" style="float:left">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
            </div>
         <div class="row">
            <div class="col-md-12 margin-10" style="float:right" >
                <asp:Button ID="btnAddRetailer" runat="server" Text="Add Retailer" CssClass="btn btn-primary btntras"  style="float:right" OnClick="btnAddRetailer_Click"/>
            </div>
        </div>
               
       <div class="row">
            <div class="col-md-12 table-responsive shadow-sm p-3 mb-5 bg-white rounded ">
               <asp:GridView ID="gvRetailerList" runat="server" CssClass="table table-bordered  table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvRetailerList_RowCommand">  
                   <columns>
                       <asp:TemplateField HeaderText="Sr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RetailerID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="RetailerName" HeaderText="Retailer Name" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="ShopName" HeaderText="Shop Name" />
                    <asp:BoundField DataField="ShopAddress" HeaderText="Shop Address" />
                    <asp:BoundField DataField="CityName" HeaderText="City Name" />
                    <asp:BoundField DataField="TransportName" HeaderText="Transport Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email"  />
                       <asp:TemplateField ItemStyle-Width="200px">
                           <ItemTemplate  >
                                <asp:ImageButton ID="btnDelete" runat="server" CssClass="mr-10 margin-bottom-5 btntras hrightwidth"
                                     ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                    CommandName="DeleteItem" CommandArgument='<%#Eval("RetailerID")%>'  />
                                 <asp:ImageButton ID="hypEdit" runat="server" CssClass=" margin-bottom-5 btntras hrightwidth" CommandName="Edit"
                                        ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/edit.png"
                                     CommandArgument='<%#Eval("RetailerID") %>' Text="Edit" />
                           </ItemTemplate>

<ItemStyle Width="200px"></ItemStyle>
                       </asp:TemplateField>
                   </columns>
                  
                </asp:GridView> 
                
            </div>
         </div>
   </div>
     <script>
     $(document).ready( function () {
    $('#<%= gvRetailerList.ClientID%>').DataTable();
    } );
 </script>
</asp:Content>

