using System;

namespace PostmanAPI.Models
{
    public class CollectionInfoModel
    {   
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Schema { get; set; }
    }
}
