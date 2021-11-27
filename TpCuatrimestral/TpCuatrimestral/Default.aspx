<%@ Page Language="C#" MasterPageFile ="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpCuatrimestral.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>

    <div class="text-center">
        <video controls="controls" autoplay="autoplay" width="640" height="360" loop="loop" >
            <source src="Content/Img/LogoAnimado.mp4" type="video/mp4" />
            <source src="Content/Img/LogoAnimado.mp4" type="video/webm" />
            <source src="Content/Img/LogoAnimado.mp4" type="video/ogg" />
            Tu navegador no es compatible
        </video>
    </div>
</asp:Content>