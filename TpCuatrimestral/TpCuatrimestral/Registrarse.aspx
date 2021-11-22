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
        <div class="col-2"></div>
        <div class="row g-3 needs-validation p-5" style="flex-basis:auto">
            <div class="col-md-3">
                    <label for="validationServer01" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="TxtNombre" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"                      ControlToValidate="TxtNombre"                      ErrorMessage="Debe ingresar un Nombre."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
            <div class="col-md-3">
                    <label for="validationCustom02" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="TxtApellido" ClientIDMode="Static"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"                      ControlToValidate="TxtApellido"                      ErrorMessage="Debe ingresar un Apellido."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
            <div class="col-md-3">
                    <label for="validationCustom03" class="form-label">DNI</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="TxtDni" ClientIDMode="Static"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"                      ControlToValidate="TxtDni"                      ErrorMessage="Debe ingresar un DNI."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
            <div class="col-md-2">
                    <label for="validationCustom04" class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtNacimiento" ClientIDMode="Static"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"                      ControlToValidate="txtNacimiento"                      ErrorMessage="Debe ingresar una Fecha."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
            <div class="col-md-3">
                    <label for="validationCustom05" class="form-label">Celular</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="TxtCelular" ClientIDMode="Static"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"                      ControlToValidate="TxtCelular"                      ErrorMessage="Debe ingresar un Celular."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>

              <div class="col-md-5">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail" ClientIDMode="Static" TextMode="Email" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"                      ControlToValidate="txtEmail"                      ErrorMessage="Debe ingresar un Email."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
                <div class="col-md-3">
                    <label for="validationCustom06" class="form-label">Nombre de Usuario</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="TxtNombreUsuario" ClientIDMode="Static"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"                      ControlToValidate="TxtNombreUsuario"                      ErrorMessage="Debe ingresar un Nombre de Usuario."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
              <div class="col-md-2">
                    <label for="inputPassword4" class="form-label">Password</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" ClientIDMode="Static" placeholder="*****" TextMode="Password"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server"                      ControlToValidate="txtPassword"                      ErrorMessage="Debe ingresar una Contraseña."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
              <div class="col-md-4">
                    <label for="inputAddress" class="form-label">Dirección</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtDireccion" ClientIDMode="Static"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server"                      ControlToValidate="txtDireccion"                      ErrorMessage="Debe ingresar una Direccion."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
              <div class="col-md-4">
                    <label for="inputCity" class="form-label">Provincia</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtProvincia" ClientIDMode="Static"/> 
                    <asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server"                      ControlToValidate="TxtProvincia"                      ErrorMessage="Debe ingresar una Provincia."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
                <div class="col-md-4">
                    <label for="inputCity" class="form-label">Pais</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="TxtPais" ClientIDMode="Static"/> 
                    <asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server"                      ControlToValidate="TxtPais"                      ErrorMessage="Debe ingresar un Pais."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
              <div class="col-md-2">
                    <label for="inputZip" class="form-label">Código Postal</label>
                    <asp:TextBox runat="server" cssclass="form-control" ID="txtCodPostal" ClientIDMode="Static"/> 
                    <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server"                      ControlToValidate="txtCodPostal"                      ErrorMessage="Debe ingresar un Codigo Postal."                      ForeColor="Red">                    </asp:RequiredFieldValidator>
              </div>
                <br />
              <div class="col-md-12">
                    <asp:Button ID="Button1" cssclass="btn btn-danger" runat="server" Text="Registrarse" OnClick="Button1_Click" OnClientClick="return validar()"/>
              </div>
            </div>
            <div class="col-2"></div>
      
</asp:Content>
