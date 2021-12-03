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
    public partial class Productos : System.Web.UI.Page
    {
        public static List<Articulo> listaArticulo { get; set; }

        private List<Articulo> listaCarrito;
        public Articulo articulo { get; set; }
        public List<Stock> listaStock { get; set; }

        string talle;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ArticuloNegocio negocio = new ArticuloNegocio();
                StockNegocio stockNegocio = new StockNegocio();

                listaArticulo = negocio.listar();
                Session.Add("listaArticulo", listaArticulo);
                if (Session["listaCarrito"] == null)
                {
                    listaCarrito = new List<Articulo>();
                    Session.Add("listaCarrito", listaCarrito);
                }
                if (Request.QueryString["id"] != null)
                {
                    
                    string id = Request.QueryString["id"].ToString();
                    listaCarrito = (List<Articulo>)Session["listaCarrito"];
                    listaArticulo = (List<Articulo>)Session["listaArticulo"];
                    if(Session["talle"] == null)
                    {
                        Session.Add("talle", 'S');
                    }

                    string talle = Session["talle"].ToString(); //no obtenemos el valor seleccionado
                    int idArt = int.Parse(id);
                    int cantidad;
                    cantidad = buscarStock(idArt, talle);
                    if (cantidad == 0)
                    {
                        Response.Write("<script language=javascript>alert('SIN STOCK');</script>");
                    }
                    else
                    {
                    Articulo seleccionado = listaArticulo.Find(x => x.Id == int.Parse(id));
                    seleccionado.Stock = new Stock();
                    seleccionado.Stock.Talle = talle;
                    listaCarrito.Add(seleccionado);
                    Session.Add("listaCarrito", listaCarrito);
                    }
                }
            }
        }

        public int buscarStock(int idArt, string talle)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            StockNegocio stockNegocio = new StockNegocio();
            int cantidad, i = 0;
            while (idArt != listaStock[i].IdArticulo.Id || talle != listaStock[i].Talle)
            {
                i++;
            }
            cantidad = listaStock[i].StockArticulo;
            i = 0;
            return cantidad;
        }

        protected void ddlTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            
            /*talle = ddlTalle.SelectedItem.Value;
            Session.Add("talle", talle); VER SI SACAR*/
        }

        protected void btnElegir_Click(object sender, EventArgs e)
        {
            //ver de borrar
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                StockNegocio stockNegocio = new StockNegocio();
                listaArticulo = negocio.listar();
                Session.Add("listaArticulo", listaArticulo);
                if (Session["listaCarrito"] == null)
                {
                    listaCarrito = new List<Articulo>();
                    Session.Add("listaCarrito", listaCarrito);
                }
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    listaCarrito = (List<Articulo>)Session["listaCarrito"];
                    listaArticulo = (List<Articulo>)Session["listaArticulo"];

                    //string talle = ddlTalle.SelectedItem.Value;
                    int idArt = int.Parse(id);
                    if (buscarStock(idArt, talle) == 0)
                    {
                        Response.Write("<script language=javascript>alert('SIN STOCK');</script>");
                        return;
                    }
                    //lblStock.Text = buscarStock(idArt, talle).ToString();
                    listaCarrito.Add(listaArticulo.Find(x => x.Id == int.Parse(id)));
                    Articulo seleccionado = listaArticulo.Find(x => x.Id == int.Parse(id));
                    Session.Add("listaArticulo", listaArticulo);
                    Session.Add("listaCarrito", listaCarrito);
                    Session.Add("articulo", seleccionado);
                    Response.Redirect("DetalleProducto");
                }


            }
        }
    }
}