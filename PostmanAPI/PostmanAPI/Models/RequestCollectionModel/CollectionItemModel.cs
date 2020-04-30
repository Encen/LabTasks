
using System.Collections.Generic;

namespace PostmanAPI.Models
{
    public class CollectionsOfItems
    {
        public string Name { get; set; }
        public List<CollectionOfItems> Item { get; set; }
        public RequestCollectionModel Request { get; set; }
    }
    public class CollectionOfItems
    {
        public string Name { get; set; }
        public RequestCollectionModel Request { get; set; }
    }
}
