<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="InvoiceListByDate.aspx.cs" Inherits="Content_ASPWMS_Invoice_InvoiceListByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" ></script>
 
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    Invoice List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
    Invoice List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTital" runat="Server">
    Invoice List By Date
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphmMainContent" runat="Server">
     <script type="text/javascript">  
         function StateCity(input) {
            
            var displayIcon = "img" + input;  
             if ($("#" + displayIcon).attr("src") == "../Assets/assets/img/icon/icons8-plus-512.png") {

                 $("#" + displayIcon).closest("tr")
                     .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                         .html() + "</td></tr>");
                   $("#" + displayIcon).attr("src", "../Assets/assets/img/icon/icons8-minus-96.png");
             }
             else {
                  $("#" + displayIcon).closest("tr").next().remove();  
                $("#" + displayIcon).attr("src", "../Assets/assets/img/icon/icons8-plus-512.png");
             }
           
        }  
    </script> 
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row">

            <div class="col-md-12 table-responsive shadow-lg p-3 mb-5 bg-white rounded float-right">
                <asp:GridView ID="gvInvoiceList" runat="server" CssClass="table table-bordered  table-striped thead-dark" AutoGenerateColumns="False" DataKeyNames="Date" OnRowDataBound="gvInvoiceList_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a  href="JavaScript:StateCity('div<%# Eval("Date")%>');" Class="mr-10 margin-bottom-5 hrightwidth btntras"  >
                                    <img alt="City" id="imgdiv<%# Eval("Date") %>"   src="../Assets/assets/img/icon/icons8-plus-512.png"  Class="mr-10 margin-bottom-5 hrightwidth btntras" />  
                                     </a> 
                                   
                                <div id="div<%#Eval("Date")%>" style="display:none">
                                    <asp:GridView ID="gvInvoice" runat="server" CssClass="table table-bordered  table-striped thead-dark" AutoGenerateColumns="False" DataKeyNames="Date">
                                        <Columns>
                                           <asp:BoundField DataField="InvoiceID" HeaderText="ID" />
                                            <asp:BoundField DataField="ShopName" HeaderText="Shop Name" />
                                          <%--  <asp:BoundField DataField="Date" HeaderText="Date" />--%>
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="NumberOfInvoice" HeaderText="Number Of Invoice " />
                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>





</asp:Content>

