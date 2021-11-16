<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpCuatrimestral.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3">
    <label for="inputEmail4" class="form-label">Usuario</label>
    <asp:TextBox runat="server" cssclass="form-control" ID="txtUsuario"/>
  </div>
  <div class="mb-3">
    <label for="inputPassword4" class="form-label">CONTRASEÑA</label>
    <asp:TextBox runat="server" cssclass="form-control" ID="txtContraseña"/>
  </div>
  <asp:Button ID="Button2"  cssclass="btn btn-danger" runat="server" Text="INGRESAR" OnClick="Button2_Click"/>
</asp:Content>
