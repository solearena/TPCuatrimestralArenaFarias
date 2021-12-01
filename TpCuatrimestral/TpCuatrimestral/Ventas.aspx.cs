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
        public List<Venta> listaCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            VentaNegocio negocio = new VentaNegocio();
            try
            {
                listaCarrito = negocio.listar();
                dgvVentas.DataSource = listaCarrito;
                dgvVentas.DataBind();
            }
            catch (Exception ex) //ACA TIRA ERROR PORQUE ESTA EN NULL
            {

                throw ex;
            }

        }
    }
}