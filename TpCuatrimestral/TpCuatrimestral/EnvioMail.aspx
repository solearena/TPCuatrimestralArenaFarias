<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EnvioMail.aspx.cs" Inherits="TpCuatrimestral.EnvioMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <asp:Label runat="server" Text="Label" class="form-label">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="txtAsunto" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMensaje" cssclass="form-control"></asp:TextBox>
            </div>
                <asp:Button Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" ID="btnAceptar" runat="server" />
        </div>
        <div class="col"></div>
    </div>
</asp:Content>