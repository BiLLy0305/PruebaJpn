using MySql.Data.MySqlClient;
using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Services
{
    public class serviceUsuario : Conexion
    {
        public bool existeUsuario(Usuario nUsuario)
        {
            try
            {
                Usuario logeado = new Usuario();
                logeado = nUsuario;
                Conectar();
                string query = @"Select codigo,nombre,email,fechaNacimiento,passw,tokenR
                                From Usuarios
                                Where email=@email and passw=@passw";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@email", nUsuario.email);
                    cmd.Parameters.AddWithValue("@passw", nUsuario.passw);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        nUsuario.codigo = Convert.ToInt32(dr["codigo"]);
                        nUsuario.nombre = Convert.ToString(dr["nombre"]);
                        return true;
                    }
                }
                Desconectar();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool existeUsuarioRee(Usuario nUsuario)
        {
            try
            {
                Usuario logeado = new Usuario();
                logeado = nUsuario;
                Conectar();
                string query = @"Select codigo,nombre,email,fechaNacimiento,passw,tokenR
                                From Usuarios
                                Where email=@email and fechaNacimiento=@fechaN";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@email", nUsuario.email);
                    cmd.Parameters.AddWithValue("@fechaN", nUsuario.fechaNacimiento);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        nUsuario.codigo = Convert.ToInt32(dr["codigo"]);
                        nUsuario.nombre = Convert.ToString(dr["nombre"]);
                        return true;
                    }
                }
                Desconectar();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool actualizarToken(Usuario nUsuario)
        {
            try
            {
                Usuario logeado = new Usuario();
                logeado = nUsuario;
                Conectar();
                string query = @"Update Usuarios set tokenR=@token
                                 Where email=@email";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                  
                    cmd.Parameters.AddWithValue("@email", nUsuario.email);
                    cmd.Parameters.AddWithValue("@token", nUsuario.tokenR);

                    int resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        return true;
                    }
                }
                Desconectar();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool actualizaPass(Usuario nUsuario)
        {
            try
            {
                Usuario logeado = new Usuario();
                logeado = nUsuario;
                Conectar();
                string query = @"Update Usuarios set tokenR='', passw=@passw
                                 Where tokenR=@token";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    
                    cmd.Parameters.AddWithValue("@passw", nUsuario.passw);
                    cmd.Parameters.AddWithValue("@token", nUsuario.tokenR);

                    int resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        return true;
                    }
                }
                Desconectar();
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}