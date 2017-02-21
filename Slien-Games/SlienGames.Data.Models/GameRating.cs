using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SlienGames.Data.Models
{
    public class GameRating
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public Guid UserId { get; set; }

        // Rated game.
        public virtual GameDetails Game { get; set; }

        // Voter.
        public virtual User User { get; set; }

        [Required]
        public int Value { get; set; }
    }
}