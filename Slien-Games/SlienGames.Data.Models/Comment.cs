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
        [MaxLength(200)]
        public string Content { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public User Author { get; set; }

        public DateTime PostedOn { get; set; }

        public int GameProfileId { get; set; }

        [Required]
        public virtual GameProfile GameProfile { get; set; }
    }
}
