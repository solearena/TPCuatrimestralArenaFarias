<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TpCuatrimestral.Carrito" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <asp:GridView ID="dgvCarrito" runat="server" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged">
        <Columns>
            <%--<asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />--%>   
            <asp:BoundField DataField="IdArticulo.Nombre" HeaderText="Remera" />
            <asp:BoundField DataField="Talle" HeaderText="Talle" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgTacho" runat="server" ImageUrl="~/Content/Img/bote-de-basura.png" CommandArgument='<%# Eval("IdArticulo.Id") %>' CommandName="Delete" OnClick="imgTacho_Click"/>
                    </ItemTemplate>
                <HeaderStyle Width="150px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="text-end fw-bold">
        <div class="align-content-center text-center">
            <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-danger text-center" BorderStyle="Groove" OnClick="btnPagar_Click"/>
        </div>
        <asp:Label Text="TOTAL: $" runat="server" />
        <asp:Label Text="" runat="server" ID="lblTotal" />
    </div>

</asp:Content>
