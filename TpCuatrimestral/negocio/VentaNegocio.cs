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
                datos.setearConsulta("Select V.Id, V.Total, V.FechaCompra, F.Tipo, V.IdCliente FROM Venta AS V INNER JOIN FOP AS F ON F.Id = V.IdFOP ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Total = (decimal)datos.Lector["Total"];
                    aux.FOP = new FormaDePago();
                    aux.FOP.Tipo = (string)datos.Lector["Tipo"];
                    aux.FechaCompra = (string)datos.Lector["FechaCompra"];
                    aux.IdCliente = new Cliente();
                    aux.IdCliente.IdCliente = (int)datos.Lector["IdCliente"];
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
        public void guardar(Venta aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Venta(Total, FechaCompra, IdFOP, IdCliente) VALUES (@Total, GETDATE(), @IdFOP, @IdCliente)");
                datos.setearParametro("@Total", aux.Total);
                datos.setearParametro("@IdFOP", aux.FOP.IdFP);
                datos.setearParametro("IdCliente", aux.IdCliente.IdCliente);
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
