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
    public partial class Pagar : System.Web.UI.Page
    {
        public List<Stock> listaStock { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Para poder abonar debes loguearte. Gracias!");
                Response.Redirect("Error.aspx", false);
            }
            listaStock = (List<Stock>)Session["listaStock"];



        }

        protected void imgBanco_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            foreach (dominio.Stock item in listaStock) 
            {
                StockNegocio negocio = new StockNegocio();
                negocio.descontarStock(listaStock[i], 1);
                i++;
            }
            Session["listaCarrito"] = null;
        }

        protected void imgDinero_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            foreach(dominio.Stock  item in listaStock)
            {
                StockNegocio negocio = new StockNegocio();
                negocio.descontarStock(listaStock[i], 1);
                i++;
            }
            Session["listaCarrito"] = null;
        }

        protected void imgMP_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            foreach (dominio.Stock item in listaStock)
            {
                StockNegocio negocio = new StockNegocio();
                negocio.descontarStock(listaStock[i], 1);
                i++;
            }
            Session["listaCarrito"] = null;
        }
    }
}