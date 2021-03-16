<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="Content_ASPWMS_City_City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    City
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    City List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
    <div class="container">
        <div class="row ">
            <div class="col-md-12 text-center">
                <h2>City List</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-9" style="float:right">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" ></asp:Label>
            </div>
            <div class="col-md-2 margin-10" style="float:right" >
                <asp:Button ID="btnAdd" runat="server" Text="Add City" CssClass="btn btn-primary" OnClick="btnAdd_Click" style="float:right"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
               <asp:GridView ID="gvCity" runat="server" CssClass="table table-bordered table-hover table-striped thead-dark" AutoGenerateColumns="False" OnRowCommand="gvCity_RowCommand">  
                   <columns>
                       <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CityID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="CityName" HeaderText="City Name" />
                    <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                       <asp:TemplateField>
                           <ItemTemplate >
                                <asp:Button ID="btnDelete" runat="server" 
                                    Text="Delete" 
                                    CssClass="btn rounded-pill btn-danger btn-sm  margin-right-5 margin-bottom-5"  
                                    CommandName="DeleteItem" CommandArgument='<%#Eval("CityID")%>' />
                                 <asp:Button ID="btnEdit" runat="server" 
                                    CssClass="btn btn-dark btn-sm rounded-pill margin-right-5 margin-bottom-5" text="Edit" 
                                    CommandName="EditItem" CommandArgument='<%#"~/Content/ASPWMS/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString() %>' />
                           </ItemTemplate>
                       </asp:TemplateField>
                   </columns>
                </asp:GridView> 
                
            </div>
        </div>

    </div>
     <script>
     $(document).ready( function () {
    $('#<%= gvCity.ClientID%>').DataTable();
    } );
 </script>
</asp:Content>

