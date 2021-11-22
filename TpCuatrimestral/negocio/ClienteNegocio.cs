using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("");//agregar consulta de bbdd
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    /*aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.DescripcionMarca = new Marca();
                    aux.DescripcionMarca.Id = (int)datos.Lector["Id"];
                    aux.DescripcionMarca.Descripcion = (string)datos.Lector["Marca"];
                    aux.DescripcionCategoria = new Categoria();
                    aux.DescripcionCategoria.Id = (int)datos.Lector["Id"];
                    aux.DescripcionCategoria.Descripcion = (string)datos.Lector["Categoria"];
                    lista.Add(aux);*/

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Cliente aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Cliente (Nombre, Apellido, Dni, FechaNac, Celular, Email, IdDireccion, IdUsuario) VALUES (@NOMBRE, @APELLIDO, @DNI, @FECHANACIMIENTO, @CELULAR, @EMAIL, (Select Id From Direccion WHERE Id = (Select max(Id) From Direccion)), (Select Id From Usuario WHERE Id = (Select max(Id) From Usuario)))");
                datos.setearParametro("@NOMBRE",aux.Nombre);
                datos.setearParametro("@APELLIDO", aux.Apellido);
                datos.setearParametro("@DNI", aux.DNI);
                datos.setearParametro("@FECHANACIMIENTO", aux.FechaNacimiento);
                datos.setearParametro("@CELULAR", aux.Celular);
                datos.setearParametro("@EMAIL", aux.Email);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

