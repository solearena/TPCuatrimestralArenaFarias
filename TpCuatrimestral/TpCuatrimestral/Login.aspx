﻿<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpCuatrimestral.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
 
          <div class="mb-3">
                <asp:Label ID="Label1" runat="server" Text="Label">Usuario</asp:Label>
                <asp:TextBox ID="TxtUsuario" runat="server" placeholder="user name" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="mb-3">
              <asp:Label ID="Label2" runat="server" Text="Label">Contraseña</asp:Label>
              <asp:TextBox ID="TxtContrasenia" runat="server" placeholder="*****" CssClass="form-control" TextMode="Password" ></asp:TextBox>
          </div>
        <div class="col-12">
            <asp:Button ID="Button1" runat="server" Text="Ingresar" cssclass="btn btn-danger" OnClick="Button1_Click" />
        </div>

          </div>
</asp:Content>
