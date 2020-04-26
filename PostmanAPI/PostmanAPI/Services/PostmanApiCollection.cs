using Newtonsoft.Json;
using PostmanAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PostmanAPI.Services
{
    public class PostmanApiCollection:WebClientRequestBase
    {
        private WebClient _client;
        public const string BaseUrl = "https://api.getpostman.com";
        public const string token = "token";
        public const string SchemaVersion = "https://schema.getpostman.com/json/collection/v2.1.0/";
        private readonly string xApiKey = "PMAK-5e988ea695df91003e6db77a-2ea7f6d668c2576e6c8fa162f0fa801332";

        public ResponseCollectionModel GetListOfCollections()
        {
            return Get<ResponseCollectionModel>($"{BaseUrl}/collections");
        }
        public ResponseCollectionModel CreateCollection(ResponseCollectionModel content)
        {
            var serializedContent = JsonConvert.SerializeObject(content);
            return Post<ResponseCollectionModel>($"{BaseUrl}/collections",serializedContent);
        }
        public ResponseCollectionModel UpdateCollection(ResponseCollectionModel content)
        {
            var serializedContent = JsonConvert.SerializeObject(content);
            return Put<ResponseCollectionModel>($"{BaseUrl}/collections", serializedContent);
        }
        public ResponseCollectionModel DeleteCollection(ResponseCollectionModel content)
        {
            var serializedContent = JsonConvert.SerializeObject(content);
            return Delete<ResponseCollectionModel>($"{BaseUrl}/collections", serializedContent);
        }
        public PostmanApiCollection() : base(BaseUrl, token) { }
    }
}
