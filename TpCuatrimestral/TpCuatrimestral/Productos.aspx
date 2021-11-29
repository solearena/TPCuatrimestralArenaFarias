﻿<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TpCuatrimestral.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <div class="container">
        <div class="row" style="display:flex">

        <% foreach (dominio.Articulo item in listaArticulo )
            {%>
            <div class="col">
                <div class="card h-100" style="width: 20rem; border: solid 3px black; padding: 10px; margin:10px;">
                    <img src="<% = item.UrlImagen %>"" class="card-img-top" alt="..." style="flex:inherit">
                    <div class="card-body">
                        <h5 class="card-title"><% = item.Nombre %></h5>
                        <p class="card-text"><%= item.Descripcion %></p>
                        <h6 class="card-text"> $<% = item.Precio %></h6>
                        <a href="Productos.aspx?id=<%:item.Id%>" class ="btn btn-danger" data-toggle="modal" >COMPRAR</a>
                        <asp:DropDownList ID="ddlTalle" runat="server" CssClass="btn btn-outline-danger dropdown-toggle"  >
                            <asp:ListItem Text="S" Value="S"/>
                            <asp:ListItem Text="M" Value="M"/>
                            <asp:ListItem Text="L" Value="L"/>
                        </asp:DropDownList>
                        <asp:Label ID="lblStock" runat="server" Text="Stock" Visible ="false"></asp:Label>
                    </div>
                </div>
            </div>
        <% } %>
        </div>
    </div> 
</asp:Content>
