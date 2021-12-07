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

        public List<ElementoCarrito> listaSinStock { get; set; }
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

        public bool validarArticulo(List<string> lista, string nombre)
        {
            foreach(string item in lista)
            {
                if(item == nombre)
                {
                    return true;
                }
            }
            return false;
        }
        protected void imgBanco_Click(object sender, ImageClickEventArgs e)
        {
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
                bool hayStock = true;
                int stock, totalStock;
                string talle2;
                List<string> art = new List<string>();
                foreach (dominio.ElementoCarrito item in listaCarrito)
                {
                    StockNegocio negocio = new StockNegocio();
                    int idArt = item.IdArticulo.Id;
                    totalStock = 0;
                    talle2 = item.Talle;
                    foreach(dominio.ElementoCarrito item2 in listaCarrito)
                    {
                        if(idArt == item2.IdArticulo.Id && talle2 == item2.Talle)
                        {
                            totalStock += item2.Cantidad;
                        }
                    }
                    stock = negocio.buscarStock(item.IdArticulo.Id, item.Talle);
                    if (stock < totalStock) 
                    {
                        hayStock = false;
                        bool existe = false;
                        if (art != null)
                        {
                            existe = validarArticulo(art, item.IdArticulo.Nombre);
                        }
                        if(existe == false)
                        {
                            art.Add(item.IdArticulo.Nombre);
                        }
                    }
                }
                Session.Add("listaSinStock", art);
                if(hayStock == true)
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
                        negocio.descontarStock(item.IdArticulo.Id, item.Cantidad, item.Talle);

                        ElementoCarritoNegocio elementoCarritoNegocio = new ElementoCarritoNegocio();
                        ElementoCarrito elemento = new ElementoCarrito();
                        elemento.IdArticulo = new Articulo();
                        elemento.IdArticulo.Id = item.IdArticulo.Id;
                        elemento.IdVenta = new Venta();
                        elemento.IdVenta.Id = idVenta;
                        elemento.Cantidad = item.Cantidad;
                        elemento.Talle = item.Talle;
                        elemento.PrecioUnitario = item.PrecioUnitario;
                        elementoCarritoNegocio.guardar(elemento);
                    }
                    Response.Redirect("Despedida.aspx");
                }
                else
                {
                    Session.Add("error", "STOCK INSUFICIENTE: ");
                    Response.Redirect("ErroStock.aspx", false);
                }
            }
            Session["listaCarrito2"] = null;
        }

        protected void imgDinero_Click(object sender, ImageClickEventArgs e)
        {
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
                bool hayStock = true;
                int stock, totalStock;
                string talle2;
                List<string> art = new List<string>();
                foreach (dominio.ElementoCarrito item in listaCarrito)
                {
                    StockNegocio negocio = new StockNegocio();
                    int idArt = item.IdArticulo.Id;
                    totalStock = 0;
                    talle2 = item.Talle;
                    foreach (dominio.ElementoCarrito item2 in listaCarrito)
                    {
                        if (idArt == item2.IdArticulo.Id && talle2 == item2.Talle)
                        {
                            totalStock += item2.Cantidad;
                        }
                    }
                    stock = negocio.buscarStock(item.IdArticulo.Id, item.Talle);
                    if (stock < totalStock)
                    {
                        hayStock = false;
                        bool existe = false;
                        if (art != null)
                        {
                            existe = validarArticulo(art, item.IdArticulo.Nombre);
                        }
                        if (existe == false)
                        {
                            art.Add(item.IdArticulo.Nombre);
                        }
                    }
                }
                Session.Add("listaSinStock", art);
                if (hayStock == true)
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
                        negocio.descontarStock(item.IdArticulo.Id, item.Cantidad, item.Talle);

                        ElementoCarritoNegocio elementoCarritoNegocio = new ElementoCarritoNegocio();
                        ElementoCarrito elemento = new ElementoCarrito();
                        elemento.IdArticulo = new Articulo();
                        elemento.IdArticulo.Id = item.IdArticulo.Id;
                        elemento.IdVenta = new Venta();
                        elemento.IdVenta.Id = idVenta;
                        elemento.Cantidad = item.Cantidad;
                        elemento.Talle = item.Talle;
                        elemento.PrecioUnitario = item.PrecioUnitario;
                        elementoCarritoNegocio.guardar(elemento);

                    }
                    Response.Redirect("Despedida.aspx");
                }
                else
                {
                    Session.Add("error", "STOCK INSUFICIENTE: ");
                    Response.Redirect("ErroStock.aspx", false);
                }
            }
            Session["listaCarrito2"] = null;
        }

        protected void imgMP_Click(object sender, ImageClickEventArgs e)
        {
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
                bool hayStock = true;
                int stock, totalStock;
                string talle2;
                List<string> art = new List<string>();
                foreach (dominio.ElementoCarrito item in listaCarrito)
                {
                    StockNegocio negocio = new StockNegocio();
                    int idArt = item.IdArticulo.Id;
                    totalStock = 0;
                    talle2 = item.Talle;
                    foreach (dominio.ElementoCarrito item2 in listaCarrito)
                    {
                        if (idArt == item2.IdArticulo.Id && talle2 == item2.Talle)
                        {
                            totalStock += item2.Cantidad;
                        }
                    }
                    stock = negocio.buscarStock(item.IdArticulo.Id, item.Talle);
                    if (stock < totalStock)
                    {
                        hayStock = false;
                        bool existe = false;
                        if (art != null)
                        {
                            existe = validarArticulo(art, item.IdArticulo.Nombre);
                        }
                        if (existe == false)
                        {
                            art.Add(item.IdArticulo.Nombre);
                        }
                    }
                }
                Session.Add("listaSinStock", art);
                if (hayStock == true)
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
                        negocio.descontarStock(item.IdArticulo.Id, item.Cantidad, item.Talle);

                        ElementoCarritoNegocio elementoCarritoNegocio = new ElementoCarritoNegocio();
                        ElementoCarrito elemento = new ElementoCarrito();
                        elemento.IdArticulo = new Articulo();
                        elemento.IdArticulo.Id = item.IdArticulo.Id;
                        elemento.IdVenta = new Venta();
                        elemento.IdVenta.Id = idVenta;
                        elemento.Cantidad = item.Cantidad;
                        elemento.Talle = item.Talle;
                        elemento.PrecioUnitario = item.PrecioUnitario;
                        elementoCarritoNegocio.guardar(elemento);
                    }
                    Response.Redirect("Despedida.aspx");
                }
                else
                {
                    Session.Add("error", "STOCK INSUFICIENTE: ");
                    Response.Redirect("ErroStock.aspx", false);
                }
            }
            Session["listaCarrito2"] = null;
        }
    }
}