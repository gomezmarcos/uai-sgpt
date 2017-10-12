<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br />
            <asp:ListBox ID="lts" runat="server" /><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
        </div>
    </form>
</body>
</html>
