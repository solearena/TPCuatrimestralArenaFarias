using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class CarritoNegocio
    {
        public List<Carrito> listar()
        {
            List<Carrito> lista = new List<Carrito>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("");//agregar consulta de bbdd
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Carrito aux = new Carrito();
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
        public void agregar(Carrito aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("");
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
