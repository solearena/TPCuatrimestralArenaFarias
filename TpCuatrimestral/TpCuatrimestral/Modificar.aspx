<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" EnableEventValidation="false"  Inherits="TpCuatrimestral.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:GridView ID="dgvArticulo" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvArticulo_SelectedIndexChanged" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" ShowFooter="True" AutoGenerateEditButton="true" OnRowEditing="dgvArticulo_RowEditing" OnRowCancelingEdit="dgvArticulo_RowCancelingEdit" OnRowUpdating="dgvArticulo_RowUpdating" >
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"/>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="UrlImagen" HeaderText="Imagen" />
                <asp:BoundField DataField="DescripcionCategoria" HeaderText="Categoría" />

                
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <asp:DropDownList ID="listaCategoria" CssClass="btn btn-outline-danger dropdown-toggle" runat="server"></asp:DropDownList>
            <asp:TextBox ID="Stock" runat="server" Text="Stock" Height="39px" Width="57px"></asp:TextBox>
            <asp:DropDownList ID="listaTalles" CssClass="btn btn-outline-danger dropdown-toggle" runat="server">
                    <asp:ListItem Text="S" />
                    <asp:ListItem Text="M" />
                    <asp:ListItem Text="L" />
                </asp:DropDownList>
            <div class="col-md-12">
                <br />
                <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                </div>
        </div>

</asp:Content>
