<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TpCuatrimestral.Contacto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <div class="container">
        <div class="row">
            <div class="col">
                <iframe width="500" height="600" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?width=100%25&amp;height=600&amp;hl=es&amp;q=Cramer%20345+(NEBULA)&amp;t=&amp;z=14&amp;ie=UTF8&amp;iwloc=B&amp;output=embed"><a href="https://www.mapsdirections.info/marcar-radio-circulo-mapa/">Marcar radio en el mapa</a>
                </iframe>
            </div>
            <div class="col-md-6">
                <h1>Contactanos</h1>
            <address>
                <strong>Telefono: </strong>11-3028-9090
            </address>
            <address>
                <strong>Dirección: </strong>Cramer 345, CABA
            </address>
            <address>
                <strong>Email:</strong>   <a href="mailto:nebula@gmail.com">nebula@gmail.com</a><br />
            </address>
            <div class="row">
                <div class="col-2"></div>
                 <div class="mb-2">
                    <asp:Label runat="server" Text="Label" class="form-label">Email</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" cssclass="form-control"></asp:TextBox>
                 </div>
            <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="txtAsunto" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMensaje" cssclass="form-control" style="resize:none; width:stretch; height:150px;"  ></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-danger" OnClick="btnEnviar_Click"/>
            </div>
            </div>
            <div class="col"></div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
