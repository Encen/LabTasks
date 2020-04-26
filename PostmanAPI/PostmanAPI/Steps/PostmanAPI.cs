
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace PostmanAPI.Steps
{
    [Binding,Scope(Feature = "Work with collections")]
     class PostmanAPI
    {
        [Given(@"I have a collection with name (.*)")]
        public void GivenIHaveACollection()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have a collection with name (*.)")]
        public void GivenIHaveACollectionWithName()
        {
            ScenarioContext.Current.Pending();
        }

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

    }
}
