using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Nombre, A.Descripcion, A.Precio, A.UrlImagen, A.Estado, C.Id AS IdCategoria, C.Descripcion AS Categoria FROM Articulo AS A INNER JOIN Categoria AS C ON C.Id = A.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.DescripcionCategoria = new Categoria();
                    aux.DescripcionCategoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.DescripcionCategoria.Descripcion = (string)datos.Lector["Categoria"];
                    lista.Add(aux);
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
        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Articulo(Nombre, Descripcion, Precio, UrlImagen, Estado, IdCategoria) VALUES (@Nombre, @Descripcion, @Precio, @UrlImagen, @Estado, @IdCategoria)");
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@UrlImagen", articulo.UrlImagen);
                datos.setearParametro("@Estado", 1);
                datos.setearParametro("@IdCategoria", articulo.DescripcionCategoria.Descripcion);
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
