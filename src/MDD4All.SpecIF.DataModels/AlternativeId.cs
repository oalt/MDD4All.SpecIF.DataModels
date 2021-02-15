/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MDD4All.SpecIF.DataModels
{
    public class AlternativeId : SpecIfElement
    {
        /// <summary>
        /// ID used in JSON
        /// </summary>
        [JsonProperty(PropertyName = "id", Order = -101)]
        [BsonElement("id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "revision", Order = -100)]
        [BsonElement("revision")]
        public string Revision { get; set; }

        [JsonProperty(PropertyName = "project", Order = -101)]
        [BsonElement("project")]
        public string Project { get; set; }
    }
}
