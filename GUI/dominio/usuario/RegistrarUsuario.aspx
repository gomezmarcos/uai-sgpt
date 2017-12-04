<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" MasterPageFile="~/Site.Master" Inherits="GUI.dominio.usuario.RegistrarUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Crear cuenta</h3>
    <div class="form-group">
        <label for="txtAlias">Alias</label>
        <asp:TextBox ID="txtAlias" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtPassword">Password</label>
        <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtEmail">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click"  runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnNuevo"  runat="server" OnClick="btnNuevo_Click" Text="Crear nuevo Usuario de Sistema"  CssClass="btn btn-primary" />
    </div>
</asp:Content>
