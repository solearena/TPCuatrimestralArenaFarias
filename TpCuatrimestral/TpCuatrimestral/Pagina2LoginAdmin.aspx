<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Pagina2LoginAdmin.aspx.cs" Inherits="TpCuatrimestral.Pagina2LoginAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <h1>Esa!</h1>
            <p>Tenés perfil admin, sino no podrías estar acá.</p>
            <p>
                <a href="MenuLogin.aspx" id="btnDesloguear" class="btn btn-primary" runat="server" onclick="btnDesloguear_Click">Desloguear</a>
        </div>
    </div>
</asp:Content>