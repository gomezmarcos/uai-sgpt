<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="GUI.dominio.Cliente" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div style="width:100%;
  height:100%;
  min-height:300px;
  height:calc(100% - 1px);
  background-image:url('/fotos/sistema/sgpt-buscar.jpg');
  background-size:cover; color:white; padding:30px; margin-bottom:20px"> 
        <h1 style="margin-top:200px">Encontra los mejores Paquetes Turisticos</h1>
        <p class="lead">Sistema de Gestion de Paquetes Turisticos</p>
  </div>     
 
    <div class="row">
        <div class="col-md-11">
            <div class="form-group">
                <asp:TextBox ID="txtBuscar" placeholder="Buscar" runat="server" CssClass="form-control"/>
            </div>
        </div>
        <div class="col-md-1">
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" CssClass="btn form-control btn-success" Text="Buscar" />
        </div>
    </div>

    <% foreach (var p in paquetes) { %>
    <div class="row well" style="margin-bottom:20px; height:270px">

        <div class="col-md-9" style="height:250px">
            <h2><%= p.Titulo %> - 

            <% foreach (var t in p.Tags)
                { %>
                   <small><span class="label label-success"><%=t.Codigo %></span> </small>
            <%} %>
            <% foreach (var d in p.Destinos)
                { %>
                   <small><span class="label label-warning"><%=d.Descripcion %></span> </small>
            <%} %>

            </h2>

            <h4><%= p.Descripcion %></h4>
            <div class="row">
                <div class="col-md-3">
                    <% if (p.Fotos.Count > 0)
                        { %>
                        <img src="<%=p.Fotos[0].path %>" alt="con path" class="img-thumbnail">

                    <%} else {
                            %>
                        <img src="..." alt="..." class="img-thumbnail">
                    <%} %>
                </div>
                <div class="col-md-3">
                    <div class="badge">7.3</div>
                    <h4><%= p.Hoteles[0].Nombre %></h4>
                    <ul>
                        <li>3 <span class="glyphicon glyphicon-star"/></li>
                        <li><%= p.Hoteles[0].Direccion %></li>
                    </ul>
                </div>

                <div class="col-md-3">
                    <h4>Vuelos</h4>
                    <ul>
                    <% foreach (var v in p.Vuelos) { %>
                        <li><%=v.Empresa %> - <%=v.objOrigen.Descripcion %> -> <%=v.objDestino.Descripcion %></li>
                    <% } %>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-3 text-center" style="margin-top:10px; margin-bottom:10px; margin-left:-10px;height:220px;border-style:dashed; padding:10px; background-color:lightblue">
            <div class="text-center align-middle">
                <small>Precio por persona.<br /> Impuestos y tasas no incluidos.</small>
                <h1>$<%= p.Precio %></h1>
                <a href="Landing.aspx?paqueteId=<%= p.Id %>" class="btn btn-primary">Ver Detalles</a>
            </div>
        </div>
    </div>
  <% } %>

</asp:Content>
