<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>SGPT</h1>
        <p class="lead">Sistema de Gestion de Paquetes Turisticos</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Aprenda mas &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Te gusta la playa?</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <ul>
                <li>Miami - $20.000</li>
                <li>Caribe - $40.000</li>
                <li>Mexico - $20.000</li>
            </ul>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Buscar mas destinos con playa &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Los mejores destinos de invierno!</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <ul>
                <li>Nueva Zelanda - $20.000</li>
                <li>Bariloche - $40.000</li>
                <li>Alemania - $20.000</li>
            </ul>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Buscar mas destinos de invierno &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Escapadas romanticas</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <ul>
                <li>Colonia del Sacramento - $20.000</li>
                <li>Cartagena de Indias - $40.000</li>
                <li>Buzios - $20.000</li>
            </ul>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Buscar mas destinos romanticos &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
