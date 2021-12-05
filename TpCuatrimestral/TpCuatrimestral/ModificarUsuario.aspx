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
    <asp:table id="tableDireccion" runat="server" CssClass="fw-bold" style="border-spacing: 5px; margin:auto">
        <asp:tablerow>
            <asp:tablecell>
                <label for="inputaddress" class="form-label">Dirección: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtdireccion" clientidmode="static"/>
            </asp:tablecell>
            <asp:TableCell>
                <asp:Label ID="lblDireccion" runat="server" Text="" style="color:dimgray"></asp:Label>
            </asp:TableCell>
        </asp:tablerow>
        <asp:tablerow>
            <asp:tablecell>
                <label for="inputcity" class="form-label">Provincia: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtprovincia" clientidmode="static"/> 
            </asp:tablecell>
            <asp:TableCell>
                <asp:Label ID="lblProvincia" runat="server" Text="" style="color:dimgray"></asp:Label>
            </asp:TableCell>
        </asp:tablerow>
            <asp:tablerow>
            <asp:tablecell>
                <label for="inputcity" class="form-label">País: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtpais" clientidmode="static"/> 
            </asp:tablecell>
                <asp:TableCell>
                <asp:Label ID="lblPais" runat="server" Text="" style="color:dimgray"></asp:Label>
                </asp:TableCell>
        </asp:tablerow>
        <asp:tablerow>
            <asp:tablecell>
                <label for="inputzip" class="form-label">Código postal: </label>
            </asp:tablecell>
            <asp:tablecell>
                <asp:textbox runat="server" cssclass="form-control" id="txtcodpostal" clientidmode="static"/> 
            </asp:tablecell>
            <asp:TableCell>
                <asp:Label ID="lblCodPostal" runat="server" Text="" style="color:dimgray"></asp:Label>
            </asp:TableCell>
        </asp:tablerow>
        <asp:TableRow>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell style="text-align:center; padding:10px;">
                <asp:Button ID="btnAceptar" runat="server" Text="ACEPTAR" CssClass="btn btn-danger border-dark" OnClick="btnAceptar_Click"/>
                <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" OnClick="btnCancelar_Click" CssClass="btn btn-danger border-dark"/>

            </asp:TableCell>
        </asp:TableRow>
    </asp:table>
    <br />
    <div style="margin:auto">
    </div>
</asp:Content>
