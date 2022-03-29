/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
    /// <summary>
    /// The resources such as diagrams, model elements or requirements.
    /// </summary>
    public class Resource : SpecIfBaseElement
    {
        [JsonProperty(PropertyName = "class", Order = -98)]
        [BsonElement("class")]
        public Key Class { get; set; }

        [JsonProperty(PropertyName = "properties", Order = -60)]
        [BsonElement("properties")]
        public List<Property> Properties { get; set; } = new List<Property>();

        [JsonProperty(PropertyName = "alternativeIds", Order = -97, NullValueHandling = NullValueHandling.Ignore)]
        [BsonElement("alternativeIds")]
        public List<AlternativeId> AlternativeIDs { get; set; } = new List<AlternativeId>();
    }
}
