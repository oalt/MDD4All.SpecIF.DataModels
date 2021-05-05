using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels.BaseTypes
{
    public class TypeDefinitionBase : SpecIfBaseElement
    {
        [JsonProperty(PropertyName = "title", Order = -97)]
        [BsonElement("title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description", Order = -96)]
        [BsonElement("description")]
        public List<MultilanguageText> Description { get; set; }

    }
}
