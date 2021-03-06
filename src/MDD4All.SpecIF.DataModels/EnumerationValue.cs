﻿/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
    /// <summary>
    /// Enumerated Value
    /// </summary>
    public class EnumerationValue : SpecIfElement
    {
        [JsonProperty(PropertyName = "id")]
        [BsonElement("id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "value")]
        [BsonElement("value")]
        public List<MultilanguageText> Value { get; set; }
    }
}
