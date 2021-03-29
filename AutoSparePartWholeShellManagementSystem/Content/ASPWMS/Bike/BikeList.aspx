<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="BikeList.aspx.cs" Inherits="Content_ASPWMS_Bike_BikeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    Bike 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Bike List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
    <div class="container">
          <div class="row ">
            <div class="col-md-12 text-center">
                <h2>Bike List</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-9" style="float:right" >
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" ></asp:Label>
            </div>
            <div class="col-md-2 margin-10" style="float:right" >
                <asp:Button ID="btnAdd" runat="server" Text="Add Bike" CssClass="btn btn-primary " OnClick="btnAdd_Bike" style="float:right"/>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-11 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
               <asp:GridView ID="gvBikeList" runat="server" CssClass="table table-bordered table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvBikeList_RowCommand" >  
                   <columns>
                       <asp:TemplateField HeaderText="Sr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BikeID" HeaderText="ID" Visible="false"/>
                     <asp:BoundField DataField="BikeName" HeaderText="Bike Name" />
                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                    <asp:BoundField DataField="BikeModelNumber" HeaderText="Model Number" />
                       <asp:BoundField DataField="BikeModelYear" HeaderText="Model Year" />
                       <asp:TemplateField>
                           <ItemTemplate >
                                <asp:ImageButton ID="btnDelete" runat="server" CssClass="mr-10 margin-bottom-5 hrightwidth btntras"
                                    ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                    CommandName="DeleteItem" CommandArgument='<%#Eval("BikeID")%>'  />
                                 <asp:ImageButton ID="hypEdit" runat="server" CssClass="margin-bottom-5 hrightwidth btntras " CommandName="Edit"
                                     ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/Edit.png"
                                     CommandArgument='<%#Eval("BikeID")%>'  />
                           </ItemTemplate>
                       </asp:TemplateField>
                   </columns>
                </asp:GridView> 
                
            </div>
        </div>

    </div>   
     <script>
     $(document).ready( function () {
    $('#<%= gvBikeList.ClientID%>').DataTable();
    } );
 </script>
</asp:Content>

