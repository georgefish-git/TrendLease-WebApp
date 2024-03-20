<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TrendLease_WebApp.Register_1" %>

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
                <form id="registerForm" runat="server">

                    <div class="text">
                        <p class="header">Register</p>
                    </div>

                    <div class="form-group">
                        <label for="username">First Name:</label>
                        <asp:TextBox autocomplete="off" ID="fNameTxtBox" CssClass="email" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="fnameTxtBox" runat="server" ErrorMessage="First Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="fnameTxtBox" runat="server" ErrorMessage="Invalid Input."  ValidationExpression="^[a-zA-Z\s]{1,50}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    
                    </div>
                    <div class="form-group">
                        <label for="password">Last Name:</label>
                        <asp:TextBox autocomplete="off" ID="lNameTxtBox" CssClass="password" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="lnameTxtBox" runat="server" ErrorMessage="Last Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="lnameTxtBox" runat="server" ErrorMessage="Invalid Input."  ValidationExpression="^[a-zA-Z\s]{1,50}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    
                    </div>

                     <div class="form-group">
                         <label for="username">Enter Address:</label>
                         <asp:TextBox autocomplete="off" ID="addressTxtBox" CssClass ="email" runat="server" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="addressTxtBox" runat="server" ErrorMessage="Address is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="addressTxtBox" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^[a-zA-Z0-9\s\-,.'#/]{1,100}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                     </div>

                    <div class="form-group">
                        <label for="username">Email:</label>
                        <asp:TextBox autocomplete="off" ID="emailTxtBox" CssClass="email" runat="server" Placeholder ="e.g. (abcdefg@gmail.com)" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="emailTxtBox" runat="server" ErrorMessage="Email is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Must be a valid E-mail!" ControlToValidate="emailTxtBox" ForeColor="Red" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>


                    <div class="form-group">
                        <label for="username">Enter Phone Number:</label>
                        <asp:TextBox autocomplete="off" ID="phoneNoTxtBox" CssClass="email" runat="server" Placeholder ="e.g. (09112223333)"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="phoneNoTxtBox" runat="server" ErrorMessage="Phone Number is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="phoneNoTxtBox" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^09\d{9}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                    </div>

                    <div class="form-group">
                        <label for="username">Username:</label>
                        <asp:TextBox autocomplete="off" ID="usernameTxtBox" CssClass="email" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="usernameTxtBox" runat="server" ErrorMessage="Username is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="usernameTxtBox" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^(?=.*[a-zA-Z])[a-zA-Z][a-zA-Z0-9]{2,49}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                    </div>

                    <div class="form-group">
                        <label for="username">Password:</label>
                        <asp:TextBox autocomplete="off" ID="pass1TxtBox" CssClass="email" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="pass1TxtBox" runat="server" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="pass1TxtBox" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^(?=.{1,50}$).*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>


                    </div>


                    <div class="form-group">
                        <label for="username">Confirm Password:</label>
                        <asp:TextBox autocomplete="off" ID="pass2TxtBox" CssClass="email" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="pass2TxtBox" runat="server" ErrorMessage="Password is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="pass2TxtBox" runat="server" ErrorMessage="Invalid Input." ValidationExpression="^(?=.{1,50}$).*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CompareValidator6" ControlToValidate="pass2TxtBox" ControlToCompare="pass1TxtBox" Operator="Equal" Type="String" runat="server" ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic"></asp:CompareValidator>

                    </div>


                    <asp:Button ID="registerBtn" CssClass="button" runat="server" Text="Create Account" OnClick="registerBtn_Click" />
                    <div class="text">
                        <p>Already have an account? <a href="Login.aspx">Sign In!</a></p>
                    </div>
                </form>
            </div>

        </div>
    </div>
</body>
</html>
