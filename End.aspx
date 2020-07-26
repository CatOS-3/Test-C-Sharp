<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="End.aspx.cs" Inherits="Test.End" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Style/Styles.css"/>
    <title>C Sharp SUSU - Результаты</title>
</head>
<body>
    <form id="form2" runat="server">
        <div class="headline">
            <div class="headtext">sharp@SUSU</div>
        </div>

        <div style="margin-top:128px"></div>

        <p class="centried">
            <asp:Image runat="server" ImageUrl="~/Res/logo.png" Height="104px" Width="172px" />
        </p>

        <p class="centried">
            <asp:Label runat="server" ID="Label1" CssClass="text-main"/>
        </p>
        <p class="centried">
            <asp:Label runat="server" ID="Label2" CssClass="text-main"/>
        </p>

        <div style="margin-top:32px"></div>
        <p class="centried">
            <asp:HyperLink runat="server" ID="Link1" href="Result.aspx" CssClass="text-link2">Таблица результатов</asp:HyperLink>
        </p>
    </form>
</body>
</html>


