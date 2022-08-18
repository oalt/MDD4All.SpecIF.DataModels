/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MDD4All.SpecIF.DataModels.Converters;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
    [JsonConverter(typeof(ValueConverter))]
    public class Value : SpecIfElement
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Value()
        {

        }

        /// <summary>
        /// Use this constructor to create a value with a non xs:string data type.
        /// </summary>
        /// <param name="value"></param>
        public Value(string value)
        {
            StringValue = value;
        }

        /// <summary>
        /// Use this constructor to add a value with data type xs:string (MultilanguageText).
        /// </summary>
        /// <param name="value"></param>
        public Value(MultilanguageText value)
        {
            MultilanguageTexts.Add(value);
        }

        [BsonElement("multilanguageTexts")]
        [JsonIgnore]
        public List<MultilanguageText> MultilanguageTexts { get; set; } = new List<MultilanguageText>();

        [BsonElement("simpleValue")]
        [JsonIgnore]
        public string StringValue { get; set; } = null;

    }
}
