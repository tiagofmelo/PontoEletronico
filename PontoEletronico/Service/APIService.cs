using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using Newtonsoft.Json;
using PontoEletronico.Models;

namespace PontoEletronico.Service
{
    public class APIService
    {
        private static string url = System.Configuration.ConfigurationManager.AppSettings["urlApi"];

        //public static string PostAPI(object serializeObject, string endPoint)
        //{
        //    var postLoginModel = JsonConvert.SerializeObject(serializeObject);

        //    var dados = Encoding.UTF8.GetBytes(postLoginModel);
        //    var requisicaoWeb = WebRequest.CreateHttp(url + endPoint);
        //    requisicaoWeb.Method = "POST";
        //    requisicaoWeb.ContentType = "application/json";
        //    requisicaoWeb.ContentLength = dados.Length;

        //    using (var stream = requisicaoWeb.GetRequestStream())
        //    {
        //        stream.Write(dados, 0, dados.Length);
        //        stream.Close();
        //    }

        //    using (var resposta = requisicaoWeb.GetResponse())
        //    {
        //        var streamDados = resposta.GetResponseStream();
        //        StreamReader reader = new StreamReader(streamDados);
        //        object objResponse = reader.ReadToEnd();

        //        streamDados.Close();
        //        resposta.Close();

        //        return objResponse.ToString();
        //    }
        //}

        public static HttpResponseMessage GetAPI(TokenModel tokenModel, string endPoint)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenModel.accessToken);
            HttpResponseMessage response = httpClient.GetAsync(url + endPoint).Result;

            return response;
        }

        public static HttpResponseMessage PostAPI(object serializeObject, string endPoint)
        {
            var json = JsonConvert.SerializeObject(serializeObject);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsync(url + endPoint, contentString).Result;

            return response;
        }

        public static HttpResponseMessage PostAPI(TokenModel tokenModel, string endPoint, object serializeObject)
        {
            var json = JsonConvert.SerializeObject(serializeObject);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenModel.accessToken);
            HttpResponseMessage response = httpClient.PostAsync(url + endPoint, contentString).Result;

            return response;
        }

        public static HttpResponseMessage PutAPI(TokenModel tokenModel, string endPoint, TimesheetModel serializeObject)
        {
            var json = JsonConvert.SerializeObject(serializeObject);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenModel.accessToken);
            HttpResponseMessage response = httpClient.PutAsync(url + endPoint + "/" + serializeObject.id, contentString).Result;

            return response;
        }
    }
}