/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
    public class Property : SpecIfElement
    {
        public Property()
        {
        }

        public Property(Key propertyClass, string singleNonStringValue)
        {
            Class = propertyClass;
            Value value = new Value(singleNonStringValue);

            if(Values == null)
            {
                Values = new List<Value>();
            }
            Values.Add(value);
        }

        public Property(Key propertyClass, MultilanguageText singleStringValue)
        {
            Class = propertyClass;
            Value value = new Value();

            value.MultilanguageTexts.Add(singleStringValue);

            if (Values == null)
            {
                Values = new List<Value>();
            }

            Values.Add(value);
        }

        public Property(Key classID, List<Value> values)
        {
            Class = new Key(classID.ID, classID.Revision);
            Values = values;
        }

        [JsonProperty(PropertyName = "class", Order = -97)]
        [BsonElement("class")]
        public Key Class { get; set; }

        [JsonProperty(PropertyName = "values", Order = -95)]
        [BsonElement("values")]
        public List<Value> Values { get; set; } = null;
    }
}
