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
        List<Stock> listaStock = new List<Stock>();
        public List<ElementoCarrito> listaCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            StockNegocio negocio = new StockNegocio();
            int stock = 0;
            dgvCarrito.DataSource = Session["listaCarrito2"];
            dgvCarrito.DataBind();
            //listaCarrito = (List<Articulo>)Session["listaCarrito"];
            decimal total = 0;
            //for (int i = 0; i < dgvcarrito.rows.count; i++)
            //{
            //    stock aux = new stock();
            //    aux.talle = listacarrito[i].stock.talle;
            //    aux.idarticulo = new articulo();
            //    aux.idarticulo.id = listacarrito[i].id;
            //    stock = negocio.buscarstock(aux.idarticulo.id,aux.talle);
            //    aux.stockarticulo = stock;
            //    listastock.add(aux);
            //}
            //session.add("listastock",listastock);
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                total += (Convert.ToDecimal(dgvCarrito.Rows[i].Cells[2].Text)* Convert.ToDecimal(dgvCarrito.Rows[i].Cells[3].Text));
            }
            lblTotal.Text = Convert.ToString(total);
            Session.Add("totalAPagar", lblTotal.Text);
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = e.ToString();

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

            
            //dgvCarrito.DataSource = Session["listaCarrito"];
            //dgvCarrito.DataBind();
            
            Response.Redirect("Pagar.aspx");
        }

        protected void imgTacho_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = sender as ImageButton;
            ElementoCarrito elemento = new ElementoCarrito();
            try
            {
                elemento.IdArticulo = new Articulo();
                elemento.IdArticulo.Id = Convert.ToInt32(button.CommandArgument);
                listaCarrito = (List<ElementoCarrito>)Session["listaCarrito2"];
                int i = 0;
                int index = 0;
                foreach(dominio.ElementoCarrito item in listaCarrito)
                {
                    if(elemento.IdArticulo.Id == item.IdArticulo.Id)
                    {
                        index = i;
                    }
                    i++;
                }
                listaCarrito.RemoveAt(index);
                Session.Add("listaCarrito2", listaCarrito);
                Response.Redirect("Carrito.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}