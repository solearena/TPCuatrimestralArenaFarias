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
    public partial class Modificar : System.Web.UI.Page
    {
        private Articulo articulo = null;

        private List<Articulo> listaArticulo;


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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No tienes permisos para ingresar a esta pantalla.");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                if ((((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.NORMAL))
                {
                    Response.Redirect("Pagina1Login.aspx", false);
                }
                try
                {
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    Stock stock = new Stock();
                    if (this.Request.QueryString.Get(0) == null)
                    {
                        return;
                    }
                    int Id = Convert.ToInt32(this.Request.QueryString.Get(0));
                    if (Id != 0)
                    {
                        this.articulo = articulo;
                        Cargar(Id);

                        List<Articulo> lista = new List<Articulo>();
                        lista.Add(articulo);
                        dgvArticulo.DataSource = lista;
                        dgvArticulo.DataBind();
                        listaCategoria.DataSource = categoria.listar();
                        listaCategoria.DataBind();
                        stock.Talle = listaTalles.SelectedValue;
                        listaTalles.DataBind();
                    }
                    else
                    {
                        return;

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        protected void dgvArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = e.ToString();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina2LoginAdmin.aspx");
        }

        protected void dgvArticulo_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void dgvArticulo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*ArticuloNegocio negocio = new ArticuloNegocio();
            
            if(e.NewValues[0] != null)
            {
                //ver como hacer para actualizar sin usar la lista o agregando metodo
                articulo.Nombre = e.NewValues[0].ToString();
                articulo.Descripcion = e.NewValues[1].ToString();
                articulo.Precio = Convert.ToDecimal(e.NewValues[2].ToString());
                articulo.UrlImagen = e.NewValues[3].ToString();
                if (listaCategoria.SelectedValue == "Manga Larga")
                {
                    articulo.DescripcionCategoria.Descripcion = "Manga Larga";
                }
                if (listaCategoria.SelectedValue == "Manga Corta")
                {
                    articulo.DescripcionCategoria.Descripcion = "Manga Corta";
                }
                negocio.modificar(articulo);

                //articulo = null;
            }
            else
            {
                return;
            }
            dgvArticulo.EditIndex = -1;
            dgvArticulo.DataBind();*/
        }

        protected void dgvArticulo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            StockNegocio stocknegocio = new StockNegocio();
            Stock stock = new Stock();
            if (txtNombre.Text != "")
            {
                articulo.Nombre = txtNombre.Text;
            }
            else
            {
                articulo.Nombre = articulo.Nombre;
            }
            if (txtDescripcion.Text != "")
            {
                articulo.Descripcion = txtDescripcion.Text;
            }
            else
            {
                articulo.Descripcion = articulo.Descripcion;
            }
            if (txtPrecio.Text != "")
            {
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
            }
            else
            {
                articulo.Precio = articulo.Precio;
            }
            if (txtImagen.Text != "")
            {
                articulo.UrlImagen = txtImagen.Text;
            }
            else
            {
                articulo.UrlImagen = articulo.UrlImagen;
            }
            if (listaCategoria.SelectedValue == "Manga Larga")
            {
                articulo.DescripcionCategoria.Descripcion = "Manga Larga";
            }
            if (listaCategoria.SelectedValue == "Manga Corta")
            {
                articulo.DescripcionCategoria.Descripcion = "Manga Corta";
            }
            if (txtStock.Text != "")
            {
                stock.IdArticulo = new Articulo();
                stock.IdArticulo.Id = articulo.Id;
                stock.StockArticulo = Convert.ToInt32(txtStock.Text);
                stock.Talle = listaTalles.SelectedItem.Text;
                stocknegocio.modificar(stock); 
            }
            articulo.Estado = true;
            negocio.modificar(articulo);
            //es tan rapido que no me lo muestra
            Response.Write("<script language=javascript>alert('SU PRODUCTO HA SIDO MODIFICADO');</script>");

            Response.Redirect("Pagina2LoginAdmin.aspx");
         
        }
    }
}