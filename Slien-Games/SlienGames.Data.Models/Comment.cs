using System;
using System.ComponentModel.DataAnnotations;

using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class Comment : IDbModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Content { get; set; }

        /* TODO: Author --> User */

        public DateTime PostedOn { get; set; }

        public int GameProfileId { get; set; }

        public GameProfile GameProfile { get; set; }
    }
}
