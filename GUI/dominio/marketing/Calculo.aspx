<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculo.aspx.cs" Inherits="GUI.dominio.marketing.Calculo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Actualizando formula de Ranking de hoteles</h3>
    <p>Formula utilizada para calcular los mejores hoteles</p>

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
        <asp:Button ID="btnCancelar"   runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnRegistrar"  runat="server" Text="Aplicar formula" OnClick="btnRegistrar_Click"  CssClass="btn btn-danger" />
    </div>
</asp:Content>

