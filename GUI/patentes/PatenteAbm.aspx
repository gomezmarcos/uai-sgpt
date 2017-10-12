<%@ Page Title="Patentes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatenteAbm.aspx.cs" Inherits="GUI.PatenteAbm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Abm de Familias</h3>

    <div class="form-group">
        <asp:Button ID="Button1" runat="server" Text="Crear nueva Patente" OnClick="Button1_Click" CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:Table ID="tbl" runat="server" class="table table-striped"/>
    </div>

    <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" ></asp:TreeView>
</asp:Content>
