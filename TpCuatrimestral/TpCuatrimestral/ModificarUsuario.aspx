<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="TpCuatrimestral.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <div class="row">
        <h3 class="text-center">Cambiar Dirección</h3>
        <div class="col">
        </div>
    </div>
    <asp:table id="tableDireccion" runat="server" CssClass="fw-bold">
        <asp:tablerow>
            <asp:tablecell>
                <label for="inputaddress" class="form-label">Dirección: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtdireccion" clientidmode="static"/>
            </asp:tablecell>
        </asp:tablerow>
        <asp:tablerow>
            <asp:tablecell>
                <label for="inputcity" class="form-label">Provincia: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtprovincia" clientidmode="static"/> 
            </asp:tablecell>
        </asp:tablerow>
            <asp:tablerow>
            <asp:tablecell>
                <label for="inputcity" class="form-label">País: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtpais" clientidmode="static"/> 
            </asp:tablecell>
        </asp:tablerow>
            <asp:tablerow>
            <asp:tablecell>
                <label for="inputzip" class="form-label">Código postal: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtcodpostal" clientidmode="static"/> 
            </asp:tablecell>
        </asp:tablerow>
    </asp:table>
    <asp:Button ID="btnAceptar" runat="server" Text="ACEPTAR" CssClass="btn btn-danger" OnClick="btnAceptar_Click"/>
    <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" OnClick="btnCancelar_Click" CssClass="btn btn-danger"/>
</asp:Content>
