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
                while(id != listaArticulo[i].Id)
                {
                    i++;
                }
                articulo.Nombre = listaArticulo[i].Nombre;
                articulo.Precio = listaArticulo[i].Precio;
                articulo.Descripcion = listaArticulo[i].Descripcion;
                articulo.UrlImagen = listaArticulo[i].UrlImagen;
                articulo.DescripcionCategoria.Descripcion = listaArticulo[i].DescripcionCategoria.Descripcion;
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

            try
            {
                Session(Request.QueryString["IdOtro"]);
                if(Id != 0)
                {
                    Cargar((Id));

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
}