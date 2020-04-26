using Newtonsoft.Json;

namespace PostmanAPI.Services
{
    public class WebClientRequestBase
    {
        public MyWebClient _webClient;

        protected WebClientRequestBase(string baseUrl,string token)
        {
            _webClient = new MyWebClient();
            _webClient.BaseAddress = baseUrl;
            _webClient.Headers.Add("x-api-key", token);
        }
        protected T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        protected T Get<T>(string resourceEndpoint)where T:class
        {
            var response = _webClient.DownloadString(resourceEndpoint);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }
        protected T Post<T>(string resourceEndpoint,string data) where T:class
        {
            _webClient.Headers.Add("Content-Type", "application/json");
            var response = _webClient.UploadString(resourceEndpoint,"POST", data);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }
        protected T Put<T>(string resourceEndpoint, string data) where T : class
        {
            _webClient.Headers.Add("Content-Type", "application/json");
            var response = _webClient.UploadString(resourceEndpoint, "PUT", data);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }
        protected T Delete<T>(string resourceEndpoint, string data="") where T : class
        {
            _webClient.Headers.Add("Content-Type", "application/json");
            var response = _webClient.UploadString(resourceEndpoint, "DELETE", data);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }
    }
}
