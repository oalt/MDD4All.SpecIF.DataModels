/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MDD4All.SpecIF.DataModels.Converters;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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


        public string ToSimpleTextString(string language = "en")
        {
            string result = "";

            if (StringValue != null)
            {
                result = StringValue;
            }
            else if (MultilanguageText.Count > 0)
            {
                try
                {
                    result = MultilanguageText.First(mlt => mlt.Language == language).Text;

                    if (result == null)
                    {
                        result = MultilanguageText[0].Text;
                    }
                }
                catch
                { }
                
            }

            return result;
        }

        public override string ToString()
        {
            return ToSimpleTextString();
        }

        public string ToString(string language)
        {
            return ToSimpleTextString(language);
        }
    }
}
