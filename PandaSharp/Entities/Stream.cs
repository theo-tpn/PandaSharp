using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Stream
    {
        [JsonPropertyName("embed_url")]
        public Uri EmbedUrl { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("main")]
        public bool Main { get; set; }

        [JsonPropertyName("official")]
        public bool Official { get; set; }

        [JsonPropertyName("raw_url")]
        public string RawUrl { get; set; }
    }
}
