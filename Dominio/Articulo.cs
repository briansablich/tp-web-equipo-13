using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Articulo
    {
        public int ID { get; set; }
        [DisplayName("Código")]
        public string CodArt { get; set; }
        [DisplayName("Nombre")]
        public string NombreArt { get; set; }
        [DisplayName("Descripción")]
        public string DescripcionArt { get; set; }
        [DisplayName("Marca")]
        public Marca MarcaArt { get; set; }
        [DisplayName("Categoria")]
        public Categoria CategoriaArt { get; set; }
        [DisplayName("Precio")]
        public decimal PrecioArt { get; set; }
        [DisplayName("Imagen")]
        public List<Imagen> ImagenArt { get; set; }

        //CTOR. CON ASIGNACIÓN DE OBJETOS A VARIABLES DE OTRAS CLASES
        public Articulo()
        {
            MarcaArt = new Marca();
            CategoriaArt = new Categoria();
            ImagenArt = new List<Imagen>();
        }
    }
}
