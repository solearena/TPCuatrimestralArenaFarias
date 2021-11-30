﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //ver de agregar tipo de usuario en la BD
                datos.setearConsulta("Select Id, TipoUsuario from Usuario where NombreUsuario = @user and Contraseña = @pass ");
                datos.setearParametro("@user",usuario.NombreUsuario);
                datos.setearParametro("@pass", usuario.Contrasenia);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;

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

   
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("");//agregar consulta de bbdd
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    /*Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.DescripcionMarca = new Marca();
                    aux.DescripcionMarca.Id = (int)datos.Lector["Id"];
                    aux.DescripcionMarca.Descripcion = (string)datos.Lector["Marca"];
                    aux.DescripcionCategoria = new Categoria();
                    aux.DescripcionCategoria.Id = (int)datos.Lector["Id"];
                    aux.DescripcionCategoria.Descripcion = (string)datos.Lector["Categoria"];
                    lista.Add(aux);*/

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
        public bool existeUsuario(string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select NombreUsuario from USUARIO where NombreUsuario = @usuario ");
                datos.setearParametro("@usuario", usuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return true;
                }

                return false;
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
        public void agregar(Usuario aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into Usuario(NombreUsuario, Contraseña,TipoUsuario) Values(@NOMBREUSUARIO, @CONTRASEÑA,@TIPOUSUARIO)");
                datos.setearParametro("@NOMBREUSUARIO",aux.NombreUsuario);
                datos.setearParametro("@CONTRASEÑA",aux.Contrasenia);
                datos.setearParametro("@TIPOUSUARIO", 1);

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
        public void modificar(Usuario aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Usuario SET NombreUsuario = @NOMBREUSUARIO, Contraseña = @CONTRASEÑA WHERE Id = @Id" );
                datos.setearParametro("@Id", aux.IdUsuario);
                datos.setearParametro("@NOMBREUSUARIO", aux.NombreUsuario);
                datos.setearParametro("@CONTRASEÑA", aux.Contrasenia);
                datos.setearParametro("@TIPOUSUARIO", 1);

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
