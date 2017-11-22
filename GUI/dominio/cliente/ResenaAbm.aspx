<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResenaAbm.aspx.cs" Inherits="GUI.dominio.cliente.ResenaAbm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Registar reseña</h3>
    <p>Esta registrando una reseña</p>

    <div class="form-group">
        <label for="lstHotel">Hotel</label>
        <asp:DropDownList ID="lstHotel" runat="server" CssClass="form-control" ></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="lstUbicacion">Ubicacion</label>
        <asp:DropDownList ID="lstUbicacion" runat="server" CssClass="form-control" ></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="lstLimpieza">Limpieza</label>
        <asp:DropDownList ID="lstLimpieza" runat="server" CssClass="form-control" ></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="lstPrecio">Precio</label>
        <asp:DropDownList ID="lstPrecio" runat="server" CssClass="form-control" ></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="lstAtencion">Atencion</label>
        <asp:DropDownList ID="lstAtencion" runat="server" CssClass="form-control" ></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="Descripcion">Observacion</label>
        <asp:TextBox ID="Descripcion" runat="server" Rows="3" CssClass="form-control" ></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click"  runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnRegistrar"  runat="server" OnClick="btnRegistrar_Click" Text="Registrar Reseña"  CssClass="btn btn-danger" />
    </div>
</asp:Content>

