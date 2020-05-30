<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="KitchenBaseWeb.Pages.Service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../Content/css/Styles.css" />
    <title>Обслуживание клиентов</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="sdsNameBluda" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsService" runat="server"></asp:SqlDataSource>
        <div class="container-fluid">
            <center>
                <h1 class="title">Обслуживание клиентов</h1>
            </center>
            <div class="form-row">
                <div class="form-group col-lg-4">
                    <label for="inputEmail4" class="lblTitle-Reg">Наименование блюда</label>
                    <asp:DropDownList class="form-control" ID="ddlNameBluda" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Цена</label>
                    <asp:TextBox CssClass="form-control" ID="tbPrice" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Сумма</label>
                    <asp:TextBox CssClass="form-control" ID="tbSum" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-4">
                    <label for="inputEmail4" class="lblTitle-Reg">Время приготовления</label>
                    <asp:TextBox CssClass="form-control" ID="tbTimeCoocking" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Фамилия официанта</label>
                    <asp:TextBox CssClass="form-control" ID="tbSurname" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Время заказа</label>
                    <asp:TextBox CssClass="form-control" ID="tbTime" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-4">
                    <label for="inputEmail4" class="lblTitle-Reg">Количество блюд</label>
                    <asp:TextBox class="form-control" ID="tbQuantity" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Введите количество блюд" CssClass="Error" ControlToValidate="tbQuantity" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Номер бронирования</label>
                    <asp:TextBox class="form-control" ID="tbNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Введите номер бронирования" CssClass="Error" ControlToValidate="tbNumber" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Номер заказа</label>
                    <asp:TextBox CssClass="form-control" ID="tbOrderNumber" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Комментарий</label>
                    <asp:TextBox class="form-control" ID="tbComment" runat="server" Style="height: 120px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Button ID="btInsert" runat="server" Text="Добавить" CssClass="button-Reserv" />
                    <asp:Button ID="btUpdate" runat="server" Text="Изменить" CssClass="button-Reserv" />
                    <asp:Button ID="btDelete" runat="server" Text="Удалить" CssClass="button-Reserv" />
                </div>
                <div class="col-lg-8" style="display: inherit">
                    <asp:TextBox ID="tbSearch" runat="server" PlaceHolder="Поиск" CssClass="Search"></asp:TextBox>
                    <asp:Button ID="btSearch" runat="server" Text="Поиск" Style="margin-left: -6px; width: 100px; font-size: 18px; height: 40px" CssClass="button-Reserv" />
                    <asp:Button ID="btFilter" runat="server" Text="Фильтр" CssClass="button-Reserv" Style="width: 100px; font-size: 18px; height: 40px" />
                    <asp:Button ID="btCansel" runat="server" Text="Отмена" CssClass="button-Reserv" Style="width: 100px; font-size: 18px; height: 40px" />
                </div>
            </div>
            <div class="row">
                <asp:Button ID="btCheckout" runat="server" Text="Оформить заказ" CssClass="button-Reserv"
                    Style="font-size: 18px; white-space: normal; word-wrap: break-word; width: 130px; margin-left: 15px;" />
                <asp:Button ID="btConfirm" runat="server" Text="Подтверждение оплаты" CssClass="button-Reserv"
                    Style="font-size: 18px; white-space: normal; word-wrap: break-word; width: 160px;" />
            </div>
            <div style="overflow-x: auto; width: 100%">
                <asp:GridView ID="gvService" runat="server" AllowSorting="true" UseAccessibleHeader="true" CurrentSortDirection="ASC" Font-Size="14px"
                    AlternatingRowStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" OnSorting="gvService_Sorting" OnRowDataBound="gvService_RowDataBound" OnSelectedIndexChanged="gvService_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div>
            <asp:GridView runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
