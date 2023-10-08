using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        //LISTA DE IMAGENES PARA CARGAR PICTUREBOX
        private List<Imagen> imagenes = new List<Imagen>();

        //OBTENER TODOS LOS DATOS
        public List<Imagen> ObtenerDatos()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdArticulo, ImagenURL FROM IMAGENES");
                datos.AbrirConexionEjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();

                    aux.IdImagen = (int)datos.Lector["Id"];
                    aux.IdArt = (int)datos.Lector["IdArticulo"];
                    aux.URLImagen = (string)datos.Lector["ImagenURL"];

                    imagenes.Add(aux);
                }

                return imagenes;
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

        //AGREGAR O MODIFICAR DECIDIENDO POR BANDERA BOOLEANA
        //SETEANDO LA CONSULTA DEPENDIENDO EL CASO
        public void Agregar_ModificarDatos(Imagen aux, bool esAgregar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //SI ES TRUE AGREGA
                if (esAgregar)
                {
                    datos.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenURL) VALUES (@IdArt, @URLImagen)");
                }
                //SI ES FALSE MODIFICA
                else
                {
                    datos.SetearConsulta("UPDATE IMAGENES SET IdArticulo = @IdArt, ImagenURL = @URLImagen WHERE Id = @Id");
                    //SE COLOCA DENTRO DEL ELSE PORQUE FORMA PARTE DEL
                    //UPDATE EN EL WHERE
                    datos.SetearParametro("@Id", aux.IdImagen);
                }

                datos.SetearParametro("@IdArt", aux.IdArt);
                datos.SetearParametro("@URLImagen", aux.URLImagen);

                datos.AbrirConexionEjecutarAccion();
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

        //ELIMINAR DATOS
        public void EliminarDatos(int IdImagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("DELETE FROM IMAGENES WHERE Id = @Id");
                datos.SetearParametro("@Id", IdImagen);

                datos.AbrirConexionEjecutarAccion();
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
