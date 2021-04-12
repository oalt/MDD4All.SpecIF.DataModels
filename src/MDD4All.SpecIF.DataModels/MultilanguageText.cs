/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.SpecIF.DataModels.BaseTypes;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MDD4All.SpecIF.DataModels
{
    [JsonObject]
    public class MultilanguageText : SpecIfElement
    {
        public MultilanguageText()
        { }

        public MultilanguageText(string value, string languageCode = "en", string format = "plain")
        {
            Text = value;
            Language = languageCode;
            Format = format;
        }

        [JsonProperty(PropertyName = "text")]
        [BsonElement("text")]
        public string Text { get; set; } = "";

        /// <summary>
        /// The format for the textual value. Allowed values are plain for unformatted and xhtml for formatted content.
        /// Constants are defined in the class TextFormat.
        /// </summary>
        [JsonProperty(PropertyName = "format")]
        [BsonElement("format")]
        public string Format { get; set; } = TextFormat.Plain;

        /// <summary>
        /// The language used for the text data. Default is 'en' for English.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        [BsonElement("language")]
        public string Language { get; set; } = "en";
    }
}
