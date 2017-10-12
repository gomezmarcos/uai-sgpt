<%@ Page Title="Bitacora" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="GUI.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <h2><%: Title %>.</h2>
    <h3>Evento registrados</h3>

    <div class="form-group">
        <label for="sel1">Elija un filtro list:</label>
        <asp:DropDownList id="filtro" runat="server" CssClass ="form-control"></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="valorFiltro">Valor:</label>
        <asp:TextBox runat="server" ID="valorFiltro"  CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Button ID="btnBuscar" UseSubmitBehavior="false" OnClick="Buscar" Text="Buscar" class="btn btn-primary " runat="server" />
    </div>

    <asp:Table ID="tablaEventos" runat="server" class="table table-striped"/>
</asp:Content>
