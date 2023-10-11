using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebCatalogo
{
    public partial class detalleArticulo : System.Web.UI.Page
    {
        public string idArticuloUrl { get; set; }
        public List<Imagen> ListaImagenes = new List<Imagen>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            ListaImagenes = imagenNegocio.ObtenerDatos();

            idArticuloUrl = Request.QueryString["id"];         // captura el id del articulo a mostrar detalle, que llega por url 


            //desarrollo para agrupar las imagenes del articulo

            //List<Imagen> imgDeArticulo = new List<Imagen>();

            //foreach (Dominio.Imagen img in ListaImagenes)
            //{
            //    if (img.IdImagen == (int)Request.QueryString["id"]) imgDeArticulo.Add(IdImagen);
            //}
        }
    }
}