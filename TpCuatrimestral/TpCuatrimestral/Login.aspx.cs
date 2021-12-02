﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TpCuatrimestral
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            
            try
            {
                usuario = new Usuario(TxtUsuario.Text, TxtContrasenia.Text, false);
                string nombreUsuario = TxtUsuario.Text;
                int cliente = clienteNegocio.buscarCliente(nombreUsuario);

                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Session.Add("cliente", cliente);
                    Response.Redirect("Pagina2LoginAdmin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}