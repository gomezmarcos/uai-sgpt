<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelAbm.aspx.cs" Inherits="GUI.dominio.hotel.HotelAbm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Administar Hoteles</h3>

    <div class="form-group">
        <asp:Button ID="btnNuevoHotel" runat="server" Text="Crear nuevo Hotel" OnClick="btnNuevoHotel_Click" CssClass="btn btn-primary" />
    </div>

    <div class="form-group">
        <asp:Table ID="tbl" runat="server" class="table table-striped"/>
    </div>

</asp:Content>
