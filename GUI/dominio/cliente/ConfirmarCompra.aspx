<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarCompra.aspx.cs" Inherits="GUI.dominio.cliente.ConfirmarCompra" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Confirmar compra</h3>
    <p>Esta confirmando la compra de <b><%=p.Titulo %></b></p>

    <div class="form-group">
        <label for="txtNombre">Nombre como en la tarjeta de credito</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator id="ValidatorNombre" runat="server"
        ControlToValidate="txtNombre"
        ErrorMessage="El nombre es un dato obligatorio."
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <div class="form-group">
        <label for="txtVencimiento">Fecha de vencimiento</label>
        <asp:TextBox ID="txtVencimiento" TextMode="Date" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator id="ValidatorVencimiento" runat="server"
        ControlToValidate="txtVencimiento"
        ErrorMessage="La fecha de vencimiento es obligatoria."
        ForeColor="Red">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat=server 
            ControlToValidate="txtVencimiento" 
            ErrorMessage="El formato de fecha debe ser dd/mm/yyyy" 
            ForeColor="Red"
            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" />
    

    <div class="form-group">
        <label for="txtTarjeta">Numero de tarjeta</label>
        <asp:TextBox ID="txtTarjeta" Rows="3" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator id="ValidatorTarjeta" runat="server"
        ControlToValidate="txtTarjeta"
        ErrorMessage="El numero de tarjeta de credito es obligatoria."
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <div class="form-group">
        <label for="txtCodigoTarjeta">Codigo de Seguridad</label>
        <asp:TextBox ID="txtCodigoTarjeta" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator id="ValidatorCodigo" runat="server"
        ControlToValidate="txtCodigoTarjeta"
        ErrorMessage="El codigo de tarjeta de credito es obligatoria."
        ForeColor="Red">
    </asp:RequiredFieldValidator>

    <div class="form-group">
        <a href="/dominio/cliente/Buscar" class="btn btn-primary">Cancelar</a>
        <asp:Button ID="btnConfirmar" OnClick="btnConfirmar_Click" runat="server" Text="Confirmar compra"  CssClass="btn btn-danger" />
    </div>
</asp:Content>

