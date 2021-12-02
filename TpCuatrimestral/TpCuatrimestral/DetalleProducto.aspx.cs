using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TpCuatrimestral
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        private List<Articulo> lista;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                StockNegocio stockNegocio = new StockNegocio();
                Articulo articulo = new Articulo();
                articulo = (Articulo)Session["articulo"];
                lista = (List<Articulo>)Session["listaArticulo"];
                if (Session["listaArticulo"] == null)
                {
                    lista = new List<Articulo>();
                    Session.Add("listaCarrito", lista);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "cerrar", "ModalStock('" + "Cerrar" + "');", true);
        }

        protected void imgEnvio_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", "ModalStock('" + "Abrir" + "');", true);
        }
    }
}