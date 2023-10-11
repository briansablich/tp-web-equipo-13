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
        public List<Imagen> ImgsDelArticulo = new List<Imagen>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            ListaImagenes = imagenNegocio.ObtenerDatos();


            //DESARROLLO PARA AGRUPAR LAS IMG DEL ARTICULO...

            foreach (Dominio.Imagen img in ListaImagenes)
            {
                if (img.IdImagen == Convert.ToInt32(Request.QueryString["id"])) 
                    ImgsDelArticulo.Add(img);
            }


        }
    }
}