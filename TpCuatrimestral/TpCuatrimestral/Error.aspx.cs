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
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
                lblMensaje.Text = Session["error"].ToString();
            List<string> lista = new List<string>();

            if (Session["listaSinStock"] != null)
            {
                lista = (List<string>)Session["listaSinStock"];
                foreach(string item in lista)
                {
                    lblStock.Text = item;
                }
            }
            Session["listaSinStock"] = null;
        }
    }
}