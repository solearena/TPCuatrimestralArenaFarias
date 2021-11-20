<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TpCuatrimestral.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <div class="container">
        <div class="row">

        <% foreach (dominio.Articulo item in listaArticulo )
            {%>
            <div class="col">
                <div class="card h-100" style="width: 20rem; border: solid 3px black">
                    <img src="<% = item.UrlImagen %>"" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><% = item.Nombre %></h5>
                        <p class="card-text"><%= item.Descripcion %></p>
                        <a href="Productos.aspx?id=<%:item.Id%>" class ="btn btn-danger">COMPRAR</a>
                        
                    </div>
                </div>
            </div>
        <% } %>
             </div>
        </div> 

</asp:Content>
