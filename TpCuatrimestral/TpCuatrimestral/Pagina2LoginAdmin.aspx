<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Pagina2LoginAdmin.aspx.cs" Inherits="TpCuatrimestral.Pagina2LoginAdmin" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnRowCommand="dgvArticulos_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="UrlImagen" HeaderText="Imagen" />
            <asp:BoundField DataField="DescripcionCategoria" HeaderText="Categoría" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                <ItemTemplate>
                    <asp:Button ID="btnModificar" runat="server" Text="Editar" CssClass="btn alert-info" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" OnClick="btnModificar_Click" />
                    <asp:ImageButton ID="imgTacho" runat="server" ImageUrl="~/Content/Img/bote-de-basura.png" OnClick="imgTacho_Click" CommandArgument='<%# Eval("ID") %>' CommandName="Delete"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="row">
        <div class="col">
            <asp:Button runat="server" Text="Agregar"  cssclass="btn btn-danger" ID="btnAgregar" OnClick="btnAgregar_Click"/>
            <a href="Default.aspx" id="btnDesloguear" class="btn btn-danger" runat="server" onclick="btnDesloguear_Click">Desloguear</a>
        </div>
    </div>
</asp:Content>