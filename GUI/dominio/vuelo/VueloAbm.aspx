<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VueloAbm.aspx.cs" Inherits="GUI.dominio.vuelo.VueloAbm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administar Vuelos</h3>

    <div class="form-group">
        <asp:Button ID="btnNuevoVuelo" runat="server" Text="Crear nuevo Vuelo" OnClick="btnNuevoVuelo_Click" CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:Table ID="tbl" runat="server" class="table table-striped"/>
    </div>

</asp:Content>
