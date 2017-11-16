<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EntradaEditar.aspx.cs" Inherits="GUI.idioma.EntradaEditar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administracion de Entradas</h3>

    <div class="form-group">
        <asp:Table ID="tbl" runat="server" class="table table-striped"/>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Editar entradas" CssClass="btn btn-primary" />
    </div>

</asp:Content>
