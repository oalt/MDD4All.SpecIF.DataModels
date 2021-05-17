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
    public class DataType : TypeDefinitionBase
    {
        [JsonProperty(PropertyName = "type")]
        [BsonElement("type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "maxLength")]
        [BsonElement("maxLength")]
        public int? MaxLength { get; set; }

        [JsonProperty(PropertyName = "fractionDigits")]
        [BsonElement("fractionDigits")]
        public int? FractionDigits { get; set; }

        [JsonProperty(PropertyName = "minInclusive")]
        [BsonElement("minInclusive")]
        public int? MinInclusive { get; set; }

        [JsonProperty(PropertyName = "maxInclusive")]
        [BsonElement("maxInclusive")]
        public int? MaxInclusive { get; set; }

        [JsonProperty(PropertyName = "enumeration")]
        [BsonElement("enumeration")]
        public List<EnumerationValue> Enumeration { get; set; }

        /// <summary>
        /// Optional use to indicates whether multiple values can be chosen; 
        /// by default the value is 'false'.
        /// </summary>
        [JsonProperty(PropertyName = "multiple")]
        [BsonElement("multiple")]
        public bool? Multiple { get; set; }

    }
}
