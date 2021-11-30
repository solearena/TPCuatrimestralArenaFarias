using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class StockNegocio
    {
        public List<Stock> listar()
        {
            List<Stock> lista = new List<Stock>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT S.IdArticulo, S.StockArticulo, S.Talle FROM Stock AS S INNER JOIN Articulo AS A ON A.Id = S.IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Stock aux = new Stock();
                    //aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = new Articulo();
                    aux.IdArticulo.Id = (int)datos.Lector["IdArticulo"];
                    aux.StockArticulo = (int)datos.Lector["StockArticulo"];
                    aux.Talle = (string)datos.Lector["Talle"];
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
        public List<Stock> cargarStockPorArticulo(int id)
        {
            List<Stock> lista = new List<Stock>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT S.IdArticulo, S.StockArticulo, S.Talle FROM Stock AS S INNER JOIN Articulo AS A ON A.Id = S.IdArticulo WHERE S.IdArticulo = "+@id +"");
                datos.setearParametro("IdArticulo",id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Stock aux = new Stock();
                    //aux.Id = (int)datos.Lector["Id"];
                    aux.StockArticulo = (int)datos.Lector["StockArticulo"];
                    aux.Talle = (string)datos.Lector["Talle"];
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
        public void agregar(Stock aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Stock(IdArticulo, StockArticulo, Talle) VALUES ((Select Id From Articulo WHERE Id = (Select max(Id) From Articulo)), @StockArticulo, @Talle)");
                datos.setearParametro("@StockArticulo", aux.StockArticulo);
                datos.setearParametro("@Talle", aux.Talle);
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
        public void modificar(Stock aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Stock SET StockArticulo = @StockArticulo WHERE IdArticulo = @IdArticulo AND Talle = @Talle");
                datos.setearParametro("@IdArticulo", aux.IdArticulo.Id);
                datos.setearParametro("@StockArticulo", aux.StockArticulo);
                datos.setearParametro("@Talle", aux.Talle);
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
        public void descontarStock(Stock aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Stock SET StockArticulo = @StockArticulo - 1 WHERE IdArticulo = @IdArticulo AND Talle = @Talle");
                datos.setearParametro("@IdArticulo", aux.IdArticulo.Id);
                datos.setearParametro("@StockArticulo", aux.StockArticulo);
                datos.setearParametro("@Talle", aux.Talle);
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
