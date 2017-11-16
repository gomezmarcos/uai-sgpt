<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioSistemaAbm.aspx.cs" Inherits="GUI.soporte.usuarios.UsuarioSistemaAbm" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Abm de Usuarios de Sistema</h3>

    <div class="form-group">
        <asp:Button ID="btnNuevoUsuario" runat="server" Text="Crear nuevo Usuario de sistema" OnClick="btnNuevoUsuario_Click" CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:Table ID="tbl" runat="server" class="table table-striped"/>
    </div>
</asp:Content>
