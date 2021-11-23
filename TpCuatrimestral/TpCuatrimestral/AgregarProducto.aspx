<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TpCuatrimestral.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>AGREGAR NUEVO PRODUCTO</h1>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col">
                <asp:Label Text="NOMBRE" runat="server" />
                <asp:TextBox ID="txtNombre" runat="server" Class="form-control"></asp:TextBox>
                <asp:Label Text="DESCRIPCION" runat="server" />
                <asp:TextBox ID="txtDescripcion" runat="server" Class="form-control"></asp:TextBox>
                <asp:Label Text="STOCK" runat="server" />
                <asp:TextBox ID="txtStock" runat="server" Class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label Text="PRECIO $" runat="server" />
                <asp:TextBox ID="txtPrecio" runat="server" Class="form-control"></asp:TextBox>
                <asp:Label Text="IMAGEN" runat="server" />
                <asp:TextBox ID="txtUrlImagen" runat="server" Class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Label Text="CATEGORIA" runat="server" />
                <asp:DropDownList ID="listaCategoria" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>
                <asp:Label Text="TALLE" runat="server" />
                <asp:DropDownList ID="listaTalles" CssClass="btn btn-outline-dark dropdown-toggle" runat="server">
                    <asp:ListItem Text="S" />
                    <asp:ListItem Text="M" />
                    <asp:ListItem Text="L" />
                </asp:DropDownList>
            </div>
            <div class="col-md-2"></div>
            <div class="col-md-12">
                <br />
                <asp:Button ID="btnAgregar" runat="server" Text="AGREGAR" CssClass="btn btn-danger" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
