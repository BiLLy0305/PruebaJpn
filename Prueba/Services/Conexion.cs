using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Prueba.Services
{
    public class Conexion
    {
        protected MySqlConnection con;
        public void Conectar()
        {
            try
            {
                con = new MySqlConnection(getConnectionString("conn"));
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Desconectar()
        {
            try
            {
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getConnectionString(string con)
        {
            string result = "";
            result = ConfigurationManager.ConnectionStrings[con].ToString();
            return result;
        }
    }
}