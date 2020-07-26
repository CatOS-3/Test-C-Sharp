<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Style/Styles.css"/>
    <title>C Sharp SUSU - Регистрация</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="headline">
            <div class="headtext">sharp@SUSU</div>
        </div>

        <div style="margin-top:128px"></div>

        <p class="centried">
            <asp:Image runat="server" ImageUrl="~/Res/logo.png" Height="104px" Width="172px" />
        </p>

        <div class="text-main">ПРОВЕРЬ СВОИ ЗНАНИЯ ЯЗЫКА C#</div>
        <div style="margin-top:32px"></div>

        <div class="rectangle">
            <div class="rectangle-title">
                <div class="text-login">Регистрация</div>
            </div>
            <div class="text-simple">Имя <asp:TextBox runat="server" ID="Text1" CssClass="text1box"/></div>
            <div class="text-simple">Фамилия<asp:TextBox runat="server" ID="Text2" CssClass="text2box" /></div>
            <div class="text-simple">Группа<asp:TextBox runat="server" ID="Text3" CssClass="text3box" /></div>
            <asp:Button runat="server" ID="Button1" cssclass="button1test" OnClick="Button1_Click" Text="Пройти тест" />
            <asp:HyperLink runat="server" ID="Link1" href="Result.aspx" CssClass="text-link">Результаты</asp:HyperLink>
        </div>

        <div style="margin-top:32px"></div>
        <p class="centried">
            <asp:Label runat="server" ID="Label1" Visible="False" CssClass="label1box">Поля заполнены не корректно</asp:Label>
        </p>
    </form>
</body>
</html>