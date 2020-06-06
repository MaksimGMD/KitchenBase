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
        <asp:SqlDataSource runat="server" ID="sdsOrders"></asp:SqlDataSource>
        <div class="container">
            <center>
                <h1 class="title">Активные заказы</h1>
            </center>
            <div class="List">
                <asp:Repeater ID="rpOrdersList" runat="server">
                    <ItemTemplate>
                        <div class="Order-block">
                            <div class="Order-block-data">
                                <asp:Label ID="lblNomer" runat="server" CssClass="Order-Text">Номер заказа - <%#Eval("NomerZakaza") %></asp:Label>
                                <br />
                                <label class="Order-Text">Время заказа - <%#Eval("VremyZakaza") %></label>
                            </div>
                            <div class="Order-block-button">
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("NomerZakaza") %>' Style="display: none" />
                                <asp:Button ID="btDetails" runat="server" Text="Подробнее" CssClass="btDetails" OnClick="btDetails_Click"/>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
