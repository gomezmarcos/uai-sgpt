<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackupAbm.aspx.cs" Inherits="GUI.soporte.backup.BackupAbm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administracion de Backups y Restores</h3>

    <div class="form-group">
        <label for="ddlDatabases">Elija la Base de Datos a resguardar:</label>
        <asp:DropDownList ID="ddlDatabases" runat="server" CssClass="form-control"/>
    </div>
    <div class="form-group">
        <asp:Button ID="btnBackup" CssClass="btn btn-primary " OnClick="btnBackup_Click" runat="server" Text="Backup" />
    </div>

    <div class="form-group">
        <label for="lstBackupfiles">Elija la base a restaurar:</label>
        <asp:ListBox ID="lstBackupfiles" CssClass="form-control" runat="server" ></asp:ListBox>
    </div>
    <div class="form-group">
        <asp:Button OnClick="btnRestore_Click" ID="btnRestore" CssClass="btn btn-primary " runat="server" Text="Restore" />
    </div>
</asp:Content>

