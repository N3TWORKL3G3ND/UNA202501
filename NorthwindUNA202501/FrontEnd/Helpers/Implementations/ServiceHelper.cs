using FrontEnd.Helpers.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd.Helpers.Implementations
{
    public class ServiceHelper : IServiceHelper
    {
        public HttpClient HttpClient { get; set; }

        


        public ServiceHelper(HttpClient client, IConfiguration configuration)
        {
            string baseURL = configuration
                                .GetValue<string>("BackEnd:URL") ?? "";
                HttpClient = client;

            var apiKey = configuration
                                .GetValue<string>("BackEnd:ApiKey") ?? "";
            client.DefaultRequestHeaders.Add("ApiKey", apiKey);
            client.BaseAddress = new Uri(baseURL);

        }


        public HttpResponseMessage Delete(string url)
        {
            return HttpClient.DeleteAsync(url).Result;
        }

        public HttpResponseMessage GetResponseMessage(string url)
        {
            return HttpClient.GetAsync(url).Result;
        }

        public HttpResponseMessage Post(string url, object data)
        {
            return HttpClient.PostAsJsonAsync(url,data).Result;
        }

        public HttpResponseMessage Put(string url, object data)
        {
            return HttpClient.PutAsJsonAsync(url,data).Result;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object data)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await client.PostAsync(url, content);
        }
    }
}
