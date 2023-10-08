using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Marca
    {
        [DisplayName("ID")]
        public int IdMarca { get; set; }
        [DisplayName("Marca")]
        public string NombreMarca { get; set; }

        public override string ToString()
        {
            return NombreMarca;
        }
    }
}
