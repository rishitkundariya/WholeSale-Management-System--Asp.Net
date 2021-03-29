<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ASPWMS/MasterPageForHome.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Content_ASPWMS_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .effect:hover {
            transform: scale(1.03);
        }

        .shadowr:hover {
            box-shadow: 0 .5rem 1rem rgba(255,0,0,.5);
        }

        .shadowb:hover {
            box-shadow: 0 .5rem 1rem rgba(0,0,255,.5);
        }

        .shadowInfo:hover {
            box-shadow: 0 .5rem 1rem rgba(23, 162, 184,.5);
        }

        .shadowLight:hover {
            box-shadow: 0 .5rem 1rem rgba(248, 249, 250,.5);
        }

        .shadowSecondary:hover {
            box-shadow: 0 .5rem 1rem rgba(108, 117, 125,.5);
        }

        .btn-primary:hover {
            box-shadow: 0 .5rem 1rem rgba(0, 123, 255,.4);
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeading" runat="Server">
    Home
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphmMainContent" runat="Server">
    <div class="container">
        <span class="text-center">
            <h1>Welcome to ASPWMS</h1>
        </span>
        <hr />
        <h6>
            <p style="font-weight: 600; text-align: justify;">
                Hello, welcome to the ASPWMS (Auto Spare Part Wholesale Management Sysytem). It's devlop to manage and increase your business. I am trying to devlop system which 
             is very helpful to the Wholesaler in many ways. My self Rishit Kundariya, I am devloper of this system. Key features of this System are below.
            </p>
        </h6>
        <h6>
            <ul style="margin-top: 2rem;">
                <li>This is management system for Auto Spare Part Wholesaler.</li>
                <br />
                <li>It is manage like Retailers details, Product Details, Brand Detail, Supplier Details.</li>
                <br />
                <li>It also manage Account Details like Credit and Debit.</li>
                <br />
                <li>It is also include Simple Billing module.</li>
            </ul>
        </h6>
        <hr />
        <div class="row" style="margin-top: 3rem; margin-bottom: 2rem; margin-left: 1rem; margin-right: 1rem;">
            <div class="col-md-12 text-center">
                <h2> Statistics About ASPWMS </h2>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3 effect">
                <div class="card text-dark bg-info mb-3 shadowInfo" style="max-width: 18rem;">
                    <div class="card-header">
                        <h2>Product</h2>
                    </div>
                    <div class="card-body">
                        <p class="card-text text-left">
                              <span class="card-title call-from-lable" style="font-size:4rem;vertical-align:middle">
                                  <asp:Label ID="lblProductCount" runat="server" Text=""></asp:Label> +</span><br /> 
                            <span style="font-size:1.5rem;">Total Product</span>

                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3 effect">
                <div class="card text-dark bg-light mb-3 shadowLight" style="max-width: 18rem;">
                    <div class="card-header">
                        <h2> <i class="fa fa-user" aria-hidden="true"></i> Retailer</h2>
                    </div>
                    <div class="card-body">
                          <span class="card-title call-from-lable" style="font-size:4rem;vertical-align:middle">
                              <asp:Label ID="lblRetailerCount" runat="server" Text=""></asp:Label> +</span> <br />
                        <span style="font-size:1.5rem;">Retailer</span>
                      
                    </div>
                </div>
            </div>
            <div class="col-md-3 effect">
                <div class="card text-white bg-danger mb-3 shadowr" style="max-width: 18rem;">
                    <div class="card-header">
                        <h3>Net Balance</h3>
                    </div>
                    <div class="card-body">
                       <span class="card-title call-from-lable" style="font-size:3rem;vertical-align:middle">
                              <asp:Label ID="lblNetTotal" runat="server" Text=""></asp:Label> <i class="fas fa-rupee-sign"></i></span> <br />
                        <span style="font-size:1.5rem;">Net Balence </span>
                    </div>
                </div>

            </div>

            <div class="col-md-3 effect">
                <div class="card text-white bg-secondary mb-3 shadowSecondary" style="max-width: 18rem;">
                    <div class="card-header">
                        <h2><i class="fa fa-shopping-cart" aria-hidden="true"></i> Invoice</h2>
                    </div>
                    <div class="card-body">
                        <span class="card-title call-from-lable" style="font-size:4rem;vertical-align:middle">
                              <asp:Label ID="lblInvoiceCount" runat="server" Text=""></asp:Label> +</span> <br />
                        <span style="font-size:1.4rem;"> Order Place </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/waypoints/2.0.3/waypoints.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Counter-Up/1.0.0/jquery.counterup.min.js"></script>
    <script>
        $('.counter').counterUp({
            delay: 10,
            time: 1000
        });
    </script>
</asp:Content>


