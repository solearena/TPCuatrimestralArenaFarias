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
    public partial class Pagina2LoginAdmin : System.Web.UI.Page
    {
        public List<Articulo> listaArticulo { get; set; }
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
            try
            {
                listaArticulo = articuloNegocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDesloguear_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx"); 
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = e.ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }

        protected void imgTacho_Click(object sender, ImageClickEventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            else
            {
                try
                {
                    articulo.Id = Convert.ToInt32(dgvArticulos.DataKeys[e.X].Values[0]);
                    articuloNegocio.eliminar(articulo);
                    Response.Redirect("Pagina2LoginAdmin.aspx");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    } 
}