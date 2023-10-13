using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCatalogo
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public List<Articulo> AgregadosAlCarro;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lblContadorCarrito_PreRender(object sender, EventArgs e)
        {
            if ((List<Articulo>)Session["carroSession"] != null)
            {
                AgregadosAlCarro = (List<Articulo>)Session["carroSession"];
                lblContadorCarrito.Text = AgregadosAlCarro.Count.ToString();
            }
            else
            {
                lblContadorCarrito.Text = "0";
            }

        }

        protected void lblTotal_PreRender(object sender, EventArgs e)
        {
            decimal total = 0;

            if ((List<Articulo>)Session["carroSession"] != null)
            {
                AgregadosAlCarro = (List<Articulo>)Session["carroSession"];

                foreach (Articulo art in AgregadosAlCarro)
                {
                    total += art.PrecioArt;
                }

                lblTotal.Text = "$" + total.ToString("N2");
            }
            else
            {
                lblTotal.Text = "$0";
            }
        }
    }
}