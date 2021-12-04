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
    public partial class Ventas : System.Web.UI.Page
    {
        public List<Venta> listaVentas { get; set; }
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
                if ((((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.NORMAL))
                {
                    Response.Redirect("Pagina1Login.aspx", false);
                }
            }
            VentaNegocio negocio = new VentaNegocio();
            try
            {
                listaVentas = negocio.listar();
                dgvVentas.DataSource = listaVentas;
                dgvVentas.DataBind();
            }
            catch (Exception ex) //ACA TIRA ERROR PORQUE ESTA EN NULL
            {

                throw ex;
            }

        }

        protected void btbDespacho_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
            Venta venta = new Venta();
            Button button = sender as Button;
            try
            {
                venta.Id = Convert.ToInt32(button.CommandArgument);

                negocio.despachar(venta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            Response.Redirect("Ventas.aspx", false);
        }
    }
}