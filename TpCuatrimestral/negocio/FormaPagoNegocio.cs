﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class FormaPagoNegocio
    {
            public List<FormaDePago> listar()
            {
                List<FormaDePago> lista = new List<FormaDePago>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("SELECT Id, Tipo FROM FOP");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        FormaDePago aux = new FormaDePago();
                        aux.IdFP = (int)datos.Lector["Id"];
                        aux.Tipo = (string)datos.Lector["Tipo"];
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
