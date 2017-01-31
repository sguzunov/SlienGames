using System.Collections.Generic;

using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class Vote : IDbModel
    {
        private ICollection<GameProfile> games;

        public Vote()
        {
            this.games = new HashSet<GameProfile>();
        }

        public int Id { get; set; }

        public bool Value { get; set; }
    }
}