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
        /// <summary>
        /// Default constructor
        /// </summary>
        public MultilanguageText()
        { }

        /// <summary>
        /// Constructor for default value.
        /// </summary>
        /// <param name="text">The text.</param>
        public MultilanguageText(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Constructor for full attribute access.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="languageCode">The language code (e.g. 'en' or 'de')</param>
        /// <param name="format">The format. Constants are defined in <code>TextFormat</code> class.</param>
        public MultilanguageText(string text, string languageCode, string format)
        {
            Text = text;
            Language = languageCode;
            Format = format;
        }

        [JsonProperty(PropertyName = "text")]
        [BsonElement("text")]
        public string Text { get; set; } = "";

        /// <summary>
        /// The format for the textual value. Allowed values are plain for unformatted 
        /// and xhtml for formatted content.
        /// Constants are defined in the class TextFormat.
        /// </summary>
        [JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        [BsonElement("format")]
        public string Format { get; set; } = null;

        /// <summary>
        /// The language used for the text data. Default is 'en' for English.
        /// </summary>
        [JsonProperty(PropertyName = "language", NullValueHandling = NullValueHandling.Ignore)]
        [BsonElement("language")]
        public string Language { get; set; } = null;
    }
}
