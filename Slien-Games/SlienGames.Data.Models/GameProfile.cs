using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SlienGames.Data.Models.Contracts;
using SlienGames.Data.Models.Constants;

namespace SlienGames.Data.Models
{
    public class GameProfile : IDbModel
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;
        private ICollection<User> usersVotedThisGame;

        public GameProfile()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
            this.usersVotedThisGame = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.GameProfileNameMinLength)]
        [MaxLength(ValidationConstants.GameProfileNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameProfileDescriptionMinLength)]
        [MaxLength(ValidationConstants.GameProfileDescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public virtual CoverImage CoverImage { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<User> UsersVotedThisGame
        {
            get { return this.usersVotedThisGame; }
            set { this.usersVotedThisGame = value; }
        }
    }
}
