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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> listaArticulo { get; set; }

        private List<Articulo> listaCarrito;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulo = negocio.listar();
                Session.Add("listaArticulo", listaArticulo);
                if (Session["listaCarrito"] == null)
                {
                    listaCarrito = new List<Articulo>();
                    Session.Add("listaCarrito", listaCarrito);
                }
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    listaCarrito = (List<Articulo>)Session["listaCarrito"];
                    listaArticulo = (List<Articulo>)Session["listaArticulo"];
                    listaCarrito.Add(listaArticulo.Find(x => x.Id == int.Parse(id)));
                    Session.Add("listaCarrito", listaCarrito);
                }
            }
        }
    }

}