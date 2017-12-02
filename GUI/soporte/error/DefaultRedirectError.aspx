<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultRedirectError.aspx.cs" Inherits="GUI.DefaultRedirectError" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Error en el sistema.</h2>
    <h3>La applicacion ha encontrado un error inesperado.</h3>
    <p>Si el error persiste, por favor contactese con el equipo de Soporte.</p>
    <p><%=Message %></p>
    <div class="form-group">
        <asp:Button runat="server" id="btnHome" OnClick="btnHome_Click" CssClass="btn btn-primary" Text="Redirigir al Inicio"/>
    </div>
</asp:Content>
