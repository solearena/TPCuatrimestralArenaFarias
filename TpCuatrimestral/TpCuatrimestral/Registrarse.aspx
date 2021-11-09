<%@ Page Language="C#" MasterPageFile ="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TpCuatrimestral.Registrarse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
          <div class="col-md-6">
                <label for="inputEmail4" class="form-label">Email</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail"/>
          </div>
          <div class="col-md-6">
                <label for="inputPassword4" class="form-label">Password</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword"/>
          </div>
          <div class="col-12">
                <label for="inputAddress" class="form-label">Dirección</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtDireccion"/>
          </div>
          <div class="col-md-6">
                <label for="inputCity" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtCiudad"/> 
          </div>
          <div class="col-md-2">
                <label for="inputZip" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtCodPostal"/> 
          </div>
            <br />
          <div class="col-12">
                <asp:Button ID="Button1"  cssclass="btn btn-danger" runat="server" Text="Registrarse" OnClick="Button1_Click"/>
          </div>
        </div>
        <div class="col-2"></div>
      </div>
</asp:Content>
