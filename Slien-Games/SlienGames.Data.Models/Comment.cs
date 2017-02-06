using System;
using System.ComponentModel.DataAnnotations;

using SlienGames.Data.Models.Contracts;
using SlienGames.Data.Models.Constants;

namespace SlienGames.Data.Models
{
    public class Comment : IDbModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.CommentContentMinLength)]
        [MaxLength(ValidationConstants.CommentContentMaxLength)]
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
