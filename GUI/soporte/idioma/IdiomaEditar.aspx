<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="IdiomaEditar.aspx.cs" Inherits="GUI.idioma.IdiomaEditar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Editar de Idioma</h3>

    <div class="form-group">
        <label for="txtCodigo">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtDescripcion">Cultura</label>
        <asp:TextBox ID="txtCultura" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Editar Idioma" CssClass="btn btn-primary" />
        <asp:Button ID="btnBorrar" OnClick="btnBorrar_Click" runat="server" Text="Borrar Idioma" CssClass="btn btn-danger" />
    </div>

</asp:Content>
