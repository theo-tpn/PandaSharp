using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Opponent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("opponent")]
        public object Target { get; set; }
    }
}
