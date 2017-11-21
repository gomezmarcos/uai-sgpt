<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gracias.aspx.cs" Inherits="GUI.dominio.cliente.Gracias" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="jumbotron text-center" >
    <h1>GRACIAS POR SU COMPRA!</h1>
    <p>En breve le llegara un mail con mas detalles.</p>
    <asp:HyperLink NavigateUrl="~/dominio/cliente/Buscar.aspx" CssClass="btn btn-primary" runat="server">Volver</asp:HyperLink>
</div>
</asp:Content>

