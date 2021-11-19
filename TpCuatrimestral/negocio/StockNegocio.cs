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
                datos.setearConsulta("SELECT S.Id, S.IdArticulo, S.StockArticulo, S.Talle FROM Stock AS S INNER JOIN Articulo AS A ON A.Id = S.IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Stock aux = new Stock();
                    aux.Id = (int)datos.Lector["Id"];
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
    }
}
