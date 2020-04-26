using System;

namespace PostmanAPI.Models
{
    public class RequestCollectionModel
    {
        public Uri Url { get; set; }
        public string Method { get; set; }
        public Header[] Header { get; set; }
        public Body Body { get; set; }
        public string Description { get; set; }
    }

    public class Body
    {
        public string Mode { get; set; }
        public string Raw { get; set; }
    }
    public class Header
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
