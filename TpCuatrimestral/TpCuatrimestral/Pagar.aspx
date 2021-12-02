<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="TpCuatrimestral.Pagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>

    <div class="form-group text-center">
        <div>
            <asp:ImageButton ID="imgDinero" runat="server" ImageUrl="~/Content/Img/dinero-en-efectivo.png" />
            <b>Pago en efectivo: </b> Al momento de recibir el producto, se hará efectivo el pago del mismo.
        </div>
        <br />
        <div>
            <asp:ImageButton ID="imgBanco" ImageUrl="~/Content/Img/banco.png" runat="server" />
            <b>Transferencia Bancaria: </b> Pago offline. Luego de efectuar tu pedido completo hasta el final, hace la transferencia desde tu home banking
        </div>
        <br />
        <div>
            <asp:ImageButton ID="imgMP" ImageUrl="~/Content/Img/ML.png" runat="server" />
            <b>Mercado Pago</b>
        </div>
        <br />
    </div>
</asp:Content>
