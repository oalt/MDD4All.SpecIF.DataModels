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

        [BsonElement("multilanguageTexts")]
        [JsonIgnore]
        public List<MultilanguageText> MultilanguageTexts { get; set; } = new List<MultilanguageText>();

        [BsonElement("simpleValue")]
        [JsonIgnore]
        public string StringValue { get; set; } = null;

        [BsonIgnore]
        [JsonIgnore]
        public bool IsStringValue
        {
            get
            {
                return StringValue != null;
            }
        }

        [BsonIgnore]
        [JsonIgnore]
        public bool IsMultilanguageValue
        {
            get
            {
                return !(MultilanguageTexts == null || MultilanguageTexts.Count == 0);
            }
        }

        public string ToSimpleTextString(string language = "en")
        {
            string result = "";

            if (StringValue != null)
            {
                result = StringValue;
            }
            else if (MultilanguageTexts.Count > 0)
            {
                try
                {
                    result = MultilanguageTexts.First(mlt => mlt.Language == language).Text;

                    if (result == null)
                    {
                        result = MultilanguageTexts[0].Text;
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
