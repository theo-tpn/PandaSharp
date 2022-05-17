using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Series
    {
        [JsonPropertyName("begin_at")]
        public DateTime BeginAt { get; set; }

        [JsonPropertyName("description")]
        public object Description { get; set; }

        [JsonPropertyName("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("season")]
        public string Season { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("tier")]
        public string Tier { get; set; }

        [JsonPropertyName("winner_id")]
        public int? WinnerId { get; set; }

        [JsonPropertyName("winner_type")]
        public string WinnerType { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}
