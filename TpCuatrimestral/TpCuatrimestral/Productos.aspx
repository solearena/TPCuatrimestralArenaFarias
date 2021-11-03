<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TpCuatrimestral.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>NEBULA</h1>
    <p>PRODUCTOS</p>
    <div class="container">
        <div class="row">

        <% foreach (dominio.Articulo item in listaArticulos )
            {%>
            <div class="col">
                <div class="card" style="width: 18rem; border: solid 5px black">
                    <img src="<% = item.UrlImagen %>"" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><% = item.Nombre %></h5>
                        <p class="card-text"><%= item.Descripcion %></p>
                        
                    </div>
                </div>
            </div>
        <% } %>
             </div>
        </div> 

</asp:Content>
