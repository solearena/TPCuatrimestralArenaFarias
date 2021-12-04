using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace TpCuatrimestral
{
    public partial class Pagar : System.Web.UI.Page
    {
        public List<Stock> listaStock { get; set; }
        public List<ElementoCarrito> listaCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Para poder abonar debes loguearte. Gracias!");
                Response.Redirect("Error.aspx", false);
            }
            listaStock = (List<Stock>)Session["listaStock"];
        }

        protected void imgBanco_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            int FOP = 3;
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Usuario nombreUsuario;
            nombreUsuario = (Usuario)Session["usuario"];
            int idCliente;
            idCliente = clienteNegocio.buscarCliente(nombreUsuario.NombreUsuario);

            string total;

            total = (string)Session["totalAPagar"];

            VentaNegocio ventaNegocio = new VentaNegocio();
            Venta aux = new Venta();

            listaCarrito = (List<ElementoCarrito>)Session["listaCarrito2"];
            if (Session["listaCarrito2"] == null)
            {
                Session.Add("error", "Ya has abonado.");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                aux.IdCliente = new Cliente();
                aux.IdCliente.IdCliente = idCliente;
                aux.FOP = new FormaDePago();
                aux.FOP.IdFP = FOP;
                aux.Total = decimal.Parse(total);
                ventaNegocio.guardar(aux);
                int idVenta = ventaNegocio.buscarUltimaVenta();
                foreach (dominio.ElementoCarrito item in listaCarrito)
                {
                    StockNegocio negocio = new StockNegocio();
                    negocio.descontarStock(listaCarrito[i].IdArticulo.Id, listaCarrito[i].Cantidad, listaCarrito[i].Talle);

                    ElementoCarritoNegocio elementoCarritoNegocio = new ElementoCarritoNegocio();
                    ElementoCarrito elemento = new ElementoCarrito();
                    elemento.IdArticulo = new Articulo();
                    elemento.IdArticulo.Id = listaCarrito[i].IdArticulo.Id;
                    elemento.IdVenta = new Venta();
                    elemento.IdVenta.Id = idVenta;
                    elemento.Cantidad = listaCarrito[i].Cantidad;
                    elemento.Talle = listaCarrito[i].Talle;
                    elemento.PrecioUnitario = listaCarrito[i].PrecioUnitario;
                    elementoCarritoNegocio.guardar(elemento);

                    i++;
                }
            }
            Session["listaCarrito2"] = null;
        }

        protected void imgDinero_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            int FOP = 1;
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Usuario nombreUsuario;
            nombreUsuario = (Usuario)Session["usuario"];
            int idCliente;
            idCliente = clienteNegocio.buscarCliente(nombreUsuario.NombreUsuario);

            string total;
            
            total = (string)Session["totalAPagar"];
            
            VentaNegocio ventaNegocio = new VentaNegocio();
            Venta aux = new Venta();

            listaCarrito = (List<ElementoCarrito>)Session["listaCarrito2"];
            if(Session["listaCarrito2"] == null)
            {
                Session.Add("error", "Ya has abonado.");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                aux.IdCliente = new Cliente();
                aux.IdCliente.IdCliente = idCliente;
                aux.FOP = new FormaDePago();
                aux.FOP.IdFP = FOP;
                aux.Total = decimal.Parse(total);
                ventaNegocio.guardar(aux);
                int idVenta = ventaNegocio.buscarUltimaVenta();
                foreach (dominio.ElementoCarrito  item in listaCarrito)
                {
                    StockNegocio negocio = new StockNegocio();
                    negocio.descontarStock(listaCarrito[i].IdArticulo.Id, listaCarrito[i].Cantidad, listaCarrito[i].Talle);

                    ElementoCarritoNegocio elementoCarritoNegocio = new ElementoCarritoNegocio();
                    ElementoCarrito elemento = new ElementoCarrito();
                    elemento.IdArticulo = new Articulo();
                    elemento.IdArticulo.Id = listaCarrito[i].IdArticulo.Id;
                    elemento.IdVenta = new Venta();
                    elemento.IdVenta.Id = idVenta;
                    elemento.Cantidad = listaCarrito[i].Cantidad;
                    elemento.Talle = listaCarrito[i].Talle;
                    elemento.PrecioUnitario = listaCarrito[i].PrecioUnitario;
                    elementoCarritoNegocio.guardar(elemento);

                    i++;
                }
            }
            Session["listaCarrito2"] = null;
        }

        protected void imgMP_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            int FOP = 2;

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Usuario nombreUsuario;
            nombreUsuario = (Usuario)Session["usuario"];
            int idCliente;
            idCliente = clienteNegocio.buscarCliente(nombreUsuario.NombreUsuario);

            string total;

            total = (string)Session["totalAPagar"];

            VentaNegocio ventaNegocio = new VentaNegocio();
            Venta aux = new Venta();

            listaCarrito = (List<ElementoCarrito>)Session["listaCarrito2"];
            if (Session["listaCarrito2"] == null)
            {
                Session.Add("error", "Ya has abonado.");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                aux.IdCliente = new Cliente();
                aux.IdCliente.IdCliente = idCliente;
                aux.FOP = new FormaDePago();
                aux.FOP.IdFP = FOP;
                aux.Total = decimal.Parse(total);
                ventaNegocio.guardar(aux);
                int idVenta = ventaNegocio.buscarUltimaVenta();
                foreach (dominio.ElementoCarrito item in listaCarrito)
                {
                    StockNegocio negocio = new StockNegocio();
                    negocio.descontarStock(listaCarrito[i].IdArticulo.Id, listaCarrito[i].Cantidad, listaCarrito[i].Talle);

                    ElementoCarritoNegocio elementoCarritoNegocio = new ElementoCarritoNegocio();
                    ElementoCarrito elemento = new ElementoCarrito();
                    elemento.IdArticulo = new Articulo();
                    elemento.IdArticulo.Id = listaCarrito[i].IdArticulo.Id;
                    elemento.IdVenta = new Venta();
                    elemento.IdVenta.Id = idVenta;
                    elemento.Cantidad = listaCarrito[i].Cantidad;
                    elemento.Talle = listaCarrito[i].Talle;
                    elemento.PrecioUnitario = listaCarrito[i].PrecioUnitario;
                    elementoCarritoNegocio.guardar(elemento);

                    i++;
                }
            }
            Session["listaCarrito2"] = null;
        }
    }
}