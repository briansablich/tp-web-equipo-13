using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;

namespace Negocio
{
    public class AccesoDatos
    {
        //ATRIBUTOS PARA CONEXION A DB
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //CTOR. CON ASIGNACIÓN DE OBJETOS A VARIABLES,
        //SETEO DEL TIPO DE COMANDO
        //ESPECIFANDO LA RUTA DE CONEXION Y LA DB
        public AccesoDatos()
        {
            conexion = new SqlConnection();
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            conexion.ConnectionString = "server= .\\SQLEXPRESS; database= CATALOGO_P3_DB; integrated security= true";
        }

        //PROPIEDAD LECTOR PARA ACCEDER AL MISMO DESDE EL EXTERIOR
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //SETEAR CONSULTA SQL
        public void SetearConsulta(string consulta)
        {
            comando.CommandText = consulta;
        }

        //SETEAR PARAMETROS DEL COMANDO PARA UTILIZAR EN CONSULTA SQL
        public void SetearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //ABRIR CONEXION Y EJECUTAR CONSULTA SQL
        public void AbrirConexionEjecutarConsulta()
        {
            try
            {
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ABRIR CONEXION Y EJECUTAR ACCION SQL (NO CONSULTA)
        public void AbrirConexionEjecutarAccion()
        {
            try
            {
                comando.Connection = conexion;

                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CERRAR CONEXION
        public void CerrarConexion()
        {
            if (!(lector == null))
            {
                lector.Close();
            }

            conexion.Close();
        }
    }
}
