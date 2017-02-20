using SlienGames.Data.Models.Contracts;
using System.Collections.Generic;

namespace SlienGames.Data.Models
{
    public class Vote : IDbModel
    {
        private ICollection<GameDetails> games;

        public Vote()
        {
            this.games = new HashSet<GameDetails>();
        }

        public int Id { get; set; }

        public bool Value { get; set; }

        public virtual ICollection<GameDetails> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}