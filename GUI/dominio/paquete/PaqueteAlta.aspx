<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaqueteAlta.aspx.cs" Inherits="GUI.dominio.paquete.PaqueteAlta" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administracion de Paquetes</h3>
    <div class="form-group">
        <label for="txtTitulo">Titulo</label>
        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtDescripcion">Descripcion</label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtPrecio">Precio</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="lstDestinoOrigen">Destinos</label>
        <asp:ListBox runat="server" ID="lstDestinos" SelectionMode="Multiple"></asp:ListBox>
    </div>
    <div class="form-group">
        <label for="lstTags">Tags</label>
        <asp:ListBox runat="server" ID="lstTags" SelectionMode="Multiple" ></asp:ListBox>
    </div>

    <div class="form-group">
        <label for="lstHoteles">Hoteles</label>
        <asp:ListBox runat="server" ID="lstHoteles" SelectionMode="Multiple" ></asp:ListBox>
    </div>

    <div class="form-group">
        <label for="lstVuelos">Vuelos</label>
        <asp:ListBox runat="server" ID="lstVuelos" SelectionMode="Multiple" ></asp:ListBox>
    </div>

    <div class="form-group">
        <h5>Fotos</h5>
        <label for="files">Files</label>
        <asp:FileUpload runat="server" ID="files" AllowMultiple="true"></asp:FileUpload>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnRegistrar" runat="server" Text="Registar Paquete" OnClick="btnRegistrar_Click"  CssClass="btn btn-primary" />
    </div>
</asp:Content>
