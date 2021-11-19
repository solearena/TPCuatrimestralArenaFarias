<%@ Page Language="C#" MasterPageFile ="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TpCuatrimestral.Registrarse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>

    <br />

    <script>
        function validar() {
            var email = document.getElementById("<% = txtEmail.ClientID %>").value;
            var valido = true;

            if (email === "") {
                alert("Email no Ingresado");
                $("#<% = txtEmail.ClientID %>").removeClass("is-valid");
                $("#<% = txtEmail.ClientID %>").addClass("is-invalid");
                valido = false;
            }
            else {
                alert("Bienvenido a NEBULA!");
                $("#<% = txtEmail.ClientID %>").removeClass("is-valid");
                $("#<% = txtEmail.ClientID %>").addClass("is-invalid");
            }
            if (!valido) {
                return false;
            }
            return true;
        }
    </script>
    
        <div class="row">
            <div class="col-2"></div>
            <div class="col">
              <div class="col-md-6">
                    <label for="inputEmail4" class="form-label">Email</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail" ClientIDMode="Static"/>
              </div>
              <div class="col-md-6">
                    <label for="inputPassword4" class="form-label">Password</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" ClientIDMode="Static"/>
              </div>
              <div class="col-12">
                    <label for="inputAddress" class="form-label">Dirección</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtDireccion" ClientIDMode="Static"/>
              </div>
              <div class="col-md-6">
                    <label for="inputCity" class="form-label">Ciudad</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtCiudad" ClientIDMode="Static"/> 
              </div>
              <div class="col-md-2">
                    <label for="inputZip" class="form-label">Código Postal</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtCodPostal" ClientIDMode="Static"/> 
              </div>
                <br />
              <div class="col-12">
                    <asp:Button ID="Button1" cssclass="btn btn-danger" runat="server" Text="Registrarse" OnClick="Button1_Click" OnClientClick="return validar()"/>
              </div>
            </div>
            <div class="col-2"></div>
          </div>
      
</asp:Content>
