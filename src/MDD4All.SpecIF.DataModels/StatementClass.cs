/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
    public class StatementClass : ResourceClass
    {
        [JsonProperty(PropertyName = "subjectClasses")]
        [BsonElement("subjectClasses")]
        public List<Key> SubjectClasses { get; set; }

        [JsonProperty(PropertyName = "objectClasses")]
        [BsonElement("objectClasses")]
        public List<Key> ObjectClasses { get; set; }


    }
}
