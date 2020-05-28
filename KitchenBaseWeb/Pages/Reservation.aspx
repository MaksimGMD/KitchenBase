<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="KitchenBaseWeb.Pages.Reservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../Content/css/Styles.css" />
    <title>Бронирование стола</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg justify-content-end">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="Reservation.aspx">Бронирование столов</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Account.aspx">Личный кабинет</a>
                </li>
            </ul>
        </nav>
        <div class="container-fluid">
            <h1 class="title">Бронирование стола</h1>
            <div class="form-row">
                <div class="form-group col-lg-4">
                    <label for="inputEmail4" class="lblTitle-Reg">Время бронирования</label>
                    <asp:DropDownList class="form-control" ID="ddlTime" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Дата бронирования</label>
                    <asp:TextBox class="form-control" ID="tbDate" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4" style="padding-left: 20px">
                    <div class="row">
                        <label for="inputPassword4" class="lblTitle-Reg">Количество гостей</label>
                    </div>
                    <div class="row">
                        <asp:TextBox class="form-control" ID="tbQuantity" runat="server" Style="width: 70px;"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Номер стола</label>
                    <asp:DropDownList class="form-control" ID="ddlNumber" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Комментарий</label>
                    <asp:TextBox class="form-control" ID="tbComment" runat="server" Style="height: 140px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <asp:Button ID="btInsert" runat="server" Text="Добавить" CssClass="button-Reserv" />
                    <asp:Button ID="btUpdate" runat="server" Text="Изменить" CssClass="button-Reserv" />
                    <asp:Button ID="btDelete" runat="server" Text="Удалить" CssClass="button-Reserv" />
                </div>
            </div>
            <div class="table" style="overflow-x: auto; width: 100%">
                <asp:GridView ID="gvReservation" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
