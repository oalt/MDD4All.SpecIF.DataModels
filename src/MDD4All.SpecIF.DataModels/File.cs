/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
    public class File : SpecIfBaseElement
    {
        [JsonProperty(PropertyName = "title", Order = -97)]
        [BsonElement("title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description", Order = -96)]
        [BsonElement("description")]
        public List<MultilanguageText> Description { get; set; }

        [JsonProperty(PropertyName = "type")]
        [BsonElement("type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "url")]
        [BsonElement("url")]
        public string URL { get; set; }
    }
}
