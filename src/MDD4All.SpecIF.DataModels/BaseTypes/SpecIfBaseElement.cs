﻿/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace MDD4All.SpecIF.DataModels.BaseTypes
{
    public class SpecIfBaseElement : IdentifiableElement
    {
        public SpecIfBaseElement()
        {
            ChangedAt = DateTime.Now;
        }

        [JsonIgnore]
        [BsonElement("project")]
        public string ProjectID { get; set; }

        [JsonProperty(PropertyName = "changedAt", Order = -96)]
        [BsonElement("changedAt")]
        public DateTime ChangedAt { get; set; }

        [JsonProperty(PropertyName = "changedBy", Order = -95, NullValueHandling = NullValueHandling.Ignore)]
        [BsonElement("changedBy")]
        public string ChangedBy { get; set; }


    }
}
