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
    public partial class VerMas : System.Web.UI.Page
    {
        private ElementoCarrito elemento= null;
        protected void Page_Load(object sender, EventArgs e)
        {
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
 
                try
                {
                    if (this.Request.QueryString.Get(0) == null)
                    {
                        return;
                    }
                    int Id = Convert.ToInt32(this.Request.QueryString.Get(0));
                    if (Id != 0)
                    {
                        this.elemento = elemento;
                        ElementoCarritoNegocio negocio = new ElementoCarritoNegocio();

                        List<ElementoCarrito> lista = new List<ElementoCarrito>();
                        lista = negocio.listar(Id);
                        dgvDetalleVenta.DataSource = lista;
                        dgvDetalleVenta.DataBind();
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
}