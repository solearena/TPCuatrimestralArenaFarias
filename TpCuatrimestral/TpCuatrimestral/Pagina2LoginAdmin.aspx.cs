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
        public List<Stock> listaStock2 { get; set; }

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
        private Stock cargarStock(int idArt)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                StockNegocio stockNegocio = new StockNegocio();
                Stock stock = new Stock();
                int i = 0;
                while (idArt != listaStock[i].IdArticulo.Id)
                {
                    i++;
                }
                //stock.Id = listaStock[i].Id;
                stock.IdArticulo = new Articulo();
                stock.IdArticulo.Id = listaStock[i].IdArticulo.Id;
                stock.Talle = listaStock[i].Talle;
                stock.StockArticulo = listaStock[i].StockArticulo;
                
                i = 0;
                return stock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stock;
            var ddl = sender as DropDownList;
            stock = buscarStock(dgvArticulos.SelectedIndex, ddl.Text );
            //lblStock.Text = stock.ToString();
        }

        protected void btnStock_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32((sender as Button).CommandArgument);

            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", "ModalStock('" + "MostrarStock" + "');", true);

            Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            StockNegocio stockneg = new StockNegocio();
            Stock stock = new Stock();

            stock = cargarStock(id);

            listaStock2 = stockneg.cargarStockPorArticulo(id);
            dgvStock.DataSource = listaStock2;
            dgvStock.DataBind();           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this,typeof(Page),"cerrar", "ModalStock('" + "Cerrar" + "');", true);
        }
    } 
}