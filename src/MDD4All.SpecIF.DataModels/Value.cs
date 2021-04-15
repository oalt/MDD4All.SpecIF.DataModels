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
        public Value()
        {

        }

        public Value(string value)
        {
            StringValue = value;
        }

        public Value(MultilanguageText value)
        {
            MultilanguageText.Add(value);
        }

        public static string ToSimpleTextString(object value)
        {
            string result = "";
            if (value is string)
            {
                result = (string)value;
            }
            else if (value is object[])
            {

            }

            return result;
        }

        [BsonElement("multilanguageText")]
        [JsonIgnore]
        public List<MultilanguageText> MultilanguageText { get; set; } = new List<MultilanguageText>();

        [BsonElement("simpleValue")]
        [JsonIgnore]
        public string StringValue { get; set; } = null;


        public string ToSimpleTextString()
        {
            string result = "";

            if (StringValue != null)
            {
                result = StringValue;
            }
            else if (MultilanguageText.Count > 0)
            {
                result = MultilanguageText[0].Text;
            }

            return result;
        }

        public override string ToString()
        {
            return ToSimpleTextString();
        }
    }
}
