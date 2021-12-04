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
            string FOP = "Transferencia Bancaria";
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Usuario nombreUsuario;
            nombreUsuario = (Usuario)Session["usuario"];
            int idCliente;
            idCliente = clienteNegocio.buscarCliente(nombreUsuario.NombreUsuario);

            string total;

            total = (string)Session["totalAPagar"];

            VentaNegocio ventaNegocio = new VentaNegocio();
            Venta aux = new Venta();
            aux.IdCliente = new Cliente();
            aux.IdCliente.IdCliente = idCliente;
            aux.FOP = new FormaDePago();
            aux.FOP.Tipo = FOP;
            aux.Total = decimal.Parse(total);
            ventaNegocio.guardar(aux);

            listaCarrito = (List<ElementoCarrito>)Session["listaCarrito2"];

            foreach (dominio.ElementoCarrito item in listaCarrito)
            {
                StockNegocio negocio = new StockNegocio();
                negocio.descontarStock(listaCarrito[i].IdArticulo.Id, listaCarrito[i].Cantidad, listaCarrito[i].Talle);
                i++;
            }
            Session["listaCarrito2"] = null;
        }

        protected void imgDinero_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            string FOP = "Efectivo";
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Usuario nombreUsuario;
            nombreUsuario = (Usuario)Session["usuario"];
            int idCliente;
            idCliente = clienteNegocio.buscarCliente(nombreUsuario.NombreUsuario);

            string total;
            
            total = (string)Session["totalAPagar"];

            VentaNegocio ventaNegocio = new VentaNegocio();
            Venta aux = new Venta();
            aux.IdCliente = new Cliente();
            aux.IdCliente.IdCliente = idCliente;
            aux.FOP = new FormaDePago();
            aux.FOP.Tipo = FOP;
            aux.Total = decimal.Parse(total);
            ventaNegocio.guardar(aux);

            listaCarrito = (List<ElementoCarrito>)Session["listaCarrito2"];

            foreach (dominio.ElementoCarrito  item in listaCarrito)
            {
                StockNegocio negocio = new StockNegocio();
                negocio.descontarStock(listaCarrito[i].IdArticulo.Id, listaCarrito[i].Cantidad, listaCarrito[i].Talle);
                i++;
            }
            Session["listaCarrito2"] = null;
        }

        protected void imgMP_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            string FOP = "Mercado Pago";

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Usuario nombreUsuario;
            nombreUsuario = (Usuario)Session["usuario"];
            int idCliente;
            idCliente = clienteNegocio.buscarCliente(nombreUsuario.NombreUsuario);

            string total;

            total = (string)Session["totalAPagar"];

            VentaNegocio ventaNegocio = new VentaNegocio();
            Venta aux = new Venta();
            aux.IdCliente = new Cliente();
            aux.IdCliente.IdCliente = idCliente;
            aux.FOP = new FormaDePago();
            aux.FOP.Tipo = FOP;
            aux.Total = decimal.Parse(total);
            ventaNegocio.guardar(aux);

            listaCarrito = (List<ElementoCarrito>)Session["listaCarrito2"];

            foreach (dominio.ElementoCarrito item in listaCarrito)
            {
                StockNegocio negocio = new StockNegocio();
                negocio.descontarStock(listaCarrito[i].IdArticulo.Id, listaCarrito[i].Cantidad, listaCarrito[i].Talle);
                i++;
            }
            Session["listaCarrito2"] = null;
        }
    }
}