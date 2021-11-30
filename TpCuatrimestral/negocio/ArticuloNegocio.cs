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
                datos.setearConsulta("SELECT A.Id, A.Nombre, A.Descripcion, A.Precio, A.UrlImagen, A.Estado, C.Id AS IdCategoria, C.Descripcion AS Categoria FROM Articulo AS A INNER JOIN Categoria AS C ON C.Id = A.IdCategoria where A.Estado=1");
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
                    aux.IdCategoria = new Categoria();
                    aux.IdCategoria.Id= (int)datos.Lector["IdCategoria"];
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
                datos.setearParametro("@IdCategoria", articulo.IdCategoria.Id);
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
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Articulo SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, UrlImagen = @UrlImagen, Estado = @Estado, IdCategoria = @IdCategoria WHERE Id = @Id");
                datos.setearParametro("@Id", articulo.Id);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@UrlImagen", articulo.UrlImagen);
                datos.setearParametro("@Estado", articulo.Estado);
                datos.setearParametro("@IdCategoria", articulo.IdCategoria.Id);
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
        public void eliminar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Articulo WHERE Id = @Id");
                datos.setearParametro("@Id", articulo.Id);
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
        public void bajaLogica(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Articulo SET Estado = 0 WHERE Id = @Id");
                datos.setearParametro("@Id", articulo.Id);
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
        public List<Articulo> listar2()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Nombre, A.Descripcion, A.Precio, A.UrlImagen, A.Estado, C.Id AS IdCategoria, C.Descripcion AS Categoria, S.StockArticulo, S.Talle FROM Articulo AS A INNER JOIN Stock AS S ON A.Id = S.IdArticulo INNER JOIN Categoria AS C ON C.Id = A.IdCategoria WHERE A.Estado=1 AND S.StockArticulo > 0");
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
                    aux.IdCategoria = new Categoria();
                    aux.IdCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.DescripcionCategoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Stock = new Stock();
                    aux.Stock.StockArticulo = (int)datos.Lector["StockArticulo"];
                    aux.Talle = new Stock();
                    aux.Talle.Talle = (string)datos.Lector["Talle"];
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
    }
}
