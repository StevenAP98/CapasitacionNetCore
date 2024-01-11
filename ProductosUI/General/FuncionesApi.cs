using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductosEnt;

namespace ProductosUI.General
{
    public class FuncionesApi
    {
        static HttpClient client = new HttpClient();
        private static readonly IConfiguration Root;
        string UrlAPI = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("urlAPI").Value;

        public async Task<Respuesta<List<T>>> Obtener<T>(int id, string controlador, string metodo)

        {
            Respuesta<List<T>> respuesta = new Respuesta<List<T>>();
            try
            {

                HttpResponseMessage response = await client.GetAsync($"{UrlAPI}/{controlador}/{metodo}/?id={id.ToString()}");
                if (response.IsSuccessStatusCode)
                {

                    string contenidoRespuesta = await response.Content.ReadAsStringAsync();
                    respuesta = JsonConvert.DeserializeObject<Respuesta<List<T>>>(contenidoRespuesta);
                }
            }
            catch (Exception ex)
            {
                respuesta.HayError = true;
                respuesta.MensajeError = ex.Message;
            }

            return respuesta;
        }

        public async Task<Respuesta<T>> Insertar<T>(T entidad, string controlador, string metodo, string usuario)
        {
            Respuesta<T> respuesta = new Respuesta<T>();
            try
            {
               
                JObject json = JObject.FromObject(new { entidad });
                var stringContent = new StringContent(json.ToString(), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(
                    $"{UrlAPI}/{controlador}/{metodo}", stringContent); 
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await response.Content.ReadAsStringAsync();
                    respuesta = JsonConvert.DeserializeObject<Respuesta<T>>(contenidoRespuesta);
                }
            }
            catch (Exception ex)
            {

                respuesta.HayError = true;
                respuesta.MensajeError = ex.Message;
            }
            return respuesta;
        }
    }
}
