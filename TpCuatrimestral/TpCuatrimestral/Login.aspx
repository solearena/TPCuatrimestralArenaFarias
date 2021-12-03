<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpCuatrimestral.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="wrapper" align="center"  >
        <div class="formcontent" style="width:550px; height:550px;">
                <div class="form-control">
                    <div class="row" align="center">
                        <asp:Label class="h2" ID="lblBienvenida" runat="server" Text="BIENVENIDO/A NEBULA"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                        <asp:TextBox ID="TxtUsuario" CssClass="form-control" runat="server" placeholder="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                        <asp:TextBox ID="TxtContrasenia" CssClass="form-control" TextMode="Password" runat="server" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <hr />
                    <br />
                    <div class="row">
                        <asp:Button ID="BtnIngresar" CssClass="btn btn-danger" runat="server" Text="Ingresar" OnClick="Button1_Click" />
                    </div>
                </div>
        </div>
    </div>
</asp:Content>


