using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

 namespace negocio
{
    public class VentaNegocio
    {
        public List<Venta> listar()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                Venta aux = new Venta();

                datos.setearConsulta("Select Id,Total,FechaCompra,IdFOP,IdCliente from Venta");
                datos.setearParametro("Id", aux.IdVenta);
                datos.setearParametro("Total",aux.Total);
                datos.setearParametro("FechaCompra", aux.FechaCompra);
                datos.setearParametro("IdFOP", aux.FOP);
                datos.setearParametro("IdCliente",aux.IdCliente);
                datos.ejecutarLectura();

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
