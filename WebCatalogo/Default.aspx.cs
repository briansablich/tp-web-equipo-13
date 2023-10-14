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
                lblVacio.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
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

        protected void btnBuscador_Click(object sender, EventArgs e)
        {
            //Button Buscador = (Button)sender;
            string filtrada = txtBuscador.Text;

            if(filtrada.Length < 2 || filtrada == null)
            {
                txtBuscador.Text = string.Empty;
                lblVacio.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                repArticulosCards.DataSource = ListaArticulos;
                repArticulosCards.DataBind();
                return;
            }
            List<Articulo> listaFiltrada = new List<Articulo>();
            listaFiltrada.Clear();

            foreach (Articulo Aux in ListaArticulos)
            {     
                if(Aux.MarcaArt.NombreMarca.Contains(filtrada) || Aux.DescripcionArt.Contains(filtrada) || Aux.NombreArt.Contains(filtrada))
                {
                    listaFiltrada.Add(Aux);
                }
                    
            }
            if (listaFiltrada.Count < 1)
            {
                lblVacio.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            }
            else
            {
            lblVacio.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
            repArticulosCards.DataSource = listaFiltrada;
            repArticulosCards.DataBind();

        }
    }
}