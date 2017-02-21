using SlienGames.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SlienGames.Data.Models
{
    public class ExternalGameResource : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public string GameContent { get; set; }

        public int GameId { get; set; }

        public GameDetails Game { get; set; }
    }
}
