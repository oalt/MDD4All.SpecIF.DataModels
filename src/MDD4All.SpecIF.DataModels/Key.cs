/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MDD4All.SpecIF.DataModels.Converters;
using MDD4All.SpecIF.DataModels.Helpers;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MDD4All.SpecIF.DataModels
{
    [JsonConverter(typeof(KeyConverter))]
    public class Key : SpecIfElement
    {
        public Key()
        {
        }

        public Key(string id)
        {
            ID = id;
            Revision = null;
        }

        public Key(string id, string revision)
        {
            ID = id;
            Revision = revision;
        }

        [JsonProperty(PropertyName = "id")]
        [BsonElement("id")]
        public string ID { get; set; } = "";

        [JsonProperty(PropertyName = "revision")]
        [BsonElement("revision")]
        public string Revision { get; set; } = null;

        public override string ToString()
        {
            string result = "";

            result += ID;
            if (Revision != null)
            {
                result += "_R_" + Revision;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if(obj is Key)
            {
                Key other = (Key)obj;
                result = ID.Equals(other.ID);
                if(Revision != null)
                {
                    result = result && Revision.Equals(other.Revision);
                }
                else
                {
                    result = result && (other.Revision == null);
                }
            }
            
            return result;
        }

        public override int GetHashCode()
        {
            int result = ID.GetHashCode();

            if(Revision != null)
            {
                result = result ^ Revision.GetHashCode();
            }

            return result;
        }
    }
}
