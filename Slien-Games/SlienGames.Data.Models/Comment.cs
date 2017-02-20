using System;
using System.ComponentModel.DataAnnotations;

using SlienGames.Data.Models.Constants;
using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class Comment : IDbModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.CommentContentMinLength)]
        [MaxLength(ValidationConstants.CommentContentMaxLength)]
        public string Content { get; set; }

        public virtual int AuthorId { get; set; }

        [Required]
        public virtual User Author { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual int GameProfileId { get; set; }

        [Required]
        public virtual GameProfile GameProfile { get; set; }
    }
}
