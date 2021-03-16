<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="SupplierList.aspx.cs" Inherits="Content_ASPWMS_Supplier_SupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    Supplier
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Supplier List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
      <div class="container">
          <div class="row ">
            <div class="col-md-12 text-center">
                <h2>Supplier List</h2>
                <hr />
            </div>
        </div>
          <div class="row">
            <div class="col-md-9" style="float:right">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="False"></asp:Label>
            </div>
            <div class="col-md-2 margin-10" style="float:right" >
                <asp:Button ID="btnAddSupplier" runat="server" Text="Add Supplier" CssClass="btn btn-primary"  style="float:right" OnClick="btnAddSupplier_Click"/>
            </div>
        </div>
        <div class="row">
            
            <div class="col-md-11 table-responsive shadow-lg p-3 mb-5 bg-white rounded ">
               <asp:GridView ID="gvSupplierList" runat="server" CssClass="table table-bordered table-hover table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvRetailerList_RowCommand">  
                   <columns>
                       <asp:TemplateField HeaderText="Sr No">
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
                           <ItemTemplate >
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn rounded-pill btn-danger btn-sm margin-right-5 margin-bottom-5 "  CommandName="DeleteItem" CommandArgument='<%#Eval("SupplierID")%>'  />
                                 <asp:Button ID="btnEdit" runat="server" CssClass="btn rounded-pill btn-dark btn-sm margin-right-5 margin-bottom-5" CommandName="Edit"
                                     CommandArgument='<%#"~/Content/ASPWMS/Supplier/SupplierAddEdit.aspx?SupplierID=" + Eval("SupplierID").ToString() %>' Text="Edit" />
                           </ItemTemplate>
                       </asp:TemplateField>
                   </columns>
                  
                </asp:GridView> 
                
            </div>
            
        </div>
    </div>
     <script>
     $(document).ready( function () {
    $('#<%= gvSupplierList.ClientID%>').DataTable();
    } );
 </script>
</asp:Content>

