using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Imagen
    {
        [DisplayName("ID")]
        public int IdImagen { get; set; }
        [DisplayName("ID de Articulo")]
        public int IdArt { get; set; }
        [DisplayName("URL Imagen")]
        public string URLImagen { get; set; }
    }
}
