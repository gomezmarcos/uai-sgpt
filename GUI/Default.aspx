﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div style="width:100%;
  height:100%;
  min-height:300px;
  height:calc(100% - 1px);
  background-image:url('/fotos/sistema/sgpt-buscar.jpg');
  background-size:cover; color:white; padding:30px; margin-bottom:20px"> 
        <h1 style="margin-top:200px">Encontra los mejores Paquetes Turisticos</h1>
        <p class="lead">Sistema de Gestion de Paquetes Turisticos</p>
        <p><asp:Button runat="server" ID="VerPaquetes" Text="Ver Paquetes >>" CssClass="btn btn-primary" OnClick="VerPaquetes_Click" /></p>
  </div>     

    <div class="row">
        <div class="col-md-4">
            <h2>Te gusta la playa?</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <ul>
                <% foreach (var h in hoteles)
                    {
                        %>

                <li><b><%=h.Nombre %></b> - $<%=h.Precio %> - <%=h.Puntos %> Puntos</li>

                <%} %>
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
                <% foreach (var h in tag1)
                    {
                        %>

                <li><b><%=h.Nombre %></b> - $<%=h.Precio %> - <%=h.Puntos %> Puntos</li>

                <%} %>
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
                <% foreach (var h in tag2)
                    {
                        %>

                <li><b><%=h.Nombre %></b> - $<%=h.Precio %> - <%=h.Puntos %> Puntos</li>

                <%} %>
            </ul>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Buscar mas destinos romanticos &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
