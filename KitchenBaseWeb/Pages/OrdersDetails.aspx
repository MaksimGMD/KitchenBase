<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersDetails.aspx.cs" Inherits="KitchenBaseWeb.Pages.OrdersDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../Content/css/Styles.css" />
    <title>Подробние о заказе</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="sdsOrders" runat="server"></asp:SqlDataSource>
        <div class="container">
            <center>
                <h1 class="title">Подробная информация о заказе</h1>
            </center>
            <div class="OrdersTitle">
                <asp:Label ID="lblNumber" runat="server" CssClass="Order-Text"></asp:Label>
                <asp:Label ID="lblTime" runat="server" CssClass="Order-Text"></asp:Label>
                <asp:Label ID="lblTableNumber" runat="server" CssClass="Order-Text"></asp:Label>
            </div>
            <div class="table">
                <asp:GridView ID="gvBludo" runat="server"></asp:GridView>
            </div>
            <div class="row" style="padding-left: 15px">
                <asp:Button ID="btBack" runat="server" Text="Назад" CssClass="button" OnClick="btBack_Click" style="margin-right: 40px"/>
                <asp:Button ID="btConfirm" runat="server" Text="Подтверждение заказа" CssClass="button" OnClick="btConfirm_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
