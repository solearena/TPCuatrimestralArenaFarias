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
        Direccion direccion = new Direccion();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            else
            {
                Usuario usuario;
                Direccion direccion = new Direccion();
                UsuarioNegocio usuarionegocio = new UsuarioNegocio();
                DireccionNegocio direccionNegocio = new DireccionNegocio();
                
                try
                {
                    usuario = (Usuario)Session["usuario"];
                    direccion = direccionNegocio.buscarDireccion(usuario.NombreUsuario);
                    if (txtdireccion.Text == "")
                    {
                        direccion.CalleNum = direccion.CalleNum;
                    }
                    else
                    {
                        direccion.CalleNum = txtdireccion.Text;
                    }
                    if (txtcodpostal.Text == "")
                    {
                        direccion.CodPostal = direccion.CodPostal;
                    }
                    else
                    {
                        direccion.CodPostal = txtcodpostal.Text;
                    }
                    if (txtprovincia.Text == "")
                    {
                        direccion.Provincia = direccion.Provincia;
                    }
                    else
                    {
                        direccion.Provincia = txtprovincia.Text;
                    }
                    if (txtpais.Text == "")
                    {
                        direccion.Pais = direccion.Pais;
                    }
                    else
                    {
                        direccion.Pais = txtpais.Text;
                    } 
                    direccionNegocio.agregar(direccion);
                    Response.Redirect("Default.aspx");
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DireccionNegocio negocio = new DireccionNegocio();
            negocio.modificar(direccion);
            Response.Write("<script language=javascript>alert('Se ha modificado con exito!');</script>");
            Response.Redirect("Default.aspx");
        }
    }
}