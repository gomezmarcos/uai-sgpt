<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaqueteAbm.aspx.cs" MasterPageFile="~/Site.Master" Inherits="GUI.dominio.paquete.PaqueteAbm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administar Paquete</h3>

    <div class="form-group">
        <asp:Button ID="btnNuevoPaquete" runat="server" Text="Crear nuevo Paquete" OnClick="btnNuevoPaquete_Click" CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:Table ID="tbl" runat="server" class="table table-striped"/>
    </div>

</asp:Content>
