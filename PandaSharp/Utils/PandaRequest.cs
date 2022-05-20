using PandaSharp.Utils.Enums;

namespace PandaSharp.Utils
{
    public class PandaRequest
    {
        private readonly Dictionary<PandaRequestAction, string> _request = new();
        private PandaQuery? _query;

        public PandaRequest From(PandaEntity entity)
        {
            var strEntity = StringifyPandaEntity(entity);

            if (!_request.TryAdd(PandaRequestAction.From, strEntity))
                throw new InvalidOperationException("'From' action have already be chained.");

            return this;
        }

        public PandaRequest Get(PandaEntity entity)
        {
            var strEntity = StringifyPandaEntity(entity);

            if (!_request.TryAdd(PandaRequestAction.Get, strEntity))
                throw new InvalidOperationException("'Get' action have already been chained.");

            return this;
        }

        public PandaRequest By(string by)
        {
            if(string.IsNullOrEmpty(by))
                throw new ArgumentException("Could not stringify the given entity.");

            if (!_request.TryAdd(PandaRequestAction.By, by))
                throw new InvalidOperationException("'By' action have already been chained.");

            return this;
        }

        public PandaRequest AddQuery(PandaQuery query)
        {
            if (_query != null)
                throw new InvalidOperationException("A 'Query' have already been chained.");

            _query = query;
            return this;
        }

        public override string ToString()
        {
            return 
                $"{string.Join('/', _request.Select(x => x.Value))}" +
                $"{(_query == null ? "" : $"?{_query.ToString()}")}";
        }

        private static string StringifyPandaEntity(PandaEntity entity) => entity switch
        {
            PandaEntity.Leagues => "leagues",
            PandaEntity.Lives => "lives",
            PandaEntity.Matches => "matches",
            PandaEntity.Players => "players",
            PandaEntity.Series => "series",
            PandaEntity.Teams => "teams",
            PandaEntity.Tournaments => "tournaments",
            PandaEntity.Videogames => "videogames",
            PandaEntity.Maps => "maps",
            PandaEntity.Csgo => "csgo",
            PandaEntity.Codmw => "codmw",
            PandaEntity.Dota2 => "dota2",
            PandaEntity.Fifa => "fifa",
            PandaEntity.Lol => "lol",
            PandaEntity.Ow => "ow",
            PandaEntity.Pubg => "pubg",
            PandaEntity.R6s => "r6siege",
            PandaEntity.Rl => "rl",
            PandaEntity.Valo => "valorant",
            PandaEntity.Kog => "kog",
            PandaEntity.Lolwr => "lol-wild-rift",
            PandaEntity.Stats => "stats",
            PandaEntity.Weapons => "weapons",
            PandaEntity.Abilities => "abilities",
            PandaEntity.Heroes => "heroes",
            PandaEntity.Items => "items",
            PandaEntity.Champions => "champions",
            PandaEntity.Masteries => "masteries",
            PandaEntity.Runes => "runes",
            PandaEntity.Spells => "spells",
            PandaEntity.Agents => "agents",
            _ => throw new InvalidOperationException($"Could not stringify the given PandaEntity {entity}"),
        };

        enum PandaRequestAction
        {
            From = 0,
            By = 1,
            Get = 2,
        }
    }
}
