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

        private List<ElementoCarrito> listaCarrito2;

        public List<Articulo> listaArticulo { get; set; }

        //private Articulo articulo = null;
        public Articulo articulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                StockNegocio stockNegocio = new StockNegocio();
                Articulo articulo = new Articulo();
                if (Session["listaCarrito2"] == null)
                {
                    listaCarrito = new List<Articulo>();
                    listaCarrito2 = new List<ElementoCarrito>();
                    Session.Add("listaCarrito", listaCarrito);
                    Session.Add("listaCarrito2", listaCarrito2);
                }
                if (Request.QueryString["Id"] != null)
                {
                    int Id = Convert.ToInt32(this.Request.QueryString.Get(0));
                    listaCarrito = (List<Articulo>)Session["listaCarrito"];
                    listaCarrito2 = (List<ElementoCarrito>)Session["listaCarrito2"];
                    if(Id != 0)
                    {
                        this.articulo = articulo;
                        Cargar(Id);
                        img.ImageUrl = articulo.UrlImagen.ToString();
                        lblNombre.Text = articulo.Nombre;
                        lblDescripcion.Text = articulo.Descripcion;
                        lblPrecio.Text = '$' + articulo.Precio.ToString();
                        ddlTalle.DataSource = stockNegocio.listarTalles(Id);
                        ddlTalle.DataBind();
                    }
                    

                    /*Articulo seleccionado = new Articulo();
                    seleccionado.Stock = new Stock();
                    seleccionado.Stock.Talle = ddlTalle.SelectedValue.ToString();
                    listaCarrito.Add(articulo);
                    listaCarrito.Add(seleccionado);*/
                    Session.Add("listaCarrito", listaCarrito);
                    Session.Add("listaCarrito2", listaCarrito2);
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
            if (Request.QueryString["Id"] == null)
            {
                Session.Add("error", "Debes seleccionar un producto.");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                StockNegocio stockNegocio = new StockNegocio();
                int Id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                ElementoCarrito elemento = new ElementoCarrito();
                Articulo articulo = new Articulo();
                this.articulo = articulo;
                Cargar(Id);
                elemento.Talle = ddlTalle.SelectedValue.ToString();
                elemento.IdArticulo = new Articulo();
                elemento.IdArticulo.Id = Id;
                elemento.IdArticulo.Nombre = articulo.Nombre;
                if (txtCantidad.Text == "")
                {
                    elemento.Cantidad = 1;
                }
                else
                {
                    elemento.Cantidad = int.Parse(txtCantidad.Text);
                }
                int stockDisponible = 0;
                stockDisponible = stockNegocio.buscarStock(Id, elemento.Talle);
                elemento.PrecioUnitario = articulo.Precio;
             
                if (stockDisponible < elemento.Cantidad)
                {
                    Response.Write("<script language=javascript>alert('STOCK INSUFICIENTE. Seleccione una cantidad menor.');</script>");
                }
                else
                {
                    listaCarrito2 = (List<ElementoCarrito>)Session["listaCarrito2"];
                    listaCarrito2.Add(elemento);
                    Session.Add("listaCarrito2", listaCarrito2);
                }
            }
            
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtCantidad.Text) > 0)
            {
                txtCantidad.Text = (Convert.ToInt32(txtCantidad.Text) - 1).ToString();
            }
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCantidad.Text) < 10)
            {
                txtCantidad.Text = (Convert.ToInt32(txtCantidad.Text) + 1).ToString();
            }
        }
    }
}