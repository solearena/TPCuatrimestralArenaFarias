<%@ Page Language="C#" MasterPageFile ="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TpCuatrimestral.Registrarse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>

    <br />

   
    <div class="container small">
        <div class="row">
            <h2 class="text-center">Formulario de Registro</h2>
            <div class="col">
                <div id="formulario_registro" class="form-check" runat="server">
                    <div>
                        <fieldset>
                            <legend>Datos Personales</legend>
                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="validationServer01" class="form-label">Nombre</label>
                                    </asp:TableCell>
                                    <asp:TableCell class="col">
                                        <asp:TextBox runat="server" cssclass="form-control" ID="TxtNombre" ClientIDMode="Static" />
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                                          ControlToValidate="TxtNombre"
                                          ErrorMessage="Debe ingresar un Nombre."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="validationCustom02" class="form-label">Apellido</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="TxtApellido" ClientIDMode="Static"/>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                                          ControlToValidate="TxtApellido"
                                          ErrorMessage="Debe ingresar un Apellido."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="validationCustom03" class="form-label">DNI</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="TxtDni" ClientIDMode="Static"/>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                                          ControlToValidate="TxtDni"
                                          ErrorMessage="Debe ingresar un DNI."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="validationCustom04" class="form-label">Fecha de Nacimiento</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="txtNacimiento" ClientIDMode="Static"/>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                                          ControlToValidate="txtNacimiento"
                                          ErrorMessage="Debe ingresar una Fecha."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="validationCustom05" class="form-label">Celular</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="TxtCelular" ClientIDMode="Static"/>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                                          ControlToValidate="TxtCelular"
                                          ErrorMessage="Debe ingresar un Celular."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="email" class="form-label">Email</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail" ClientIDMode="Static" TextMode="Email" />
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                                          ControlToValidate="txtEmail"
                                          ErrorMessage="Debe ingresar un Email."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="inputAddress" class="form-label">Dirección</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="txtDireccion" ClientIDMode="Static"/>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server"
                                          ControlToValidate="txtDireccion"
                                          ErrorMessage="Debe ingresar una Direccion."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="inputCity" class="form-label">Provincia</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="txtProvincia" ClientIDMode="Static"/> 
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server"
                                          ControlToValidate="TxtProvincia"
                                          ErrorMessage="Debe ingresar una Provincia."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                  <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="inputCity" class="form-label">Pais</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="TxtPais" ClientIDMode="Static"/> 
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server"
                                          ControlToValidate="TxtPais"
                                          ErrorMessage="Debe ingresar un Pais."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                 <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="inputZip" class="form-label">Código Postal</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="txtCodPostal" ClientIDMode="Static"/> 
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server"
                                          ControlToValidate="txtCodPostal"
                                          ErrorMessage="Debe ingresar un Codigo Postal."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </fieldset>
                        <br />
                        <fieldset>
                            <legend>Datos de Login</legend>
                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="validationCustom06" class="form-label">Nombre de Usuario</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="TxtNombreUsuario" ClientIDMode="Static"/>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
                                          ControlToValidate="TxtNombreUsuario"
                                          ErrorMessage="Debe ingresar un Nombre de Usuario."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label for="inputPassword4" class="form-label">Password</label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" ClientIDMode="Static" placeholder="*****" TextMode="Password"/>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server"
                                          ControlToValidate="txtPassword"
                                          ErrorMessage="Debe ingresar una Contraseña."
                                          ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </fieldset>
                        <br />
                        <div>
                             <asp:Button ID="Button1" cssclass="btn btn-danger" runat="server" Text="Registrarse" OnClick="Button1_Click" OnClientClick="return validar()"/>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
