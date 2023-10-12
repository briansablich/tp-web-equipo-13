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

        private List<Articulo> AgregadosAlCarro;
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<Articulo> ListaArticulos = articuloNegocio.ObtenerDatos();


            if (!IsPostBack)
            {
                AgregadosAlCarro = new List<Articulo>();
   
                foreach (Articulo X in ListaArticulos)
                {
                    Articulo Aux = new Articulo();

                    if (Session["ID" + X.ID] != null)
                    {
                        Aux = ListaArticulos.Find(E => E.ID == int.Parse(Session["ID" + X.ID].ToString()));

                        AgregadosAlCarro.Add(Aux);
                    }
                }
            }
                if(Session["carroSession"] == null)
                {
                    AgregadosAlCarro = new List<Articulo>();
                }
            else
            {
                AgregadosAlCarro = (List<Articulo>)Session["carroSession"];

            }
                
                repCarrito.DataSource = Session["carroSession"];
                repCarrito.DataBind();
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int idArticulo = int.Parse(btnEliminar.CommandArgument);

            List<Articulo> copiaCarro = new List<Articulo>(AgregadosAlCarro);

            Articulo articuloAEliminar = copiaCarro.FirstOrDefault(a => a.ID == idArticulo);

            if (articuloAEliminar != null)
            {
                copiaCarro.Remove(articuloAEliminar);
            }

            Session["carroSession"] = copiaCarro;
            repCarrito.DataSource = copiaCarro;
            repCarrito.DataBind();
        }
    }
}