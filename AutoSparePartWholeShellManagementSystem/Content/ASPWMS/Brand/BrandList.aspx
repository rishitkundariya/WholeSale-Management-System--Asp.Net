<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="BrandList.aspx.cs" Inherits="Content_ASPWMS_Brand_BrandList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    Brand
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
     Brand List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
    <div class="container">
         <div class="row ">
            <div class="col-md-12 text-center">
                <h2>Brand List</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-9" style="float:right">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" ></asp:Label>
            </div>
            <div class="col-md-2 margin-10" style="float:right" >
                <asp:Button ID="btnAdd" runat="server" Text="Add Brand" CssClass="btn btn-primary"  style="float:right" OnClick="btnAdd_Click"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
               <asp:GridView ID="gvBrandList" runat="server" CssClass="table  table-bordered  table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvBrandList_RowCommand" >  
                   <columns>
                       <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BrandID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="BrandName" HeaderText="Brand Name" />
                    <asp:BoundField DataField="BrandSortName" HeaderText="Brand SortName" />
                       <asp:TemplateField>
                           <ItemTemplate >
                                <asp:ImageButton ID="btnDelete" runat="server" 
                                    ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                    CssClass="mr-10 margin-bottom-5 hrightwidth btntras"  CommandName="DeleteItem" CommandArgument='<%#Eval("BrandID")%>'  />
                                  <asp:ImageButton ID="btnEdit" runat="server" 
                                      ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/Edit.png"
                                      CssClass=" margin-bottom-5 hrightwidth btntras" 
                                      CommandName="Edit" CommandArgument='<%#"~/Content/ASPWMS/Brand/BrandAddEdit.aspx?BrandID=" + Eval("BrandID").ToString() %>' Text="Edit" />
                           </ItemTemplate>
                       </asp:TemplateField>
                      
                   </columns>
                </asp:GridView> 
                
            </div>
        </div>

    </div>
     <script>
     $(document).ready( function () {
    $('#<%= gvBrandList.ClientID%>').DataTable();
    } );
 </script>
</asp:Content>

