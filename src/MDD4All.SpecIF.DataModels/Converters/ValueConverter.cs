/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels.Converters
{
    public class ValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Value));
        }

        public override object ReadJson(JsonReader reader, 
                                        Type objectType, 
                                        object existingValue, 
                                        JsonSerializer serializer)
        {

            Value value = new Value();

            switch (reader.TokenType)
            {
                case JsonToken.String:
                    string stringValue = serializer.Deserialize<string>(reader);
                    value.StringValue = stringValue;
                    break;
                case JsonToken.StartArray:
                    List<MultilanguageText> arrayValue = serializer.Deserialize<List<MultilanguageText>>(reader);
                    value.MultilanguageTexts = arrayValue;
                    break;
            }

            return value;
        }

        public override void WriteJson(JsonWriter writer, object jsonValue, JsonSerializer serializer)
        {
            Value value = jsonValue as Value;

            if (value.StringValue != null)
            {
                JToken token = JToken.FromObject(value.StringValue);

                token.WriteTo(writer);
            }
            else if (value.MultilanguageTexts != null && value.MultilanguageTexts.Count > 0)
            {
                JArray array = new JArray();

                foreach (MultilanguageText languageValue in value.MultilanguageTexts)
                {
                    array.Add(JToken.FromObject(languageValue));
                }

                array.WriteTo(writer);

            }
        }

    }
}
