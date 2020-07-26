<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Test.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Style/Styles.css"/>
    <link rel="stylesheet" href="Style/TableRes.css"/>
    <title>C Sharp SUSU - Таблица результатов</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="headline">
            <div class="headtext">sharp@SUSU</div>
        </div>

        <div style="margin-top:96px"/>
        <div class="text-main">РЕЗУЛЬТАТЫ</div>
        <div style="margin-top:32px"/>
        <asp:Table ID="Table1" runat="server" CssClass="table1">
            <asp:TableRow ID="Head" runat="server" CssClass="tablehead">
                    <asp:TableCell runat="server">№</asp:TableCell>
                    <asp:TableCell runat="server">Студент</asp:TableCell>
                    <asp:TableCell runat="server">Группа</asp:TableCell>
                    <asp:TableCell runat="server">Баллы</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <div style="margin-top:32px"/>
        <p class="centried">
            <asp:HyperLink runat="server" ID="Link1" href="Default.aspx" CssClass="text-link2">На главную</asp:HyperLink>
        </p>
    </form>
</body>
</html>