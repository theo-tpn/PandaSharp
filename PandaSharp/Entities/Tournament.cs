using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Tournament
    {
        [JsonPropertyName("begin_at")]
        public DateTime BeginAt { get; set; }

        [JsonPropertyName("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("league")]
        public League League { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("live_supported")]
        public bool LiveSupported { get; set; }

        [JsonPropertyName("matches")]
        public List<object> Matches { get; set; }

        [JsonPropertyName("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("prizepool")]
        public object Prizepool { get; set; }

        [JsonPropertyName("serie")]
        public Serie Serie { get; set; }

        [JsonPropertyName("serie_id")]
        public int SerieId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("teams")]
        public List<object> Teams { get; set; }

        [JsonPropertyName("tier")]
        public string Tier { get; set; }

        [JsonPropertyName("videogame")]
        public Videogame Videogame { get; set; }

        [JsonPropertyName("winner_id")]
        public object WinnerId { get; set; }

        [JsonPropertyName("winner_type")]
        public string WinnerType { get; set; }
    }
}
