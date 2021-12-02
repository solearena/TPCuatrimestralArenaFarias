<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TpCuatrimestral.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <div >
            <div class="card text-white bg-dark mb-3" style="max-width: 540px; height: 540px">
              <div class="row no-gutters">
                <div class="col-md-4">
                    <asp:Image ID="img" runat="server" src="<%: articulo.UrlImagen.ToString() %>" />
                </div>
                <div class="col-md-8">
                  <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
                  </div>
                </div>
              </div>
            </div>
            <!-- Enlace para abrir el modal -->
            <asp:ImageButton ID="imgEnvio" runat="server" ImageUrl="~/Content/Img/caja.png"  data-target="#miModal" data-toggle="modal" OnClick="imgEnvio_Click" CssClass="align-content-lg-end"/>
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

                    <p><span>RETIRO EN TIENDA</span></p> 

                    <p><span>¿Cuánto tarda el envío en estar disponible para retirar en la tienda?</span>El plazo
                        estimado es entre 3 y 6 días hábiles.</p>

                    <p><span>¿Qué necesito para retirar mi pedido por la tienda?</span>¡Solamente presentando tu
                        DNI! Solo el titular de la tarjeta podra retirar el pedido</p>

                    <p><span>¿Cuánto tiempo tengo para retirar mi pedido por el local?</span>Una vez que te llega el
                        e-mail de confirmación tenés 48 hs para retirarlo por la tienda.</p>
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
