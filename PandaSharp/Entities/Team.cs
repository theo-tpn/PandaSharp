using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Team
    {
        [JsonPropertyName("acronym")]
        public object Acronym { get; set; }

        [JsonPropertyName("current_videogame")]
        public Videogame CurrentVideogame { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image_url")]
        public object ImageUrl { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("players")]
        public List<Player> Players { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
}
