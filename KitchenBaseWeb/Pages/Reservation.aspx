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
        <asp:SqlDataSource ID="sdsReserv" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsTime" runat="server"></asp:SqlDataSource>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Выберите дату бронирования" CssClass="Error" ControlToValidate="tbDate" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-4" style="padding-left: 20px">
                    <div class="row">
                        <label for="inputPassword4" class="lblTitle-Reg">Количество гостей</label>
                    </div>
                    <div class="row">
                        <asp:TextBox class="form-control" ID="tbQuantity" runat="server" Style="width: 70px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Введите количество гостей" CssClass="Error" ControlToValidate="tbQuantity" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Номер стола</label>
                    <asp:DropDownList class="form-control" ID="ddlNumber" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:Button ID="btInsert" runat="server" Text="Добавить" CssClass="button-Reserv" OnClick="btInsert_Click" />
                    <asp:Button ID="btUpdate" runat="server" Text="Изменить" CssClass="button-Reserv" OnClick="btUpdate_Click" />
                    <asp:Button ID="btDelete" runat="server" Text="Удалить" CssClass="button-Reserv" OnClick="btDelete_Click" CausesValidation="false" />
                </div>
            </div>
            <div class="table" style="overflow-x: auto; width: 100%">
                <asp:GridView ID="gvReservation" runat="server" AllowSorting="True" CurrentSortDirection="ASC" Font-Size="14px" AlternatingRowStyle-Wrap="false"
                     HeaderStyle-HorizontalAlign="Center" OnRowDataBound="gvReservation_RowDataBound" OnSorting="gvReservation_Sorting" OnSelectedIndexChanged="gvReservation_SelectedIndexChanged" DataSourceID="sdsReserv">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" SelectText="Выбрать" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
