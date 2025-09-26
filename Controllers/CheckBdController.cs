using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using apiRESTCheckBdTADS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace apiRESTCheckBdTADS.Controllers
{
    public class CheckBdController : ApiController
    {
        //Definicion del endpoint
        //Definicion del metodo

        [HttpGet]

        [Route("check/checkbd/mysqlconectioncheckbd")]
        public clsApiStatus mySqlConecction(){

            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();

            // ---------------------------
            // Creacion del objeto,sobre el modelo clsCheckBD
            clsCheckBd objCheckBd = new clsCheckBd();

            // Ejecucion del metodo de chequeo de BD
            objCheckBd.checkBd();

            // Analizar los atributos y configurar el objeto de salida

            if (objCheckBd.ban == 1)
            {
                objRespuesta.statusExec = true;
                //Configuracion del objeto JSON
                jsonResp.Add("msgData", "Conexion exitosa");
            } 
            else
            {
                objRespuesta.statusExec = false;
                //Configuracion del objeto JSON
                jsonResp.Add("msgData", "Conexion fallida");
            }
            objRespuesta.ban = objCheckBd.ban;
            objRespuesta.msg = objCheckBd.statusMsg;
            objRespuesta.datos = jsonResp;
            // Envio de respuesta al cliente 
            return objRespuesta;
        }

    }   
}
