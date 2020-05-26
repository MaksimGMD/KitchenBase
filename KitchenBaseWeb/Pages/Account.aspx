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
                    <a class="nav-link" href="Account.aspx">Личный кабинет</a>
                </li>
            </ul>
        </nav>
        <div>
        </div>
    </form>
</body>
</html>
