using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Player
    {
        [JsonPropertyName("age")]
        public int? Age { get; set; }

        [JsonPropertyName("birth_year")]
        public int? BirthYear { get; set; }

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("hometown")]
        public object Hometown { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image_url")]
        public object ImageUrl { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("role")]
        public object Role { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
}
