using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaSharp.Entities
{
    public class Live
    {
        [JsonPropertyName("endpoints")]
        public List<Endpoint> Endpoints { get; set; }

        [JsonPropertyName("match")]
        public Match Match { get; set; }
    }

    public class Endpoint
    {
        [JsonPropertyName("begin_at")]
        public DateTime BeginAt { get; set; }

        [JsonPropertyName("expected_begin_at")]
        public DateTime ExpectedBeginAt { get; set; }

        [JsonPropertyName("last_active")]
        public int LastActive { get; set; }

        [JsonPropertyName("match_id")]
        public int MatchId { get; set; }

        [JsonPropertyName("open")]
        public bool Open { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
