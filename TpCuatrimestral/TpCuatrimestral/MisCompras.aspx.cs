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
    public partial class MisCompras : System.Web.UI.Page
    {
        public List<Venta> listaCompras { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
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
                    Usuario nombreUsuario;
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    nombreUsuario = (Usuario)Session["usuario"];
                    int idCliente;
                    idCliente = clienteNegocio.buscarCliente(nombreUsuario.NombreUsuario);
                    listaCompras = negocio.listaPorCliente(idCliente);
                    dgvCompras.DataSource = listaCompras;
                    dgvCompras.DataBind();
                }
                catch (Exception ex) //ACA TIRA ERROR PORQUE ESTA EN NULL
                {

                    throw ex;
                }
            }
        }
    }
}