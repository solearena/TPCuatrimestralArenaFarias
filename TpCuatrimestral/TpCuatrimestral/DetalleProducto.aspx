<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TpCuatrimestral.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
            <div class="table" style="max-width: 540px; height: 540px">
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="img" runat="server" style="width:500px; height:500px;" />
                        </td>
                        <td style="text-align:center; font-size:20px">
                            <div>
                                <asp:Label ID="lblNombre" runat="server" Text="NOMBRE" style="font:25px bold; background-color:black; color:white"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="lblDescripcion" runat="server" Text="DESCRIPCIÓN"></asp:Label>
                            </div>
                            <div>
                                <asp:DropDownList ID="ddlTalle" runat="server"></asp:DropDownList>
                            </div>
                            <div>
                                <asp:Label ID="lblPrecio" runat="server" Text="PRECIO"></asp:Label>
                            </div>
                                <asp:Button ID="btnRestar" runat="server" Text="-" OnClick="btnRestar_Click"/>
                                <asp:TextBox ID="txtCantidad" runat="server" value="1" style="width:40px" CssClass="text-center" ></asp:TextBox>
                                <asp:Button ID="btnSumar" runat="server" Text="+" OnClick="btnSumar_Click"/>
                            <div>
                                <br />
                                <asp:Button ID="btnCarrito" runat="server" CssClass="btn btn-danger" Text="AGREGAR AL CARRITO" OnClick="btnCarrito_Click"/>
                            </div>
                            <div>
                                <br />
                                <!-- Enlace para abrir el modal -->
                                <div style="border:double; font-size:15px">
                                    <p>Información sobre envíos:</p>
                                    <asp:ImageButton ID="imgEnvio" runat="server" ImageUrl="~/Content/Img/caja.png"  data-target="#miModal" data-toggle="modal" OnClick="imgEnvio_Click"  />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
    </div>
    <div class="modal-fade modal-dialog-scrollable position-absolute top-50 start-50 translate-middle d-none" tabindex="-1" role="dialog" id="miModal">
        <div id="fancy-tiempo-costos" class="fancy-pop" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2>¿Cuál es el tiempo de entrega?</h2>
                </div>
                <div class="modal-body">
                    <p><span>ENVÍO A DOMICILIO</span> 

                    <p><span>Información sobre el envío</span> Los tiempos de envío varían entre
                        1 a 3 días hábiles si tu domicilio es en Capital Federal o GBA y entre 4 y 7 días hábiles si
                        el domicilio es en el Interior. Las entregas se realizan de lunes a viernes, entre las 9:00
                        y las 20:30 horas, según el operador logístico.</p>
                    <p><span>¿Qué puedo hacer para asegurar la entrega?</span>Te recomendamos que elijas un
                        domicilio donde sea más seguro encontrarte o que siempre haya alguien para recibir. Podes
                        elegir tu trabajo, la casa de algún familiar o de alguien de confianza. Tene en cuenta que
                        no entregamos a menores de edad. Asegúrate que tu domicilio esté completo, no olvides
                        aclarar el número de la calle, piso, departamento, oficina, torre o monoblock si fuera
                        necesario. Mientras más datos nos dejes, más fácil será para el correo encontrar tu casa.
                        Déjanos también tu celular o el teléfono de alguien que esté al tanto de tu compra, para que
                        podamos contactarnos fácilmente si fuera necesario re-coordinar la entrega.</p>
                    <p><span>¿Quién realiza la entrega?</span>Trabajamos con 3 operadores logísticos: Treggo,
                        Shipnow y Andreani. Según tu código postal vamos a designar el que más rápido llegue.</p>
                    <p><span>¿A partir de cuando se cuenta el tiempo de envío?</span>El tiempo de envío se cuenta a
                        partir de que tu pago se procese y apruebe.</p>

                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-secondary" Text="CERRAR" data-dismiss="modal" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
    <script>
        function ModalStock(decision) {
            if (decision == "Abrir") {
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
