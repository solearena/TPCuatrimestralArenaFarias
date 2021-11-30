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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
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
                Cliente cliente = new Cliente();
                UsuarioNegocio usuarionegocio = new UsuarioNegocio();
                DireccionNegocio direccionNegocio = new DireccionNegocio();
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                try
                {
                    direccion.CalleNum = txtDireccion.Text;
                    direccion.CodPostal = txtCodPostal.Text;
                    direccion.Provincia = txtProvincia.Text;
                    direccion.Pais = TxtPais.Text;
                    cliente.Nombre = TxtNombre.Text;
                    cliente.Apellido = TxtApellido.Text;
                    cliente.DNI = TxtDni.Text;
                    cliente.FechaNacimiento = txtNacimiento.Text;
                    cliente.Celular = TxtCelular.Text;
                    cliente.Email = txtEmail.Text;
                    usuario = new Usuario(TxtNombreUsuario.Text, txtPassword.Text, false);
                    usuario.NombreUsuario = TxtNombreUsuario.Text;
                    usuario.Contrasenia = txtPassword.Text;

                    if (usuarionegocio.existeUsuario(TxtNombreUsuario.Text))
                    {
                        Session.Add("ERROR", "NOMBRE DE USUARIO EXISTENTE");
                        Response.Redirect("Error.aspx");
                    }
                    else
                    {
                        clienteNegocio.agregar(cliente);
                        usuarionegocio.agregar(usuario);
                        direccionNegocio.agregar(direccion);
                        Response.Redirect("Default.aspx");

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