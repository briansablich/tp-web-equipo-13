using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCatalogo
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<Articulo> ListaArticulos = articuloNegocio.ObtenerDatos();
            List<Articulo> AgregadosAlCaro = new List<Articulo>();

            if (!IsPostBack)
            {
                foreach (Articulo X in ListaArticulos)
                {
                    Articulo Aux = new Articulo();

                    if (Session["ID" + X.ID] != null)
                    {
                        Aux = ListaArticulos.Find(E => E.ID == int.Parse(Session["ID" + X.ID].ToString()));

                        AgregadosAlCaro.Add(Aux);
                    }
                }

                repCarrito.DataSource = AgregadosAlCaro;
                repCarrito.DataBind();
            }
        }
    }
}