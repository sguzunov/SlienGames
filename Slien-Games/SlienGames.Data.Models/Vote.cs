using SlienGames.Data.Models.Contracts;
using System.Collections.Generic;

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

        public virtual ICollection<GameProfile> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}