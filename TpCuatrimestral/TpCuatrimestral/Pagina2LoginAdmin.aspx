<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Pagina2LoginAdmin.aspx.cs" Inherits="TpCuatrimestral.Pagina2LoginAdmin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <div class="modal-fade position-absolute top-50 start-50 translate-middle d-none" tabindex="-1" role="dialog" id="miModal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">STOCK</h5>
                    </div>
                    <div class="modal-body">
                        <asp:GridView ID="dgvStock" runat="server" CssClass="table" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Talle" HeaderText="Talle" />
                                <asp:BoundField DataField="StockArticulo" HeaderText="Stock" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-secondary" Text="OK" data-dismiss="modal" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnRowCommand="dgvArticulos_RowCommand" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="UrlImagen" HeaderText="Imagen" />
                <asp:BoundField DataField="DescripcionCategoria" HeaderText="Categoría" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <!-- Enlace para abrir el modal -->
                        <asp:Button Text="MOSTRAR STOCK" ID="btnStock" CssClass="btn alert-info" runat="server" CommandArgument='<%# Eval("ID") %>' data-target="#miModal" OnClick="btnStock_Click" data-toggle="modal" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" Text="EDITAR" CssClass="btn alert-info" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" OnClick="btnModificar_Click" />
                        <asp:ImageButton ID="imgTacho" runat="server" ImageUrl="~/Content/Img/bote-de-basura.png" OnClick="imgTacho_Click" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" />
                    </ItemTemplate>

                    <HeaderStyle Width="150px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <RowStyle BackColor="#9999ff" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <div class="row">
            <div class="col">
                <asp:Button runat="server" Text="Agregar" CssClass="btn btn-danger" ID="btnAgregar" OnClick="btnAgregar_Click" />
            </div>
        </div>
    </div>
    <script>
        function ModalStock(decision) {
            if (decision == "MostrarStock") {
                $('#miModal').removeClass('d-none');
                $('#miModal').addClass('d-block');

            }
            if (decision == "Cerrar") {
                $('#miModal').removeClass('d-block');
                $('#miModal').addClass('d-none');
            }

        }
    </script>
</asp:Content>
