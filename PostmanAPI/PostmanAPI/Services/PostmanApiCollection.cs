using Newtonsoft.Json;
using PostmanAPI.Models;

namespace PostmanAPI.Services
{
    public class PostmanApiCollection : WebClientRequestBase
    {
        
        public ResponseCollectionModel GetListOfCollections()
            => Get<ResponseCollectionModel>($"{Data.BaseUrl}/collections");

        public Collections CreateCollection(Collections content)
            => RequestType<Collections>($"{Data.BaseUrl}/collections", JsonConvert.SerializeObject(content), RequestTypes.POST);

        public Collections UpdateCollection(Collections content)
            => RequestType<Collections>($"{Data.BaseUrl}/collections", JsonConvert.SerializeObject(content), RequestTypes.PUT);

        public Collections DeleteCollection(Collections content)
            => RequestType<Collections>($"{Data.BaseUrl}/collections", JsonConvert.SerializeObject(content), RequestTypes.DELETE);

        public PostmanApiCollection() : base(Data.CurrentxApiKey) { }
    }
}

