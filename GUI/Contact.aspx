<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="GUI.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </address>

    <asp:Table ID="Table1" runat="server" class="table table-striped">
        <asp:TableHeaderRow runat="server" Font-Bold="true">
                <asp:TableHeaderCell>Id</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                <asp:TableHeaderCell>Descripcion</asp:TableHeaderCell>
            </asp:TableHeaderRow>
    </asp:Table>

    



    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
