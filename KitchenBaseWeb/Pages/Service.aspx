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
                    <asp:DropDownList class="form-control" ID="ddlNameBluda" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNameBluda_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Цена</label>
                    <asp:TextBox CssClass="form-control" ID="tbPrice" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A" ForeColor="#eeebf5"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Сумма</label>
                    <asp:TextBox CssClass="form-control" ID="tbSum" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A" ForeColor="#eeebf5"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-4">
                    <label for="inputEmail4" class="lblTitle-Reg">Время приготовления</label>
                    <asp:TextBox CssClass="form-control" ID="tbTimeCoocking" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A" ForeColor="#eeebf5"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Фамилия официанта</label>
                    <asp:TextBox CssClass="form-control" ID="tbSurname" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A" ForeColor="#eeebf5"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Время заказа</label>
                    <asp:TextBox CssClass="form-control" ID="tbTime" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A" ForeColor="#eeebf5"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-lg-4">
                    <label for="inputEmail4" class="lblTitle-Reg">Количество блюд</label>
                    <asp:TextBox class="form-control" ID="tbQuantity" runat="server" TextMode="Number" max="30" min="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Введите количество блюд" CssClass="Error" ControlToValidate="tbQuantity" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Номер бронирования</label>
                    <asp:TextBox class="form-control" ID="tbNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Введите номер бронирования" CssClass="Error" ControlToValidate="tbNumber" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-4">
                    <label for="inputPassword4" class="lblTitle-Reg">Номер заказа</label>
                    <asp:TextBox CssClass="form-control" ID="tbOrderNumber" runat="server" Enabled="false" BackColor="#545A8A" BorderColor="#545A8A" ForeColor="#eeebf5"></asp:TextBox>
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
                    <asp:Button ID="btInsert" runat="server" Text="Добавить" CssClass="button-Reserv" OnClick="btInsert_Click" />
                    <asp:Button ID="btUpdate" runat="server" Text="Изменить" CssClass="button-Reserv" OnClick="btUpdate_Click" />
                    <asp:Button ID="btDelete" runat="server" Text="Удалить" CssClass="button-Reserv" OnClick="btDelete_Click" />
                </div>
                <div class="col-lg-8" style="display: inherit">
                    <asp:TextBox ID="tbSearch" runat="server" PlaceHolder="Поиск" CssClass="Search"></asp:TextBox>
                    <asp:Button ID="btSearch" runat="server" Text="Поиск" Style="margin-left: -6px; width: 100px; font-size: 18px; height: 40px"
                        CssClass="button-Reserv" OnClick="btSearch_Click" CausesValidation="false" />
                    <asp:Button ID="btFilter" runat="server" Text="Фильтр" CssClass="button-Reserv" Style="width: 100px; font-size: 18px; height: 40px"
                        OnClick="btFilter_Click" CausesValidation="false" />
                    <asp:Button ID="btCanсel" runat="server" Text="Отмена" CssClass="button-Reserv" Style="width: 100px; font-size: 18px; height: 40px"
                        OnClick="btCanсel_Click" Visible="false" CausesValidation="false" />
                </div>
            </div>
            <div class="row">
                <asp:Button ID="btCheckout" runat="server" Text="Оформить заказ" CssClass="button-Reserv"
                    Style="font-size: 18px; white-space: normal; word-wrap: break-word; width: 130px; margin-left: 15px;" OnClick="btCheckout_Click" Enabled="false"/>
                <asp:Button ID="btConfirm" runat="server" Text="Подтверждение оплаты" CssClass="button-Reserv"
                    Style="font-size: 18px; white-space: normal; word-wrap: break-word; width: 160px;" OnClick="btConfirm_Click" />
            </div>
            <div class="Table mt-3" style="overflow-x: auto; width: 90%">
                <asp:GridView ID="gvService" runat="server" CssClass="table table-condensed table-hover" AllowSorting="true" UseAccessibleHeader="true" CurrentSortDirection="ASC" Font-Size="14px"
                    AlternatingRowStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" OnSorting="gvService_Sorting" OnRowDataBound="gvService_RowDataBound" OnSelectedIndexChanged="gvService_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" SelectText="Выбрать" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
