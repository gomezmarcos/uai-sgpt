<%@ Page Title="Patentes Alta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatenteAlta.aspx.cs" Inherits="GUI.patentes.PatentesAlta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Alta de Patentes</h3>

    <div class="form-group">
        <label for="txtCodigo">Codigo</label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtDescripcion">Descripcion</label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" ></asp:TreeView>
    </div>

    <div class="form-group">
        <asp:Button ID="btnAceptar" runat="server" Text="Crear Patente" CssClass="btn btn-primary" OnClick="btnAceptar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
