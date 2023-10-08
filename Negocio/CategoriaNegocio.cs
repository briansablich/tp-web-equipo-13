using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        //LISTA DE CATEGORIAS PARA CARGAR COMBOBOX
        private List<Categoria> categorias = new List<Categoria>();

        //OBTENER TODOS LOS DATOS
        public List<Categoria> ObtenerDatos()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.AbrirConexionEjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

                    aux.IdCategoria = (int)datos.Lector["Id"];

                    //CHECK NULL
                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        aux.NombreCategoria = (string)datos.Lector["Descripcion"];
                    }

                    categorias.Add(aux);
                }

                return categorias;
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
