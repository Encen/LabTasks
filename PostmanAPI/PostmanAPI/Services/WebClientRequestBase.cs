using Newtonsoft.Json;

namespace PostmanAPI.Services
{
    public class WebClientRequestBase
    {
        public MyWebClient _webClient;

        protected WebClientRequestBase(string xApiKey)
        {
            _webClient = new MyWebClient();
            _webClient.Headers.Add("x-api-key",xApiKey);
            _webClient.Headers.Add("Content-type", "application/json");
        }
        protected T Deserialize<T>(string data)
            =>JsonConvert.DeserializeObject<T>(data);
        public enum RequestTypes
            {
                POST,
                PUT,
                DELETE
            }
        protected T Get<T>(string resourceEndpoint)where T : class
        {
            var response = _webClient.DownloadString(resourceEndpoint);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }
        protected T RequestType<T>(string resourceEndpoint,string data,RequestTypes request) where T : class
        {
            if(request == RequestTypes.DELETE)
            {
                data = "";
            }
            _webClient.Headers.Add("Content-Type", "application/json");
            var response = _webClient.UploadString(resourceEndpoint,request.ToString(), data);
            T deserializedResponse = Deserialize<T>(response);
            return deserializedResponse;
        }
      
    }
}
