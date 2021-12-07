using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpCuatrimestral
{
    public partial class ErroStock : System.Web.UI.Page
    {
        public List<string> lista { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
                lblMensaje.Text = Session["error"].ToString();

            if (Session["listaSinStock"] != null)
            {
                lista = (List<string>)Session["listaSinStock"];
                dgvSinStock.DataSource = lista;
                dgvSinStock.DataBind();
                
            }
            Session["listaSinStock"] = null;
        }
    }
}