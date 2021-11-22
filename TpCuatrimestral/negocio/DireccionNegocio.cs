using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class DireccionNegocio
    {
        public List<Direccion> listar()
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("");//agregar consulta de bbdd
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.IdDireccion = (int)datos.Lector["Id"];
                    aux.CalleNum = (string)datos.Lector["Calle"];
                    aux.CodPostal = (string)datos.Lector["CodigoPostal"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.Pais = (string)datos.Lector["Pais"];

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
        public void agregar(Direccion aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert Into Direccion(CALLENUM, CODIGOPOSTAL, PROVINCIA, PAIS) Values(@CALLE, @CODIGOPOSTAL, @PROVINCIA, @PAIS)");
                datos.setearParametro("@CALLE", aux.CalleNum);
                datos.setearParametro("@CODIGOPOSTAL", aux.CodPostal);
                datos.setearParametro("@PROVINCIA", aux.Provincia);
                datos.setearParametro("@PAIS", aux.Pais);

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

