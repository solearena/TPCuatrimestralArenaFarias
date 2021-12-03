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
        private List<Articulo> listaCarrito;

        private List<Carrito> listaCarrito2;

        public List<Articulo> listaArticulo { get; set; }

        private Articulo articulo = null;
        private ElementoCarrito carrito = new ElementoCarrito();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                StockNegocio stockNegocio = new StockNegocio();
                Articulo articulo = new Articulo();
                if (Session["listaCarrito"] == null)
                {
                    listaCarrito2 = new List<Carrito>();
                    Session.Add("listaCarrito", listaCarrito2);
                }
                if (Request.QueryString["Id"] != null)
                {
                    int Id = Convert.ToInt32(this.Request.QueryString.Get(0));
                    listaCarrito2 = (List<Carrito>)Session["listaCarrito"];

                    if(Id != 0)
                    {
                        this.articulo = articulo;
                        Cargar(Id);
                        img.ImageUrl = articulo.UrlImagen.ToString();
                        lblNombre.Text = articulo.Nombre;
                        lblDescripcion.Text = articulo.Descripcion;
                        lblPrecio.Text = articulo.Precio.ToString();
                        ddlTalle.DataSource = stockNegocio.listarTalles(Id);
                        ddlTalle.DataBind();
                    }
                    ElementoCarrito elemento = new ElementoCarrito();
                    elemento.Talle = ddlTalle.SelectedValue.ToString();
                    elemento.IdArticulo.Id = articulo.Id;
                    //elemento.Cantidad = 


                    /*Articulo seleccionado = new Articulo();
                    seleccionado.Stock = new Stock();
                    seleccionado.Stock.Talle = ddlTalle.SelectedValue.ToString();
                    listaCarrito.Add(articulo);
                    listaCarrito.Add(seleccionado);
                    Session.Add("listaCarrito", listaCarrito);*/

                }
                
                

            }
        }
        private void Cargar(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulo = negocio.listar();
                int i = 0;
                while (id != listaArticulo[i].Id)
                {
                    i++;
                }
                articulo.Id = listaArticulo[i].Id;
                articulo.Precio = listaArticulo[i].Precio;
                articulo.Nombre = listaArticulo[i].Nombre;
                articulo.Descripcion = listaArticulo[i].Descripcion;
                articulo.UrlImagen = listaArticulo[i].UrlImagen;
                articulo.DescripcionCategoria = (Categoria)listaArticulo[i].DescripcionCategoria;
                articulo.IdCategoria = (Categoria)listaArticulo[i].IdCategoria;

                i = 0;
            }
            catch (Exception ex)
            {

                throw ex;
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

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            
        }
    }
}