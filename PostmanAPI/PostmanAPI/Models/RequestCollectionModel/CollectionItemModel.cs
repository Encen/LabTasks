
using System.Collections.Generic;

namespace PostmanAPI.Models
{
    public class CollectionsOfItems
    {
        public string Name { get; set; }
        public List<CollectionItemModel> Item { get; set; }
        public RequestCollectionModel Request { get; set; }
    }
    public class CollectionItemModel
    {
        public string Name { get; set; }
        public RequestCollectionModel Request { get; set; }
    }
}
