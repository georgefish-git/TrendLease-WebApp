<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TrendLease_WebApp.Sample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <%-- Bootstrap --%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <%-- CSS --%>
    <link href="Styles/Entry.css" rel="stylesheet" type="text/css" />

    <title></title>
</head>
<body>
    <div class="container">
        <div class="row justify-content-center align-items-center">

            <div class="col-md-6">
                <h1 class="logo">TREND<span>LEASE</span></h1>
                <h1 class="tagline">Join the Trend</h1>
            </div>

            <div class="col-md-6 card box--container">
                <form id="loginForm" runat="server">

                    <div class="text">
                        <p class="header">Log in</p>
                    </div>

                    <div class="form-group">
                        <label for="username">Username:</label>
                        <asp:TextBox autocomplete="off" ID="username" CssClass="email" runat="server" placeholder="Enter Username" />

                    </div>

                    <div class="form-group">
                        <label for="password">Password:</label>
                        <asp:TextBox autocomplete="off" ID="password" CssClass="password" runat="server" TextMode="Password" placeholder="Enter Password" />
                    </div>

                    <asp:Button ID="loginBtn" CssClass="button" runat="server" Text="Sign In" OnClick="loginBtn_Click" />
                    <div class="text">
                        <p>Don't have an account yet? <a href="Register.aspx">Sign Up!</a></p>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
