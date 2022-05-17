using System.Text.Json.Serialization;

namespace PandaSharp.Entities
{
    public class Match
    {
        [JsonPropertyName("begin_at")]
        public DateTime BeginAt { get; set; }

        [JsonPropertyName("detailed_stats")]
        public bool DetailedStats { get; set; }

        [JsonPropertyName("draw")]
        public bool Draw { get; set; }

        [JsonPropertyName("end_at")]
        public object EndAt { get; set; }

        [JsonPropertyName("forfeit")]
        public bool Forfeit { get; set; }

        [JsonPropertyName("game_advantage")]
        public object GameAdvantage { get; set; }

        [JsonPropertyName("games")]
        public List<object> Games { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("league")]
        public League League { get; set; }

        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("live")]
        public Live Live { get; set; }

        [JsonPropertyName("live_embed_url")]
        public object LiveEmbedUrl { get; set; }

        [JsonPropertyName("match_type")]
        public string MatchType { get; set; }

        [JsonPropertyName("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("number_of_games")]
        public int NumberOfGames { get; set; }

        [JsonPropertyName("official_stream_url")]
        public object OfficialStreamUrl { get; set; }

        [JsonPropertyName("opponents")]
        public List<Opponent> Opponents { get; set; }

        [JsonPropertyName("original_scheduled_at")]
        public DateTime OriginalScheduledAt { get; set; }

        [JsonPropertyName("rescheduled")]
        public bool Rescheduled { get; set; }

        [JsonPropertyName("results")]
        public List<object> Results { get; set; }

        [JsonPropertyName("scheduled_at")]
        public DateTime ScheduledAt { get; set; }

        [JsonPropertyName("serie")]
        public Serie Serie { get; set; }

        [JsonPropertyName("serie_id")]
        public int SerieId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("streams")]
        public StreamOverview Streams { get; set; }

        [JsonPropertyName("streams_list")]
        public List<Stream> StreamsList { get; set; }

        [JsonPropertyName("tournament")]
        public Tournament Tournament { get; set; }

        [JsonPropertyName("tournament_id")]
        public int TournamentId { get; set; }

        [JsonPropertyName("videogame")]
        public Videogame Videogame { get; set; }

        [JsonPropertyName("videogame_version")]
        public VideogameVersion VideogameVersion { get; set; }

        [JsonPropertyName("winner")]
        public object? Winner { get; set; }

        [JsonPropertyName("winner_id")]
        public int? WinnerId { get; set; }
    }

    public class VideogameVersion
    {
        [JsonPropertyName("current")]
        public bool Current { get; set; } 

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public record StreamOverview(
        [property: JsonPropertyName("english")] Stream english,
        [property: JsonPropertyName("official")] Stream official,
        [property: JsonPropertyName("russian")] Stream russian);
}
