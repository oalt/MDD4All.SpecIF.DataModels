/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
    public class PropertyClass : TypeDefinitionBase
    {
        [JsonProperty(PropertyName = "dataType")]
        [BsonElement("dataType")]
        public Key DataType { get; set; }

        [JsonProperty(PropertyName = "multiple")]
        [BsonElement("multiple")]
        public bool? Multiple { get; set; }

        [JsonProperty(PropertyName = "format")]
        [BsonElement("format")]
        public string Format { get; set; } = TextFormat.Plain;

        [JsonProperty(PropertyName = "unit")]
        [BsonElement("unit")]
        public string Unit { get; set; }

        [JsonProperty(PropertyName = "values")]
        [BsonElement("values")]
        public List<Value> Values { get; set; } = null;
    }
}
