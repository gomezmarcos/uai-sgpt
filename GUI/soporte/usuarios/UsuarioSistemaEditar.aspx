<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioSistemaEditar.aspx.cs" Inherits="GUI.soporte.usuarios.UsuarioSistemaEditar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administracion de Usuarios de Sistema</h3>
    <div class="form-group">
        <label for="txtAlias">Alias</label>
        <asp:TextBox ID="txtAlias" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtPassword">Password</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtEmail">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="lstRol">Rol</label>
        <asp:DropDownList ID="lstRol" runat="server" CssClass="form-control" OnSelectedIndexChanged="lstRol_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnEditar" OnClick="btnEditar_Click" runat="server" Text="Editar Usuario de Sistema"  CssClass="btn btn-primary" />
        <asp:Button ID="btnBorrar" OnClick="btnBorrar_Click" runat="server" Text="Borrar Usuario" CssClass="btn btn-danger" />
    </div>
</asp:Content>
