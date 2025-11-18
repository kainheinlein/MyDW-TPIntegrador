<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error_Webmaster.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.Error_Webmaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtLog" runat="server"
             TextMode="MultiLine"
             CssClass="autoResize"
             Rows="1"
             Style="overflow:hidden;" Height="475px" Width="838px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="36px" OnClick="Button1_Click" Text="Recalcular Digito Verificador" Width="263px" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Height="36px" style="margin-top: 1px" Text="Restore" Width="262px" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Height="35px" OnClick="Button3_Click" Text="Volver" Width="263px" />
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
