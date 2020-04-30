
namespace PostmanAPI.Models
{
    public class GeneralCollectionRequestModels
    {
        
        public class Collection
        {
            public CollectionInfoModel Info { get; set; }
            public CollectionsOfItems Item { get; set; }
        }
    }
}
