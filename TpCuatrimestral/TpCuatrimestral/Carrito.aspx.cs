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
    public partial class Carrito : System.Web.UI.Page
    {
        private List<Articulo> listaCarrito;
        List<Stock> listaStock = new List<Stock>();
        protected void Page_Load(object sender, EventArgs e)
        {
            dgvCarrito.DataSource = Session["listaCarrito"];
            dgvCarrito.DataBind();
            listaCarrito = (List<Articulo>)Session["listaCarrito"];
            decimal total = 0;
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                Stock aux = new Stock();
                aux.StockArticulo = listaCarrito[i].Stock.StockArticulo;
                aux.Talle = listaCarrito[i].Talle.Talle;
                aux.IdArticulo = new Articulo();
                aux.IdArticulo.Id = listaCarrito[i].Id;
                listaStock.Add(aux);
            }
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

            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                StockNegocio negocio = new StockNegocio();
                negocio.descontarStock(listaStock[i]);
            }
            Session["listaCarrito"] = null;
            dgvCarrito.DataSource = Session["listaCarrito"];

            dgvCarrito.DataBind();
            Response.Redirect("Pagar.aspx");
        }
    }
}