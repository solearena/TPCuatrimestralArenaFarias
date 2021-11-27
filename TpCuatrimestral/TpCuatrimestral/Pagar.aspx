<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="TpCuatrimestral.Pagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Image ID="imgDinero" runat="server" ImageUrl="~/Content/Img/dinero-en-efectivo.png"/>
        Pago en efectivo
    </div>
    <div>
        <asp:Image ID="imgBanco" ImageUrl="~/Content/Img/banco.png" runat="server" />
        Transferencia Bancaria
    </div>
    <div>
        <asp:Image ID="imgMP" ImageUrl="~/Content/Img/MP.jpg" runat="server" />
        Mercado Pago
    </div>
</asp:Content>
