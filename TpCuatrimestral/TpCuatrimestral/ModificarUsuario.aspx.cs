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
                
            //    try
            //    {
            //        usuario = (usuario)session["usuario"];
            //        //direccion = direccionnegocio.buscardireccion(usuario.nombreusuario);
            //        if (txtdireccion.text == "")
            //        {
            //            direccion.callenum = direccion.callenum;
            //        }
            //        else
            //        {
            //            direccion.callenum = txtdireccion.text;
            //        }
            //        if (txtcodpostal.text == "")
            //        {
            //            direccion.codpostal = direccion.codpostal;
            //        }
            //        else
            //        {
            //            direccion.codpostal = txtcodpostal.text;
            //        }
            //        if (txtprovincia.text == "")
            //        {
            //            direccion.provincia = direccion.provincia;
            //        }
            //        else
            //        {
            //            direccion.provincia = txtprovincia.text;
            //        }
            //        if (txtpais.text == "")
            //        {
            //            direccion.pais = direccion.pais;
            //        }
            //        else
            //        {
            //            direccion.pais = txtpais.text;
            //        } 
            //        direccionnegocio.agregar(direccion);
            //        response.redirect("default.aspx");
            //    }
            //    catch (exception ex)
            //    {

            //        throw ex;
            //    }

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