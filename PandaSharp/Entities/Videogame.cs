using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Videogame
    {
        [JsonPropertyName("current_version")]
        public object CurrentVersion { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("leagues")]
        public List<League> Leagues { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
}
