<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Despedida.aspx.cs" Inherits="TpCuatrimestral.Despedida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <br />
    <div style=" border-style: dashed; border-color: inherit; border-width: 10px; font-size:100px; font-family:'Goudy Old Style'; border-radius:50%; width:732px; height:311px; margin-left:auto; margin-right:auto" class="text-center">
        <asp:Image ID="imgBolsa" runat="server" ImageUrl="~/Content/Img/bolsa-de-la-compra.png"  />
        <h2>GRACIAS POR SU COMPRA, LO ESPERAMOS NUEVAMENTE EN NUESTRO SITIO!</h2>
    </div>
    <br />
    <br />
</asp:Content>
