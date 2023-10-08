using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        //LISTA DE MARCAS PARA CARGAR COMBOBOX
        private List<Marca> marcas = new List<Marca>();

        //OBTENER TODOS LOS DATOS
        public List<Marca> ObtenerDatos()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.AbrirConexionEjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.IdMarca = (int)datos.Lector["Id"];

                    //CHECK NULL
                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        aux.NombreMarca = (string)datos.Lector["Descripcion"];
                    }

                    marcas.Add(aux);
                }

                return marcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
