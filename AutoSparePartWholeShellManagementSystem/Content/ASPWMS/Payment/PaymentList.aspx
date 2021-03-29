<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentList.aspx.cs" Inherits="Content_ASPWMS_Payment_PaymentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" Runat="Server">
    Payment
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" Runat="Server">
    Payment List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" Runat="Server">
     <div class="container">
         <div class="row ">
            <div class="col-md-12 text-center">
                <h2>Payment List</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12"  >
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" ></asp:Label>
            </div>
            </div>
         <div class="row">
            
            <div class="col-md-12 margin-bottom-5 text-right mb-3" >
                <asp:Button ID="btnAdd" runat="server" Text="Add Payment" CssClass="btn btn-primary btntras"  style="float:right" OnClick="btnAdd_Click"/>
            </div>
        </div>
        <div class="row">
            
            <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
               <asp:GridView ID="gvPayment" runat="server" CssClass="table table-bordered thead-dark" AutoGenerateColumns="False" OnRowCommand="gvPayment_RowCommand" >  
                   <columns>
                       <asp:TemplateField HeaderText="Sr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="PaymentID" HeaderText="ID" Visible="false" />
                       <asp:BoundField DataField="Payment_Type" HeaderText="Payment Type" />
                       <asp:BoundField DataField="Payment_Amount" HeaderText=" Amount" />
                       <asp:BoundField DataField="ShopName" HeaderText="Person Name" />
                       <asp:BoundField DataField="Payment_Date" HeaderText=" Date" />
                       <asp:BoundField DataField="Payment_Description" HeaderText="Description" />
                       <asp:TemplateField>
                           <ItemTemplate >
                                <asp:ImageButton ID="btnDelete" runat="server"  CssClass="btntras mr-10 hrightwidth margin-bottom-5"
                                     ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/x-button.png"
                                    CommandName="DeleteItem" CommandArgument='<%#Eval("PaymentID")%>'  />
                                 <asp:ImageButton ID="btnEdit" runat="server" CssClass="btntras hrightwidth  margin-bottom-5"
                                      ImageUrl="~/Content/ASPWMS/Assets/assets/img/icon/Edit.png"
                                     CommandName="Edit" CommandArgument='<%#"~/Content/ASPWMS/Payment/PaymentAddEdit.aspx?PaymentID=" + Eval("PaymentID").ToString() %>' Text="Edit" />
                           </ItemTemplate>
                       </asp:TemplateField>
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

