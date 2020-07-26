<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Run.aspx.cs" Inherits="Test.Run" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Style/Styles.css"/>
    <link rel="stylesheet" href="Style/TableRun.css"/>
    <title>C Sharp SUSU - Прохождение теста</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="headline">
            <div class="headtext">sharp@SUSU</div>
        </div>
        
        <div style="margin-top:80px"/>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l1" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r1" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l2" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r2" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l3" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r3" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l4" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r4" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l5" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r5" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l6" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r6" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l7" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r7" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l8" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r8" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l9" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r9" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l10" CssClass="text-quest" />
            <asp:RadioButtonList runat="server" ID="r10" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l11" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r11" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l12" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r12" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l13" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r13" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l14" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r14" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l15" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r15" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l16" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r16" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l17" CssClass="text-quest" />
            <asp:RadioButtonList runat="server" ID="r17" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l18" CssClass="text-quest" />
            <asp:RadioButtonList runat="server" ID="r18" CssClass="radio-quest" />
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l19" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r19" CssClass="radio-quest"/>
        </div>
        <div class="frame-quest">
            <asp:Label runat="server" ID="l20" CssClass="text-quest"/>
            <asp:RadioButtonList runat="server" ID="r20" CssClass="radio-quest"/>
        </div>  
        
        <div class="centried"> 
            <asp:Button runat="server" ID="Button1" cssclass="button1end" OnClick="ButtonClickEnd" Text="Завершить" />
        </div>

    </form>
</body>
</html>