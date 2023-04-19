using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using PontoEletronico.Models;

namespace PontoEletronico.Service
{
    public class APIService
    {
        private static string url = System.Configuration.ConfigurationManager.AppSettings["urlApi"];

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