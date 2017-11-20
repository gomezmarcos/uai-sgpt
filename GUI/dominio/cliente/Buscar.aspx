<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="GUI.dominio.Cliente" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Encontra los mejores Paquetes Turisticos</h1>
        <p class="lead">Sistema de Gestion de Paquetes Turisticos</p>
    </div>

    <div class="row">
        <div class="col-md-11">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control input-block" Text="Buscar..." />
        </div>
        <div class="col-md-1">
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn form-control btn-success" Text="Buscar" />
        </div>
    </div>

    <div class="row">

        <div class="col-md-9">
            <h2>Miami Toda la Noche</h2>
            <div class="row">
                <div class="col-md-2">

                </div>
                <div class="col-md-6">
                    <div class="badge">7.3</div><h5>Hotel Merriot</h5>
                    <ul>
                        <li>3 Estrellas</li>
                        <li>O'Higgins 2356 - Lanus - Bs As - Argentina</li>
                    </ul>

                </div>
                <div class="col-md-4">
                    <h5>Vuelos</h5>
                    <ul>
                        <li>Buenos Aires - Miami</li>
                        <li>Miami - Buenos Aires</li>
                    </ul>
                </div>
            </div>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Buscar mas destinos con playa &raquo;</a>
            </p>
        </div>
        <div class="col-md-3">
            <h1>$300</h1>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Ver detalles" />
        </div>
    </div>

</asp:Content>
