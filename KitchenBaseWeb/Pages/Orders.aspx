<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="KitchenBaseWeb.Pages.Orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-grid.min.css" />
    <link rel="stylesheet" href="../Content/css/Styles.css" />
    <title>Заказы</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <center>
                <h1 class="title">Активные заказы</h1>
            </center>
            <div class="List">
                <%--<asp:Repeater ID="rpOrdersList" runat="server">
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:Repeater>--%>
                <div class="Order-block">
                    <div class="Order-block-data">
                        <label class="Order-Text">Номер заказа - 20</label>
                        <br />
                        <label class="Order-Text">Время заказа - 17:20</label>
                    </div>
                    <div class="Order-block-button">
                        <asp:Button ID="btDetails" runat="server" Text="Подробнее" CssClass="btDetails"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
