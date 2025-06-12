<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" 
    Inherits="LibraryApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Librarian Registration</title>
    <style>
                    body {font-family: Arial, sans-serif; background-color: #fef2f5; margin: 0; padding: 0;}
            form {width: 400px; margin: 60px auto; padding: 30px; background-color: #fff; border-radius: 12px; box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);}
            form h2 {text-align: center;color: #2c3e50;margin-bottom: 20px;}
            label {display: block;margin-top: 15px;font-weight: bold;color: #333;}
            input[type="text"],input[type="password"] {width: 100%;padding: 8px;margin-top: 5px;border: 1px solid #ccc;border-radius: 5px;box-sizing: border-box;}
            .form-group {margin-bottom: 15px;}
            .btn {margin-top: 20px;width: 100%;padding: 10px;background-color: #27ae60;color: white;border: none;border-radius: 5px;font-weight: bold;cursor: pointer;}
            .btn:hover {background-color: #219150;}
            .message {color: red;text-align: center;margin-top: 10px;font-weight: bold;}
            .login-link {display: block;text-align: center;margin-top: 20px;color: #2980b9;text-decoration: none;}
            .login-link:hover {text-decoration: underline;}


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Register Librarian</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="message" />

        <div class="form-group">
            <label for="txtFullName">Full Name: </label>
            <asp:TextBox ID="txtFullName" runat="server" />
        </div>

        <div class="form-group">
            <lable for="txtEmail">Email: </lable>
            <asp:TextBox ID="txtEmail" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtPassword">Password: </label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        </div>

        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />

        <a href="Login.aspx" class="login-link">Already have an account? Login</a>
    </form>
</body>
</html>
