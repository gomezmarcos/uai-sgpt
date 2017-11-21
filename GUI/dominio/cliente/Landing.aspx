<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="GUI.dominio.cliente.Landing" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .image{
    position:relative;
    overflow:hidden;
    padding-bottom:100%;
}
.image img{
      position: absolute;
      max-width: 100%;
      max-height: 100%;
      top: 50%;
      left: 50%;
      transform: translateX(-50%) translateY(-50%);
}
    </style>
   <div style="width:100%;
  height:100%;
  min-height:300px;
  height:calc(100% - 1px);
  background-image:url('/fotos/sistema/sgpt-buscar.jpg');
  background-size:cover; color:white; padding:30px; margin-bottom:20px"> 
            <h1><%= p.Titulo %> - 

            <% foreach (var t in p.Tags)
                { %>
                   <small><span class="label label-success"><%=t.Codigo %></span> </small>
            <%} %>
            <% foreach (var d in p.Destinos)
                { %>
                   <small><span class="label label-warning"><%=d.Descripcion %></span> </small>
            <%} %>

            </h1>

            <h4><%= p.Descripcion %></h4>
  </div>     
 
    <div class="row well">
    <div class="row col-md-10 " >
        <div class="col-md-6">
        <h4>Hoteles</h4>
            <% foreach (var h in p.Hoteles)
                { %>
                
            <div style="height:300px;width:300px" class="col-md-6">
                <h4><%= h.Nombre %> <small><span class="badge">7.3</span></small></h4>
                <div class="image">
                <% if (h.fotos != null && h.fotos.Count > 0)
                    { %>
                        <img src="<%= h.fotos[0].path %>" alt="<%=h.fotos[0].nombre %>"  class="img-thumbnail">
                <% } else { %>
                        <img src="/fotos/sistema/sgpt-default-hotel.jpg" style="max-height:10px" class="img-thumbnail">
                <% } %>
            </div>
            </div>
                <div  class="col-md-6">
                    <br />3 <span class="glyphicon glyphicon-star"></span>
                    <br /><span class="glyphicon glyphicon-home"></span> <%= h.Direccion %>
                    <br /><span class="glyphicon glyphicon-user"></span> <%= h.Habitaciones %>
                    </div>
            <%} %>
        </div>

        <div class="col-md-6">
            <h4>Vuelos</h4>
            <% foreach (var v in p.Vuelos) { %>
            <div>
                <h4><span class="glyphicon glyphicon-plane"></span> <%=v.objOrigen.Descripcion %> -> <%=v.objDestino.Descripcion %> </h4>
                <%=v.Empresa %> 
                <br />Fecha de Salida: 24/12/2017 - 08.30AM
                <br />Fecha de Llegada: 24/12/2017 - 19.30AM
            </div>
            <% } %>
        </div>
    </div>

    <div class="col-md-2 text-center" 
        style="background-color:lightblue; height:200px">
        <div class="text-center align-middle">
            <small>Precio por persona.<br /> Impuestos y tasas no incluidos.</small>
            <h1>$<%= p.Precio %></h1>
            <a href="ConfirmarCompra.aspx?paqueteId=<%= p.Id %>" class="btn btn-danger">Comprar</a>
        </div>
    </div>

    </div>
</asp:Content>
