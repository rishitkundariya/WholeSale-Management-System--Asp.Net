<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Content_ASPWMS_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js"></script>
    <meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

   
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/bootstrap/css/bootstrap.min.css")%>">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/fonts/font-awesome-4.7.0/css/font-awesome.min.css")%>">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/fonts/iconic/css/material-design-iconic-font.min.css")%>">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/animate/animate.css")%>">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/css-hamburgers/hamburgers.min.css")%>">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/animsition/css/animsition.min.css")%>">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/select2/select2.min.css")%>">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/daterangepicker/daterangepicker.css")%>">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/css/util.css")%>">
	<link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/css/main.css")%>">

</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnLogin" runat="server">
            <div class="limiter">
		<div class="container-login100" style="background-image: url('Assets/assets/img/bg-01.jpg');">
			<div class="wrap-login100">
				<span class="login100-form-title p-b-34 p-t-27">Log in </span>
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="false"></asp:Label> <br /><br />
                <div class="wrap-input100 validate-input" >
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input100" EnableViewState="False" ></asp:TextBox>
                    <span class="focus-input100  " data-placeholder="Username"></span>
                </div>
                <div class="wrap-input100 validate-input" >
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input100"  TextMode="Password" EnableViewState="False"></asp:TextBox>
                    <span class="focus-input100" data-placeholder="Password"></span>
                </div>
                
                <div class="container-login100-form-btn">
                    <asp:Button ID="btnLogin" runat="server" CssClass=" btn btn-light form-control" Text="Login" OnClick="btnLogin_Click" />
                </div>
                <div class="text-center p-t-40">
                    <asp:Button ID="btnForgetPassword" runat="server" CssClass="btn btn-danger form-control" OnClick="btnForgetPassword_Click" Text="Forget Password" />
                </div>
			</div>
		</div>
	</div>
        </asp:Panel>
        <asp:Panel ID="pnForgetPassword" runat="server" Visible="false">
                   <div class="limiter">
		<div class="container-login100" style="background-image: url('Assets/assets/img/bg-01.jpg');">
			<div class="wrap-login100">
				<span class="login100-form-title p-b-34 p-t-27">Reset Password </span>
                 <asp:Label ID="lblMessageForget" runat="server" CssClass="text-danger" EnableViewState="False"></asp:Label> <br />
                <div class="wrap-input100 validate-input" data-validate="Enter username">
                   <asp:TextBox ID="txtUsernameforget" runat="server" CssClass="input100" EnableViewState="False" ></asp:TextBox>
                    <span class="focus-input100  " data-placeholder="Username"></span>
                </div>
                <div class="contact100-form-checkbox">
                   
                   
                   </div>
                <div class="container-login100-form-btn">
                    <asp:Button ID="btnSubmit" runat="server" CssClass=" btn btn-light form-control" Text="Sumbit" OnClick="btnSubmit_Click" />
                </div>
                  <div class="text-center p-t-40">
                    <asp:Button ID="btnLoginFromForget" runat="server" CssClass="btn btn-dark form-control"  Text="Login" OnClick="btnLoginFromForget_Click" />
                </div>
               
			</div>
		</div>
	</div>

        </asp:Panel>

    </form>

 <!--===============================================================================================-->
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/jquery/jquery-3.2.1.min.js")%>"></script>
<!--===============================================================================================-->
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/animsition/js/animsition.min.js")%>"></script>
<!--===============================================================================================-->
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/bootstrap/js/popper.js")%>"></script>
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/bootstrap/js/bootstrap.min.js")%>"></script>
<!--===============================================================================================-->
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/select2/select2.min.js")%>"></script>
<!--===============================================================================================-->
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/daterangepicker/moment.min.js")%>"></script>
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/daterangepicker/daterangepicker.js")%>"></script>
<!--===============================================================================================-->
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/vendor/countdowntime/countdowntime.js")%>"></script>
<!--===============================================================================================-->
	<script src="<%=ResolveClientUrl("~/Content/ASPWMS/Assets/assets/js/main.js")%>"></script>
</body>
</html>
