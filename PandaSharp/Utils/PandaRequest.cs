using PandaSharp.Utils.Enums;

namespace PandaSharp.Utils
{
    public class PandaRequest
    {
        private readonly Dictionary<PandaRequestAction, string> _request = new();

        public PandaRequest From(PandaEntity entity)
        {
            var strEntity = StringifyPandaEntity(entity);
            if (strEntity == null)
                throw new ArgumentException("Could not stringify the given entity.");

            if (!_request.TryAdd(PandaRequestAction.From, strEntity))
                throw new InvalidOperationException("'From' action have already be chained.");

            return this;
        }

        public PandaRequest Get(PandaEntity entity)
        {
            var strEntity = StringifyPandaEntity(entity);
            if (strEntity == null)
                throw new ArgumentException("Could not stringify the given entity.");

            if (!_request.TryAdd(PandaRequestAction.Get, strEntity))
                throw new InvalidOperationException("'Get' action have already be chained.");

            return this;
        }

        public PandaRequest By(string by)
        {
            if (!_request.TryAdd(PandaRequestAction.By, by))
                throw new InvalidOperationException("'By' action have already be chained.");

            return this;
        }

        public override string ToString()
        {
            return string.Join('/', _request.Select(x => x.Value));
        }

        private string? StringifyPandaEntity(PandaEntity entity) => entity switch
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
            _ => null,
        };

        enum PandaRequestAction
        {
            From = 0,
            By = 1,
            Get = 2,
        }
    }
}
