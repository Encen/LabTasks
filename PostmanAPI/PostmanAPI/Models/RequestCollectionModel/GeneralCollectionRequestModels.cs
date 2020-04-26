
namespace PostmanAPI.Models
{
    public class GeneralCollectionRequestModels
    {
        public class Collections
        {
            public Collection Collection { get; set; }
        }
        public class Collection
        {
            public CollectionInfoModel Info { get; set; }
            public CollectionsOfItems Item { get; set; }
        }
    }
}
