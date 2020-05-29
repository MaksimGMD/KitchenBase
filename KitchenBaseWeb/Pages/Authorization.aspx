<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authorization.aspx.cs" Inherits="KitchenBaseWeb.Pages.Authorization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../Content/css/Styles.css" />
    <title>Авторизация</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sign-form">
            <h1 class="title">Авторизация</h1>
            <asp:Label runat="server" ID="lblAuthorization" Text="Неверный логин или пароль" Visible="false" CssClass="Error"></asp:Label>
            <div class="form-group">
                <label for="formGroupExampleInput" class="lblTitle" style="float: left">Логин</label>
                <asp:TextBox ID="tbLogin" runat="server" type="text" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Введите логин"
                    Display="Dynamic" ControlToValidate="tbLogin" CssClass="Error"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="formGroupExampleInput2" class="lblTitle" style="float: left">Пароль</label>
                <asp:TextBox ID="tbPassword" runat="server" type="text" class="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Введите пароль"
                    Display="Dynamic" ControlToValidate="tbPassword" CssClass="Error"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button runat="server" ID="btEnter" Text="ВОЙТИ" CssClass="button" OnClick="btEnter_Click" />
                </div>
            </div>
            <a href="Registration.aspx">Регистрация</a>
        </div>
    </form>
</body>
</html>
