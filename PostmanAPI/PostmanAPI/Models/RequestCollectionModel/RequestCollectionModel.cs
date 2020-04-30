using System;
using System.Collections.Generic;

namespace PostmanAPI.Models
{
    public class RequestCollectionModel
    {
        public Url Url { get; set; }
        public string Method { get; set; }
        public List<Header> Header { get; set; }
        public Body Body { get; set; }
        public string Description { get; set; }
    }
    public class Url
    {
        public string raw { get; set; }
        public string protocol { get; set; }
        public List<string> host { get; set; }
        public List<string> path { get; set; }
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
