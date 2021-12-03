<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TpCuatrimestral.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <div class="row">
        <div class="container">
            <div class="row" style="display:flex">

            <% foreach (dominio.Articulo item in listaArticulo )
                { %>
                <div class="col">
                    <div class="card h-100" style="width:400px; height:400px;border: solid 3px black">
                        <div align="center">
                            <img src="<% = item.UrlImagen %>"" class="card-img-top" alt="..." style="width:350px; height:350px">
                        </div>
                        <div class="card-body">
                            <h5 class="card-title"><% = item.Nombre %></h5>
                            <p class="card-text"><%= item.Descripcion %></p>
                            <h6 class="card-text"> $<% = item.Precio %></h6>   
                            <asp:Label ID="Label1" runat="server" Text="Stock" Visible ="false"></asp:Label>
                        </div>
                        <footer align="center">
                            <a href="DetalleProducto.aspx?id=<%:item.Id%>" class ="btn btn-danger" align="right">COMPRAR</a>
                        </footer>
                    </div>
                </div>
            <% } %>
            </div>
        </div>
    </div>
</asp:Content>
