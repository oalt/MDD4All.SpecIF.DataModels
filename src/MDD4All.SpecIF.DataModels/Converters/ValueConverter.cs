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

            if (reader.ValueType != null)
            {
                if (reader.ValueType == typeof(string))
                {
                    value.StringValue = reader.Value.ToString();
                }
                else
                {
                    JArray ja = JArray.Load(reader);
                    List<MultilanguageText> values = ja.ToObject<List<MultilanguageText>>();

                    value.MultilanguageText = values;
                }
            }
            else
            {
                value.StringValue = "";
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
