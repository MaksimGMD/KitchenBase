<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="KitchenBaseWeb.Pages.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../Content/css/Styles.css" />
    <title>Регистрация</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="reg-form">
            <h1 class="title">Регистрация</h1>
            <div class="form-row">
                <div class="form-group col-lg-6">
                    <label for="inputEmail4" class="lblTitle-Reg">Фамилия</label>
                    <asp:TextBox class="form-control" ID="tbSurname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Введите фамилию" ControlToValidate="tbSurname"
                        CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-6">
                    <label for="inputPassword4" class="lblTitle-Reg">Логин</label>
                    <asp:TextBox class="form-control" ID="tbLogin" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Введите логин" ControlToValidate="tbLogin"
                        CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label runat="server" ID="lblLoginCheck" CssClass="Error" Text="Логин уже занят" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-6">
                    <label for="inputEmail4" class="lblTitle-Reg">Имя</label>
                    <asp:TextBox class="form-control" ID="tbName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Введите имя" ControlToValidate="tbName"
                        CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-6">
                    <label for="inputPassword4" class="lblTitle-Reg">Пароль</label>
                    <asp:TextBox class="form-control" ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Введите пароль" ControlToValidate="tbPassword"
                        CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="Error"
                ErrorMessage="Длина пароля должна быть больше 6 символов, содеражть минимум одну ланитскую букву, одну цифру и один из символов !@#$%^&*_" ControlToValidate="tbPassword" Display="Dynamic"
                ValidationExpression="(?=.*[0-9])(?=.*[!@#$%^&*_])((?=.*[a-z])|(?=.*[A-Z]))[0-9a-zA-Z!@#$%^&*_]{6,}"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-6">
                    <label for="inputEmail4" class="lblTitle-Reg">Отчество</label>
                    <asp:TextBox class="form-control" ID="tbMiddleName" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-lg-6">
                    <label for="inputPassword4" class="lblTitle-Reg">Подтверждение пароля</label>
                    <asp:TextBox class="form-control" ID="tbPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblPasswordConfirm" runat="server" CssClass="Error" Visible="false" Text="Пароли не совпадают" Display="Dynamic"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <label for="inputPassword4" class="lblTitle-Reg">Электронная почта</label>
                    <asp:TextBox class="form-control" ID="tbEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Введите почту" ControlToValidate="tbEmail"
                        CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Почта введена неверно" 
                        ControlToValidate="tbEmail" CssClass="Error" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <label for="inputPassword4" class="lblTitle-Reg">Номер телефона</label>
                    <asp:TextBox class="form-control" ID="tbPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Введите номер телефона" ControlToValidate="tbPhone"
                        CssClass="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button runat="server" ID="btEnter" Text="ЗАРЕГИСТРИРОВАТЬСЯ" CssClass="button" OnClick="btEnter_Click" />
                </div>
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
