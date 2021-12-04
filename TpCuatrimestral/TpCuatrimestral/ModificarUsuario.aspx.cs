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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                Usuario usuario;
                
                UsuarioNegocio usuarionegocio = new UsuarioNegocio();
                DireccionNegocio direccionNegocio = new DireccionNegocio();

                usuario = (Usuario)Session["usuario"];
                Direccion direccion = new Direccion();
                direccion = direccionNegocio.buscarDireccion(usuario.NombreUsuario);
                Session.Add("direccion", direccion);

                lblDireccion.Text = direccion.CalleNum;
                lblPais.Text = direccion.Pais;
                lblProvincia.Text = direccion.Provincia;
                lblCodPostal.Text = direccion.CodPostal;
            }
       }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DireccionNegocio negocio = new DireccionNegocio();
            Direccion direccion = new Direccion();
            direccion = (Direccion)Session["direccion"];
            try
            {
                if (txtdireccion.Text != "")
                {
                    direccion.CalleNum = txtdireccion.Text;
                }
                if (txtcodpostal.Text != "")
                {
                    direccion.CodPostal = txtcodpostal.Text;
                }
                if (txtprovincia.Text != "")
                {
                    direccion.Provincia = txtprovincia.Text;
                }
                if (txtpais.Text != "")
                {
                    direccion.Pais = txtpais.Text;
                }
                negocio.modificar(direccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.Write("<script language=javascript>alert('Se ha modificado con exito!');</script>");
            Response.Redirect("ModificarUsuario.aspx");
        }
    }
}