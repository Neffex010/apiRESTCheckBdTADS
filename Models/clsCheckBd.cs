using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiRESTCheckBdTADS.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;



namespace apiRESTCheckBdTADS.Models
{
    public class clsCheckBd
    {
        // Definición de atributos

        private String cadConn = ConfigurationManager.ConnectionStrings["bdControlAcceso"].ConnectionString;



        public string statusMsg;
        public int ban;

        // Defincion del metodo de conexion a MySQL

        public void checkBd()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(cadConn);
                conn.Open();
                conn.Close();
                ban = 1;
                statusMsg = "Conexión exitosa a la base de datos.";

            }
            catch (Exception ex)
            {
                ban = 0;
                statusMsg = ex.Message.ToString();

            }

        }



    }
}