using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebCatalogo
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }                     // la clase tiene un atributo lista de articulos
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();            // creamos objeto negocio en la carga
            ListaArticulos = articuloNegocio.ObtenerDatos();                    // cargamos a la lista de articulos desde la BD a traves de negocio

            if (!IsPostBack)
            {
                repArticulosCards.DataSource = ListaArticulos;                  // cargamos la lista en el repeater si fue la primer carga
                repArticulosCards.DataBind();                                   // enlazamos los datos de la lista
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string valorID = ((Button)sender).CommandArgument;

            Response.Redirect("detalleArticulo.aspx?id=" + valorID, false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo Aux = new Articulo();
            
            int valorID = int.Parse(((Button)sender).CommandArgument);
            List<Articulo> ListaArticulos = articuloNegocio.ObtenerDatos();

            foreach (Articulo X in ListaArticulos)
            {

                if (valorID != 0)
                {
                    Aux = ListaArticulos.Find(E => E.ID == valorID);
                }

            }

            if (Session["carroSession"] != null)
            {
                List<Articulo> auxCarro = (List<Articulo>)Session["carroSession"];
                auxCarro.Add(Aux);

            }
            else
            {
                List<Articulo> auxCarro = new List<Articulo>();
                auxCarro.Add(Aux);
                Session["carroSession"] = auxCarro;
            }
        }
    }
}