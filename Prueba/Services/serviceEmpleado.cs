using MySql.Data.MySqlClient;
using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Services
{
    public class serviceEmpleado : Conexion
    {
        public IEnumerable<Empleado> getEmpleados()
        {
            Conectar();
            List<Empleado> lEmpleados = new List<Empleado>();
            try
            {
                string query = @"SElect dpi,nombreCompleto,cantidadHijos,SalarioBase,SalarioLiquido from empleados";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Empleado nEmpleado = new Empleado();
                        nEmpleado.dpi= Convert.ToInt64(dr["dpi"]);
                        nEmpleado.nombreCompleto = Convert.ToString(dr["nombreCompleto"]);
                        nEmpleado.cantidadHijos = Convert.ToInt32(dr["cantidadHijos"]);
                        nEmpleado.salarioBase = Convert.ToDouble(dr["salarioBase"]);
                        nEmpleado.salarioLiquido = Convert.ToDouble(dr["SalarioLiquido"]);
                        lEmpleados.Add(nEmpleado);
                    }
                }
                Desconectar();
            }
            catch (Exception ex)
            {

            }
            return lEmpleados;
        }

        public bool crearEmpleado(Empleado nEmpleado)
        {
            Conectar();
            try
            {
                string query = $@"insert into empleados (dpi,nombrecompleto,cantidadhijos,salariobase,
                                                            salarioliquido,usuariocreacion,fechacreacion)
                                                        values (@dpi,@nombrecompleto,@cantidadhijos,@salariobase,
                                                                @salarioliquido,@usuariocreacion,@fechacreacion)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dpi", nEmpleado.dpi);
                    cmd.Parameters.AddWithValue("@nombrecompleto", nEmpleado.nombreCompleto);
                    cmd.Parameters.AddWithValue("@cantidadhijos", nEmpleado.cantidadHijos);
                    cmd.Parameters.AddWithValue("@salariobase", nEmpleado.salarioBase);
                    cmd.Parameters.AddWithValue("@salarioliquido", nEmpleado.salarioLiquido);
                    cmd.Parameters.AddWithValue("@usuariocreacion", nEmpleado.usuarioCreacion);
                    cmd.Parameters.AddWithValue("@fechacreacion", DateTime.Now);

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
                throw ex;
            }
            return false;
        }
        
        public bool modificarEmpleado(Empleado nEmpleado)
        {
            Conectar();
            try
            {
                string query = $@"update empleados set nombreCompleto=@nombreCompleto, cantidadHijos=@cantidadhijos,
                                  salarioBase=@salariobase, salarioliquido=@salarioliquido
                                  where dpi=@dpi";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dpi", nEmpleado.dpi);
                    cmd.Parameters.AddWithValue("@nombrecompleto", nEmpleado.nombreCompleto);
                    cmd.Parameters.AddWithValue("@cantidadhijos", nEmpleado.cantidadHijos);
                    cmd.Parameters.AddWithValue("@salariobase", nEmpleado.salarioBase);
                    cmd.Parameters.AddWithValue("@salarioliquido", nEmpleado.salarioLiquido);
           

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
                throw ex;
            }
            return false;
        }

        public bool eliminarEmpleado(Int64 dpi)
        {
            Conectar();
            try
            {
                string query = $@"DELETE FROM Empleados WHERE dpi=@dpi";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dpi", dpi);
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
                throw ex;
            }
            return false;
        }

    }
}