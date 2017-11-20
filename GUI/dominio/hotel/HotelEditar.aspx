<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelEditar.aspx.cs" Inherits="GUI.dominio.hotel.HotelEditar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administracion de Hoteles</h3>
    <div class="form-group">
        <label for="txtAlias">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtDescripcion">Descripcion</label>
        <asp:TextBox ID="txtDescripcion" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtDireccion">Direccion</label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtLat">Latitud</label>
        <asp:TextBox ID="txtLat" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtLong">Longitud</label>
        <asp:TextBox ID="txtLong" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtHabitaciones">Habitaciones</label>
        <asp:TextBox ID="txtHabitaciones" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtPrecio">Precio por Noche</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
    </div>


    <div class="form-group">
        <label for="chktags">Tags</label>
        <asp:CheckBoxList ID="chkTags" runat="server" />
    </div>

    <div class="form-group">
        <label for="lstDestinos">Destinos</label>
        <asp:ListBox runat="server" ID="lstDestinos" SelectionMode="Multiple"></asp:ListBox>
    </div>


    <div class="form-group">
        <h5>Administracion de Hoteles</h5>
        <asp:Table ID="tblFotos" runat="server" CssClass="table table-striped" ></asp:Table>
        <label for="files">Files</label>
        <asp:FileUpload runat="server" ID="files" AllowMultiple="true"></asp:FileUpload>
        <asp:Image runat="server" ID="imagenPrincipal" />
    </div>
    `
    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnEditar" OnClick="btnEditar_Click" runat="server" Text="Editar Hotel"  CssClass="btn btn-primary" />
        <asp:Button ID="btnBorrar" OnClick="btnBorrar_Click" runat="server" Text="Borrar Hotel" CssClass="btn btn-danger" />
    </div>
</asp:Content>