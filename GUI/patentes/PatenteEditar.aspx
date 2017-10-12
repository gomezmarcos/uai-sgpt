<%@ Page  Title="Patentes Alta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatenteEditar.aspx.cs" Inherits="GUI.patentes.PatentesEditar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Editar de Patente</h3>

    <div class="form-group">
        <label for="txtCodigo">Codigo</label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtDescripcion">Descripcion</label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:DropDownList ID="ramas" AutoPostBack="true" runat="server" CssClass="btn btn-primary dropdown-toggle" OnSelectedIndexChanged="patentes_SelectedIndexChanged"></asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:CheckBoxList ID="patentes" runat="server"></asp:CheckBoxList>
        <asp:Button ID="btnActualizar" OnClick="btnActualizar_Click" runat="server" Text="Actualizar" CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" ></asp:TreeView>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
        <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Editar Patente" CssClass="btn btn-primary" />
        <asp:Button ID="btnBorrar" OnClick="btnBorrar_Click" runat="server" Text="Borrar Patente" CssClass="btn btn-danger" />
    </div>

</asp:Content>
