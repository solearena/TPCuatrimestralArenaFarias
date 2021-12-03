<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TpCuatrimestral.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <asp:GridView ID="dgvCarrito" runat="server" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged">
        <Columns>
            <%--<asp:BoundField DataField="Nombre" HeaderText="Nombre Producto" />--%>   
            <asp:BoundField DataField="IdArticulo.Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Talle" HeaderText="Talle" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="TotalParcial" HeaderText="Precio" />
            <asp:CommandField ShowSelectButton="true"/>
            <asp:CommandField ShowDeleteButton="true"/>
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
