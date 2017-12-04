<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Integridad.aspx.cs" Inherits="GUI.soporte.integridad.Integridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Verificar integridad del sistema</h2>

    <div class="form-group">
        <asp:Button ID="verificar" CssClass="btn btn-primary" OnClick="verificar_Click" runat="server" Text="Verificar Integridad" />
    </div>

    <div class="form-group" >
        <p><%=Mensaje %></p>
    </div>
    <div class="form-group">
        <asp:Button ID="volver" OnClick="volver_Click" CssClass="btn btn-primary " runat="server" Text="Salir" />
    </div>
</asp:Content>

