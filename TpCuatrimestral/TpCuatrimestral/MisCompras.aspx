<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="TpCuatrimestral.MisCompras" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <asp:GridView ID="dgvCompras" runat="server" CssClass="table" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Número de Venta" />
            <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:n}"/>
            <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" />
            <asp:BoundField DataField="FOP.Tipo" HeaderText="Forma de Pago" />

            <asp:TemplateField>
                <ItemTemplate>
                    <%# Boolean.Parse(Eval("Despachado").ToString()) ? "DESPACHADO" : "EN PREPARACIÓN" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnVerMas" runat="server" Text="VER MÁS" CssClass="btn btn-danger" CommandArgument='<%# Eval("Id") %>' CommandName="mostrar" OnClick="btnVerMas_Click"/>
                </ItemTemplate>
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
</asp:Content>
