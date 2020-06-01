<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="KitchenBaseWeb.Pages.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../Content/css/Styles.css" />
    <title>Личный кабинет</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg justify-content-end">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="Reservation.aspx">Бронирование столов</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="AccountDisabled.aspx">Личный кабинет</a>
                </li>
            </ul>
        </nav>
        <div class="AccountPage mt-4">
            <div class="container">
                <div class="row">
                    <div class="col-lg-4"><strong class="AccTitle">Имя</strong></div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="tbName" runat="server" CssClass="AccountDisabled" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Введите имя" CssClass="Error" ControlToValidate="tbName" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4"><strong class="AccTitle">Фамилия</strong></div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="tbSurname" runat="server" CssClass="AccountDisabled" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Введите фамилию" CssClass="Error" ControlToValidate="tbSurname" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4"><strong class="AccTitle">Отчество</strong></div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="tbMiddleName" runat="server" CssClass="AccountDisabled " Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4"><strong class="AccTitle">Электронная почта</strong></div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="tbEmail" runat="server" CssClass="AccountDisabled" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Введите почту" CssClass="Error" ControlToValidate="tbEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Введите почту корректно" CssClass="Error" ControlToValidate="tbEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4"><strong class="AccTitle">Номер телефона</strong></div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="tbPhone" runat="server" CssClass="AccountDisabled " Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Введите номер телефона" CssClass="Error" ControlToValidate="tbPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4"><strong class="AccTitle">Логин</strong></div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="tbLogin" runat="server" CssClass="AccountDisabled " Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Введите логин" CssClass="Error" ControlToValidate="tbLogin" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4"><strong class="AccTitle">Пароль</strong></div>
                    <div class="col-lg-6">
                        <asp:TextBox ID="tbPassword" runat="server" CssClass="AccountDisabled " Enabled="false" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Введите пароль" CssClass="Error" ControlToValidate="tbSurname" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="Error"
                            ErrorMessage="Длина пароля должна быть больше 6 символов, содеражть минимум одну ланитскую букву, одну цифру и один из символов !@#$%^&*_" ControlToValidate="tbPassword" Display="Dynamic"
                            ValidationExpression="(?=.*[0-9])(?=.*[!@#$%^&*_])((?=.*[a-z])|(?=.*[A-Z]))[0-9a-zA-Z!@#$%^&*_]{6,}"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <asp:Button ID="btEdit" runat="server" Text="Редактировать" CssClass="button" ToolTip="Редактировать личные данные" CausesValidation="False" OnClick="btEdit_Click" />
                <asp:Button ID="btSave" runat="server" Text="Сохранить" CssClass="button" ToolTip="Сохранить изменения" Visible="false" OnClick="btSave_Click" />
                <asp:Button ID="btCansel" runat="server" Text="Отмена" Visible="false" CssClass="button" ToolTip="Отменить редактирование" CausesValidation="False" OnClick="btCansel_Click" />
                <asp:Button ID="Button1" runat="server" Text="Выйти" CssClass="button" OnClick="Button1_Click" CausesValidation="false"/>
            </div>
        </div>
    </form>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.maskedinput.min.js"></script>
    <%--Маска для ввода номера телефона--%>
    <script>
        $(document).ready(function () {
            $("#tbPhone").mask("+79999999999");
        });
    </script>
</body>
</html>
