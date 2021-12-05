using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ElementoCarritoNegocio
    {
        public List<ElementoCarrito> listar(int idVenta)
        {
            List<ElementoCarrito> lista = new List<ElementoCarrito>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Nombre, EC.Cantidad, EC.Talle, EC.PrecioUnitario FROM ElementoCarrito AS EC INNER JOIN Articulo AS A ON A.Id = EC.IdArticulo WHERE IdVenta =" + idVenta + "");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ElementoCarrito aux = new ElementoCarrito();
                    aux.IdArticulo = new Articulo();
                    aux.IdArticulo.Nombre = (string)datos.Lector["Nombre"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Talle = (string)datos.Lector["Talle"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
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

        public void guardar(ElementoCarrito aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ELEMENTOCARRITO(IDVENTA, IDARTICULO, CANTIDAD, TALLE, PRECIOUNITARIO) VALUES(@IdVenta, @IdArticulo,@Cantidad,@Talle,@PrecioUnitario)");
                datos.setearParametro("@IdVenta",aux.IdVenta.Id);
                datos.setearParametro("@IdArticulo", aux.IdArticulo.Id);
                datos.setearParametro("@Cantidad", aux.Cantidad);
                datos.setearParametro("@Talle", aux.Talle);
                datos.setearParametro("@PrecioUnitario", aux.PrecioUnitario);
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
