﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Pagina2LoginAdmin.aspx.cs" Inherits="TpCuatrimestral.Pagina2LoginAdmin" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnRowCommand="dgvArticulos_RowCommand" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" />
            <asp:BoundField DataField="UrlImagen" HeaderText="Imagen" />
            <asp:BoundField DataField="DescripcionCategoria" HeaderText="Categoría" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                <ItemTemplate>
                    <asp:DropDownList runat="server" CssClass="btn btn-secondary dropdown-toggle" ID="ddlTalle" AutoPostBack="true" OnSelectedIndexChanged="ddlTalle_SelectedIndexChanged">
                        <asp:ListItem Text="S" />
                        <asp:ListItem Text="M" />
                        <asp:ListItem Text="L" />
                    </asp:DropDownList>
                    <asp:Label ID="lblStock" runat="server" Text="Stock"></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>     
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                <ItemTemplate>
                    <asp:Button ID="btnModificar" runat="server" Text="Editar" CssClass="btn alert-info" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" OnClick="btnModificar_Click" />
                    <asp:ImageButton ID="imgTacho" runat="server" ImageUrl="~/Content/Img/bote-de-basura.png" OnClick="imgTacho_Click" CommandArgument='<%# Eval("ID") %>' CommandName="Delete"  />
                </ItemTemplate>
                <HeaderStyle Width="150px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <div class="row">
        <div class="col">
            <asp:Button runat="server" Text="Agregar"  cssclass="btn btn-danger" ID="btnAgregar" OnClick="btnAgregar_Click"/>
            <asp:Button ID="btnStock" runat="server" Text="Ver Stock" cssclass="btn btn-danger"/>
        </div>
    </div>
</asp:Content>