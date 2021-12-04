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
                datos.setearConsulta("Select V.Id, V.Total, V.FechaCompra, F.Tipo, V.IdCliente, V.Despachado FROM Venta AS V INNER JOIN FOP AS F ON F.Id = V.IdFOP ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Total = (decimal)datos.Lector["Total"];
                    aux.FOP = new FormaDePago();
                    aux.FOP.Tipo = (string)datos.Lector["Tipo"];
                    aux.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    aux.IdCliente = new Cliente();
                    aux.IdCliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Despachado = (bool)datos.Lector["Despachado"];
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
                datos.setearConsulta("INSERT INTO Venta(Total, FechaCompra, IdFOP, IdCliente, Despachado) VALUES (@Total, GETDATE(), @IdFOP, @IdCliente, 0)");
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
        public int buscarUltimaVenta()
        {
            AccesoDatos datos = new AccesoDatos();
            Venta aux = new Venta();
            try
            {
                datos.setearConsulta("SELECT MAX(Id) AS Id FROM Venta");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                }

                return aux.Id;
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
        public void despachar(Venta aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Venta SET Despachado = 1 WHERE Id = @Id");
                datos.setearParametro("@Id", aux.Id);
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
        public List<Venta>listaPorCliente(int idCliente)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT V.Id, V.Total, V.FechaCompra, F.Tipo, V.Despachado FROM Venta AS V INNER JOIN FOP AS F ON F.Id = V.IdFOP WHERE V.IdCliente=" + idCliente + "");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Total = (decimal)datos.Lector["Total"];
                    aux.FOP = new FormaDePago();
                    aux.FOP.Tipo = (string)datos.Lector["Tipo"];
                    aux.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    aux.Despachado = (bool)datos.Lector["Despachado"];
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
