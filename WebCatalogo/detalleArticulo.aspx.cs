using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.Configuration;

namespace WebCatalogo
{
    public partial class detalleArticulo : System.Web.UI.Page
    {
        public int idArticuloUrl { get; set; }

        public List<Imagen> ListaImagenes = new List<Imagen>();

        public List<Imagen> ImgsDelArticulo = new List<Imagen>();

        public List<Articulo> Articulos = new List<Articulo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            ListaImagenes = imagenNegocio.ObtenerDatos();

            idArticuloUrl = int.Parse(Request.QueryString["id"]);         // capturamos el id del art a mostrar detalle


            //DESARROLLO PARA AGRUPAR LAS IMG DEL ARTICULO...
            ImgsDelArticulo = ListaImagenes.FindAll(x => x.IdArt == idArticuloUrl);

            repCarouselImagenes.DataSource = ImgsDelArticulo;
            repCarouselImagenes.DataBind();


            //DESARROLLO PARA LA DESCRIPCION
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulos = articuloNegocio.ObtenerDatos();
            Articulo aux = new Articulo();
            aux = Articulos.Find(x => x.ID == idArticuloUrl);

            lblNombre.Text = aux.NombreArt.ToString();
            lblDescripcion.Text = aux.DescripcionArt.ToString();
            lblPrecio.Text = '$' + aux.PrecioArt.ToString();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //CARGAR ARTICULO AL CARRITO, TERMINAR
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}