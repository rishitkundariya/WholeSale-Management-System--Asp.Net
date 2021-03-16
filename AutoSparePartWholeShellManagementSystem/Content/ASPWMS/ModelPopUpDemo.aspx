<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPage.master" AutoEventWireup="true" CodeFile="ModelPopUpDemo.aspx.cs" Inherits="Content_ASPWMS_ModelPopUpDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageNameForBreadcrumbs" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
   <div class="row ">
            <div class="col-md-12 text-center">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" ></asp:Label>
            </div>
        </div>
    <div class="table-responsive">
        <asp:GridView ID="GridView1"
            CssClass="table table-bordered table-hover table-striped thead-dark"
            AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField DataField="CityID" HeaderText="ID" />
                <asp:BoundField DataField="CityName" HeaderText="City Name" />
                <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" href="#myModal" data-toggle="modal" runat="server">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <!-- this is bootstrp modal popup -->
    <div id="myModal" class="modal fade" tabindex="-1" role="dialog"
        aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="exampleModalLabel">Edit City</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                      <div class="row" style="margin: 20px;">
                        <div class="col-md-6" style="float: right">
                            <b><span class="text-danger">*</span> City ID &nbsp;:-</b>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin: 20px;">
                        <div class="col-md-6" style="float: right">
                            <b><span class="text-danger">*</span>  City Name &nbsp;:-</b>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin: 20px;">
                        <div class="col-md-6" style="float: right">
                            <b>&nbsp;&nbsp; Pincode &nbsp;:-</b>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" class="btn btn-success" OnClick="btnSave_Click"  />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

