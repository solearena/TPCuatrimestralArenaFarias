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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                if (!IsPostBack)
                {
                    listaCategoria.DataSource = categoria.listar();
                    listaCategoria.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("ERROR!", ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina2LoginAdmin.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            else
            {
                Articulo articulo = new Articulo();
                ArticuloNegocio artnegocio = new ArticuloNegocio();
                Stock stock = new Stock();
                StockNegocio stocknegocio = new StockNegocio();
                try
                {
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Precio = int.Parse(txtPrecio.Text);
                    articulo.UrlImagen = txtUrlImagen.Text;
                    if (listaCategoria.SelectedValue == "Manga Larga")
                    {
                        articulo.DescripcionCategoria.IdCategoria = 1;
                    }
                    if(listaCategoria.SelectedValue == "Manga Corta")
                    {
                        articulo.DescripcionCategoria.IdCategoria = 2;
                    }
                    artnegocio.agregar(articulo);
                    stock.StockArticulo = int.Parse(txtStock.Text);
                    stock.Talle = listaTalles.SelectedValue;
                    stocknegocio.agregar(stock);

                }
                catch (Exception ex)
                {

                    throw ex;
                }    


            }

        }
    }
}