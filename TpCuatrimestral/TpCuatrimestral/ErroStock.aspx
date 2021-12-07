<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ErroStock.aspx.cs" Inherits="TpCuatrimestral.ErroStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="text-center">
        <h1 style="color:red">HUBO UN PROBLEMA</h1>
    </div>
    <br />
    <div class="spinner-grow align-content-center text-center">
        <asp:Image ID="imgAlert" runat="server" ImageUrl="~/Content/Img/advertencia.png"  />

    </div>
    <div class="text-center">
        <asp:Label Text="" ID="lblMensaje" runat="server" style="color:red; Background:aliceblue; height:max-content"/> 
    </div>
    <div class="row">
        <div class="container">
            <asp:GridView ID="dgvSinStock" runat="server" CssClass="table text-center"  >
            </asp:GridView>
           
        </div>
    </div>
    <br />
    <br />
</asp:Content>
