<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="IdiomaAbm.aspx.cs" Inherits="GUI.idioma.IdiomaAbm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administracion de Idioma</h3>
    <asp:Label ID="idiomaAbmTest" Text="sin traduccion" runat="server" />

    <div class="form-group">
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtCultura" runat="server"></asp:TextBox>
        <asp:Button ID="btnNuevo" OnClick="btnNuevo_Click" runat="server" Text="Crear nuevo Idioma"  CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:Table ID="tbl" runat="server" class="table table-striped"/>
    </div>

</asp:Content>
