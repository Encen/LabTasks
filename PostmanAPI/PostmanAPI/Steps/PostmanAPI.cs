
using PostmanAPI.Models;
using static PostmanAPI.Models.GeneralCollectionRequestModels;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace PostmanAPI.Steps
{
    [Binding]
     class PostmanAPI
    {
        [Given(@"I have a collection with name (.*)")]
        public void GivenIHaveACollection()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I send (.*) request to postman collections api")]
        [When(@"I send (.*) request to postman collections api")]
        public void WhenISendRequestToPostmanCollectionsApi()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I send GET request to postman collections api")]
        [When(@"I send GET request to postman collections api")]
        public void WhenISendGETRequestToPostmanCollectionsApi()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I send POST request to postman collections api")]
        public void WhenISendPOSTRequestToPostmanCollectionsApi()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"I send PUT request to postman collections api with new Name")]
        public void WhenISendPUTRequestToPostmanCollectionsApiWithNewName()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"I send DELETE request to postman collections api")]
        public void WhenISendDELETERequestToPostmanCollectionsApi()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I get the list of my collections")]
        public void ThenIGetTheListOfMyCollections()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"New collection will be created")]
        public void ThenNewCollectionWillBeCreated()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The collection will be renamed")]
        public void ThenTheCollectionWillBeRenamed()
        {
            ScenarioContext.Current.Pending();

        }
        [Then(@"The collection will be deleted")]
        public void ThenTheCollectionWillBeDeleted()
        {
            ScenarioContext.Current.Pending();
        }

        private Collections CreateCollectionModel(string nameOfCollection = null, string id = null, string method = null, string requestName = null)
        {
            var header = new List<Header>
            {
                new Header {Key = "x-api-key",Value =Data.CurrentxApiKey },
                new Header{Key = "Content-type", Value="application/json"}
            };
            var url = new Url
            {
                raw = Data.BaseUrl,
                protocol = "https",
                host = new List<string>
                {
                    "api",
                    "getpostman",
                    "com"
                },
                path = new List<string>
                {
                    "collections"
                }
            };
            var request = new RequestCollectionModel
            {
                Url = url,
                Method = method ?? "GET",
                Header = header
            };
            var info = new CollectionInfoModel
            {
                Postman_id = id ?? Guid.NewGuid().ToString(),
                Name = nameOfCollection ?? "Test",
                Schema = Data.CollectionSchema
            };
            var item = new CollectionsOfItems
            {
                Name = requestName ?? "Test",
                Request = request
            };
            var collection = new Collection
            {
                Info = info,
                Item = item
            };
            return new Collections { Collection = collection };
        }
    }
}
