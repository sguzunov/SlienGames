using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class GameProfile : IDbModel
    {
        private ICollection<LikeHate> likes;
        private ICollection<Comment> comments;

        public GameProfile()
        {
            this.likes = new HashSet<LikeHate>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(300)]
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CoverId { get; set; }

        public Image Cover { get; set; }

        public ICollection<LikeHate> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
