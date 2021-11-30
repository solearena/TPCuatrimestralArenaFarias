<%@ Page Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TpCuatrimestral.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  class="d-flex justify-content-center">
        <h1 class="text-dark" style="font-size:120px; font-family:'Goudy Old Style' ">NEBULA</h1>
    </div>
    <div class="modal-fade position-absolute top-50 start-50 translate-middle d-none" tabindex="-1" role="dialog" id="miModal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">SELECCIONE EL TALLE</h5>
                    </div>
                    <div class="modal-body">
                        <asp:DropDownList ID="ddlTalle" runat="server">
                            <asp:ListItem Text="S" Value="S"/>
                            <asp:ListItem Text="M" Value="M"/>
                            <asp:ListItem Text="L" Value="L"/>
                        </asp:DropDownList>
                        <asp:Label ID="lblStock" runat="server" Text="Stock" Visible ="false"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-secondary" Text="CANCELAR" data-dismiss="modal" />
                        <asp:Button runat="server" ID="btnComprar" CssClass="btn btn-secondary" Text="COMPRAR" data-dismiss="modal" />
                    </div>
                </div>
            </div>
        </div>
    <div class="container">
        <div class="row" style="display:flex">

        <%  List<int> listId = new List<int>(); 
            foreach (dominio.Articulo item in listaArticulo )
            {
                bool existe = false;
                for(int i=0; i<listId.Count(); i++)
                {
                    if(item.Id == listId[i])
                    {
                        existe = true;
                    }
                }
                listId.Add(item.Id);
                if(existe == false)
                { %>
            <div class="col">
                <div class="card h-100" style="width: 20rem; border: solid 3px black">
                    <img src="<% = item.UrlImagen %>"" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><% = item.Nombre %></h5>
                        <p class="card-text"><%= item.Descripcion %></p>
                        <h6 class="card-text"> $<% = item.Precio %></h6>
                        <a href="Productos.aspx?id=<%:item.Id%>" class ="btn btn-danger">COMPRAR</a>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-outline-danger dropdown-toggle" OnSelectedIndexChanged="ddlTalle_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem Text="S" Value="S"/>
                            <asp:ListItem Text="M" Value="M"/>
                            <asp:ListItem Text="L" Value="L"/>
                        </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Text="Stock" Visible ="false"></asp:Label>

             <% } %>
                    </div>
                </div>
            </div>
        <% } %>
        </div>
    </div> 
    <script>
        function ModalStock(decision) {
            if (decision == "MostrarStock") {
                $('#miModal').removeClass('d-none');
                $('#miModal').addClass('d-block');

            }
            if (decision == "Cerrar") {
                $('#miModal').removeClass('d-block');
                $('#miModal').addClass('d-none');
            }

        }
    </script>
</asp:Content>
