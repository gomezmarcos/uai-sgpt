<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VueloEditar.aspx.cs" Inherits="GUI.dominio.vuelo.VueloEditar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Edicion de Vuelo</h3>
    <div class="form-group">
        <label for="txtUid">UID</label>
        <asp:TextBox ID="txtUid" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtEmpresa">Empresa</label>
        <asp:TextBox ID="txtEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="lstDestinoOrigen">Origen</label>
        <asp:DropDownList runat="server" ID="lstDestinoOrigen"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="lstDestinoDestinoo">Destino</label>
        <asp:DropDownList runat="server" ID="lstDestinoDestino" ></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtPrecio">Precio</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click"  runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnEditar" OnClick="btnEditar_Click"  runat="server" Text="Editar Vuelo"  CssClass="btn btn-primary" />
        <asp:Button ID="btnBorrar" OnClick="btnBorrar_Click" runat="server" Text="Borrar Vuelo" CssClass="btn btn-danger" />
    </div>
</asp:Content>
