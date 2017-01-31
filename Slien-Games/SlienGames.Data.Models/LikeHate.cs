using System.Collections.Generic;

using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class LikeHate : IDbModel
    {
        private ICollection<GameProfile> games;

        public LikeHate()
        {
            this.games = new HashSet<GameProfile>();
        }

        public int Id { get; set; }

        public bool Value { get; set; }
    }
}