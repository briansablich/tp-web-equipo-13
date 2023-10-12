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
            AgregadosAlCarro = (List<Articulo>)Session["carroSession"];

            repCarrito.DataSource = AgregadosAlCarro;
            repCarrito.DataBind();
        }

        protected void repCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar") //Pregunta si "Eliminar" disparó el Item Command
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                List<Articulo> copiaCarro = new List<Articulo>(AgregadosAlCarro); //Se crea y carga la lista auxiliar

                Articulo articuloAEliminar = copiaCarro.FirstOrDefault(a => a.ID == idArticulo); //Busca el articulo en la lista

                if (articuloAEliminar != null)
                {
                    copiaCarro.Remove(articuloAEliminar); //Elimina el articulo de la copia
                }

                Session["carroSession"] = copiaCarro;   //Vuelve a cargar el carro
                
                repCarrito.DataSource = copiaCarro;
                repCarrito.DataBind();
            }

            if (e.CommandName == "VerDetalle")
            {
                int valorID = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("detalleArticulo.aspx?id=" + valorID, false);
            }
        }
    }
}