<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Pagina2LoginAdmin.aspx.cs" Inherits="TpCuatrimestral.Pagina2LoginAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="UrlImagen" HeaderText="Imagen" />
            <asp:BoundField DataField="Estado" HeaderText="Activo(1)/Inactivo(0)" />
            <asp:BoundField DataField="DescripcionCategoria" HeaderText="Categoría" />
        </Columns>
    </asp:GridView>
    <div class="row">
        <div class="col">
            <asp:Button runat="server" Text="Agregar"  cssclass="btn btn-danger" ID="btnAgregar" OnClick="btnAgregar_Click"/>
            <a href="Default.aspx" id="btnDesloguear" class="btn btn-danger" runat="server" onclick="btnDesloguear_Click">Desloguear</a>
        </div>
    </div>
</asp:Content>