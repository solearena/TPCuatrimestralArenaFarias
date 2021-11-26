﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="TpCuatrimestral.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:GridView ID="dgvArticulo" runat="server" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulo_SelectedIndexChanged" AutoGenerateEditButton="true" OnRowEditing="dgvArticulo_RowEditing">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="UrlImagen" HeaderText="Imagen" />
                <asp:BoundField DataField="DescripcionCategoria" HeaderText="Categoría" />
                <asp:BoundField DataField="StockArticulo" HeaderText="Stock" />
            </Columns>        
        </asp:GridView>
            <div class="col-md-12">
                <br />
                <asp:Button ID="btnAceptar" runat="server" Text="ACEPTAR" CssClass="btn btn-danger" />
                <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                </div>
        </div>

</asp:Content>
