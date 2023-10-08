using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Categoria
    {
        [DisplayName("ID")]
        public int IdCategoria { get; set; }
        [DisplayName("Categoria")]
        public string NombreCategoria { get; set; }

        public override string ToString()
        {
            return NombreCategoria;
        }
    }
}
