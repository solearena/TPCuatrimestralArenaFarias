using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TpCuatrimestral
{
    public partial class Pagina2LoginAdmin : System.Web.UI.Page
    {
        public List<Articulo> listaArticulo { get; set; }
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        public List<Stock> listaStock { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            StockNegocio stockNegocio = new StockNegocio();

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
            try
            {
                listaArticulo = articuloNegocio.listar();
                listaStock = stockNegocio.listar();

                
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDesloguear_Click(object sender, EventArgs e)
        {
             
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = e.ToString();
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }

        protected void imgTacho_Click(object sender, ImageClickEventArgs e)
        {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ImageButton button = sender as ImageButton;
                Articulo articulo = new Articulo();
            try
            {
                articulo.Id = Convert.ToInt32(button.CommandArgument);

                negocio.bajaLogica(articulo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articulo = new Articulo();
                Button boton = sender as Button;
            try
            {
                articulo.Id = Convert.ToInt32(boton.CommandArgument);
                Response.Redirect("Modificar.aspx?IdOtro=" + articulo.Id,false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int buscarStock(int idArticulo, string talle)
        {
            int stock;
            StockNegocio negocio = new StockNegocio();
            try
            {
                listaStock = negocio.listar();
                int i = 0;
                while (idArticulo != listaStock[i].IdArticulo.Id || talle != listaStock[i].Talle )
                {
                    i++;
                }
                stock = listaStock[i].StockArticulo;

                i = 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return stock;
        }
        protected void ddlTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stock;
            var ddl = sender as DropDownList;
            stock = buscarStock(dgvArticulos.SelectedIndex, ddl.Text );
            //lblStock.Text = stock.ToString();
        }
    } 
}