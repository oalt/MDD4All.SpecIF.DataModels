/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDD4All.SpecIF.DataModels.Converters
{
    public class ValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Value));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            Value value = new Value();
            value.MultilanguageText = new List<MultilanguageText>();

            switch (reader.TokenType)
            {
                case JsonToken.String:
                    string stringValue = serializer.Deserialize<string>(reader);
                    value.StringValue = stringValue;
                    break;
                case JsonToken.StartArray:
                    List<MultilanguageText> arrayValue = serializer.Deserialize<List<MultilanguageText>>(reader);
                    value.MultilanguageText = arrayValue;
                    break;
            }

            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Value val = value as Value;

            if (val.StringValue != null)
            {
                JToken token = JToken.FromObject(val.StringValue);

                token.WriteTo(writer);
            }
            else if (val.MultilanguageText != null)
            {
                JArray array = new JArray();

                foreach (MultilanguageText languageValue in val.MultilanguageText)
                {
                    array.Add(JToken.FromObject(languageValue));
                }

                array.WriteTo(writer);

            }
        }

    }
}
