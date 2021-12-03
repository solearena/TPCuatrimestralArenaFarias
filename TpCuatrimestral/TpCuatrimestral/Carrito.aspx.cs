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
    public partial class Carrito : System.Web.UI.Page
    {
        private List<Articulo> listaCarrito;
        List<Stock> listaStock = new List<Stock>();
        protected void Page_Load(object sender, EventArgs e)
        {
            StockNegocio negocio = new StockNegocio();
            int stock = 0;
            dgvCarrito.DataSource = Session["listaCarrito"];
            dgvCarrito.DataBind();
            listaCarrito = (List<Articulo>)Session["listaCarrito"];
            decimal total = 0;
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                Stock aux = new Stock();
                aux.Talle = listaCarrito[i].Stock.Talle;
                aux.IdArticulo = new Articulo();
                aux.IdArticulo.Id = listaCarrito[i].Id;
                stock = negocio.buscarStock(aux.IdArticulo.Id,aux.Talle);
                aux.StockArticulo = stock;
                listaStock.Add(aux);
            }
            Session.Add("listaStock",listaStock);
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgvCarrito.Rows[i].Cells[1].Text);
            }
            lblTotal.Text = Convert.ToString(total);
            
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = e.ToString();

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

            Session["listaCarrito"] = null;
            dgvCarrito.DataSource = Session["listaCarrito"];
            dgvCarrito.DataBind();
            
            Response.Redirect("Pagar.aspx");
        }
    }
}