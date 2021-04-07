/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MDD4All.SpecIF.DataModels.Helpers;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MDD4All.SpecIF.DataModels
{
	public class Property : SpecIfElement
	{
		public Property()
		{
		}

		public Property(Key propertyClass, string singleValue)
        {
			Class = propertyClass;
			Value value = new Value(singleValue);

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
		public List<Value> Values { get; set; } = new List<Value>();
			
		[JsonIgnore]
		[BsonIgnore]
		public string Value
        {
			set
            {
				Value v = new Value(value);

				if(Values.Count > 0)
                {
					Values[0] = v;
                }
				else
                {
					Values.Add(v);
                }
            }
        }
	}
}
