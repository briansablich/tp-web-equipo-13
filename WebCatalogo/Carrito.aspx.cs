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
            calcularTotales();
            
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
                AgregadosAlCarro = copiaCarro;
                repCarrito.DataSource = AgregadosAlCarro;
                repCarrito.DataBind();
                calcularTotales();
            }

            if (e.CommandName == "VerDetalle")
            {
                string valorID = (string)e.CommandArgument;

                Response.Redirect("detalleArticulo.aspx?id=" + valorID, false);
            }
        }
    
        protected void calcularTotales()
        {
            if(AgregadosAlCarro == null)
            {
                return;
            }

            decimal total = 0;

            foreach (Articulo item in AgregadosAlCarro) 
            {
                total += item.PrecioArt; //suma el precio de todos los articulos
            }
            GridViewRow filaNueva = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal); //agrega una nueva fila de tipo footer

            TableCell celda = new TableCell(); // crea una celda

            celda.ColumnSpan = 6;
            celda.HorizontalAlign = HorizontalAlign.Center;
            celda.Font.Bold = true;
            celda.Text = "Cantidad articulos: " + AgregadosAlCarro.Count() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Importe total: $" + total.ToString("N2");
            
            filaNueva.Cells.Add(celda); //agrega la celda a la fila nueva

            if(repCarrito.Controls.Count > 0)
            {

            repCarrito.Controls[AgregadosAlCarro.Count - 1].Controls.Add(filaNueva); //agrega la fila en el indice ultimo del repeater
            }

        }

    }
}