﻿using System;
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
                while (id != listaArticulo[i].Id)
                {
                    i++;
                }
                articulo.Id = listaArticulo[i].Id;
                articulo.Precio = listaArticulo[i].Precio;
                articulo.Nombre = listaArticulo[i].Nombre;
                articulo.Descripcion = listaArticulo[i].Descripcion;
                articulo.UrlImagen = listaArticulo[i].UrlImagen;
                articulo.DescripcionCategoria = (Categoria)listaArticulo[i].DescripcionCategoria;
                articulo.IdCategoria = (Categoria)listaArticulo[i].IdCategoria;

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
                try
                {

                    int Id = Convert.ToInt32(this.Request.QueryString.Get(0));
                    if (Id != 0)
                    {
                        this.articulo = articulo;
                        Cargar(Id);
                        int idart = articulo.Id; //ver porque queda null
                        List<Articulo> lista = new List<Articulo>();
                        lista.Add(articulo);
                        dgvArticulo.DataSource = lista;
                        dgvArticulo.DataBind();
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

        protected void dgvArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = e.ToString();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina2LoginAdmin.aspx");
        }

        protected void dgvArticulo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvArticulo.EditIndex = e.NewEditIndex;
            dgvArticulo.DataBind();
        }

        protected void dgvArticulo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();

            //ver como hacer para actualizar sin usar la lista o agregando metodo

            negocio.modificar(articulo);

        }

        protected void dgvArticulo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvArticulo.EditIndex = -1;
            dgvArticulo.DataBind();
        }
    }
}